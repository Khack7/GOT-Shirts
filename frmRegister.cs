//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where new customers will create an account for quicker purchases
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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            cmboStates.Items.Add("AL");
            cmboStates.Items.Add("AK");
            cmboStates.Items.Add("AZ");
            cmboStates.Items.Add("AR");
            cmboStates.Items.Add("CA");
            cmboStates.Items.Add("CO");
            cmboStates.Items.Add("CT");
            cmboStates.Items.Add("DE");
            cmboStates.Items.Add("FL");
            cmboStates.Items.Add("GA");
            cmboStates.Items.Add("HI");
            cmboStates.Items.Add("ID");
            cmboStates.Items.Add("IL");
            cmboStates.Items.Add("IN");
            cmboStates.Items.Add("IA");
            cmboStates.Items.Add("KS");
            cmboStates.Items.Add("KY");
            cmboStates.Items.Add("LA");
            cmboStates.Items.Add("ME");
            cmboStates.Items.Add("MD");
            cmboStates.Items.Add("MA");
            cmboStates.Items.Add("MI");
            cmboStates.Items.Add("MN");
            cmboStates.Items.Add("MS");
            cmboStates.Items.Add("MO");
            cmboStates.Items.Add("MT");
            cmboStates.Items.Add("NE");
            cmboStates.Items.Add("NV");
            cmboStates.Items.Add("NH");
            cmboStates.Items.Add("NJ");
            cmboStates.Items.Add("NM");
            cmboStates.Items.Add("NY");
            cmboStates.Items.Add("NC");
            cmboStates.Items.Add("ND");
            cmboStates.Items.Add("OH");
            cmboStates.Items.Add("OK");
            cmboStates.Items.Add("OR");
            cmboStates.Items.Add("PA");
            cmboStates.Items.Add("RI");
            cmboStates.Items.Add("SC");
            cmboStates.Items.Add("SD");
            cmboStates.Items.Add("TN");
            cmboStates.Items.Add("TX");
            cmboStates.Items.Add("UT");
            cmboStates.Items.Add("VT");
            cmboStates.Items.Add("VA");
            cmboStates.Items.Add("WA");
            cmboStates.Items.Add("WV");
            cmboStates.Items.Add("WI");
            cmboStates.Items.Add("WY");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress1.Text == "" ||
                   txtCity.Text == "" || cmboStates.SelectedItem == null ||
                   txtZip.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Feilds with ' * ' are required", "Please fill out all required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO HackK21Su2332.Person(NameFirst, NameLast, Address1, Address2, Address3," +
                                                               " City, State, Zipcode, Email, PhonePrimary)" +
                                                               " VALUES(@NameFirst, @NameLast, @Address1, @Address2, @Address3," +
                                                               " @City, @State, @Zipcode, @Email, @PhonePrimary)"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@NameFirst", txtFirst.Text);
                            cmd.Parameters.AddWithValue("@NameLast", txtLast.Text);
                            cmd.Parameters.AddWithValue("@Address1", txtAddress1.Text);
                            cmd.Parameters.AddWithValue("@Address2", txtAddress2.Text);
                            cmd.Parameters.AddWithValue("@Address3", txtAddress3.Text);
                            cmd.Parameters.AddWithValue("@City", txtCity.Text);
                            cmd.Parameters.AddWithValue("@State", cmboStates.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Zipcode", txtZip.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@PhonePrimary", txtPhone.Text);

                            cmd.Connection = con;
                            con.Close();
                        }
                    }
                }
            }
            catch
            {
                //TODO
            }

            //THIS WILL BE FOR THE ACCOUNTS TABLE
            try
            {

            }
            catch
            {

            }
        }

        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
