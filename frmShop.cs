//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the user will be able to add items they want to buy to a
// cart, remove items from cart they no longer want, and/or use codes to get discounts
//*******************************************
//*******************************************
using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmShop : Form
    {
        private List<DataProduct> _lstProducts;
        public frmShop()
        {
            InitializeComponent();
            try
            {
                _lstProducts = DataProduct.ListProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        double dblCurrentTotal = 0.00;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strSize, strColor, strQuantity;
            int intNumOfShirts = (int)numUDQuantity.Value;

            strColor = strCurrentColor;
            strQuantity = numUDQuantity.Value.ToString();


            if (rdoSmall.Checked == true)
            {
                strSize = "Small";
            }
            else if (rdoMedium.Checked == true)
            {
                strSize = "Medium";
            }
            else if (rdoLarge.Checked == true)
            {
                strSize = "Large";
            }
            else
            {
                strSize = string.Empty;
            }

            if (intNumOfShirts <= 0)
            {
                MessageBox.Show("Zero is not a valid amount", "Please select a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (strColor == null)
            {
                MessageBox.Show("You have not selected a color", "Please select a color", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (strSize == string.Empty)
            {
                MessageBox.Show("You have not selected a size", "Please select a size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataProduct product = DataProduct.GetProduct(strColor, strSize);
                    if (product != null)
                    {
                        CartItem existingItem = GetExistingCartItem(product);
                        int intQuantityAvailable = product.QuantityOnHand;

                        if (existingItem != null)
                        {
                            intQuantityAvailable -= existingItem.intQuantity;
                        }

                        if (intQuantityAvailable - intNumOfShirts < 0)
                        {
                            MessageBox.Show(
                                string.Format(
                                    "The amount selected is more than we have on hand. We only have {0} total",
                                    product.QuantityOnHand.ToString()
                                ),
                                "Too many selected", MessageBoxButtons.OK, MessageBoxIcon.Information
                           );
                        }
                        else if (existingItem == null)
                        {
                            lstCart.Items.Add(new CartItem { Product = product, intQuantity = intNumOfShirts });

                            dblCurrentTotal += (product.Price * intNumOfShirts);
                            lblAmount.Text = dblCurrentTotal.ToString("C2");
                        }
                        else
                        {
                            existingItem.intQuantity += intNumOfShirts;

                            for (int intIndex = 0; intIndex < lstCart.Items.Count; intIndex++)
                            {
                                lstCart.Items[intIndex] = lstCart.Items[intIndex];
                            }

                            dblCurrentTotal += (product.Price * intNumOfShirts);
                            lblAmount.Text = dblCurrentTotal.ToString("C2");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was a problem loading data", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (lstCart.Items.Count <= 0)
                    {
                        btnCheckout.Enabled = false;
                    }
                    else
                    {
                        btnCheckout.Enabled = true;
                    }
                    numUDQuantity.Value = 1;
                }
            }
        }

        private CartItem GetExistingCartItem(DataProduct product)
        {
            CartItem result = null;

            for (int intIndex = 0; intIndex < lstCart.Items.Count; intIndex++)
            {
                CartItem item = (CartItem)lstCart.Items[intIndex];
                if (item.Product.ProductID == product.ProductID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        string strCurrentColor;
        bool bolCloseShop = false;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to log out? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bolCloseShop = true;
                this.Close();
                frmSignIn.intID = 0;
                frmCouponInput.strCouponCode = string.Empty;
                frmCouponInput.bolCodeUsed = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItem == null)
            {
                MessageBox.Show("Please select the item you want removed", "Must have an item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    lstCart.Items.RemoveAt(lstCart.SelectedIndex);

                    dblCurrentTotal = 0;
                    for (int intIndex = 0; intIndex < lstCart.Items.Count; intIndex++)
                    {
                        CartItem objItem = (CartItem)lstCart.Items[intIndex];
                        dblCurrentTotal += objItem.Product.Price * objItem.intQuantity;
                    }

                    lblAmount.Text = dblCurrentTotal.ToString("C2");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (lstCart.Items.Count <= 0)
                    {
                        btnCheckout.Enabled = false;
                    }
                    else
                    {
                        btnCheckout.Enabled = true;
                    }
                }
            }
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnOrange.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnBlack.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnBlue.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnGreen.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnPink.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnPurple.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnRed.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnWhite.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }

                if (strSize != null)
                {
                    getItemPrice(strCurrentColor, strSize);
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            try
            {
                cboColor.SelectedIndex = -1;
                strCurrentColor = btnYellow.BackColor.Name;
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    strSize = "Large";
                }
                else
                {
                    strSize = null;
                }



                if (strSize != null)
                {
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);
                    pbxShirt.Image = product.ProductImage;
                    getItemPrice(strCurrentColor, strSize);
                }
                else
                {
                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        DataProduct product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                        if (product != null)
                        {
                            pbxShirt.Image = product.ProductImage;
                            lblItemPrice.Text = "$0.00";
                            MessageBox.Show("This item is currently not available in any size", "Out of stock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<CartItem> lstCartItems = new List<CartItem>();
        public static string strSubtotal;

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            strSubtotal = dblCurrentTotal.ToString();
            lstCartItems.Clear();

            for (int intIndex = 0; intIndex < lstCart.Items.Count; intIndex++)
            {
                lstCartItems.Add((CartItem)lstCart.Items[intIndex]);
            }
            frmShipping frmShip = new frmShipping();
            this.Hide();
            frmShip.ShowDialog();

            if (frmCheckout.bolCloseShop == false)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            frmCouponInput frmCoupon = new frmCouponInput();
            frmCoupon.ShowDialog();
            if (frmCouponInput.bolCodeUsed == true)
            {
                lblCode.Text = frmCouponInput.strCouponCode;
                lblCode.Visible = true;
                lblCodePointer.Visible = true;
            }
        }

        public static bool bolEmpFromShop = false;

        private void btnAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSignIn.strCustomerType == "Employee")
                {
                    bolEmpFromShop = true;
                    frmEmpInfo frmInfo = new frmEmpInfo();
                    this.Hide();
                    frmInfo.ShowDialog();
                    this.Show();
                }
                else
                {
                    frmAccountInfo frmAccount = new frmAccountInfo();
                    this.Hide();
                    frmAccount.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Shop_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getItemPrice(string strColor, string strSize)
        {
            try
            {
                DataProduct productPrice = DataProduct.GetProduct(strColor, strSize);

                if (productPrice != null && productPrice.Deleted != true)
                {
                    lblItemPrice.Text = productPrice.Price.ToString("C2");
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                    lblItemPrice.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null && rdoSmall.Checked == true)
            {
                getItemPrice(strCurrentColor, "Small");
            }
        }

        private void rdoMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null && rdoMedium.Checked == true)
            {
                getItemPrice(strCurrentColor, "Medium");
            }
        }

        private void rdoLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null && rdoLarge.Checked == true)
            {
                getItemPrice(strCurrentColor, "Large");
            }
        }

        private void frmShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmCheckout.bolCloseShop == true || bolCloseShop == true)
            {
                //this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    frmSignIn.intID = 0;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        public void CheckAvailability(string color)
        {
            List<string> lstSizes = new List<string>();
            List<RadioButton> lstRadioButtons = new List<RadioButton>();

            try
            {
                lstSizes.Add("Small");
                lstSizes.Add("Medium");
                lstSizes.Add("Large");

                lstRadioButtons.Add(rdoSmall);
                lstRadioButtons.Add(rdoMedium);
                lstRadioButtons.Add(rdoLarge);


                for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                {
                    DataProduct product = DataProduct.GetProduct(color, lstSizes[intIndex]);

                    if (product == null || product.Deleted == true || product.QuantityOnHand <= 0)
                    {
                        foreach (RadioButton r in lstRadioButtons)
                        {
                            if (r.Text == "&" + lstSizes[intIndex])
                            {
                                r.Enabled = false;
                                if (r.Checked == true)
                                {
                                    r.Checked = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        bool bolSelectedSize = false;
                        foreach (RadioButton r in lstRadioButtons)
                        {
                            if (r.Text == "&" + lstSizes[intIndex])
                            {
                                r.Enabled = true;
                            }
                        }
                        if (rdoSmall.Enabled == true && bolSelectedSize == false)
                        {
                            rdoSmall.Checked = true;
                            bolSelectedSize = true;
                        }
                        else if (rdoMedium.Enabled == true && bolSelectedSize == false)
                        {
                            rdoMedium.Checked = true;
                            bolSelectedSize = true;
                        }
                        else if (rdoLarge.Enabled == true && bolSelectedSize == false)
                        {
                            rdoLarge.Checked = true;
                            bolSelectedSize = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstShowColors = new List<string>();
                lstShowColors.Add(btnBlack.BackColor.Name);
                lstShowColors.Add(btnBlue.BackColor.Name);
                lstShowColors.Add(btnGreen.BackColor.Name);
                lstShowColors.Add(btnOrange.BackColor.Name);
                lstShowColors.Add(btnPink.BackColor.Name);
                lstShowColors.Add(btnPurple.BackColor.Name);
                lstShowColors.Add(btnRed.BackColor.Name);
                lstShowColors.Add(btnWhite.BackColor.Name);
                lstShowColors.Add(btnYellow.BackColor.Name);

                List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();

                for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                {
                    if (!lstShowColors.Contains(lstColors[intIndex]))
                    {
                        cboColor.Items.Add(lstColors[intIndex]);
                    }
                }

                List<string> lstSizes = new List<string>();
                lstSizes.Add("Small");
                lstSizes.Add("Medium");
                lstSizes.Add("Large");
                DataProduct product = new DataProduct();
                int intRemoveProduct = 0;

                for (int intIndex = 0; intIndex < cboColor.Items.Count; intIndex++)
                {
                    for(int intSizeIndex = 0; intSizeIndex < lstSizes.Count; intSizeIndex++)
                    {
                        product = DataProduct.GetProduct(cboColor.Items[intIndex].ToString(), lstSizes[intSizeIndex]);
                        if(product == null || product.Deleted == true)
                        {
                            intRemoveProduct++;
                        }
                        if(intRemoveProduct >= 3)
                        {
                            cboColor.Items.RemoveAt(intIndex);
                            intIndex = 0;
                            intRemoveProduct = 0;
                        }
                    }
                    intRemoveProduct = 0;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboColor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedIndex != -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                strCurrentColor = cboColor.SelectedItem.ToString();
                lblColor.Text = strCurrentColor;
                CheckAvailability(strCurrentColor);
                string strSize;
                if (rdoSmall.Checked == true)
                {
                    strSize = "Small";
                }
                else if (rdoMedium.Checked == true)
                {
                    strSize = "Medium";
                }
                else
                {
                    strSize = "Large";
                }

                try
                {
                    DataProduct product = DataProduct.GetProduct(strCurrentColor, strSize);

                    if (product != null)
                    {
                        pbxShirt.Image = product.ProductImage;
                        getItemPrice(strCurrentColor, strSize);
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        List<string> lstSizes = new List<string>();
                        lstSizes.Add("Small");
                        lstSizes.Add("Medium");
                        lstSizes.Add("Large");

                        for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                        {
                            product = DataProduct.GetProduct(strCurrentColor, lstSizes[intIndex]);
                            if (product != null)
                            {
                                pbxShirt.Image = product.ProductImage;
                                break;
                            }
                        }

                        MessageBox.Show("This product doesn't seem to be available. Please select a different size and/or color", "Unavailable!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cboColor.SelectedIndex != -1)
                        {
                            cboColor.SelectedIndex = -1;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to clear your cart?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                lstCart.Items.Clear();
            }
            if (lstCart.Items.Count <= 0)
            {
                btnCheckout.Enabled = false;
            }
            else
            {
                btnCheckout.Enabled = true;
            }
            dblCurrentTotal = 0;
            lblAmount.Text = dblCurrentTotal.ToString("C2");
        }
    }

    public class CartItem
    {
        public DataProduct Product { get; set; }
        public int intQuantity { get; set; }

        public override string ToString()
        {
            return $"{intQuantity}  {Product.Size} {Product.Color}";
        }
    }

}
