using HBaseThrift.Thrift;
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
    public partial class NewTableForm : Form
    {
        public NewTableForm()
        {
            InitializeComponent();
            Columns = new List<ColumnDescriptor>();
        }

        public List<ColumnDescriptor> Columns { get; private set; }
        public string TableName { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dgvColumn.EndEdit();
            if(!string.IsNullOrWhiteSpace(this.txtTableName.Text))
            {
                this.TableName = this.txtTableName.Text.Trim();
                this.Columns.Clear();
                List<string> names = new List<string>();
                foreach(DataGridViewRow row in this.dgvColumn.Rows)
                {
                    string name = row.GetCellStringValue(0);
                    if(name != null)
                    {
                        if (!names.Contains(name))
                        {
                            names.Add(name);
                            if (!name.Contains(":"))
                            {
                                var cd = new ColumnDescriptor();
                                cd.StringName = name + ":";
                                cd.InMemory = row.Cells[1].Value == null ? false : (bool)row.Cells[1].Value;
                                cd.Compression = row.Cells[2].Value == null ? null : row.Cells[2].Value.ToString();
                                int? timetolive = row.GetCellIntValue(3);
                                if (timetolive.HasValue) cd.TimeToLive = timetolive.Value;
                                int? maxversions = row.GetCellIntValue(4);
                                cd.MaxVersions = maxversions.HasValue ? maxversions.Value : 1;
                                this.Columns.Add(cd);
                            }
                            else
                            {
                                MessageBoxOperator.ShowError("Family Name Can't Contain ':'");
                                return;
                            }
                        }
                        else
                        {
                            MessageBoxOperator.ShowError("Duplicate Family Name!");
                            return;
                        }
                    }
                }

                if (Columns.Count != 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBoxOperator.ShowError("Empty Family List!");
                }
            }
            else
            {
                MessageBoxOperator.ShowError("Table Name is Empty!");
                this.txtTableName.Focus();
            }
        }
    }
}
