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
using SU21_Final_Project.Data;
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

        public static string strCustomerType { get; set; }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }

        public static int intID { get; set; }
        public static string strUserName { get; set; }
        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                if (person != null)
                {
                    if (person.Deleted == true)
                    {
                        MessageBox.Show("This account has been suspended. If you'd like to reactivate this account, please click on the help file and contact the supervisor via their email", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {


                        if (txtPassword.Text == person.Password)
                        {
                            strCustomerType = person.AccountType;

                            intID = person.PersonID;
                            strUserName = txtUsername.Text;

                            frmShop shop = new frmShop();
                            this.Hide();
                            shop.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Sign_In_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool bolShowPass = true;

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (bolShowPass == true)
            {
                txtPassword.PasswordChar = '\0';
                bolShowPass = false;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                bolShowPass = true;
            }
        }
    }
}
