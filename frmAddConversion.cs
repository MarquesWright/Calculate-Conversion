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
    public partial class frmAddConversion : Form
    {
        public frmAddConversion()
        {
            InitializeComponent();
        }

        private Options option = null;

        public Options GetNewConversion()
        {
            this.ShowDialog();
            return option;
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                option = new Options(txtFrom.Text, txtTo.Text,
                    Convert.ToDecimal(txtMultiplier.Text));

                this.Close();
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtFrom) &&
                Validator.IsPresent(txtTo) &&
                Validator.IsPresent(txtMultiplier) &&
                Validator.IsDecimal(txtMultiplier);
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
