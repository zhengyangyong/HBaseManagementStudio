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
    public partial class ResourceManagementFrame : DockContent
    {
        public MainForm MainForm { get; private set; }

        public ResourceManagementFrame(MainForm main)
        {
            InitializeComponent();
            this.MainForm = main;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
                var tables = client.GetAllTableDefinition();
                this.tvMain.Nodes[0].Nodes[0].Nodes.Clear();
                foreach (var table in tables)
                {
                    var tn = this.tvMain.Nodes[0].Nodes[0].Nodes.Add(table.Key);
                    tn.SetImageIndex(table.Value.Item2 ? 2 : 3);
                    tn.Tag = table.Value.Item1;

                    var schema = TableSchemaManager.GetInstance().Get(table.Key);
                    if(schema != null)
                    {
                        var ktn = tn.Nodes.Add("Row", string.Concat("Row", "(", schema.RowKeyType, ")"));
                        ktn.SetImageIndex(6);
                    }

                    foreach (var column in table.Value.Item1)
                    {
                        var stn = tn.Nodes.Add(column.StringName, string.Concat(column.StringName, "(", column.Compression, ")", "[", column.MaxVersions, "]"));
                        stn.SetImageIndex(4);
                        stn.Tag = column;
                        if(schema != null && schema.ColumnQualifierTypeAndFormats.ContainsKey(column.StringName))
                        {
                            foreach(var qualifier in schema.ColumnQualifierTypeAndFormats[column.StringName])
                            {
                                var qtn = stn.Nodes.Add(qualifier.Key, string.Concat(qualifier.Key, "(", qualifier.Value, ")"));
                                qtn.SetImageIndex(5);
                            }
                        }

                    }
                }
                this.tvMain.ExpandAll();
            }
            catch(Exception ex)
            {
                LogOperator.Get().Error(ex.ToString());
                MessageBoxOperator.ShowError(ex.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            this.tsmiDisableTable.Enabled = this.tvMain.SelectedNode != null && this.tvMain.SelectedNode.ImageIndex == 2;
            this.tsmiDeleteTable.Enabled = this.tvMain.SelectedNode != null && this.tvMain.SelectedNode.ImageIndex == 3;
            this.tsmiEnableTable.Enabled = this.tvMain.SelectedNode != null && this.tvMain.SelectedNode.ImageIndex == 3;
            this.tsmiOperateData.Enabled = this.tvMain.SelectedNode != null && this.tvMain.SelectedNode.ImageIndex == 2;
            this.tsmiSetTableSchema.Enabled = this.tvMain.SelectedNode != null && (this.tvMain.SelectedNode.ImageIndex == 2 || this.tvMain.SelectedNode.ImageIndex == 3);
            this.tsmiQueryRegion.Enabled = this.tvMain.SelectedNode != null && (this.tvMain.SelectedNode.ImageIndex == 2 || this.tvMain.SelectedNode.ImageIndex == 3);
        }

        private void tsmiEnableTable_Click(object sender, EventArgs e)
        {
            try
            {
                HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
                client.EnableTable(this.tvMain.SelectedNode.Text);
                this.btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                LogOperator.Get().Error(ex.ToString());
                MessageBoxOperator.ShowError(ex.Message);
            }
        }

        private void tsmiDisableTable_Click(object sender, EventArgs e)
        {
            try
            {
                HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
                client.DisableTable(this.tvMain.SelectedNode.Text);
                this.btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                LogOperator.Get().Error(ex.ToString());
                MessageBoxOperator.ShowError(ex.Message);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            NewTableForm form = new NewTableForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
                    client.CreateTable(form.TableName, null, form.Columns);
                    this.btnRefresh_Click(null, null);
                }
                catch (Exception ex)
                {
                    LogOperator.Get().Error(ex.ToString());
                    MessageBoxOperator.ShowError(ex.Message);
                }
            }

        }

        private void tsmiDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
                client.DeleteTable(this.tvMain.SelectedNode.Text);
                MainForm.DeleteDataManagementForm(this.tvMain.SelectedNode.Text);
                this.btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                LogOperator.Get().Error(ex.ToString());
                MessageBoxOperator.ShowError(ex.Message);
            }
        }

        private void tsmiOperateData_Click(object sender, EventArgs e)
        {
            if (TableSchemaManager.GetInstance().Schemas.ContainsKey(this.tvMain.SelectedNode.Text))
            {
                MainForm.AddDataManagementForm(this.tvMain.SelectedNode.Text, this.tvMain.SelectedNode.Tag as ColumnDescriptor[]);
            }
            else
            {
                MessageBoxOperator.ShowWarning("Please Set Table Schema First!");
            }
        }

        private void tsbSchemaManagement_Click(object sender, EventArgs e)
        {
            new ManageSchemaForm().ShowDialog();
            TableSchemaManager.GetInstance().Save();
            this.btnRefresh_Click(null,null);
        }

        private void tsmiSetTableSchema_Click(object sender, EventArgs e)
        {
            new SetTableSchemaForm(this.tvMain.SelectedNode.Text).ShowDialog();
            TableSchemaManager.GetInstance().Save();
            this.btnRefresh_Click(null, null);
        }

        private void tsmiQueryRegion_Click(object sender, EventArgs e)
        {
            new ViewTableRegionForm(this.tvMain.SelectedNode.Text).ShowDialog();
        }
    }
}
