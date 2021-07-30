//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the shipping form where the user will either input thier info
// or if they are signed in, have them already prepopulated
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
    public partial class frmShipping : Form
    {
        public frmShipping()
        {
            InitializeComponent();
        }       

        private void frmShipping_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            if (frmSignIn.strCustomerType == "Customer" || frmSignIn.strCustomerType == "Employee" || frmSignIn.strCustomerType == "Manager")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT NameFirst, NameLast, Address1, Address2, Address3," +
                                                               " City, State, Zipcode, PhonePrimary FROM HackK21Su2332.Person WHERE PersonID = @PersonID"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@PersonID", frmSignIn.intID);
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    txtFirst.Text = sdr["NameFirst"].ToString();
                                    txtLast.Text = sdr["NameLast"].ToString();
                                    txtAddress1.Text = sdr["Address1"].ToString();
                                    txtAddress2.Text = sdr["Address2"].ToString();
                                    txtAddress3.Text = sdr["Address3"].ToString();
                                    txtCity.Text = sdr["City"].ToString();
                                    txtState.Text = sdr["State"].ToString();
                                    txtZip.Text = sdr["Zipcode"].ToString();
                                    txtPhone.Text = sdr["PhonePrimary"].ToString();

                                    txtFirst.ReadOnly = true;
                                    txtLast.ReadOnly = true;
                                    txtAddress1.ReadOnly = true;
                                    txtAddress2.ReadOnly = true;
                                    txtAddress3.ReadOnly = true;
                                    txtCity.ReadOnly = true;
                                    txtPhone.ReadOnly = true;
                                    txtZip.ReadOnly = true;
                                    txtState.ReadOnly = true;
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem loading customer info. Please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            frmCheckout frmCheck = new frmCheckout();
            this.Hide();
            this.Close();
            frmCheck.ShowDialog();
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
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Shipping_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
