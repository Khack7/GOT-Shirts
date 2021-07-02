//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the selected item(s) are displayed, the pricings,
// and the payment options.
//*******************************************
//*******************************************using System;
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
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void getShipping(string method)
        {
            try
            {
                DataMoney shipping = null;

                shipping = DataMoney.GetValues(method);

                double.TryParse(shipping.SettingValue, out double d);
                dblShippingCost = d;

                lblShipping.Text = dblShippingCost.ToString("C2");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        double dblShippingCost, dblTaxCost, dblSubCost, dblTotalCost;

        private void frmCheckout_Load(object sender, System.EventArgs e)
        {
            try
            {
                string strCurrentItem;
                for (int i = 0; i < frmShop.lstCartItems.Count; i++)
                {
                    strCurrentItem = frmShop.lstCartItems.ElementAt(i);
                    lstCart.Items.Add(strCurrentItem);
                }

                if (frmCouponInput.CodeUsed == true)
                {
                    double.TryParse(frmShop.strSubtotal, out double sub);

                    int intDiscount = frmCouponInput.percentOff;
                    dblSubCost = (sub - (sub * intDiscount));



                    lblSubtotal.Text = dblSubCost.ToString("C2");
                }
                else
                {
                    double.TryParse(frmShop.strSubtotal, out double s);
                    dblSubCost = s;
                    lblSubtotal.Text = dblSubCost.ToString("C2");
                }

                getShipping(strShippingMethod);

                DataMoney tax = null;

                tax = DataMoney.GetValues("TaxRate");

                double.TryParse(tax.SettingValue, out double d);

                double dblTaxes = d;

                dblTaxCost = dblTaxes * dblSubCost;

                lblTax.Text = (dblTaxCost).ToString("C2");

                dblTotalCost = dblSubCost + dblTaxCost + dblShippingCost;

                lblTotal.Text = (dblTotalCost).ToString("C2");


                string[] arrYears = new string[12];

                cboMonth.Items.Add("01");
                cboMonth.Items.Add("02");
                cboMonth.Items.Add("03");
                cboMonth.Items.Add("04");
                cboMonth.Items.Add("05");
                cboMonth.Items.Add("06");
                cboMonth.Items.Add("07");
                cboMonth.Items.Add("08");
                cboMonth.Items.Add("09");
                cboMonth.Items.Add("10");
                cboMonth.Items.Add("11");
                cboMonth.Items.Add("12");

                for (int i = 0; i < 12; i++)
                {
                    if (int.TryParse(DateTime.Now.Year.ToString(), out int y))
                    {
                        arrYears[i] = (y + i).ToString();
                    }
                }
                for (int y = 0; y < arrYears.Length; y++)
                {
                    cboYear.Items.Add(arrYears[y]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string strShippingMethod = "StandardShipping";

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {                 
                DataOrder order = null;

                DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd"), out DateTime todaysDate);

                string strCode;

                if (frmCouponInput.CouponCode == null)
                {
                    strCode = null;
                }
                else
                {
                    strCode = frmCouponInput.CouponCode;
                }

                string strCardType;

                if (rdoDiscover.Checked == true)
                {
                    strCardType = "Discover";
                }
                else if (rdoVisa.Checked == true)
                {
                    strCardType = "Visa";
                }
                else
                {
                    strCardType = "MasterCard";
                }

                order = new DataOrder
                {
                    PersonID = frmSignIn.intID,
                    OrderDate = todaysDate,
                    DiscountCode = strCode,
                    Shipping = dblShippingCost,
                    CardType = strCardType,
                    CardNumber = Convert.ToInt32(txtCard.Text),
                    CardExperation = cboMonth.SelectedItem + "/" + cboYear.SelectedItem
                };

                DataOrder.SaveOrder(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCard.MaxLength = 16;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0 && txtCard.Text.Length == 16)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0 && txtCard.Text.Length == 16)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex >= 0 && cboYear.SelectedIndex >= 0 && txtCard.Text.Length == 16)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        public static bool bolCloseShop = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bolCloseShop = true;
                this.Close();
                frmSignIn.intID = 0;
            }
        }

        private void rdoStandard_CheckedChanged(object sender, EventArgs e)
        {
            strShippingMethod = "StandardShipping";
            getShipping(strShippingMethod);
            dblTotalCost = dblSubCost + dblTaxCost + dblShippingCost;

            lblTotal.Text = (dblTotalCost).ToString("C2");
        }

        private void rdoNextDay_CheckedChanged(object sender, EventArgs e)
        {
            strShippingMethod = "NextDayShipping";
            getShipping(strShippingMethod);
            dblTotalCost = dblSubCost + dblTaxCost + dblShippingCost;

            lblTotal.Text = (dblTotalCost).ToString("C2");
        }

        private void rdoSecondDay_CheckedChanged(object sender, EventArgs e)
        {
            strShippingMethod = "SecondDayShipping";
            getShipping(strShippingMethod);
            dblTotalCost = dblSubCost + dblTaxCost + dblShippingCost;

            lblTotal.Text = (dblTotalCost).ToString("C2");
        }
    }
}
