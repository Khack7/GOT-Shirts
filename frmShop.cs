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
        private string _appPath;
        public frmShop()
        {
            InitializeComponent();
            _appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private Image resizeImage(Image src, int width, int height)
        {
            Image bmpNewImage = new Bitmap(width, height);
            using (Graphics gfxNewImage = Graphics.FromImage(bmpNewImage))
            {
                gfxNewImage.DrawImage(
                    src,
                    new Rectangle(0, 0, bmpNewImage.Width, bmpNewImage.Height),
                    0,
                    0,
                    src.Width,
                    src.Height,
                    GraphicsUnit.Pixel
                );
            }
            return bmpNewImage;
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

        private void getShirt(string color)
        {
            string strString = color;
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            try
            {
                using (Image image = Image.FromFile($"{path}\\Shirts\\{strString}.PNG"))
                {
                    picbxShirt.Image = resizeImage(image, picbxShirt.Width, picbxShirt.Height);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string strCurrentColor;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
                frmSignIn.intID = 0;
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
                }
            }
        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            if (frmSignIn.strCustomerType == "Guest")
            {
                btnAccount.Visible = false;
            }
            else
            {
                btnAccount.Visible = true;
            }
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnOrange.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnBlack.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnBlue.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnGreen.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnPink.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnPurple.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnRed.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnWhite.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            strCurrentColor = btnYellow.BackColor.Name;
            getShirt(strCurrentColor);
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
            getItemPrice(strCurrentColor, strSize);
        }

        public static List<CartItem> lstCartItems = new List<CartItem>();
        public static string strSubtotal;

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            strSubtotal = dblCurrentTotal.ToString();
            lstCartItems.Clear();

            for (int i = 0; i < lstCart.Items.Count; i++)
            {
                lstCartItems.Add((CartItem)lstCart.Items[i]);
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
            frmAccountInfo accountInfo = new frmAccountInfo();
            this.Hide();
            accountInfo.ShowDialog();
            this.Show();
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

        private void getItemPrice(string color, string size)
        {
            try
            {
                DataProduct productPrice = DataProduct.GetProduct(color, size);
                lblItemPrice.Text = productPrice.Price.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null)
            {
                getItemPrice(strCurrentColor, "Small");
            }
        }

        private void rdoMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null)
            {
                getItemPrice(strCurrentColor, "Medium");
            }
        }

        private void rdoLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (strCurrentColor != null)
            {
                getItemPrice(strCurrentColor, "Large");
            }
        }

        private void frmShop_FormClosing(object sender, FormClosingEventArgs e)
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
