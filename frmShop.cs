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
            //MessageBox.Show($"{_appPath}\\Shirts");
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

        double currentTotal = 0.00;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string size, color, quantity;
            int numOfShirts = (int)numUDQuantity.Value;

            color = currentColor;
            quantity = numUDQuantity.Value.ToString();


            if (rdoSmall.Checked == true)
            {
                size = "Small";
            }
            else if (rdoMedium.Checked == true)
            {
                size = "Medium";
            }
            else
            {
                size = "Large";
            }

            if (numOfShirts <= 0)
            {
                MessageBox.Show("Zero is not a valid amount", "Please select a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (color == null)
            {
                MessageBox.Show("You have not selected a color", "Please select a color", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataProduct product = DataProduct.GetProduct(color, size);
                    if (product != null)
                    {
                        CartItem existingItem = GetExistingCartItem(product);
                        int quantityAvailable = product.QuantityOnHand;

                        if(existingItem != null)
                        {
                            quantityAvailable -= existingItem.Quantity;
                        }

                        if (quantityAvailable - numOfShirts < 0)
                        {
                            MessageBox.Show(
                                string.Format(
                                    "The amount selected is more than we have on hand. We only have {0} total", 
                                    product.QuantityOnHand.ToString()
                                ), 
                                "Too many selected", MessageBoxButtons.OK, MessageBoxIcon.Information
                           );
                        }
                        else if(existingItem == null)
                        {
                            lstCart.Items.Add(new CartItem { Product = product, Quantity = numOfShirts});
                            
                            currentTotal += (product.Price * numOfShirts);
                            lblAmount.Text = currentTotal.ToString("C2");
                        }
                        else
                        {
                            existingItem.Quantity += numOfShirts;
                            
                            for(int i = 0; i < lstCart.Items.Count; i++)
                            {
                                lstCart.Items[i] = lstCart.Items[i];
                            }

                            currentTotal += (product.Price * numOfShirts);
                            lblAmount.Text = currentTotal.ToString("C2");
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
                    numUDQuantity.Value = 0;
                }
            }
        }

        private CartItem GetExistingCartItem(DataProduct product)
        {
            CartItem result = null;

            for (int i = 0; i < lstCart.Items.Count; i++)
            {
                CartItem item = (CartItem)lstCart.Items[i];
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
            string shirt = color;
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            using (Image image = Image.FromFile($"{path}\\Shirts\\{shirt}.PNG"))
            {
                picbxShirt.Image = resizeImage(image, picbxShirt.Width, picbxShirt.Height);
            }
        }

        string currentColor;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
                frmSignIn.ID = 0;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItem == null || lstCart.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select the item you want removed", "Must have an item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string selection = lstCart.SelectedItem.ToString();
                string[] words = selection.Split(' ');

                string[] stuff = new string[3];
                int i = 0;

                string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

                try
                {
                    foreach (var word in words)
                    {
                        stuff[i] = $"{word}";
                        i++;
                        if (i > 2)
                        {
                            break;
                        }
                    }

                    int.TryParse(stuff[0], out int x);
                    int numOfShirts = x;
                    string size = stuff[1];
                    string color = stuff[2];


                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT QuantityOnHand, Color, Size, Cost FROM HackK21Su2332.Products WHERE Color = @Color AND Size = @Size"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@Size", size);
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    int.TryParse(sdr["QuantityOnHand"].ToString(), out int q);
                                    double.TryParse(sdr["Cost"].ToString(), out double d);

                                    currentTotal -= (d * numOfShirts);
                                    lblAmount.Text = currentTotal.ToString("C2");
                                    lstCart.Items.Remove(lstCart.SelectedItem);
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem loading data", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            con.Close();
                        }
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
                }
            }
        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            if (frmSignIn.CustomerType == "Guest")
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
            currentColor = btnOrange.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            currentColor = btnBlack.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            currentColor = btnBlue.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            currentColor = btnGreen.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            currentColor = btnPink.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            currentColor = btnPurple.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            currentColor = btnRed.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            currentColor = btnWhite.BackColor.Name;
            getShirt(currentColor);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            currentColor = btnYellow.BackColor.Name;
            getShirt(currentColor);
        }

        public static List<string> cartItems = new List<string>();
        public static string Subtotal;

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Subtotal = currentTotal.ToString();
            for (int i = 0; i < lstCart.Items.Count; i++)
            {
                cartItems.Add(lstCart.Items[i].ToString());
            }
            frmShipping ship = new frmShipping();
            this.Hide();
            ship.ShowDialog();
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            frmCouponInput coupon = new frmCouponInput();
            coupon.ShowDialog();
        }
    }

    public class CartItem
    {
        public DataProduct Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Quantity}  {Product.Size} {Product.Color}";
        }
    }

}
