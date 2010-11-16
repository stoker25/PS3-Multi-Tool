using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PS3MultiTool
{
    public partial class About : Form
    {

        public About()
        {
            InitializeComponent();
            Text = "About";
            ControlBox = false;
        }

        private void lblURL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://stoker25.com/");
        }

        private void lblURL2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.psx-scene.com");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
