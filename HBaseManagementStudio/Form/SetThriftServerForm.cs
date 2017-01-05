using HBaseThrift;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace HBaseManagementStudio
{
    public partial class SetThriftServerForm : Form
    {
        public SetThriftServerForm()
        {
            InitializeComponent();

            string ts = ConfigOperator.GetAppConfigValue<string>("ThriftServer");
            if(!string.IsNullOrWhiteSpace(ts))
            {
                string[] tss = ts.Split(':');
                if(tss.Length == 2)
                {
                    this.txtServerIP.Text = tss[0];
                    this.nudServerPort.Value = int.Parse(tss[1]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IPAddress address = null;
            if (IPAddress.TryParse(this.txtServerIP.Text, out address))
            {
                ConfigOperator.SaveAppConfig(new Dictionary<string, object>()
                {
                    {"ThriftServer",this.txtServerIP.Text.Trim()+":"+((int)this.nudServerPort.Value).ToString()},
                });
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBoxOperator.ShowError("Illegal IP Address!");
            }
        }

        public static string GetHBaseMasterServerIP()
        {
            string ip1 = "localhost";
            string ts = ConfigOperator.GetAppConfigValue<string>("ThriftServer");
            if (!string.IsNullOrWhiteSpace(ts))
            {
                string[] tss = ts.Split(':');
                if (tss.Length == 2)
                {
                    ip1 = tss[0];
                }
            }
            return ip1;
        }

        public static HBaseThriftClient GetHBaseThriftClient()
        {
            string ip = "localhost";
            int port = 9090;

            string ts = ConfigOperator.GetAppConfigValue<string>("ThriftServer");
            int timeout = int.Parse(ConfigurationManager.AppSettings["ThriftTimeoutMilliseconds"]);
            if (!string.IsNullOrWhiteSpace(ts))
            {
                string[] tss = ts.Split(':');
                if (tss.Length == 2)
                {
                    ip = tss[0];
                    port = int.Parse(tss[1]);
                }
            }

            return new HBaseThriftClient(ip, port, timeout);
        }
    }
}
