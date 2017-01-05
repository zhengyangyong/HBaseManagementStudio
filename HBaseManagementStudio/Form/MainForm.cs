using HBaseThrift.Thrift;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HBaseManagementStudio
{
    public partial class MainForm : Form
    {
        private ResourceManagementFrame _schemaForm = null;

        public MainForm()
        {
            InitializeComponent();

            _schemaForm = new ResourceManagementFrame(this);
            _schemaForm.Show(this.dpMain, DockState.DockLeft);

            this.dpMain.AllowEndUserDocking = false;
            this.dpMain.AllowEndUserNestedDocking = false;

            this.txtVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void AddDataManagementForm(string tableName, ColumnDescriptor[] columns)
        {
            var target = this.dpMain.Documents.SingleOrDefault(d => d.DockHandler.TabText == tableName);
            if (target == null)
            {
                TableDataManagementFrame form = new TableDataManagementFrame(tableName, columns);
                form.Show(this.dpMain, DockState.Document);
            }
            else
            {
                target.DockHandler.Form.Select();
            }
        }

        public void DeleteDataManagementForm(string tableName)
        {
            var target = this.dpMain.Documents.SingleOrDefault(d => d.DockHandler.TabText == tableName);
            if (target != null)
            {
                (target as TableDataManagementFrame).Close();
            }
        }

        private void tsmiSetThriftServer_Click(object sender, EventArgs e)
        {
            new SetThriftServerForm().ShowDialog();
        }

        private void tsmiHbaseMaster_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("http://" + SetThriftServerForm.GetHBaseMasterServerIP() + ":60010/master-status"));
        }
    }
}
