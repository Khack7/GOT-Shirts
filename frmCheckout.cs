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
using SU21_Final_Project.Classes;
using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        private void getShipping(string strMethod)
        {
            try
            {
                DataMoney shipping = null;

                shipping = DataMoney.GetValues(strMethod);

                if (double.TryParse(shipping.SettingValue, out double dblShipping))
                {
                    dblShippingCost = dblShipping;
                }
                else
                {
                    dblShippingCost = 0;
                }

                lblShipping.Text = dblShippingCost.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        double dblShippingCost, dblTaxCost, dblSubCost, dblTotalCost;

        private void frmCheckout_Load(object sender, System.EventArgs e)
        {
            try
            {
                CartItem objCurrentItem;
                for (int intIndex = 0; intIndex < frmShop.lstCartItems.Count; intIndex++)
                {
                    objCurrentItem = frmShop.lstCartItems[intIndex];
                    lstCart.Items.Add(objCurrentItem);
                }

                if (frmCouponInput.CodeUsed == true)
                {
                    if (!double.TryParse(frmShop.strSubtotal, out double dblSub))
                    {
                        dblSub = 0;
                    }

                    double dblDiscount = frmCouponInput.percentOff;
                    dblSubCost = (dblSub - (dblSub * (dblDiscount / 100)));

                    lblSubtotal.Text = dblSubCost.ToString("C2");
                }
                else
                {
                    if (!double.TryParse(frmShop.strSubtotal, out double dblSub))
                    {
                        dblSub = 0;
                    }
                    dblSubCost = dblSub;
                    lblSubtotal.Text = dblSubCost.ToString("C2");
                }

                getShipping(strShippingMethod);

                DataMoney tax = null;

                tax = DataMoney.GetValues("TaxRate");

                if (!double.TryParse(tax.SettingValue, out double dblTax))
                {
                    dblTax = 0;
                }

                dblTaxCost = dblTax * dblSubCost;

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

                for (int intIndex = 0; intIndex < 12; intIndex++)
                {
                    if (int.TryParse(DateTime.Now.Year.ToString(), out int intYear))
                    {
                        arrYears[intIndex] = (intYear + intIndex).ToString();
                    }
                    else
                    {
                        throw new Exception("Error Loading years");
                    }
                }
                for (int intNumOfYears = 0; intNumOfYears < arrYears.Length; intNumOfYears++)
                {
                    cboYear.Items.Add(arrYears[intNumOfYears]);
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
            //REFERENCE: https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime
            var parsedDate = DateTime.Now;
            try
            {
                if (!int.TryParse(cboMonth.SelectedItem.ToString(), out int intMonth))
                {
                    intMonth = 0;
                }
                string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(intMonth);
                string strYear = cboYear.SelectedItem.ToString();
                string strSelectedDate = strMonthName + " 1, " + strYear;

                parsedDate = DateTime.Parse(strSelectedDate);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (parsedDate < DateTime.Today.Date)
                {
                    MessageBox.Show("This card is expired", "Date is expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        DataOrder order = null;

                        if (!DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd"), out DateTime todaysDate))
                        {
                            throw new Exception("Error Getting Today's Date");
                        }

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
                            CardNumber = txtCard.Text,
                            CardExperation = cboMonth.SelectedItem + "/" + cboYear.SelectedItem
                        };

                        using (var con = DataCommon.StartConnection())
                        {
                            var objTrans = con.BeginTransaction();
                            try
                            {
                                DataOrder.SaveOrder(con, order, objTrans);

                                List<DataOrderItem> orderItems = new List<DataOrderItem>();

                                for (int intIndex = 0; intIndex < lstCart.Items.Count; intIndex++)
                                {
                                    CartItem objItem = (CartItem)lstCart.Items[intIndex];

                                    orderItems.Add(new DataOrderItem
                                    {
                                        intOrderNum = order.OrderNum,
                                        intProductID = objItem.Product.ProductID,
                                        intQuantity = objItem.intQuantity,
                                        Product = objItem.Product
                                    });

                                    DataProduct.ReduceProductQuantity(con, objItem.Product.ProductID, objItem.intQuantity, objTrans);
                                }

                                DataOrderItem.SaveItems(con, orderItems, objTrans);

                                objTrans.Commit();

                                PrintReceipt(order, orderItems);
                            }
                            catch (Exception ex)
                            {
                                objTrans.Rollback();
                                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            }
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
        }

        private void PrintReceipt(DataOrder order, List<DataOrderItem> lstItems)
        {
            try
            {
                string strReceipt = Receipt.LoadTemplate();
                strReceipt = strReceipt.Replace("{OrderNum}", order.OrderNum.ToString());
                strReceipt = strReceipt.Replace("{OrderDate}", order.OrderDate.ToString("MM-dd-yyyy"));
                strReceipt = strReceipt.Replace("{Payment}", $"{order.CardType} xxxx{order.CardNumber.Substring(order.CardNumber.Length - 4)}");
                var person = DataPerson.GetPerson(order.PersonID);
                strReceipt = strReceipt.Replace("{AddressName}", $"{person.NameFirst} {person.NameLast}");
                List<string> streetLines = new List<string>();
                streetLines.Add(person.Address1);
                if (!string.IsNullOrEmpty(person.Address2))
                {
                    streetLines.Add(person.Address2);
                }
                if (!string.IsNullOrEmpty(person.Address3))
                {
                    streetLines.Add(person.Address3);
                }
                strReceipt = strReceipt.Replace("{AddressStreet}", string.Join("<br/>", streetLines));
                strReceipt = strReceipt.Replace("{AddressCity}", person.City);
                strReceipt = strReceipt.Replace("{AddressState}", person.State);
                strReceipt = strReceipt.Replace("{AddressZip}", person.Zipcode);

                StringBuilder itemHTML = new StringBuilder();

                for (int intIndex = 0; intIndex < lstItems.Count; intIndex++)
                {

                    itemHTML.AppendFormat("<tr>");
                    itemHTML.AppendFormat("    <td>{0} {1}</td>", lstItems[intIndex].Product.Color, lstItems[intIndex].Product.Size);
                    itemHTML.AppendFormat("    <td>{0}</td>", lstItems[intIndex].intQuantity);
                    itemHTML.AppendFormat("    <td>{0:C2}</td>", lstItems[intIndex].Product.Price);
                    itemHTML.AppendFormat("    <td>{0:C2}</td>", lstItems[intIndex].Product.Price * lstItems[intIndex].intQuantity);
                    itemHTML.AppendFormat("</tr>");
                }
                strReceipt = strReceipt.Replace("{Items}", itemHTML.ToString());
                strReceipt = strReceipt.Replace("{SubTotal}", dblSubCost.ToString("C2"));
                strReceipt = strReceipt.Replace("{TaxTotal}", dblTaxCost.ToString("C2"));
                strReceipt = strReceipt.Replace("{ShippingTotal}", dblShippingCost.ToString("C2"));
                strReceipt = strReceipt.Replace("{OrderTotal}", dblTotalCost.ToString("C2"));

                //GET USERS SELECTED PATH
                string strPath = "";
                bool bolPathSelected = false;

                DialogResult wantReceipt = MessageBox.Show("Would you like a receipt?", "Almost Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (wantReceipt == DialogResult.Yes)
                {
                    while (bolPathSelected == false)
                    {
                        SaveFileDialog fd = new SaveFileDialog();
                        fd.Title = "Select save location";
                        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        fd.FileName = $"GOT Shirts-Receipt-{order.OrderNum}.html";

                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            strPath = fd.FileName;
                            bolPathSelected = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Please select a folder to save your receipt", "Please choose a folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bolPathSelected = false;
                        }

                    }

                    using (FileStream fs = new FileStream(strPath, FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.Write(strReceipt);
                        }
                    }
                    System.Diagnostics.Process.Start(strPath);
                    this.Close();
                    bolCloseShop = true;
                }
                else
                {
                    this.Close();
                    bolCloseShop = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Checkout_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCheckout_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bolCloseShop = true;
                frmSignIn.intID = 0;
            }
            else
            {
                e.Cancel = true;
            }
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
