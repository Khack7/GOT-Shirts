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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            bool success = false;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UserName FROM HackK21Su2332.Person"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                if (txtUsername.Text != sdr["UserName"].ToString())
                                {
                                    MessageBox.Show("This account doesn't exist", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtUsername.Focus();
                                }
                                else
                                {
                                    if (txtConfirmPass.Text == txtPassword.Text)
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand("UPDATE HackK21Su2332.Person SET Password = @Password WHERE " +
                                                                               "UserName = @UserName"))
                                        {
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.Parameters.AddWithValue("@Password", txtPassword.Text);
                                            cmd2.Parameters.AddWithValue("@UserName", txtUsername.Text);
                                            cmd2.Connection = con;

                                            success = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please make sure that both the password and password confirmation are the same", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (success == true)
            {
                DialogResult dialogResult = MessageBox.Show("Password successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool acceptedUsername = false;

            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                if (btnEnter.Text == "Load")
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3 FROM HackK21Su2332.Person WHERE UserName = @UserName"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    txtSecurity1.Text = sdr["SecurityQuestion1"].ToString();
                                    txtSecurity2.Text = sdr["SecurityQuestion2"].ToString();
                                    txtSecurity3.Text = sdr["SecurityQuestion3"].ToString();
                                    btnEnter.Text = "Enter";
                                }
                                else
                                {
                                    MessageBox.Show("This account doesn't exist", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                sdr.Close();
                                con.Close();
                            }
                        }
                    }
                }
                else if (btnEnter.Text == "Enter")
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT SecurityAnswer1, SecurityAnswer2, SecurityAnswer3 FROM HackK21Su2332.Person WHERE UserName = @UserName AND SecurityQuestion1 = @SecurityQuestion1," +
                                                               " AND SecurityQuestion2 = @SecurityQuestion2 AND SecurityQuestion3 = @SecurityQuestion3"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@SecurityQuestion1", txtSecurity1.Text);
                            cmd.Parameters.AddWithValue("@SecurityQuestion2", txtSecurity2.Text);
                            cmd.Parameters.AddWithValue("@SecurityQuestion3", txtSecurity3.Text);

                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {

                                    if (txtAnswer1.Text != sdr["SecurityAnswer1"].ToString())
                                    {
                                        MessageBox.Show("Your answer for quetion 1 in wrong", "Incorrect answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (txtAnswer2.Text != sdr["SecurityAnswer2"].ToString())
                                    {
                                        MessageBox.Show("Your answer for quetion 2 in wrong", "Incorrect answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (txtAnswer3.Text != sdr["SecurityAnswer3"].ToString())
                                    {
                                        MessageBox.Show("Your answer for quetion 3 in wrong", "Incorrect answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("You now have permission to change your password", "Access granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        btnEnter.Text = "Change Password";
                                        txtUsername.ReadOnly = true;
                                        txtAnswer1.ReadOnly = true;
                                        txtAnswer2.ReadOnly = true;
                                        txtAnswer3.ReadOnly = true;
                                        txtPassword.Enabled = true;
                                        txtConfirmPass.Enabled = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("This account doesn't exist", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                sdr.Close();
                                con.Close();
                            }
                        }
                    }
                }
                else
                {
                    if(txtConfirmPass.Text == txtPassword.Text)
                    {
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("UPDATE HackK21Su2332.Person SET Password = @Password WHERE UserName = @UserName"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Password", txtConfirmPass);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                con.Close();
                                acceptedUsername = true;
                            }
                        }
                        MessageBox.Show("Password successfully changed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Make sure you are spelling both the password and confirmation the exact same", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
