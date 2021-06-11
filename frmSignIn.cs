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
            CustomerType = "Guest";
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

        public static int ID { get; set; }
        private void btnSign_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UserName, Password FROM HackK21Su2332.Person"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if(sdr.Read())
                            {
                                if (txtUsername.Text != sdr["UserName"].ToString())
                                {
                                    MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtUsername.Focus();
                                }
                                else
                                {
                                    if (txtPassword.Text == sdr["Password"].ToString())
                                    {
                                        CustomerType = "Customer";

                                        using(SqlCommand cmd2 = new SqlCommand("SELECT PersonID from FROM HackK21Su2332.Person WHERE UserName = @UserName"))
                                        {
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.Connection = con;
                                            using(SqlDataReader sdr2 = cmd2.ExecuteReader())
                                            {
                                                //ID = int.TryParse(sdr["PersonID"].ToString(), out int x);
                                            }
                                        }



                                        frmShop shop = new frmShop();
                                        this.Hide();
                                        shop.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        txtUsername.Focus();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsername.Focus();
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
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            frmResetPassword reset = new frmResetPassword();
            reset.ShowDialog();
        }
    }
}
