//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the sign in form where returning users can sign in
// new users can register, or the user can just shop as a guest
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
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        public static string CustomerType { get; set; }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CustomerType = "guest";
            frmShop shop = new frmShop();
            this.Hide();
            this.Close();
            shop.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                //THROWS ERROR FOR SOME REASON
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Accounts WHERE Username = @Username"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Connection = con;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (sdr == null)
                            {
                                MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsername.Focus();
                            }
                            else
                            {
                                if (txtPassword.Text == sdr["Password"].ToString())
                                {
                                    frmShop shop = new frmShop();
                                    this.Hide();
                                    shop.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtUsername.Focus();
                                }
                            }

                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                //TODO
            }
        }
    }
}
