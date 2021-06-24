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

            cboStates.Items.Add("AL");
            cboStates.Items.Add("AK");
            cboStates.Items.Add("AZ");
            cboStates.Items.Add("AR");
            cboStates.Items.Add("CA");
            cboStates.Items.Add("CO");
            cboStates.Items.Add("CT");
            cboStates.Items.Add("DE");
            cboStates.Items.Add("FL");
            cboStates.Items.Add("GA");
            cboStates.Items.Add("HI");
            cboStates.Items.Add("ID");
            cboStates.Items.Add("IL");
            cboStates.Items.Add("IN");
            cboStates.Items.Add("IA");
            cboStates.Items.Add("KS");
            cboStates.Items.Add("KY");
            cboStates.Items.Add("LA");
            cboStates.Items.Add("ME");
            cboStates.Items.Add("MD");
            cboStates.Items.Add("MA");
            cboStates.Items.Add("MI");
            cboStates.Items.Add("MN");
            cboStates.Items.Add("MS");
            cboStates.Items.Add("MO");
            cboStates.Items.Add("MT");
            cboStates.Items.Add("NE");
            cboStates.Items.Add("NV");
            cboStates.Items.Add("NH");
            cboStates.Items.Add("NJ");
            cboStates.Items.Add("NM");
            cboStates.Items.Add("NY");
            cboStates.Items.Add("NC");
            cboStates.Items.Add("ND");
            cboStates.Items.Add("OH");
            cboStates.Items.Add("OK");
            cboStates.Items.Add("OR");
            cboStates.Items.Add("PA");
            cboStates.Items.Add("RI");
            cboStates.Items.Add("SC");
            cboStates.Items.Add("SD");
            cboStates.Items.Add("TN");
            cboStates.Items.Add("TX");
            cboStates.Items.Add("UT");
            cboStates.Items.Add("VT");
            cboStates.Items.Add("VA");
            cboStates.Items.Add("WA");
            cboStates.Items.Add("WV");
            cboStates.Items.Add("WI");
            cboStates.Items.Add("WY");

            if (frmSignIn.CustomerType == "Customer" || frmSignIn.CustomerType == "Employee" || frmSignIn.CustomerType == "Manager")
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
                            cmd.Parameters.AddWithValue("@PersonID", frmSignIn.ID);
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
                                    cboStates.SelectedItem = sdr["State"].ToString();
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
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem loading customer info. Please fill out all fields manually", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtFirst.ReadOnly = false;
                                    txtLast.ReadOnly = false;
                                    txtAddress1.ReadOnly = false;
                                    txtAddress2.ReadOnly = false;
                                    txtAddress3.ReadOnly = false;
                                    txtCity.ReadOnly = false;
                                    cboStates.Enabled = true;
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
            else
            {
                txtFirst.ReadOnly = false;
                txtLast.ReadOnly = false;
                txtAddress1.ReadOnly = false;
                txtAddress2.ReadOnly = false;
                txtAddress3.ReadOnly = false;
                txtCity.ReadOnly = false;
                cboStates.Enabled = true;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            if (frmSignIn.CustomerType == "Customer" || frmSignIn.CustomerType == "Employee" || frmSignIn.CustomerType == "Manager")
            {
                frmCheckout checkout = new frmCheckout();
                this.Hide();
                checkout.ShowDialog();
            }
            else
            {
                //THIS IS THE GUEST CONFIRMATION. WILL MOST LIKELY REMOVE SINCE NO LONGER NECCESSARY,
                //UNLESS IT'S FULLY WORKING PROPERLY.
                //!!!DON'T SPEND TIME ON THIS UNLESS EVERYTHING ELSE REQUIRED IS DONE AND WORKING!!!
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT NameFirst, NameLast, Address1, Address2, Address3," +
                                                               " City, State, Zipcode, PhonePrimary FROM HackK21Su2332.Person"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    if (txtFirst.Text != sdr["NameFirst"].ToString() && txtLast.Text != sdr["NameLast"].ToString() &&
                                       txtAddress1.Text != sdr["Address1"].ToString() && txtAddress2.Text != sdr["Address2"].ToString() &&
                                       cboStates.SelectedItem.ToString() != sdr["State"].ToString() && txtAddress3.Text != sdr["Address3"].ToString() &&
                                       txtCity.Text != sdr["City"].ToString() && txtZip.Text != sdr["Zipcode"].ToString() && txtPhone.Text != sdr["PhonePrimary"].ToString())
                                    {

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
