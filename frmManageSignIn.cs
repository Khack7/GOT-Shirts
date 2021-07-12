using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmManageSignIn : Form
    {
        public frmManageSignIn()
        {
            InitializeComponent();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            frmResetPassword reset = new frmResetPassword();
            this.Hide();
            reset.ShowDialog();
            this.Show();
        }

        public static int intID { get; set; }
        public static string strUserName { get; set; }
        public static string strCustomerType { get; set; }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                if (person != null)
                {

                    if (txtPassword.Text == person.Password)
                    {
                        strCustomerType = person.AccountType;

                        intID = person.PersonID;
                        strUserName = txtUsername.Text;

                        if(strCustomerType == "Employee")
                        {
                            frmEmpMain empMain = new frmEmpMain();
                            this.Hide();
                            this.Close();
                            empMain.ShowDialog();
                        }
                        else if(strCustomerType == "Manager")
                        {
                            frmManagerMain manager = new frmManagerMain();
                            this.Hide();
                            this.Close();
                            manager.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPassword.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
