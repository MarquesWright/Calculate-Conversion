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
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }


        public List<Options> options = null;
        frmMain main = new frmMain();
        

        //Loads the options form with conversions
        private void frmOptions_Load(object sender, EventArgs e)
        {
            options = OptionsDB.GetConversions();
            FillConversionListBox();
            FillConversionComboBox();
            cboDefault.SelectedIndex = 0;
        }

        //Loads conversions from xml file into the list box
        private void FillConversionListBox()
        {
            lstConversions.Items.Clear();

            foreach (Options o in options)
            {
                lstConversions.Items.Add(o.GetDisplayText());
            }
        }

        //Loads conversion list into default combo box
        private void FillConversionComboBox()
        {
            cboDefault.Items.Clear();

            foreach (Options o in options)
            {
                cboDefault.Items.Add(o.GetComboText());
            }
        }

        //shows the add new conversion form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddConversion addForm = new frmAddConversion();

            Options option = addForm.GetNewConversion();
            if (option != null)
            {
                options.Add(option);
                OptionsDB.SaveConversions(options);
                FillConversionListBox();
            }
        }

        
        //Determines if the toolbar will be shown or not
        public void chkToolbar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToolbar.Checked == true)
                EnableToolbar();
            else
                DisableToolbar();
        }

        private void EnableToolbar()
        {
            main.toolStrip1.Visible = true;
        }

        private void DisableToolbar()
        {
            main.toolStrip1.Enabled = false;
        }

        //Remove a conversion from the form
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lstConversions.SelectedIndex;
            if (i != -1)
            {
                Options option = (Options)options[i];
                string message = "Are you sure you want to delete "
                    + option.From + " to " + option.To + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (button == DialogResult.Yes)
                {
                    options.Remove(option);
                    OptionsDB.SaveConversions(options);
                    FillConversionListBox();
                }
            }
        }

        //Saves the options form
        private void btnOK_Click(object sender, EventArgs e)
        {
            OptionsDB.SaveConversions(options);
        }

        //Exits the options form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
