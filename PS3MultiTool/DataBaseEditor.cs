using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public partial class DataBaseEditor : UserControl, IEditor
    {
        public PackageDataBase DataBase;
        public ListViewItem SelectedEntry;
        private ToolTip tips = new ToolTip();
        public DataBaseEditor(X360IO IO)
        {
            InitializeComponent();
            DataBase = new PackageDataBase();
            DataBase.Load(IO);
            LoadEntries();
        }

        public void LoadEntries()
        {
            ClearSelected();
            lvEntries.Items.Clear();
            foreach (PackageDataBase.DataBaseEntry entry in DataBase.Entries)
            {
                string name = "0x" + ((uint)entry.ID).ToString("X2");
                if (Enum.GetNames(typeof(PackageDataBase.EntryID)).Contains(entry.ID.ToString()))
                    name = entry.ID.ToString();
                ListViewItem item = new ListViewItem(name);
                item.SubItems.Add(entry.Size.ToString());
                item.SubItems.Add(entry.Size2.ToString());
                item.SubItems.Add(entry.DataString);
                item.Tag = entry;
                lvEntries.Items.Add(item);
            }
        }

        private void ClearSelected()
        {
            SelectedEntry = null;
            txtID.Text = "";
            txtData.Text = "";
            txtSize.Text = "";
            txtSize2.Text = "";
            cmdSave.Enabled = false;
        }

        public void Save()
        {
            DataBase.Save();

        }

        private void lvEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntries.SelectedItems == null || lvEntries.SelectedItems.Count <= 0)
            {
                ClearSelected();
                return;
            }
            SelectedEntry = lvEntries.SelectedItems[0];
            PackageDataBase.DataBaseEntry entry = (PackageDataBase.DataBaseEntry)SelectedEntry.Tag;
            txtID.Text = ((uint)entry.ID).ToString("X2");
            txtSize.Text = entry.Size.ToString();
            txtSize2.Text = entry.Size2.ToString();

            txtData.Text = entry.DataString;
            tips.RemoveAll();
            try
            {
                tips.SetToolTip(txtData, Encoding.ASCII.GetString(entry.Data).Trim('\0'));
            }
            catch
            {
                tips.SetToolTip(txtData, "Invalid ASCII!");
            }
            cmdSave.Enabled = true;
        }
        public void Close()
        {
            DataBase.IO.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
            {
                ClearSelected();
                return;
            }
            PackageDataBase.DataBaseEntry entry = (PackageDataBase.DataBaseEntry)SelectedEntry.Tag;
            entry.ID = (PackageDataBase.EntryID)UInt32.Parse(txtID.Text, NumberStyles.HexNumber);
            entry.Data = Program.HexStringToBytes(txtData.Text);
            entry.Size = UInt32.Parse(txtSize.Text);
            entry.Size2 = UInt32.Parse(txtSize2.Text);
            string name = "0x" + ((uint)entry.ID).ToString("X2");
            if (Enum.GetNames(typeof(PackageDataBase.EntryID)).Contains(entry.ID.ToString()))
                name = entry.ID.ToString();
            SelectedEntry.Text = name;
            SelectedEntry.SubItems[1].Text = entry.Size.ToString();
            SelectedEntry.SubItems[2].Text = entry.Size2.ToString();
            SelectedEntry.SubItems[3].Text = entry.DataString;
        }
    }
}
