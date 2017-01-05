namespace HBaseManagementStudio
{
    partial class SetTableSchemaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetTableSchemaForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvColumn = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRowKeyType = new System.Windows.Forms.ComboBox();
            this.cboRowKeyFormat = new System.Windows.Forms.ComboBox();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColFormat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(464, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvColumn
            // 
            this.dgvColumn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColDataType,
            this.ColFormat});
            this.dgvColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumn.Location = new System.Drawing.Point(0, 51);
            this.dgvColumn.Name = "dgvColumn";
            this.dgvColumn.RowTemplate.Height = 23;
            this.dgvColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvColumn.Size = new System.Drawing.Size(464, 208);
            this.dgvColumn.TabIndex = 4;
            this.dgvColumn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumn_CellValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboRowKeyType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboRowKeyFormat, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 26);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Row Key Type：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRowKeyType
            // 
            this.cboRowKeyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRowKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRowKeyType.FormattingEnabled = true;
            this.cboRowKeyType.Location = new System.Drawing.Point(123, 3);
            this.cboRowKeyType.Name = "cboRowKeyType";
            this.cboRowKeyType.Size = new System.Drawing.Size(166, 20);
            this.cboRowKeyType.TabIndex = 1;
            this.cboRowKeyType.SelectedIndexChanged += new System.EventHandler(this.cboRowKeyType_SelectedIndexChanged);
            // 
            // cboRowKeyFormat
            // 
            this.cboRowKeyFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRowKeyFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRowKeyFormat.FormattingEnabled = true;
            this.cboRowKeyFormat.Location = new System.Drawing.Point(295, 3);
            this.cboRowKeyFormat.Name = "cboRowKeyFormat";
            this.cboRowKeyFormat.Size = new System.Drawing.Size(166, 20);
            this.cboRowKeyFormat.TabIndex = 2;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "ColumnName";
            this.ColName.Name = "ColName";
            this.ColName.Width = 150;
            // 
            // ColDataType
            // 
            this.ColDataType.HeaderText = "DataType";
            this.ColDataType.Name = "ColDataType";
            this.ColDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDataType.Width = 120;
            // 
            // ColFormat
            // 
            this.ColFormat.HeaderText = "Format";
            this.ColFormat.Name = "ColFormat";
            this.ColFormat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColFormat.Width = 120;
            // 
            // Sub_SetTableSchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.dgvColumn);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sub_SetTableSchemaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Table Schema";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgvColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRowKeyType;
        private System.Windows.Forms.ComboBox cboRowKeyFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDataType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColFormat;
    }
}