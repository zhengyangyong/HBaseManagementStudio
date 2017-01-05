using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HBaseManagementStudio
{
    public partial class TreeViewEx : TreeView
    {
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_RBUTTONDOWN = 0x0204;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                TreeViewHitTestInfo tvhti = HitTest(new Point((int)m.LParam));
                if (tvhti != null && tvhti.Location == TreeViewHitTestLocations.StateImage)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
            else if (m.Msg == WM_RBUTTONDOWN)
            {
                TreeViewHitTestInfo tvhti = HitTest(new Point((int)m.LParam));
                if (tvhti != null)
                    this.SelectedNode = tvhti.Node;
            }
            base.WndProc(ref m);
        }
    }
}
