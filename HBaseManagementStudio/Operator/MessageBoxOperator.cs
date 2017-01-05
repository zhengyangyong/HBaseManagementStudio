using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace HBaseManagementStudio
{
    public static class MessageBoxOperator
    {
        public static DialogResult ShowQuery(string text)
        {
            return MessageBox.Show(text, "Query", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult ShowInfo(string text)
        {
            return MessageBox.Show(text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowError(string text)
        {
            return MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowWarning(string text)
        {
            return MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
