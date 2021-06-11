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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(success == true)
            {
                DialogResult dialogResult = MessageBox.Show("Password successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
