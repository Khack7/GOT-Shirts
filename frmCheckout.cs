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
                shippingCost = d;

                lblShipping.Text = shippingCost.ToString("C2");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        double shippingCost, TaxCost, SubCost, TotalCost;

        private void frmCheckout_Load(object sender, System.EventArgs e)
        {
            try
            {
                string currentItem;
                for (int i = 0; i < frmShop.cartItems.Count; i++)
                {
                    currentItem = frmShop.cartItems.ElementAt(i);
                    lstCart.Items.Add(currentItem);
                }

                if (frmCouponInput.CodeUsed == true)
                {
                    double.TryParse(frmShop.Subtotal, out double sub);

                    int discount = frmCouponInput.percentOff;
                    SubCost = (sub - (sub * discount));



                    lblSubtotal.Text = SubCost.ToString("C2");
                }
                else
                {
                    double.TryParse(frmShop.Subtotal, out double s);
                    SubCost = s;
                    lblSubtotal.Text = SubCost.ToString("C2");
                }

                getShipping(shippingMethod);

                DataMoney tax = null;

                tax = DataMoney.GetValues("TaxRate");

                double.TryParse(tax.SettingValue, out double d);

                double taxes = d;

                TaxCost = taxes * SubCost;

                lblTax.Text = (TaxCost).ToString("C2");

                TotalCost = SubCost + TaxCost + shippingCost;

                lblTotal.Text = (TotalCost).ToString("C2");


                string[] years = new string[12];

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
                        years[i] = (y + i).ToString();
                    }
                }
                for (int y = 0; y < years.Length; y++)
                {
                    cboYear.Items.Add(years[y]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string shippingMethod = "StandardShipping";

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                DataOrder order = null;

                DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd"), out DateTime todaysDate);

                string code;

                if (frmCouponInput.CouponCode == null)
                {
                    code = null;
                }
                else
                {
                    code = frmCouponInput.CouponCode;
                }

                string cardType;

                if (rdoDiscover.Checked == true)
                {
                    cardType = "Discover";
                }
                else if (rdoVisa.Checked == true)
                {
                    cardType = "Visa";
                }
                else
                {
                    cardType = "MasterCard";
                }

                order = new DataOrder
                {
                    PersonID = frmSignIn.ID,
                    OrderDate = todaysDate,
                    DiscountCode = code,
                    Shipping = shippingCost,
                    CardType = cardType,
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

        private void rdoStandard_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "StandardShipping";
            getShipping(shippingMethod);
            TotalCost = SubCost + TaxCost + shippingCost;

            lblTotal.Text = (TotalCost).ToString("C2");
        }

        private void rdoNextDay_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "NextDayShipping";
            getShipping(shippingMethod);
            TotalCost = SubCost + TaxCost + shippingCost;

            lblTotal.Text = (TotalCost).ToString("C2");
        }

        private void rdoSecondDay_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "SecondDayShipping";
            getShipping(shippingMethod);
            TotalCost = SubCost + TaxCost + shippingCost;

            lblTotal.Text = (TotalCost).ToString("C2");
        }
    }
}
