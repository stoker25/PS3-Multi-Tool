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
    public partial class PUPFile : UserControl, IEditor
    {
        public PlaystationUpdatePackage Package;
        public PUPFile(X360IO IO)
        {
            InitializeComponent();
            Package = new PlaystationUpdatePackage();
            Package.Load(IO);
            lblPkgVersion.Text = string.Format("Update Package Version: 0x{0:X2}", Package.Version);
            lblImgVersion.Text = string.Format("Image Version: 0x{0:X2}", Package.ImageVersion);
            lblFileCount.Text = string.Format("File Count: {0}", Package.FileCount);
            lblHeaderSize.Text = string.Format("Header Size: 0x{0:X2}", Package.HeaderSize);
            lblDataSize.Text = string.Format("Data Size: 0x{0:X2}", Package.DataSize);
            txtHeaderHash.Text = Program.BytesToHexString(Package.HeaderHash);
            txtPadding.Text = Program.BytesToHexString(Package.Padding);
            PlaystationUpdatePackage.FileEntry versionentry = Package.Files.Find(sec => sec.ID == 0x100);
            if(versionentry != null)
            {
                byte[] data = Package.GetFileData(versionentry);
                string version = Encoding.ASCII.GetString(data);
                lblVersion.Text = "Version: " + version;
            }
            else
                lblVersion.Text = "Version: N/A";
            
            foreach(PlaystationUpdatePackage.FileEntry entry in Package.Files)
            {
                ListViewItem item = new ListViewItem(entry.ID.ToString("X2"));
                string filename = (string) PlaystationUpdatePackage.FileNames[entry.ID];
                if (String.IsNullOrEmpty(filename))
                    filename = string.Format("file_{0:X2}.tar", entry.ID);
                item.SubItems.Add(filename);
                item.SubItems.Add(entry.Size.ToString());
                item.SubItems.Add(entry.Offset.ToString());
                item.SubItems.Add(Program.BytesToHexString(entry.Hash.HMACSHA1));
                item.Tag = entry;
                lvFiles.Items.Add(item);
            }
            tsmiExtractAll.Enabled = true;
        }
        public void Save()
        {

        }
        public void Close()
        {
            Package.IO.Close();
        }
        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems == null || lvFiles.SelectedItems.Count <= 0)
            {
                tsmiExtract.Enabled = false;
                return;
            }
            if (lvFiles.SelectedItems.Count > 1)
                tsmiExtract.Text = "Extract files";
            tsmiExtract.Enabled = true;
        }
        public void ExtractFile(ListViewItem file, string filePath)
        {
            PlaystationUpdatePackage.FileEntry entry =
                    ((PlaystationUpdatePackage.FileEntry)file.Tag);
            
            File.WriteAllBytes(filePath, Package.GetFileData(entry));
            
        }
        private void tsmiExtract_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems == null || lvFiles.SelectedItems.Count <= 0)
            {
                tsmiExtract.Enabled = false;
                return;
            }
            if (lvFiles.SelectedItems.Count == 1)
            {
                PlaystationUpdatePackage.FileEntry entry =
                       ((PlaystationUpdatePackage.FileEntry)lvFiles.SelectedItems[0].Tag);
                string filename = (string)PlaystationUpdatePackage.FileNames[entry.ID];
                if (String.IsNullOrEmpty(filename))
                    filename = string.Format("file_{0:X2}.tar", entry.ID);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = filename;
                if (sfd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(sfd.FileName))
                {
                    ExtractFile(lvFiles.SelectedItems[0], sfd.FileName);
                }
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if(fbd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(fbd.SelectedPath))
                {
                    foreach(ListViewItem item in lvFiles.SelectedItems)
                    {
                        PlaystationUpdatePackage.FileEntry entry =
                       ((PlaystationUpdatePackage.FileEntry)item.Tag);
                        string filename = (string)PlaystationUpdatePackage.FileNames[entry.ID];
                        if (String.IsNullOrEmpty(filename))
                            filename = string.Format("file_{0:X2}.tar", entry.ID);
                        string path = Path.Combine(fbd.SelectedPath, filename);
                        ExtractFile(item, path);
                    }
                }
            }
            MessageBox.Show("Done!");
        }

        private void tsmiExtractAll_Click(object sender, EventArgs e)
        {
            if (lvFiles.Items == null || lvFiles.Items.Count <= 0)
            {
                tsmiExtractAll.Enabled = false;
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(fbd.SelectedPath))
            {
                foreach (ListViewItem item in lvFiles.Items)
                {
                    PlaystationUpdatePackage.FileEntry entry =
                        ((PlaystationUpdatePackage.FileEntry) item.Tag);
                    string filename = (string) PlaystationUpdatePackage.FileNames[entry.ID];
                    if (String.IsNullOrEmpty(filename))
                        filename = string.Format("file_{0:X2}.tar", entry.ID);
                    string path = Path.Combine(fbd.SelectedPath, filename);
                    ExtractFile(item, path);
                }
            }
            MessageBox.Show("Done!");
        }
    }
}
