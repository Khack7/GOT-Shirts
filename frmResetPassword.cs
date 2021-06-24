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
            bool acceptedUsername = false;

            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);

                if (btnEnter.Text == "Load")
                {
                    
                    if(person != null)
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

                        btnEnter.Text = "Enter";
                        txtAnswer1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("This account doesn't exist", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (btnEnter.Text == "Enter")
                {
                    if(txtAnswer1.Text == person.SecurityAnswer1 && txtAnswer2.Text == person.SecurityAnswer2 &&
                        txtAnswer3.Text == person.SecurityAnswer3)
                    {
                        btnEnter.Text = "Confirm Change";
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
                    string attemptedPassword = txtPassword.Text;

                    if (!attemptedPassword.Any(char.IsLower))
                    {
                        MessageBox.Show("Password must contain a lower case letter", "Missing password requirement", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else if (!attemptedPassword.Any(char.IsUpper))
                    {
                        MessageBox.Show("Password must contain an upper case letter", "Missing password requirement", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else if (!attemptedPassword.Any(char.IsDigit))
                    {
                        MessageBox.Show("Password must contain a number", "Missing password requirement", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else if (attemptedPassword.Length < 8 || attemptedPassword.Length > 10)
                    {
                        MessageBox.Show("Password must be between 8 and 10 charactors", "Invalid length", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else
                    {
                        if (txtConfirmPass.Text == txtPassword.Text)
                        {
                            person.Password = txtConfirmPass.Text;
                            DataPerson.SavePerson(person);

                            MessageBox.Show("Password successfully changed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            acceptedUsername = true;

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
                if(acceptedUsername == true)
                {
                    this.Close();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
