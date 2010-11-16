namespace PS3MultiTool
{
    partial class SCEEditor
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
            this.lblHdrVersion = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblFlags = new System.Windows.Forms.Label();
            this.lblUnk1 = new System.Windows.Forms.Label();
            this.lblUnk2 = new System.Windows.Forms.Label();
            this.cmsFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExtractAll = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHdrSize = new System.Windows.Forms.Label();
            this.gbFuncs = new System.Windows.Forms.GroupBox();
            this.cmdUnfself = new System.Windows.Forms.Button();
            this.cmsFiles.SuspendLayout();
            this.gbFuncs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHdrVersion
            // 
            this.lblHdrVersion.AutoSize = true;
            this.lblHdrVersion.Location = new System.Drawing.Point(14, 19);
            this.lblHdrVersion.Name = "lblHdrVersion";
            this.lblHdrVersion.Size = new System.Drawing.Size(86, 13);
            this.lblHdrVersion.TabIndex = 0;
            this.lblHdrVersion.Text = "Header Version: ";
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(14, 49);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(56, 13);
            this.lblFileType.TabIndex = 1;
            this.lblFileType.Text = "File Type: ";
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Location = new System.Drawing.Point(14, 79);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(38, 13);
            this.lblFlags.TabIndex = 2;
            this.lblFlags.Text = "Flags: ";
            // 
            // lblUnk1
            // 
            this.lblUnk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnk1.AutoSize = true;
            this.lblUnk1.Location = new System.Drawing.Point(411, 19);
            this.lblUnk1.Name = "lblUnk1";
            this.lblUnk1.Size = new System.Drawing.Size(68, 13);
            this.lblUnk1.TabIndex = 3;
            this.lblUnk1.Text = "Unknown 1: ";
            // 
            // lblUnk2
            // 
            this.lblUnk2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnk2.AutoSize = true;
            this.lblUnk2.Location = new System.Drawing.Point(411, 49);
            this.lblUnk2.Name = "lblUnk2";
            this.lblUnk2.Size = new System.Drawing.Size(68, 13);
            this.lblUnk2.TabIndex = 4;
            this.lblUnk2.Text = "Unknown 2: ";
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
            this.tsmiExtract.Size = new System.Drawing.Size(148, 22);
            this.tsmiExtract.Text = "Extract file";
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
            this.tsmiExtractAll.Size = new System.Drawing.Size(148, 22);
            this.tsmiExtractAll.Text = "Extract all files";
            // 
            // lblHdrSize
            // 
            this.lblHdrSize.AutoSize = true;
            this.lblHdrSize.Location = new System.Drawing.Point(14, 108);
            this.lblHdrSize.Name = "lblHdrSize";
            this.lblHdrSize.Size = new System.Drawing.Size(71, 13);
            this.lblHdrSize.TabIndex = 10;
            this.lblHdrSize.Text = "Header Size: ";
            // 
            // gbFuncs
            // 
            this.gbFuncs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFuncs.Controls.Add(this.cmdUnfself);
            this.gbFuncs.Location = new System.Drawing.Point(414, 71);
            this.gbFuncs.Name = "gbFuncs";
            this.gbFuncs.Size = new System.Drawing.Size(363, 72);
            this.gbFuncs.TabIndex = 11;
            this.gbFuncs.TabStop = false;
            this.gbFuncs.Text = "Functions";
            // 
            // cmdUnfself
            // 
            this.cmdUnfself.Enabled = false;
            this.cmdUnfself.Location = new System.Drawing.Point(10, 18);
            this.cmdUnfself.Name = "cmdUnfself";
            this.cmdUnfself.Size = new System.Drawing.Size(135, 22);
            this.cmdUnfself.TabIndex = 0;
            this.cmdUnfself.Text = "UnFSELF (SELF to ELF)";
            this.cmdUnfself.UseVisualStyleBackColor = true;
            this.cmdUnfself.Click += new System.EventHandler(this.cmdUnfself_Click);
            // 
            // SCEEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFuncs);
            this.Controls.Add(this.lblHdrSize);
            this.Controls.Add(this.lblFlags);
            this.Controls.Add(this.lblUnk2);
            this.Controls.Add(this.lblUnk1);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.lblHdrVersion);
            this.Name = "SCEEditor";
            this.Size = new System.Drawing.Size(796, 311);
            this.cmsFiles.ResumeLayout(false);
            this.gbFuncs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHdrVersion;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.Label lblUnk1;
        private System.Windows.Forms.Label lblUnk2;
        private System.Windows.Forms.ContextMenuStrip cmsFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtract;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtractAll;
        private System.Windows.Forms.Label lblHdrSize;
        private System.Windows.Forms.GroupBox gbFuncs;
        private System.Windows.Forms.Button cmdUnfself;
    }
}
