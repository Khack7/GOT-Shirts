//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where employee's can sign in and go to their respective menus
// depending on their status as an employee or manager
//*******************************************
//*******************************************
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
            frmResetPassword frmReset = new frmResetPassword();
            this.Hide();
            frmReset.ShowDialog();
            this.Show();
        }

        public static int intID { get; set; }
        public static string strUserName { get; set; }
        public static string strEmployeeType { get; set; }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                if (person != null)
                {
                    if (person.Deleted == true)
                    {
                        Cursor.Current = Cursors.Default;
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
                                Cursor.Current = Cursors.Default;
                                frmEmpMain frmEmp = new frmEmpMain();
                                this.Hide();
                                this.Close();
                                frmEmp.ShowDialog();
                            }
                            else if (strEmployeeType == "Manager")
                            {
                                Cursor.Current = Cursors.Default;
                                frmManagerMain frmManager = new frmManagerMain();
                                this.Hide();
                                this.Close();
                                frmManager.ShowDialog();
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Invalid Login", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                        }
                    }

                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Employee_SignIn_Help.html");
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSign.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
