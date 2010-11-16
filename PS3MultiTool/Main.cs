using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public partial class Main : Form
    {
        public string ver;
        public Main()
        {
            InitializeComponent();
            ver = Text;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
            {
                tsmiClose_Click(null, null);
                OpenFile(ofd.FileName);
            }
        }

        public void OpenFile(string fileName)
        {
            Text = ver + " - " + fileName;
            X360IO io = new X360IO(fileName, FileMode.Open, true);
            uint magic = io.Reader.ReadUInt32();
            pnlContent.Controls.Clear();
            switch(magic)
            {
                case 0x00000000:
                    // PDB?
                    DataBaseEditor editor = new DataBaseEditor(io);
                    pnlContent.Controls.Add(editor);
                    break;
                case 0x53434555:
                    // PUP file
                    PUPFile file = new PUPFile(io);// {AutoSize = true, BackColor = Color.Transparent};
                    pnlContent.Controls.Add(file);
                    break;
                case 0x53434500:
                    // SCE header
                    SCEEditor form1 = new SCEEditor(io);// {AutoSize = true, BackColor = Color.Transparent};
                    pnlContent.Controls.Add(form1);
                    break;
                case 0xBCADADBC:
                    // registry file
                    RegistryEditor form = new RegistryEditor(io);// { AutoSize = true, BackColor = Color.Transparent };
                    pnlContent.Controls.Add(form);
                    break;
                default:
                    // unknown
                    MessageBox.Show("Unknown file!");
                    io.Close();
                    Text = ver;
                    break;
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if(pnlContent.Controls.Count > 0)
            {
                ((IEditor)pnlContent.Controls[0]).Save();
            }
        }

        private void tsmiSupported_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "SELF executables\r\nUpdate PKG files\r\nPUP (Playstation Update Package) files\r\nPS3 Registry (xRegistry.sys) files\r\n(SOON) PDB Editor\r\n(SOON) SFD SYSTEM FILE Editor");
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            if (pnlContent.Controls.Count > 0)
            {
                ((IEditor)pnlContent.Controls[0]).Close();
            }
            pnlContent.Controls.Clear();
            Text = ver;
        }

        private void pDBFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(sfd.FileName))
            {
                DialogResult result = MessageBox.Show("Do you want to load initial database values?", "Load Initial Values?",
                                                  MessageBoxButtons.YesNo);

                pnlContent.Controls.Clear();
                File.WriteAllBytes(sfd.FileName, new byte[4]);
                DataBaseEditor editor = new DataBaseEditor(new X360IO(sfd.FileName, FileMode.OpenOrCreate, true));
                pnlContent.Controls.Add(editor);
                if (result == DialogResult.Yes)
                {
                    editor.DataBase.LoadInitialValues();
                    editor.LoadEntries();
                }
            }
        }
    }
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
