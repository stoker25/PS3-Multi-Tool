namespace PS3MultiTool
{
    partial class RegistryEditor
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
            this.chChecksum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFlags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtHeaderValue = new System.Windows.Forms.TextBox();
            this.lblHeaderValue = new System.Windows.Forms.Label();
            this.txtSetting = new System.Windows.Forms.TextBox();
            this.lblSettingName = new System.Windows.Forms.Label();
            this.lblFlags = new System.Windows.Forms.Label();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
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
            this.chChecksum,
            this.chSetting,
            this.chValue,
            this.chHeaderValue,
            this.chFlags});
            this.lvEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntries.FullRowSelect = true;
            this.lvEntries.Location = new System.Drawing.Point(0, 0);
            this.lvEntries.Name = "lvEntries";
            this.lvEntries.Size = new System.Drawing.Size(540, 311);
            this.lvEntries.TabIndex = 0;
            this.lvEntries.UseCompatibleStateImageBehavior = false;
            this.lvEntries.View = System.Windows.Forms.View.Details;
            this.lvEntries.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEntries_ColumnClick);
            this.lvEntries.SelectedIndexChanged += new System.EventHandler(this.lvEntries_SelectedIndexChanged);
            // 
            // chChecksum
            // 
            this.chChecksum.Text = "Checksum";
            this.chChecksum.Width = 64;
            // 
            // chSetting
            // 
            this.chSetting.Text = "Setting";
            this.chSetting.Width = 181;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 145;
            // 
            // chHeaderValue
            // 
            this.chHeaderValue.Text = "Header Value";
            this.chHeaderValue.Width = 81;
            // 
            // chFlags
            // 
            this.chFlags.Text = "Flags";
            this.chFlags.Width = 56;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtHeaderValue);
            this.gbInfo.Controls.Add(this.lblHeaderValue);
            this.gbInfo.Controls.Add(this.txtSetting);
            this.gbInfo.Controls.Add(this.lblSettingName);
            this.gbInfo.Controls.Add(this.lblFlags);
            this.gbInfo.Controls.Add(this.txtFlags);
            this.gbInfo.Controls.Add(this.cmdSave);
            this.gbInfo.Controls.Add(this.lblValue);
            this.gbInfo.Controls.Add(this.txtValue);
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
            // txtHeaderValue
            // 
            this.txtHeaderValue.Location = new System.Drawing.Point(30, 106);
            this.txtHeaderValue.Name = "txtHeaderValue";
            this.txtHeaderValue.Size = new System.Drawing.Size(197, 20);
            this.txtHeaderValue.TabIndex = 24;
            // 
            // lblHeaderValue
            // 
            this.lblHeaderValue.AutoSize = true;
            this.lblHeaderValue.Location = new System.Drawing.Point(25, 90);
            this.lblHeaderValue.Name = "lblHeaderValue";
            this.lblHeaderValue.Size = new System.Drawing.Size(72, 13);
            this.lblHeaderValue.TabIndex = 23;
            this.lblHeaderValue.Text = "Header Value";
            // 
            // txtSetting
            // 
            this.txtSetting.Location = new System.Drawing.Point(30, 67);
            this.txtSetting.Name = "txtSetting";
            this.txtSetting.Size = new System.Drawing.Size(197, 20);
            this.txtSetting.TabIndex = 22;
            // 
            // lblSettingName
            // 
            this.lblSettingName.AutoSize = true;
            this.lblSettingName.Location = new System.Drawing.Point(25, 51);
            this.lblSettingName.Name = "lblSettingName";
            this.lblSettingName.Size = new System.Drawing.Size(71, 13);
            this.lblSettingName.TabIndex = 21;
            this.lblSettingName.Text = "Setting Name";
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Location = new System.Drawing.Point(25, 168);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(32, 13);
            this.lblFlags.TabIndex = 20;
            this.lblFlags.Text = "Flags";
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(28, 184);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(197, 20);
            this.txtFlags.TabIndex = 19;
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
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(25, 129);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(70, 13);
            this.lblValue.TabIndex = 17;
            this.lblValue.Text = "Setting Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(29, 145);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(197, 20);
            this.txtValue.TabIndex = 16;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(30, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(197, 20);
            this.txtID.TabIndex = 15;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(25, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(57, 13);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "Checksum";
            // 
            // RegistryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "RegistryEditor";
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
        private System.Windows.Forms.ColumnHeader chChecksum;
        private System.Windows.Forms.ColumnHeader chSetting;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chHeaderValue;
        private System.Windows.Forms.ColumnHeader chFlags;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox txtHeaderValue;
        private System.Windows.Forms.Label lblHeaderValue;
        private System.Windows.Forms.TextBox txtSetting;
        private System.Windows.Forms.Label lblSettingName;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;

    }
}
