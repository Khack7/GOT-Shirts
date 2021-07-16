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
        public static string strEmployeeType { get; set; }

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
                            strEmployeeType = person.AccountType;

                            intID = person.PersonID;
                            strUserName = txtUsername.Text;

                            if (strEmployeeType == "Employee")
                            {
                                frmEmpMain empMain = new frmEmpMain();
                                this.Hide();
                                this.Close();
                                empMain.ShowDialog();
                            }
                            else if (strEmployeeType == "Manager")
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                //WILL BE CREATING HELP FILES FOR MANAGERS AND EMPLOYEES. THIS IS A PLACEHOLDER
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Sign_In_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
