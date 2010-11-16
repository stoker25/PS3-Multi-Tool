using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public partial class SCEEditor : UserControl, IEditor
    {
        public SCEHeader Header;
        public SCEEditor(X360IO IO)
        {
            InitializeComponent();
            Header = new SCEHeader();
            Header.Load(IO);
            lblHdrVersion.Text = string.Format("Header Version: 0x{0:X2}", Header.Version);
            lblFileType.Text = string.Format("File Type: 0x{0:X2} ({1})", Header.FileType,
                                               SCEHeader.FileTypes[Header.FileType]);
            lblFlags.Text = string.Format("Flags: 0x{0:X4}", Header.Flags);
            if (Header.IsContentEncrypted)
                lblFlags.Text += " (ENCRYPTED)";
            else
                lblFlags.Text += " (DECRYPTED)";
            lblHdrSize.Text = string.Format("Header Size: 0x{0:X2}", Header.HeaderSize);
            lblUnk1.Text = string.Format("Unknown 1: 0x{0:X2}", Header.Unknown1);
            lblUnk2.Text = string.Format("Unknown 2: 0x{0:X2}", Header.Unknown2);
            if (Header.FileType == 1 && !Header.IsContentEncrypted)
                cmdUnfself.Enabled = true;
            /*lblImgVersion.Text = string.Format("Image Version: {0:X2}", Package.ImageVersion);
            lblFileCount.Text = string.Format("File Count: {0}", Package.FileCount);
            lblHeaderSize.Text = string.Format("Header Size: {0:X2}", Package.HeaderSize);
            lblDataSize.Text = string.Format("Data Size: {0:X2}", Package.DataSize);
            txtHeaderHash.Text = Program.BytesToHexString(Package.HeaderHash);
            txtPadding.Text = Program.BytesToHexString(Package.Padding);*/
            
            tsmiExtractAll.Enabled = true;
        }
        public void Save()
        {

        }

        public void Close()
        {
            Header.IO.Close();
            Header.IO = null;
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdUnfself_Click(object sender, EventArgs e)
        {
            if (Header.FileType != 1 || Header.IsContentEncrypted)
            {
                MessageBox.Show("This file cannot be decrypted.");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(sfd.FileName))
            {
                byte[] data = Header.UnFSELF();
                File.WriteAllBytes(sfd.FileName, data);
            }
        }
    }
}
