using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate_Conversions
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            toolStrip1.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            Form newForm = new frmConversion();
        }

        //creates and displays a new instance of a conversion form
        private void mnuNewConversion_Click(object sender, EventArgs e)
        {
            Form newForm = new frmConversion();
            newForm.MdiParent = this;
            newForm.Show();
        }


        private void mnuClose_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;
            if (activeForm != null)
                activeForm.Close();
        }

        //
        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //arranges the conversion forms vertically
        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        //arranges the conversion forms horizontally
        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        //exits the application and closes all conversion forms
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            Form options = new frmOptions();
            options.ShowDialog();
        }

        
    }
}
