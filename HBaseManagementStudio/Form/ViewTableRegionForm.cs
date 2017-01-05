using HBaseThrift;
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
    public partial class ViewTableRegionForm : Form
    {
        public ViewTableRegionForm(string tableName)
        {
            InitializeComponent();

            HBaseThriftClient client = SetThriftServerForm.GetHBaseThriftClient();
            var regions = client.TableRegionQuery(tableName);
            foreach (var regiongroup in regions.GroupBy(r => r.ServerName.GetUTF8String()))
            {
                TreeNode servernode = this.tvMain.Nodes.Add(regiongroup.Key);
                servernode.SetImageIndex(0);
                foreach (var region in regiongroup)
                {
                    TreeNode regionnode = servernode.Nodes.Add(region.Name.GetUTF8String());
                    regionnode.SetImageIndex(1);

                    TreeNode infonode = regionnode.Nodes.Add(string.Concat("StartKey:" + region.StartKey.GetUTF8String()));
                    infonode.SetImageIndex(2);
                    infonode = regionnode.Nodes.Add(string.Concat("EndKey:" + region.EndKey.GetUTF8String()));
                    infonode.SetImageIndex(2);
                }
            }

            this.tvMain.ExpandAll();
        }
    }
}