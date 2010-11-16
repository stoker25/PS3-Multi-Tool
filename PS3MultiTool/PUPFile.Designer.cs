namespace PS3MultiTool
{
    partial class PUPFile
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
            this.components = new System.ComponentModel.Container();
            this.lblPkgVersion = new System.Windows.Forms.Label();
            this.lblImgVersion = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblHeaderSize = new System.Windows.Forms.Label();
            this.lblDataSize = new System.Windows.Forms.Label();
            this.lblHeaderHash = new System.Windows.Forms.Label();
            this.lblPadding = new System.Windows.Forms.Label();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSHA1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExtractAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHeaderHash = new System.Windows.Forms.TextBox();
            this.txtPadding = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cmsFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPkgVersion
            // 
            this.lblPkgVersion.AutoSize = true;
            this.lblPkgVersion.Location = new System.Drawing.Point(14, 19);
            this.lblPkgVersion.Name = "lblPkgVersion";
            this.lblPkgVersion.Size = new System.Drawing.Size(132, 13);
            this.lblPkgVersion.TabIndex = 0;
            this.lblPkgVersion.Text = "Update Package Version: ";
            // 
            // lblImgVersion
            // 
            this.lblImgVersion.AutoSize = true;
            this.lblImgVersion.Location = new System.Drawing.Point(14, 49);
            this.lblImgVersion.Name = "lblImgVersion";
            this.lblImgVersion.Size = new System.Drawing.Size(80, 13);
            this.lblImgVersion.TabIndex = 1;
            this.lblImgVersion.Text = "Image Version: ";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(14, 79);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(60, 13);
            this.lblFileCount.TabIndex = 2;
            this.lblFileCount.Text = "File Count: ";
            // 
            // lblHeaderSize
            // 
            this.lblHeaderSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderSize.AutoSize = true;
            this.lblHeaderSize.Location = new System.Drawing.Point(411, 19);
            this.lblHeaderSize.Name = "lblHeaderSize";
            this.lblHeaderSize.Size = new System.Drawing.Size(71, 13);
            this.lblHeaderSize.TabIndex = 3;
            this.lblHeaderSize.Text = "Header Size: ";
            // 
            // lblDataSize
            // 
            this.lblDataSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSize.AutoSize = true;
            this.lblDataSize.Location = new System.Drawing.Point(411, 49);
            this.lblDataSize.Name = "lblDataSize";
            this.lblDataSize.Size = new System.Drawing.Size(59, 13);
            this.lblDataSize.TabIndex = 4;
            this.lblDataSize.Text = "Data Size: ";
            // 
            // lblHeaderHash
            // 
            this.lblHeaderHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderHash.AutoSize = true;
            this.lblHeaderHash.Location = new System.Drawing.Point(411, 79);
            this.lblHeaderHash.Name = "lblHeaderHash";
            this.lblHeaderHash.Size = new System.Drawing.Size(76, 13);
            this.lblHeaderHash.TabIndex = 5;
            this.lblHeaderHash.Text = "Header Hash: ";
            // 
            // lblPadding
            // 
            this.lblPadding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPadding.AutoSize = true;
            this.lblPadding.Location = new System.Drawing.Point(411, 108);
            this.lblPadding.Name = "lblPadding";
            this.lblPadding.Size = new System.Drawing.Size(52, 13);
            this.lblPadding.TabIndex = 6;
            this.lblPadding.Text = "Padding: ";
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chLength,
            this.chOffset,
            this.chSHA1});
            this.lvFiles.ContextMenuStrip = this.cmsFiles;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.Location = new System.Drawing.Point(17, 149);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(761, 147);
            this.lvFiles.TabIndex = 7;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // chID
            // 
            this.chID.Text = "File ID";
            // 
            // chName
            // 
            this.chName.Text = "File Name";
            this.chName.Width = 179;
            // 
            // chLength
            // 
            this.chLength.Text = "Length";
            // 
            // chOffset
            // 
            this.chOffset.Text = "Offset";
            this.chOffset.Width = 82;
            // 
            // chSHA1
            // 
            this.chSHA1.Text = "HMAC SHA1";
            this.chSHA1.Width = 231;
            // 
            // cmsFiles
            // 
            this.cmsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExtract,
            this.tsmiSeperator,
            this.tsmiExtractAll});
            this.cmsFiles.Name = "cmsFiles";
            this.cmsFiles.Size = new System.Drawing.Size(149, 54);
            // 
            // tsmiExtract
            // 
            this.tsmiExtract.Enabled = false;
            this.tsmiExtract.Name = "tsmiExtract";
            this.tsmiExtract.Size = new System.Drawing.Size(152, 22);
            this.tsmiExtract.Text = "Extract file";
            this.tsmiExtract.Click += new System.EventHandler(this.tsmiExtract_Click);
            // 
            // tsmiSeperator
            // 
            this.tsmiSeperator.Name = "tsmiSeperator";
            this.tsmiSeperator.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmiExtractAll
            // 
            this.tsmiExtractAll.Enabled = false;
            this.tsmiExtractAll.Name = "tsmiExtractAll";
            this.tsmiExtractAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiExtractAll.Text = "Extract all files";
            this.tsmiExtractAll.Click += new System.EventHandler(this.tsmiExtractAll_Click);
            // 
            // txtHeaderHash
            // 
            this.txtHeaderHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeaderHash.Location = new System.Drawing.Point(493, 76);
            this.txtHeaderHash.Name = "txtHeaderHash";
            this.txtHeaderHash.ReadOnly = true;
            this.txtHeaderHash.Size = new System.Drawing.Size(277, 20);
            this.txtHeaderHash.TabIndex = 8;
            // 
            // txtPadding
            // 
            this.txtPadding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPadding.Location = new System.Drawing.Point(493, 105);
            this.txtPadding.Name = "txtPadding";
            this.txtPadding.ReadOnly = true;
            this.txtPadding.Size = new System.Drawing.Size(277, 20);
            this.txtPadding.TabIndex = 9;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(14, 108);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "Version: ";
            // 
            // PUPFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.txtPadding);
            this.Controls.Add(this.txtHeaderHash);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblPadding);
            this.Controls.Add(this.lblHeaderHash);
            this.Controls.Add(this.lblDataSize);
            this.Controls.Add(this.lblHeaderSize);
            this.Controls.Add(this.lblImgVersion);
            this.Controls.Add(this.lblPkgVersion);
            this.Name = "PUPFile";
            this.Size = new System.Drawing.Size(796, 311);
            this.cmsFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPkgVersion;
        private System.Windows.Forms.Label lblImgVersion;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblHeaderSize;
        private System.Windows.Forms.Label lblDataSize;
        private System.Windows.Forms.Label lblHeaderHash;
        private System.Windows.Forms.Label lblPadding;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chLength;
        private System.Windows.Forms.ColumnHeader chOffset;
        private System.Windows.Forms.ColumnHeader chSHA1;
        private System.Windows.Forms.TextBox txtHeaderHash;
        private System.Windows.Forms.TextBox txtPadding;
        private System.Windows.Forms.ContextMenuStrip cmsFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtract;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtractAll;
        private System.Windows.Forms.Label lblVersion;
    }
}
