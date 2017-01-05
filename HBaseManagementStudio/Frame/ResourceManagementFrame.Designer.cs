namespace HBaseManagementStudio
{
    partial class ResourceManagementFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceManagementFrame));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tables", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("HBase Root", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCreateTable = new System.Windows.Forms.ToolStripButton();
            this.tsbSchemaManagement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEnableTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisableTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSetTableSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOperateData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQueryRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCreateTable,
            this.tsbSchemaManagement,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(410, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateTable.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateTable.Image")));
            this.btnCreateTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(23, 22);
            this.btnCreateTable.Text = "New Table";
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // tsbSchemaManagement
            // 
            this.tsbSchemaManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSchemaManagement.Image = ((System.Drawing.Image)(resources.GetObject("tsbSchemaManagement.Image")));
            this.tsbSchemaManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSchemaManagement.Name = "tsbSchemaManagement";
            this.tsbSchemaManagement.Size = new System.Drawing.Size(23, 22);
            this.tsbSchemaManagement.Text = "Manage Schema";
            this.tsbSchemaManagement.ToolTipText = "Manage Schema";
            this.tsbSchemaManagement.Click += new System.EventHandler(this.tsbSchemaManagement_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tvMain
            // 
            this.tvMain.ContextMenuStrip = this.cmsMain;
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.ImageIndex = 0;
            this.tvMain.ImageList = this.ilMain;
            this.tvMain.Location = new System.Drawing.Point(0, 25);
            this.tvMain.Name = "tvMain";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Tables";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "Tables";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "HBase";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "HBase Root";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvMain.SelectedImageIndex = 0;
            this.tvMain.Size = new System.Drawing.Size(410, 500);
            this.tvMain.StateImageList = this.ilMain;
            this.tvMain.TabIndex = 1;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnableTable,
            this.tsmiDisableTable,
            this.tsmiDeleteTable,
            this.toolStripSeparator3,
            this.tsmiSetTableSchema,
            this.tsmiOperateData,
            this.toolStripSeparator1,
            this.tsmiQueryRegion});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(185, 170);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMain_Opening);
            // 
            // tsmiEnableTable
            // 
            this.tsmiEnableTable.Name = "tsmiEnableTable";
            this.tsmiEnableTable.Size = new System.Drawing.Size(184, 22);
            this.tsmiEnableTable.Text = "Enable Table";
            this.tsmiEnableTable.Click += new System.EventHandler(this.tsmiEnableTable_Click);
            // 
            // tsmiDisableTable
            // 
            this.tsmiDisableTable.Name = "tsmiDisableTable";
            this.tsmiDisableTable.Size = new System.Drawing.Size(184, 22);
            this.tsmiDisableTable.Text = "Disable Table";
            this.tsmiDisableTable.Click += new System.EventHandler(this.tsmiDisableTable_Click);
            // 
            // tsmiDeleteTable
            // 
            this.tsmiDeleteTable.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDeleteTable.Image")));
            this.tsmiDeleteTable.Name = "tsmiDeleteTable";
            this.tsmiDeleteTable.Size = new System.Drawing.Size(184, 22);
            this.tsmiDeleteTable.Text = "Drop Table";
            this.tsmiDeleteTable.Click += new System.EventHandler(this.tsmiDeleteTable_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmiSetTableSchema
            // 
            this.tsmiSetTableSchema.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSetTableSchema.Image")));
            this.tsmiSetTableSchema.Name = "tsmiSetTableSchema";
            this.tsmiSetTableSchema.Size = new System.Drawing.Size(184, 22);
            this.tsmiSetTableSchema.Text = "Set Table Schema";
            this.tsmiSetTableSchema.Click += new System.EventHandler(this.tsmiSetTableSchema_Click);
            // 
            // tsmiOperateData
            // 
            this.tsmiOperateData.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOperateData.Image")));
            this.tsmiOperateData.Name = "tsmiOperateData";
            this.tsmiOperateData.Size = new System.Drawing.Size(184, 22);
            this.tsmiOperateData.Text = "Operate Data";
            this.tsmiOperateData.Click += new System.EventHandler(this.tsmiOperateData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmiQueryRegion
            // 
            this.tsmiQueryRegion.Image = ((System.Drawing.Image)(resources.GetObject("tsmiQueryRegion.Image")));
            this.tsmiQueryRegion.Name = "tsmiQueryRegion";
            this.tsmiQueryRegion.Size = new System.Drawing.Size(184, 22);
            this.tsmiQueryRegion.Text = "View Table Region";
            this.tsmiQueryRegion.Click += new System.EventHandler(this.tsmiQueryRegion_Click);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "Database.ico");
            this.ilMain.Images.SetKeyName(1, "Grid.ico");
            this.ilMain.Images.SetKeyName(2, "Grid-2.ico");
            this.ilMain.Images.SetKeyName(3, "Grid-3.ico");
            this.ilMain.Images.SetKeyName(4, "Grid-Select Column-2.ico");
            this.ilMain.Images.SetKeyName(5, "Columns-2.ico");
            this.ilMain.Images.SetKeyName(6, "Key.ico");
            // 
            // Main_TesourceManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 525);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Main_TesourceManagementForm";
            this.Text = "Resource Management";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ToolStripButton btnCreateTable;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnableTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisableTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiOperateData;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetTableSchema;
        private System.Windows.Forms.ToolStripButton tsbSchemaManagement;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiQueryRegion;
    }
}