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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string size, color, quantity;

            color = currentColor;
            quantity = numUDQuantity.Value.ToString();

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

        private void getShirt()
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Image FROM HackK21Su2332.Products WHERE Image = @Image"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Image", currentColor);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                picbxShirt.Image = (Image)sdr["Image"];
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch
            {

            }

        }

        string currentColor;
        private void btnOrange_Click(object sender, EventArgs e)
        {
            currentColor = btnOrange.BackColor.Name;
        }

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
    }
}
