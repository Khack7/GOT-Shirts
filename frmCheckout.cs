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
            DataMoney shipping = null;

            shipping = DataMoney.GetValues(method);

            double.TryParse(shipping.SettingValue, out double d);
            shippingCost = d;

            lblShipping.Text = string.Format(shipping.SettingValue, "C2");
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
                    double.TryParse(frmShop.Subtotal, out double s);
                    double sub = s;

                    int discount = frmCouponInput.percentOff;
                    SubCost = (sub - (sub * discount));

                    lblSubtotal.Text = (sub - (sub * discount)).ToString();
                }
                else
                {
                    lblSubtotal.Text = frmShop.Subtotal;
                }

                getShipping(shippingMethod);

                DataMoney tax = null;

                tax = DataMoney.GetValues("TaxRate");

                double.TryParse(tax.SettingValue, out double d);

                double taxes = d;

                lblTax.Text = (taxes * SubCost).ToString();


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
                    else
                    {

                    }
                }
                for (int y = 0; y < years.Length; y++)
                {
                    cboYear.Items.Add(years[y]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string shippingMethod = "StandardShipping";

        private void rdoStandard_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "StandardShipping";
            getShipping(shippingMethod);
        }

        private void rdoNextDay_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "NextDayShipping";
            getShipping(shippingMethod);
        }

        private void rdoSecondDay_CheckedChanged(object sender, EventArgs e)
        {
            shippingMethod = "SecondDayShipping";
            getShipping(shippingMethod);
        }
    }
}
