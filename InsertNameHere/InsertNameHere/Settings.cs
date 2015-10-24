using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertNameHere
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public string rHeight
        {
            get { return tbHeight.Text; }
        }
        public string rWidth
        {
            get { return tbWidth.Text; }
        }
        public bool Fullscreen
        {
            get { return cbFullscreen.Checked; }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            tbHeight.Text = Screen.GetBounds(tbHeight).Height.ToString();
            tbWidth.Text = Screen.GetBounds(tbHeight).Width.ToString();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
