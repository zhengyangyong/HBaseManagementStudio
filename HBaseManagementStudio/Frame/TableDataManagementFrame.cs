using HBaseThrift;
using HBaseThrift.Thrift;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HBaseManagementStudio
{
    public partial class TableDataManagementFrame : DockContent
    {
        public string TableName { get; private set; }
        public ColumnDescriptor[] Columns { get; private set; }

        private NumericUpDown _maxPrefixQueryCount = null;
        private NumericUpDown _maxScanCount = null;
        private CheckBox _enableSingleQueryTS = null;
        private DateTimePicker _singleQueryTS = null;

        private Guid _scanID;

        public TableDataManagementFrame(string tableName, ColumnDescriptor[] columns)
        {
            InitializeComponent();
            this.Text = tableName;
            this.TableName = tableName;
            this.Columns = columns;

            var schema = TableSchemaManager.GetInstance().Get(this.TableName);
            foreach (var column in columns)
            {
                TreeNode node = this.tvQueryColumn.Nodes[0].Nodes.Add(column.StringName);
                TreeNode node2 = this.tvScanColumns.Nodes[0].Nodes.Add(column.StringName);
                if (schema != null)
                {
                    if (schema.ColumnQualifierTypeAndFormats.ContainsKey(column.StringName))
                    {
                        foreach (var qualifier in schema.ColumnQualifierTypeAndFormats[column.StringName])
                        {
                            node.Nodes.Add(qualifier.Key);
                            node2.Nodes.Add(qualifier.Key);
                        }
                    }
                }
            }

            this.tvQueryColumn.ExpandAll();
            this.tvScanColumns.ExpandAll();

            _maxPrefixQueryCount = new NumericUpDown();
            _maxPrefixQueryCount.Maximum = 1000;
            _maxPrefixQueryCount.Minimum = 1;
            _maxPrefixQueryCount.Value = 100;
            var host = new ToolStripControlHost(_maxPrefixQueryCount);
            host.Visible = false;
            this.tsSingleQuery.Items.Insert(2, host);
            host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            _maxPrefixQueryCount.Width = 80;

            _enableSingleQueryTS = new CheckBox();
            _enableSingleQueryTS.Text = "TS：";
            _enableSingleQueryTS.Checked = false;
            _enableSingleQueryTS.CheckedChanged += EnableSingleQueryTS_CheckedChanged;
            host = new ToolStripControlHost(_enableSingleQueryTS);
            this.tsSingleQuery.Items.Insert(3, host);
            host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            _singleQueryTS = new DateTimePicker();
            _singleQueryTS.Enabled = false;
            host = new ToolStripControlHost(_singleQueryTS);
            this.tsSingleQuery.Items.Insert(4, host);
            host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            _singleQueryTS.Width = 130;

            _maxScanCount = new NumericUpDown();
            _maxScanCount.Maximum = 1000;
            _maxScanCount.Minimum = 1;
            _maxScanCount.Value = 100;
            host = new ToolStripControlHost(_maxScanCount);
            this.tsScan.Items.Insert(6, host);
            host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            _maxPrefixQueryCount.Width = 80;

            this.cboScanMode.SelectedIndex = 0;

            ChangeScanStatus(false);
        }

        #region Single Query
        private void btnSingleQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtSingleQueryRowKey.Text))
            {
                this.Enabled = false;
                try
                {
                    this.ClearSingleQuery();
                    var schema = TableSchemaManager.GetInstance().Get(this.TableName);
                    Type t = TableSchemaManager.ColumnDataTypes[schema.RowKeyType];
                    object v = Convert.ChangeType(this.txtSingleQueryRowKey.Text,t);

                    byte[] rowkey = Extension.GetBytes(v, schema.RowKeyType, schema.RowKeyFormat);

                    List<string> checkedcolumns = new List<string>();
                    foreach (TreeNode cnode in this.tvQueryColumn.Nodes[0].Nodes)
                    {
                        if (cnode.Checked)
                        {
                            checkedcolumns.Add(cnode.Text.Substring(0, cnode.Text.Length - 1));
                        }
                        else
                        {
                            foreach (TreeNode qnode in cnode.Nodes)
                            {
                                if (qnode.Checked)
                                {
                                    checkedcolumns.Add(string.Concat(cnode.Text, qnode.Text));
                                }
                            }
                        }
                    }

                    if (checkedcolumns.Count != 0)
                    {
                        List<TRowResult> result = null;
                        long timestamp = 0;
                        if (_enableSingleQueryTS.Checked)
                        {
                            timestamp = _singleQueryTS.Value.GetHBaseTimestamp();
                        }
                        result = SetThriftServerForm.GetHBaseThriftClient().SingleQuery(this.TableName, rowkey, checkedcolumns, timestamp);
                        if (result != null)
                        {
                            this.txtSingleQueryResult.Text = TableSchemaManager.GetInstance().ProcessTRowResultToString(this.TableName, result);
                            this.txtSingleQueryRowCount.Text = result.Count.ToString();
                        }
                    }
                    else
                    {
                        MessageBoxOperator.ShowInfo("Please Check one Column at least");
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxOperator.ShowError(ex.Message);
                    LogOperator.Get().Error(ex.ToString());
                }
                finally
                {
                    this.Enabled = true;
                }
            }
        }

        private void ClearSingleQuery()
        {
            this.txtSingleQueryRowCount.Text = "0";
            this.txtSingleQueryResult.Text = null;
        }

        private void tsmiSingleQuerySelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in this.tvQueryColumn.Nodes)
            {
                item.Checked = true;
            }
        }

        private void tsmiSingleQueryUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in this.tvQueryColumn.Nodes)
            {
                item.Checked = false;
            }
        }

        private void cboSingleQueryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._maxPrefixQueryCount.Visible = this.cboScanMode.SelectedIndex == 1;
            this._enableSingleQueryTS.Visible = this.cboScanMode.SelectedIndex == 0;
            this._singleQueryTS.Visible = this.cboScanMode.SelectedIndex == 0;
        }

        private void EnableSingleQueryTS_CheckedChanged(object sender, EventArgs e)
        {
            this._singleQueryTS.Enabled = this._enableSingleQueryTS.Checked;
        }

        private void tvColumn_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                bool status = e.Node.Checked;
                if (e.Node.Nodes.Count > 0)
                {
                    LoopChangeChildNodes(e.Node, status);
                }

                if (!status)
                {
                    LoopChangeFatherNodes(e.Node, status);
                }
            }
        }

        private void LoopChangeChildNodes(TreeNode node, bool status)
        {
            if (node.Nodes.Count != 0)
            {
                foreach (TreeNode snode in node.Nodes)
                {
                    snode.Checked = status;
                    LoopChangeChildNodes(snode, status);
                }
            }
        }

        private void LoopChangeFatherNodes(TreeNode node, bool status)
        {
            if (!status)
            {
                if (node.Parent != null)
                {
                    node.Parent.Checked = false;
                    LoopChangeFatherNodes(node.Parent, status);
                }
            }
        }

        #endregion

        private void btnScanOpen_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> checkedcolumns = new List<string>();
                foreach (TreeNode cnode in this.tvScanColumns.Nodes[0].Nodes)
                {
                    if (cnode.Checked)
                    {
                        checkedcolumns.Add(cnode.Text.Substring(0, cnode.Text.Length - 1));
                    }
                    else
                    {
                        foreach (TreeNode qnode in cnode.Nodes)
                        {
                            if (qnode.Checked)
                            {
                                checkedcolumns.Add(string.Concat(cnode.Text, qnode.Text));
                            }
                        }
                    }
                }

                if (checkedcolumns.Count != 0)
                {
                    if (this.cboScanMode.SelectedIndex == 0)
                    {
                        _scanID = SetThriftServerForm.GetHBaseThriftClient().GetScan(this.TableName, new byte[0], checkedcolumns);
                    }
                    else if(this.cboScanMode.SelectedIndex == 1)
                    {
                        _scanID = SetThriftServerForm.GetHBaseThriftClient().GetScanWithPrefix(this.TableName, this.txtScanValue1.Text.Trim().GetUTF8Bytes(), checkedcolumns);
                    }
                    else if (this.cboScanMode.SelectedIndex == 2)
                    {
                        _scanID = SetThriftServerForm.GetHBaseThriftClient().GetScanWithStop(this.TableName, this.txtScanValue1.Text.Trim().GetUTF8Bytes(), this.txtScanValue2.Text.Trim().GetUTF8Bytes(), checkedcolumns);
                    }
                    ChangeScanStatus(true);
                }
                else
                {
                    MessageBoxOperator.ShowInfo("Please Check one Column at least");
                }
            }
            catch (Exception ex)
            {
                MessageBoxOperator.ShowError(ex.Message);
                LogOperator.Get().Error(ex.ToString());
            }
        }

        private void btnScanNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearScanQuery();
                var result = HBaseThriftClient.DoScan(_scanID, (int)_maxScanCount.Value);
                if (result != null)
                {
                    this.txtScanResult.Text = TableSchemaManager.GetInstance().ProcessTRowResultToString(this.TableName, result);
                    this.txtScanRowCount.Text = result.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBoxOperator.ShowError(ex.Message);
                LogOperator.Get().Error(ex.ToString());
            }
        }

        private void ClearScanQuery()
        {
            this.txtScanRowCount.Text = "0";
            this.txtScanResult.Text = null;
        }

        private void btnScanClose_Click(object sender, EventArgs e)
        {
            try
            {
                HBaseThriftClient.CloseScan(_scanID);
            }
            catch (Exception ex)
            {
                MessageBoxOperator.ShowError(ex.Message);
                LogOperator.Get().Error(ex.ToString());
            }
            finally
            {
                ChangeScanStatus(false);
            }
        }

        private void ChangeScanStatus(bool opened)
        {
            this.btnScanOpen.Enabled = !opened;
            this.tvScanColumns.Enabled = !opened;
            this.btnScanNext.Enabled = opened;
            this.btnScanClose.Enabled = opened;
            this._maxScanCount.Enabled = opened;
        }

        private void cboScanMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cboScanMode.SelectedIndex == 0)
            {
                this.txtScanValue1.Visible = false;
                this.txtScanRangeMiddle.Visible = false;
                this.txtScanValue2.Visible = false;
            }
            else if (this.cboScanMode.SelectedIndex == 1)
            {
                this.txtScanValue1.Visible = true;
                this.txtScanRangeMiddle.Visible = false;
                this.txtScanValue2.Visible = false;
            }
            else if (this.cboScanMode.SelectedIndex == 2)
            {
                this.txtScanValue1.Visible = true;
                this.txtScanRangeMiddle.Visible = true;
                this.txtScanValue2.Visible = true;
            }
        }
    }
}