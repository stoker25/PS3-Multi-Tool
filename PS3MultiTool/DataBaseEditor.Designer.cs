namespace PS3MultiTool
{
    partial class DataBaseEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvEntries = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtSize2 = new System.Windows.Forms.TextBox();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvEntries);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbInfo);
            this.splitContainer1.Size = new System.Drawing.Size(796, 311);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvEntries
            // 
            this.lvEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chSize,
            this.chSize2,
            this.chValue});
            this.lvEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntries.FullRowSelect = true;
            this.lvEntries.Location = new System.Drawing.Point(0, 0);
            this.lvEntries.Name = "lvEntries";
            this.lvEntries.Size = new System.Drawing.Size(540, 311);
            this.lvEntries.TabIndex = 0;
            this.lvEntries.UseCompatibleStateImageBehavior = false;
            this.lvEntries.View = System.Windows.Forms.View.Details;
            this.lvEntries.SelectedIndexChanged += new System.EventHandler(this.lvEntries_SelectedIndexChanged);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 150;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.Width = 64;
            // 
            // chSize2
            // 
            this.chSize2.Text = "Size 2";
            this.chSize2.Width = 64;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 250;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtSize2);
            this.gbInfo.Controls.Add(this.lblSize2);
            this.gbInfo.Controls.Add(this.txtSize);
            this.gbInfo.Controls.Add(this.lblSize);
            this.gbInfo.Controls.Add(this.cmdSave);
            this.gbInfo.Controls.Add(this.lblData);
            this.gbInfo.Controls.Add(this.txtData);
            this.gbInfo.Controls.Add(this.txtID);
            this.gbInfo.Controls.Add(this.lblID);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(252, 311);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Information";
            // 
            // txtSize2
            // 
            this.txtSize2.Location = new System.Drawing.Point(30, 113);
            this.txtSize2.Name = "txtSize2";
            this.txtSize2.Size = new System.Drawing.Size(197, 20);
            this.txtSize2.TabIndex = 24;
            // 
            // lblSize2
            // 
            this.lblSize2.AutoSize = true;
            this.lblSize2.Location = new System.Drawing.Point(25, 97);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(36, 13);
            this.lblSize2.TabIndex = 23;
            this.lblSize2.Text = "Size 2";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(30, 74);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(197, 20);
            this.txtSize.TabIndex = 22;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(25, 58);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 21;
            this.lblSize.Text = "Size";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(58, 268);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(143, 31);
            this.cmdSave.TabIndex = 18;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(25, 136);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 17;
            this.lblData.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(29, 152);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(197, 20);
            this.txtData.TabIndex = 16;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(30, 35);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(197, 20);
            this.txtID.TabIndex = 15;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(25, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "ID";
            // 
            // DataBaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DataBaseEditor";
            this.Size = new System.Drawing.Size(796, 311);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvEntries;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chSize2;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox txtSize2;
        private System.Windows.Forms.Label lblSize2;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;

    }
}
