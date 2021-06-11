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
    public partial class frmShop : Form
    {
        public frmShop()
        {
            InitializeComponent();
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: CHECK DB TO SEE IF AMOUNT SELECTED WILL MAKE NEGATIVE NUMBER
            // AND GET PRICE TO DISPLAY
            string size, color, quantity;
            int numOfShirts = (int)numUDQuantity.Value;

            color = currentColor;
            quantity = numUDQuantity.Value.ToString();

            if (numOfShirts <= 0)
            {
                MessageBox.Show("Zero is not a valid amount", "Please select a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (rdoSmall.Checked == true)
                {
                    size = "small";
                }
                else if (rdoMedium.Checked == true)
                {
                    size = "medium";
                }
                else
                {
                    size = "large";
                }

                lstCart.Items.Add(quantity + " " + size + " " + color);
            }
        }

        private void getShirt(string color)
        {
            string shirt = color;
            //string path = @"D:\tstc\Take 2\Project\Shirts\" + shirt + ".PNG";

            using (Image image = Image.FromFile(@"D:\tstc\Take 2\Project\Shirts\" + shirt + ".PNG"))
            {
                picbxShirt.Image = resizeImage(image, picbxShirt.Width, picbxShirt.Height);
            }


            //string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(constr))
            //    {
            //        using (SqlCommand cmd = new SqlCommand("SELECT Image FROM HackK21Su2332.Products WHERE Image = @Image"))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("@Image", currentColor);
            //            cmd.Connection = con;
            //            con.Open();
            //            using (SqlDataReader sdr = cmd.ExecuteReader())
            //            {
            //                if (sdr.Read())
            //                {
            //                    picbxShirt.Image = (Image)sdr["Image"];
            //                }
            //            }
            //            con.Close();
            //        }
            //    }
            //}
            //catch
            //{

            //}

        }

        string currentColor;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit? Your order will be canceled and you will be signed out", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
                //SIGN OUT TODO
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstCart.Items.Remove(lstCart.SelectedItem);
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
    }
}
