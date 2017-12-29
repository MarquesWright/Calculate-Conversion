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
    public partial class frmConversion : Form
    {
        public frmConversion()
        {
            InitializeComponent();
        }

        public List<Conversions> conversions = null;

        private void frmConversionMain_Load(object sender, EventArgs e)
        {
            conversions = ConversionDB.GetConversions();
            FillConversionComboBox();
            cboConversion.SelectedIndex = 0;
        }

        private void FillConversionComboBox()
        {
            cboConversion.Items.Clear();
            foreach (Conversions c in conversions)
            {
                cboConversion.Items.Add(c.GetDisplayText());
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // checks to be sure input is valid
        private bool IsValidData()
        {
            return Validator.IsPresent(txtFrom) &&
                Validator.IsPresent(txtTo);
                
        }
    }
}
