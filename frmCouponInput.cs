using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmCouponInput : Form
    {
        public frmCouponInput()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string CouponCode;
        public static double percentOff;
        public static bool CodeUsed = false;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                DataCodes code = DataCodes.GetCode(txtCode.Text.ToUpper());

                if (code != null)
                {
                    if(code.Active == true)
                    {
                        MessageBox.Show("Code accepted! Your discount will be applied at checkout", "Accepted!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CodeUsed = true;
                        CouponCode = code.DiscountCode;
                        percentOff = code.PercentOff;
                    }
                    else
                    {
                        MessageBox.Show("This code is inactive", "Code unavailable for use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                   MessageBox.Show("This code doesn't exist", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCouponInput_Load(object sender, EventArgs e)
        {
            txtCode.MaxLength = 5;
        }
    }
}
