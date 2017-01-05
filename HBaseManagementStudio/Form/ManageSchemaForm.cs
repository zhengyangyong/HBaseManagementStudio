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
    public partial class ManageSchemaForm : Form
    {
        public ManageSchemaForm()
        {
            InitializeComponent();
            this.ColDataType.Items.AddRange(TableSchemaManager.ColumnDataTypes.Keys.ToArray());
            this.cboRowKeyType.Items.AddRange(TableSchemaManager.ColumnDataTypes.Keys.Where(k => !k.StartsWith("OPC")).ToArray());
        }

        private void LoadSchema()
        {
            this.lbSchema.Items.Clear();
            this.dgvColumn.Rows.Clear();
            foreach (var schema in TableSchemaManager.GetInstance().Schemas)
            {
                this.lbSchema.Items.Add(schema.Key);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.txtSchemaName.Text))
            {
                string tablename = this.txtSchemaName.Text.Trim();
                if (!TableSchemaManager.GetInstance().Schemas.ContainsKey(tablename))
                {
                    TableSchemaManager.GetInstance().Schemas.Add(tablename, new TableSchema() { RowKeyType = "string",RowKeyFormat = "UTF-8" });
                    this.LoadSchema();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(this.lbSchema.SelectedItem != null)
            {
                TableSchemaManager.GetInstance().Schemas.Remove(this.lbSchema.SelectedItem.ToString());
                this.LoadSchema();
            }
        }

        private void lbSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            var schema = TableSchemaManager.GetInstance().Schemas[this.lbSchema.SelectedItem.ToString()];
            this.dgvColumn.Rows.Clear();
            this.cboRowKeyType.SelectedItem = schema.RowKeyType;
            this.cboRowKeyFormat.SelectedItem = schema.RowKeyFormat;
            foreach (var column in schema.ColumnTypeAndFormats)
            {
                int index = this.dgvColumn.Rows.Add(column.Key, column.Value.Item1, null);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dgvColumn.EndEdit();
            Dictionary<string, Tuple<string, string>> newcolumns = new Dictionary<string, Tuple<string, string>>();
            foreach(DataGridViewRow row in this.dgvColumn.Rows)
            {
                if(row.Cells[0].Value != null && !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) 
                    && row.Cells[1].Value != null && !string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString())
                    && row.Cells[2].Value != null && !string.IsNullOrWhiteSpace(row.Cells[2].Value.ToString()))
                {
                    if (row.Cells[0].Value.ToString().Trim().Contains(":"))
                    {
                        if (row.Cells[0].Value.ToString().Trim().IndexOf(':') != row.Cells[0].Value.ToString().Trim().Length - 1)
                        {
                            newcolumns.Add(row.Cells[0].Value.ToString().Trim(),new Tuple<string, string>(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()));
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
            if (this.cboRowKeyType.SelectedItem != null)
            {
                TableSchemaManager.GetInstance().Schemas[this.lbSchema.SelectedItem.ToString()] = new TableSchema()
                {
                    RowKeyType = this.cboRowKeyType.SelectedItem.ToString(),
                    RowKeyFormat = this.cboRowKeyFormat.SelectedItem.ToString(),
                    ColumnTypeAndFormats = newcolumns
                };
            }
            else
            {
                MessageBoxOperator.ShowError("Must select row key type!");
                return;
            }
        }
    }
}
