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
        private List<DataProduct> _products;
        public frmShop()
        {
            InitializeComponent();
            try
            {
                _products = DataProduct.ListProducts();
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
            else
            {
                strSize = "Large";
            }

            if (intNumOfShirts <= 0)
            {
                MessageBox.Show("Zero is not a valid amount", "Please select a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (strColor == null)
            {
                MessageBox.Show("You have not selected a color", "Please select a color", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            for (int intI = 0; intI < lstCart.Items.Count; intI++)
                            {
                                lstCart.Items[intI] = lstCart.Items[intI];
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

            for (int intI = 0; intI < lstCart.Items.Count; intI++)
            {
                CartItem item = (CartItem)lstCart.Items[intI];
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
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bolCloseShop = true;
                this.Close();
                frmSignIn.intID = 0;
                frmCouponInput.CouponCode = string.Empty;
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
                    for (int i = 0; i < lstCart.Items.Count; i++)
                    {
                        CartItem objItem = (CartItem)lstCart.Items[i];
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
            strCurrentColor = btnOrange.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnBlack.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnBlue.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnGreen.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnPink.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnPurple.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnRed.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnWhite.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = -1;
            strCurrentColor = btnYellow.BackColor.Name;
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
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
            frmShipping ship = new frmShipping();
            this.Hide();
            ship.ShowDialog();

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
            frmCouponInput coupon = new frmCouponInput();
            coupon.ShowDialog();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (frmSignIn.strCustomerType == "Employee")
            {
                frmEmpInfo frmInfo = new frmEmpInfo();
                this.Hide();
                frmInfo.ShowDialog();
                this.Show();
            }
            else
            {
                frmAccountInfo accountInfo = new frmAccountInfo();
                this.Hide();
                accountInfo.ShowDialog();
                this.Show();
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

                if (productPrice != null)
                {
                    lblItemPrice.Text = productPrice.Price.ToString("C2");
                    btnAdd.Enabled = true;
                }
                else
                {
                    MessageBox.Show("We currently don't have this size available", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


                List<string> lstColors = _products.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();

                for (int intI = 0; intI < lstColors.Count; intI++)
                {
                    if (!lstShowColors.Contains(lstColors[intI]))
                    {
                        cboColor.Items.Add(lstColors[intI]);
                    }
                }
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
                strCurrentColor = cboColor.SelectedItem.ToString();
            }
            lblColor.Text = strCurrentColor;
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
                pbxShirt.Image = product.ProductImage;
                getItemPrice(strCurrentColor, strSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
