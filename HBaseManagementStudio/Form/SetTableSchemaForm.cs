using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HBaseManagementStudio
{
    public partial class SetTableSchemaForm : Form
    {
        public string TableName { get; private set; }

        public SetTableSchemaForm(string tableName)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.ColDataType.Items.AddRange(TableSchemaManager.ColumnDataTypes.Keys.ToArray());

            this.cboRowKeyType.Items.AddRange(TableSchemaManager.ColumnDataTypes.Keys.Where(k => !k.StartsWith("OPC")).ToArray());
            var schema = TableSchemaManager.GetInstance().Get(tableName);
            if(schema != null)
            {
                this.cboRowKeyType.SelectedItem = schema.RowKeyType;
                this.cboRowKeyFormat.SelectedItem = schema.RowKeyFormat;
                foreach (var column in schema.ColumnTypeAndFormats)
                {
                    int index = this.dgvColumn.Rows.Add(column.Key, column.Value.Item1,null);
                    if (column.Value.Item1 == "string")
                    {
                        (this.dgvColumn.Rows[index].Cells[2] as DataGridViewComboBoxCell).Items.AddRange(new string[] { "ASCII", "UTF-8", "Unicode", "GBK", "GB2312" });
                    }
                    else if (column.Value.Item1 == "int"
                        || column.Value.Item1 == "long"
                        || column.Value.Item1 == "float"
                        || column.Value.Item1 == "double")
                    {
                        (this.dgvColumn.Rows[index].Cells[2] as DataGridViewComboBoxCell).Items.AddRange(new string[] { "Big-Endian", "Little-Endian" });
                    }
                    else
                    {
                        (this.dgvColumn.Rows[index].Cells[2] as DataGridViewComboBoxCell).Items.AddRange(new string[] { "None" });
                    }
                    this.dgvColumn.Rows[index].Cells[2].Value = column.Value.Item2;
                }
            }
            else
            {
                this.cboRowKeyType.SelectedItem = "string";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dgvColumn.EndEdit();
            Dictionary<string, Tuple<string, string>> newcolumns = new Dictionary<string, Tuple<string, string>>();
            foreach (DataGridViewRow row in this.dgvColumn.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString())
                    && row.Cells[1].Value != null && !string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()) 
                    && row.Cells[2].Value != null && !string.IsNullOrWhiteSpace(row.Cells[2].Value.ToString()))
                {
                    if (row.Cells[0].Value.ToString().Trim().Contains(":"))
                    {
                        if (row.Cells[0].Value.ToString().Trim().IndexOf(':') != row.Cells[0].Value.ToString().Trim().Length - 1)
                        {
                            newcolumns.Add(row.Cells[0].Value.ToString().Trim(), new Tuple<string, string>(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()));
                        }
                        else
                        {
                            MessageBoxOperator.ShowError("Empty Qualifier,like Family:Qualifier!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxOperator.ShowError("ColumnName Must Contain ':',like Family:Qualifier!");
                        return;
                    }
                }
            }
            TableSchemaManager.GetInstance().Schemas[TableName] = new TableSchema()
            {
                RowKeyType = this.cboRowKeyType.SelectedItem.ToString(),
                RowKeyFormat = this.cboRowKeyFormat.SelectedItem.ToString(),
                ColumnTypeAndFormats = newcolumns
            };
            this.DialogResult = DialogResult.OK;
        }

        private void cboRowKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboRowKeyFormat.Items.Clear();
            if(this.cboRowKeyType.SelectedItem.ToString() == "string")
            {
                this.cboRowKeyFormat.Items.AddRange(new string[] { "ASCII", "UTF-8", "Unicode", "GBK","GB2312" });
                this.cboRowKeyFormat.SelectedItem = "UTF-8";
            }
            else if(this.cboRowKeyType.SelectedItem.ToString() == "int"
                || this.cboRowKeyType.SelectedItem.ToString() == "long"
                || this.cboRowKeyType.SelectedItem.ToString() == "float"
                || this.cboRowKeyType.SelectedItem.ToString() == "double")
            {
                this.cboRowKeyFormat.Items.AddRange(new string[] { "Big-Endian", "Little-Endian" });
                this.cboRowKeyFormat.SelectedItem = "Big-Endian";
            }
            else
            {
                this.cboRowKeyFormat.Items.AddRange(new string[] { "None" });
                this.cboRowKeyFormat.SelectedItem = "None";
            }
        }

        private void dgvColumn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                string value = this.dgvColumn[e.ColumnIndex, e.RowIndex].Value as string;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var cell = this.dgvColumn.Rows[e.RowIndex].Cells[2] as DataGridViewComboBoxCell;
                    cell.Items.Clear();
                    if (value == "string")
                    {
                        cell.Items.AddRange(new string[] { "ASCII", "UTF-8", "Unicode", "GBK", "GB2312" });
                        cell.Value = "UTF-8";
                    }
                    else if (value == "int"
                        || value == "long"
                        || value == "float"
                        || value == "double")
                    {
                        cell.Items.AddRange(new string[] { "Big-Endian", "Little-Endian" });
                        cell.Value = "Big-Endian";
                    }
                    else
                    {
                        cell.Items.AddRange(new string[] { "None" });
                        cell.Value = "None";
                    }
                }
            }
        }
    }
}
