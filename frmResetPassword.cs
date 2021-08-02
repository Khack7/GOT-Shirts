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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmResetPassword : Form
    {
        public frmResetPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool bolAcceptedUsername = false;

            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);

                if (btnEnter.Text == "&Load")
                {

                    if (person != null)
                    {
                        txtSecurity1.Enabled = true;
                        txtSecurity2.Enabled = true;
                        txtSecurity3.Enabled = true;
                        txtAnswer1.Enabled = true;
                        txtAnswer2.Enabled = true;
                        txtAnswer3.Enabled = true;
                        lblAnswer1.Enabled = true;
                        lblAnswer2.Enabled = true;
                        lblAnswer3.Enabled = true;
                        lblSecurity1.Enabled = true;
                        lblSecurity2.Enabled = true;
                        lblSecurity3.Enabled = true;


                        txtSecurity1.Text = person.SecurityQuestion1;
                        txtSecurity2.Text = person.SecurityQuestion2;
                        txtSecurity3.Text = person.SecurityQuestion3;

                        btnEnter.Text = "&Enter";
                        txtAnswer1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("This account doesn't exist", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (btnEnter.Text == "&Enter")
                {
                    if (string.Equals(txtAnswer1.Text, person.SecurityAnswer1, StringComparison.CurrentCultureIgnoreCase) && string.Equals(txtAnswer2.Text, person.SecurityAnswer2, StringComparison.CurrentCultureIgnoreCase) &&
                        string.Equals(txtAnswer3.Text, person.SecurityAnswer3, StringComparison.CurrentCultureIgnoreCase))
                    {
                        btnEnter.Text = "&Confirm";
                        lblPass.Enabled = true;
                        lblConfirm.Enabled = true;
                        txtPassword.Enabled = true;
                        txtConfirmPass.Enabled = true;
                        txtAnswer1.ReadOnly = true;
                        txtAnswer2.ReadOnly = true;
                        txtAnswer3.ReadOnly = true;
                        txtPassword.Focus();
                    }
                    else
                    {
                        MessageBox.Show("1 or more incorrect answers", "Wrong answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string strAttemptedPassword = txtPassword.Text;

                    int intPasswordRequirements = 0;
                    var regex = new Regex(@"[^a-zA-Z0-9\s]");

                    if (strAttemptedPassword.Any(char.IsLower))
                    {
                        intPasswordRequirements++;
                    }
                    if (strAttemptedPassword.Any(char.IsUpper))
                    {
                        intPasswordRequirements++;
                    }
                    if (strAttemptedPassword.Any(char.IsDigit))
                    {
                        intPasswordRequirements++;
                    }
                    if (regex.IsMatch(strAttemptedPassword))
                    {
                        intPasswordRequirements++;
                    }
                    if (strAttemptedPassword.Length < 8 || strAttemptedPassword.Length > 10)
                    {
                        intPasswordRequirements = 0;
                    }

                    if (intPasswordRequirements < 3)
                    {
                        MessageBox.Show("Password must be at least 8 charactors long and contain at least 3 of the following: lower case letter, upper case letter, number, or special charactor(ex: !, @, #, $)", "Missing password requirement", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else
                    {
                        if (txtConfirmPass.Text == txtPassword.Text)
                        {
                            person.Password = txtConfirmPass.Text;
                            DataPerson.SavePerson(person);

                            MessageBox.Show("Password successfully changed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bolAcceptedUsername = true;

                        }
                        else
                        {
                            MessageBox.Show("Make sure you are spelling both the password and confirmation the exact same", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bolAcceptedUsername == true)
                {
                    this.Close();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Password_Reset_Help.html");
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
                txtConfirmPass.PasswordChar = '\0';
                bolShowPass = false;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPass.PasswordChar = '•';
                bolShowPass = true;
            }
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
