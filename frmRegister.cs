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
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress1.Text == "" ||
                   txtCity.Text == "" || cboStates.SelectedItem == null ||
                   txtZip.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Feilds with ' * ' are required", "Please fill out all required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO HackK21Su2332.Person(NameFirst, NameLast, Address1, Address2, Address3," +
                                                               " City, State, Zipcode, Email, PhonePrimary, UserName, Password, AccountType)" +
                                                               " VALUES(@NameFirst, @NameLast, @Address1, @Address2, @Address3," +
                                                               " @City, @State, @Zipcode, @Email, @PhonePrimary, @UserName, @Password, @AccountType)"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@NameFirst", txtFirst.Text);
                            cmd.Parameters.AddWithValue("@NameLast", txtLast.Text);
                            cmd.Parameters.AddWithValue("@Address1", txtAddress1.Text);
                            cmd.Parameters.AddWithValue("@Address2", txtAddress2.Text);
                            cmd.Parameters.AddWithValue("@Address3", txtAddress3.Text);
                            cmd.Parameters.AddWithValue("@City", txtCity.Text);
                            cmd.Parameters.AddWithValue("@State", cboStates.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Zipcode", txtZip.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@PhonePrimary", txtPhone.Text);
                            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@AccountType", "Customer");

                            cmd.Connection = con;
                            con.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
