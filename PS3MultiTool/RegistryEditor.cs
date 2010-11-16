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
    public partial class RegistryEditor : UserControl, IEditor
    {
        public PS3Registry Registry;
        public ListViewItem SelectedEntry;
        private ListViewColumnSorter lvwColumnSorter;

        public RegistryEditor(X360IO IO)
        {
            InitializeComponent();
            Registry = new PS3Registry();
            Registry.Load(IO);
            lvwColumnSorter = new ListViewColumnSorter();
            lvEntries.ListViewItemSorter = lvwColumnSorter;
            LoadEntries();
        }

        public void LoadEntries()
        {
            ClearSelected();
            lvEntries.Items.Clear();
            foreach (PS3Registry.SettingDataEntry entry in Registry.DataEntries)
            {
                if (entry.Flags != 0x7A)
                {
                    ListViewItem item = new ListViewItem(string.Format("0x{0:X4}", entry.Checksum));
                    item.SubItems.Add(entry.FileNameEntry.Setting);
                    item.SubItems.Add(entry.ValueString);
                    item.SubItems.Add(string.Format("0x{0:X2}", entry.FileNameEntry.Value));
                    item.SubItems.Add(string.Format("0x{0:X4}", entry.Flags));
                    item.Tag = entry;
                    lvEntries.Items.Add(item);
                }
            }
        }

        private void ClearSelected()
        {
            SelectedEntry = null;
            txtID.Text = "";
            txtValue.Text = "";
            txtFlags.Text = "";
            txtHeaderValue.Text = "";
            cmdSave.Enabled = false;
            txtSetting.Text = "";
        }

        public void Save()
        {
            Registry.Save();

        }

        private void lvEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntries.SelectedItems == null || lvEntries.SelectedItems.Count <= 0)
            {
                ClearSelected();
                return;
            }
            SelectedEntry = lvEntries.SelectedItems[0];
            PS3Registry.SettingDataEntry entry = (PS3Registry.SettingDataEntry) SelectedEntry.Tag;
            txtID.Text = entry.Checksum.ToString("X4");
            txtSetting.Text = entry.FileNameEntry.Setting;
            txtFlags.Text = entry.Flags.ToString("X4");
            txtHeaderValue.Text = entry.FileNameEntry.Value.ToString("X2");
            cmdSave.Enabled = true;
            txtValue.Text = entry.ValueString;
        }
        public void Close()
        {
            Registry.IO.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
            {
                ClearSelected();
                return;
            }
            PS3Registry.SettingDataEntry entry = (PS3Registry.SettingDataEntry)SelectedEntry.Tag;
            ushort checksum;
            ushort flags;
            byte hvalue;
            try
            {
                checksum = UInt16.Parse(txtID.Text, NumberStyles.HexNumber);
                flags = UInt16.Parse(txtFlags.Text, NumberStyles.HexNumber);
                hvalue = byte.Parse(txtHeaderValue.Text, NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Invalid input!", "PS3 Multi Tool");
                return;
            }
            
            try
            {
                entry.ValueString = txtValue.Text;
            }
            catch
            {
                MessageBox.Show("Invalid setting value!", "PS3 Multi Tool");
                return;
            }
            entry.Checksum = checksum;
            entry.Flags = flags;
            entry.FileNameEntry.Value = hvalue;
            SelectedEntry.Text = string.Format("0x{0:X4}", entry.Checksum);
            SelectedEntry.SubItems[1].Text = entry.FileNameEntry.Setting;
            SelectedEntry.SubItems[2].Text = entry.ValueString;
            SelectedEntry.SubItems[3].Text = string.Format("0x{0:X2}", entry.FileNameEntry.Value);
            SelectedEntry.SubItems[4].Text = string.Format("0x{0:X4}", entry.Flags);
        }

        private void lvEntries_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvEntries.Sort();
        }
    }
}
