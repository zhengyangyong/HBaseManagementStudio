namespace HBaseManagementStudio
{
    partial class TableDataManagementFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDataManagementFrame));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Return Column");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Return Column");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSingleQueryResult = new System.Windows.Forms.RichTextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSingleQueryRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSingleQuery = new System.Windows.Forms.ToolStrip();
            this.txtSingleQueryRowKey = new System.Windows.Forms.ToolStripTextBox();
            this.btnSingleQuery = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tsScan = new System.Windows.Forms.ToolStrip();
            this.cboScanMode = new System.Windows.Forms.ToolStripComboBox();
            this.txtScanValue1 = new System.Windows.Forms.ToolStripTextBox();
            this.txtScanRangeMiddle = new System.Windows.Forms.ToolStripLabel();
            this.txtScanValue2 = new System.Windows.Forms.ToolStripTextBox();
            this.btnScanOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnScanNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnScanClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtScanRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvQueryColumn = new HBaseManagementStudio.TreeViewEx();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvScanColumns = new HBaseManagementStudio.TreeViewEx();
            this.txtScanResult = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tsSingleQuery.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tsScan.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 449);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.statusStrip2);
            this.tabPage1.Controls.Add(this.tsSingleQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvQueryColumn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtSingleQueryResult);
            this.splitContainer1.Size = new System.Drawing.Size(598, 370);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 9;
            // 
            // txtSingleQueryResult
            // 
            this.txtSingleQueryResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSingleQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSingleQueryResult.Location = new System.Drawing.Point(0, 0);
            this.txtSingleQueryResult.Name = "txtSingleQueryResult";
            this.txtSingleQueryResult.ReadOnly = true;
            this.txtSingleQueryResult.Size = new System.Drawing.Size(415, 368);
            this.txtSingleQueryResult.TabIndex = 1;
            this.txtSingleQueryResult.Text = "";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.txtSingleQueryRowCount});
            this.statusStrip2.Location = new System.Drawing.Point(3, 398);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(598, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 7;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel2.Text = "Count：";
            // 
            // txtSingleQueryRowCount
            // 
            this.txtSingleQueryRowCount.AutoSize = false;
            this.txtSingleQueryRowCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtSingleQueryRowCount.Name = "txtSingleQueryRowCount";
            this.txtSingleQueryRowCount.Size = new System.Drawing.Size(100, 17);
            this.txtSingleQueryRowCount.Text = "0";
            // 
            // tsSingleQuery
            // 
            this.tsSingleQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSingleQueryRowKey,
            this.btnSingleQuery});
            this.tsSingleQuery.Location = new System.Drawing.Point(3, 3);
            this.tsSingleQuery.Name = "tsSingleQuery";
            this.tsSingleQuery.Padding = new System.Windows.Forms.Padding(0);
            this.tsSingleQuery.Size = new System.Drawing.Size(598, 25);
            this.tsSingleQuery.TabIndex = 0;
            this.tsSingleQuery.Text = "toolStrip2";
            // 
            // txtSingleQueryRowKey
            // 
            this.txtSingleQueryRowKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSingleQueryRowKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtSingleQueryRowKey.Name = "txtSingleQueryRowKey";
            this.txtSingleQueryRowKey.Size = new System.Drawing.Size(200, 25);
            // 
            // btnSingleQuery
            // 
            this.btnSingleQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSingleQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnSingleQuery.Image")));
            this.btnSingleQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSingleQuery.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSingleQuery.Name = "btnSingleQuery";
            this.btnSingleQuery.Size = new System.Drawing.Size(23, 25);
            this.btnSingleQuery.Text = "Query";
            this.btnSingleQuery.Click += new System.EventHandler(this.btnSingleQuery_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Controls.Add(this.tsScan);
            this.tabPage3.Controls.Add(this.statusStrip3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(604, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Scan";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tsScan
            // 
            this.tsScan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboScanMode,
            this.txtScanValue1,
            this.txtScanRangeMiddle,
            this.txtScanValue2,
            this.btnScanOpen,
            this.toolStripLabel1,
            this.btnScanNext,
            this.toolStripSeparator2,
            this.btnScanClose});
            this.tsScan.Location = new System.Drawing.Point(3, 3);
            this.tsScan.Name = "tsScan";
            this.tsScan.Size = new System.Drawing.Size(598, 25);
            this.tsScan.TabIndex = 9;
            this.tsScan.Text = "toolStrip2";
            // 
            // cboScanMode
            // 
            this.cboScanMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScanMode.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboScanMode.Items.AddRange(new object[] {
            "Full",
            "Prefix",
            "Range"});
            this.cboScanMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cboScanMode.Name = "cboScanMode";
            this.cboScanMode.Size = new System.Drawing.Size(75, 25);
            this.cboScanMode.SelectedIndexChanged += new System.EventHandler(this.cboScanMode_SelectedIndexChanged);
            // 
            // txtScanValue1
            // 
            this.txtScanValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanValue1.Name = "txtScanValue1";
            this.txtScanValue1.Size = new System.Drawing.Size(150, 25);
            // 
            // txtScanRangeMiddle
            // 
            this.txtScanRangeMiddle.Name = "txtScanRangeMiddle";
            this.txtScanRangeMiddle.Size = new System.Drawing.Size(17, 22);
            this.txtScanRangeMiddle.Text = "~";
            // 
            // txtScanValue2
            // 
            this.txtScanValue2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanValue2.Name = "txtScanValue2";
            this.txtScanValue2.Size = new System.Drawing.Size(150, 25);
            // 
            // btnScanOpen
            // 
            this.btnScanOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScanOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnScanOpen.Image")));
            this.btnScanOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScanOpen.Name = "btnScanOpen";
            this.btnScanOpen.Size = new System.Drawing.Size(23, 22);
            this.btnScanOpen.Text = "Open Scan";
            this.btnScanOpen.Click += new System.EventHandler(this.btnScanOpen_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 22);
            this.toolStripLabel1.Text = "Fetch Count：";
            // 
            // btnScanNext
            // 
            this.btnScanNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScanNext.Image = ((System.Drawing.Image)(resources.GetObject("btnScanNext.Image")));
            this.btnScanNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScanNext.Name = "btnScanNext";
            this.btnScanNext.Size = new System.Drawing.Size(23, 22);
            this.btnScanNext.Text = "Next";
            this.btnScanNext.Click += new System.EventHandler(this.btnScanNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnScanClose
            // 
            this.btnScanClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScanClose.Image = ((System.Drawing.Image)(resources.GetObject("btnScanClose.Image")));
            this.btnScanClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScanClose.Name = "btnScanClose";
            this.btnScanClose.Size = new System.Drawing.Size(23, 22);
            this.btnScanClose.Text = "Close Scan";
            this.btnScanClose.Click += new System.EventHandler(this.btnScanClose_Click);
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.txtScanRowCount});
            this.statusStrip3.Location = new System.Drawing.Point(3, 398);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(598, 22);
            this.statusStrip3.SizingGrip = false;
            this.statusStrip3.TabIndex = 8;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel3.Text = "Count：";
            // 
            // txtScanRowCount
            // 
            this.txtScanRowCount.AutoSize = false;
            this.txtScanRowCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtScanRowCount.Name = "txtScanRowCount";
            this.txtScanRowCount.Size = new System.Drawing.Size(100, 17);
            this.txtScanRowCount.Text = "0";
            // 
            // tvQueryColumn
            // 
            this.tvQueryColumn.CheckBoxes = true;
            this.tvQueryColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvQueryColumn.Location = new System.Drawing.Point(0, 0);
            this.tvQueryColumn.Name = "tvQueryColumn";
            treeNode1.Name = "QueryRootNode";
            treeNode1.Text = "Return Column";
            this.tvQueryColumn.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvQueryColumn.Size = new System.Drawing.Size(175, 368);
            this.tvQueryColumn.TabIndex = 0;
            this.tvQueryColumn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvColumn_AfterCheck);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 28);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvScanColumns);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtScanResult);
            this.splitContainer2.Size = new System.Drawing.Size(598, 370);
            this.splitContainer2.SplitterDistance = 177;
            this.splitContainer2.TabIndex = 10;
            // 
            // tvScanColumns
            // 
            this.tvScanColumns.CheckBoxes = true;
            this.tvScanColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScanColumns.Location = new System.Drawing.Point(0, 0);
            this.tvScanColumns.Name = "tvScanColumns";
            treeNode2.Name = "ScanRootNode";
            treeNode2.Text = "Return Column";
            this.tvScanColumns.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvScanColumns.Size = new System.Drawing.Size(175, 368);
            this.tvScanColumns.TabIndex = 0;
            this.tvScanColumns.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvColumn_AfterCheck);
            // 
            // txtScanResult
            // 
            this.txtScanResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScanResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScanResult.Location = new System.Drawing.Point(0, 0);
            this.txtScanResult.Name = "txtScanResult";
            this.txtScanResult.ReadOnly = true;
            this.txtScanResult.Size = new System.Drawing.Size(415, 368);
            this.txtScanResult.TabIndex = 0;
            this.txtScanResult.Text = "";
            // 
            // Main_TableDataManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 449);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_TableDataManagementForm";
            this.Text = "AddDataForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tsSingleQuery.ResumeLayout(false);
            this.tsSingleQuery.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tsScan.ResumeLayout(false);
            this.tsScan.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip tsSingleQuery;
        private System.Windows.Forms.ToolStripTextBox txtSingleQueryRowKey;
        private System.Windows.Forms.ToolStripButton btnSingleQuery;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel txtSingleQueryRowCount;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel txtScanRowCount;
        private System.Windows.Forms.ToolStrip tsScan;
        private System.Windows.Forms.ToolStripButton btnScanOpen;
        private System.Windows.Forms.ToolStripButton btnScanNext;
        private System.Windows.Forms.ToolStripButton btnScanClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtScanResult;
        private System.Windows.Forms.RichTextBox txtSingleQueryResult;
        private System.Windows.Forms.ToolStripComboBox cboScanMode;
        private System.Windows.Forms.ToolStripTextBox txtScanValue2;
        private System.Windows.Forms.ToolStripLabel txtScanRangeMiddle;
        private System.Windows.Forms.ToolStripTextBox txtScanValue1;
        private TreeViewEx tvQueryColumn;
        private TreeViewEx tvScanColumns;
    }
}