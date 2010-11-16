namespace PS3MultiTool
{
    partial class About
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblURL2 = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblAbout3 = new System.Windows.Forms.Label();
            this.lblAbout2 = new System.Windows.Forms.Label();
            this.lblAbout1 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lblURL2);
            this.panel1.Controls.Add(this.lblURL);
            this.panel1.Controls.Add(this.lblAbout3);
            this.panel1.Controls.Add(this.lblAbout2);
            this.panel1.Controls.Add(this.lblAbout1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 252);
            this.panel1.TabIndex = 4;
            // 
            // lblURL2
            // 
            this.lblURL2.AutoSize = true;
            this.lblURL2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblURL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblURL2.Location = new System.Drawing.Point(19, 214);
            this.lblURL2.Name = "lblURL2";
            this.lblURL2.Size = new System.Drawing.Size(160, 13);
            this.lblURL2.TabIndex = 9;
            this.lblURL2.Text = "http://www.psx-scene.com";
            this.lblURL2.Click += new System.EventHandler(this.lblURL2_Click);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblURL.Location = new System.Drawing.Point(19, 187);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(121, 13);
            this.lblURL.TabIndex = 8;
            this.lblURL.Text = "http://stoker25.com";
            this.lblURL.Click += new System.EventHandler(this.lblURL_Click);
            // 
            // lblAbout3
            // 
            this.lblAbout3.AutoSize = true;
            this.lblAbout3.Location = new System.Drawing.Point(19, 131);
            this.lblAbout3.Name = "lblAbout3";
            this.lblAbout3.Size = new System.Drawing.Size(135, 39);
            this.lblAbout3.TabIndex = 7;
            this.lblAbout3.Text = "PS3 Multi Tool v0.2\r\nby stoker25\r\nCovered by the GPL (soon)";
            // 
            // lblAbout2
            // 
            this.lblAbout2.AutoSize = true;
            this.lblAbout2.Location = new System.Drawing.Point(195, 47);
            this.lblAbout2.Name = "lblAbout2";
            this.lblAbout2.Size = new System.Drawing.Size(63, 13);
            this.lblAbout2.TabIndex = 6;
            this.lblAbout2.Text = "By stoker25";
            // 
            // lblAbout1
            // 
            this.lblAbout1.AutoSize = true;
            this.lblAbout1.Location = new System.Drawing.Point(162, 19);
            this.lblAbout1.Name = "lblAbout1";
            this.lblAbout1.Size = new System.Drawing.Size(76, 13);
            this.lblAbout1.TabIndex = 5;
            this.lblAbout1.Text = "PS3 Multi Tool";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(181, 256);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(60, 22);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PS3MultiTool.Properties.Resources.ps3mt;
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 282);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblURL2;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblAbout3;
        private System.Windows.Forms.Label lblAbout2;
        private System.Windows.Forms.Label lblAbout1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdClose;

    }
}