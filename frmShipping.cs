﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the shipping form where the user will either input thier info
// or if they are signed in, have them already prepopulated
//*******************************************
//*******************************************
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

            if (frmSignIn.CustomerType == "Customer")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT NameFirst, NameLast, Address1, City, State, Zipcode FROM HackK21Su2332.Person WHERE PersonID = @PersonID"))
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
                                    txtAddress.Text = sdr["Address1"].ToString();
                                    txtCity.Text = sdr["City"].ToString();
                                    txtState.Text = sdr["State"].ToString();

                                    txtFirst.ReadOnly = true;
                                    txtLast.ReadOnly = true;
                                    txtAddress.ReadOnly = true;
                                    txtCity.ReadOnly = true;
                                    txtState.ReadOnly = true;
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem loading customer info. Please fill out all fields manually", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                txtFirst.ReadOnly = false;
                txtLast.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtCity.ReadOnly = false;
                txtState.ReadOnly = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            if(frmSignIn.CustomerType == "Customer")
            {
                //TODO: ADD TO PERSON TABLE AND IF A RETURNING GUEST DON'T ADD AND CONTINUE ON
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT NameFirst, NameLast, Address1, City, State, Zipcode FROM HackK21Su2332.Person"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    if (txtFirst.Text == sdr["NameFirst"].ToString() && txtLast.Text == sdr["NameLast"].ToString() &&
                                       txtAddress.Text == sdr["Address1"].ToString() && txtState.Text == sdr["State"].ToString() &&
                                       txtCity.Text == sdr["City"].ToString() && txtZip.Text == sdr["Zipcode"].ToString())
                                    {

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem loading customer info. Please fill out all fields manually", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
