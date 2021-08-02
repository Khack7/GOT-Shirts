using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmEmpCodes : Form
    {
        private List<DataCodes> _lstActiveCodes, _lstInactiveCodes;
        public frmEmpCodes()
        {
            InitializeComponent();
            try
            {
                _lstActiveCodes = DataCodes.ListActiveOnlyCodes();
                _lstInactiveCodes = DataCodes.ListInactiveCodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstActive_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataCodes codes = DataCodes.GetCode(lstActive.SelectedItem.ToString());
                lblActiveDiscount.Text = codes.PercentOff.ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstInactive_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataCodes codes = DataCodes.GetCode(lstActive.SelectedItem.ToString());
                lblInactiveDiscount.Text = codes.PercentOff.ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEmpCodes_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstActiveCodes = _lstActiveCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();
                List<string> lstInactiveCodes = _lstInactiveCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

                for (int intIndex = 0; intIndex < lstActiveCodes.Count; intIndex++)
                {
                    lstActive.Items.Add(lstActiveCodes[intIndex]);
                }
                for (int intIndex = 0; intIndex < lstInactiveCodes.Count; intIndex++)
                {
                    lstInactive.Items.Add(lstInactiveCodes[intIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
