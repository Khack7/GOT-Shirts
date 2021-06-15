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

        bool changesMade = false;

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


            cmboSecurity1.Items.Add("What was your childhood nickname?");
            cmboSecurity1.Items.Add("What is the name of your favorite childhood friend?");
            cmboSecurity1.Items.Add("What was the last name of your third grade teacher?");
            cmboSecurity1.Items.Add("What is your spouse's mother's maiden name?");
            cmboSecurity1.Items.Add("In what year was your father born?");

            cmboSecurity2.Items.Add("In what city or town was your first job?");
            cmboSecurity2.Items.Add("What is the name of a college you applied to but didn't attend?");
            cmboSecurity2.Items.Add("What was your dream job as a child?");
            cmboSecurity2.Items.Add("What was your favorite sport in high school?");
            cmboSecurity2.Items.Add("What year did you graduate from high School?");

            cmboSecurity3.Items.Add("What is your mother's middle name?");
            cmboSecurity3.Items.Add("What is your preferred musical genre?");
            cmboSecurity3.Items.Add("What was your high school mascot?");
            cmboSecurity3.Items.Add("What is your pet's name?");
            cmboSecurity3.Items.Add("What is the name of your favorite childhood teacher?");


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            try
            {
                List<TextBox> textBoxes = new List<TextBox>();
                textBoxes.Add(txtFirst);
                textBoxes.Add(txtLast);
                textBoxes.Add(txtAddress1);
                textBoxes.Add(txtCity);
                textBoxes.Add(txtZip);
                textBoxes.Add(txtUsername);
                textBoxes.Add(txtPassword);
                textBoxes.Add(txtFirst);

                List<ComboBox> comboBoxes = new List<ComboBox>();
                comboBoxes.Add(cboStates);
                comboBoxes.Add(cmboSecurity1);
                comboBoxes.Add(cmboSecurity2);
                comboBoxes.Add(cmboSecurity3);

                bool emptyTextbox = false;

                if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress1.Text == "" ||
                   txtCity.Text == "" || cboStates.SelectedItem == null ||
                   txtZip.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" ||
                   cmboSecurity1.SelectedItem == null || cmboSecurity2.SelectedItem == null ||
                   cmboSecurity3.SelectedItem == null || txtAnswer1.Text == "" || txtAnswer2.Text == ""
                   || txtAnswer3.Text == "")
                {
                    MessageBox.Show("Feilds with ' * ' are required", "Please fill out all required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    foreach (TextBox t in textBoxes)
                    {
                        if (t.Text == null || t.Text == "")
                        {
                            emptyTextbox = true;
                            t.Focus();
                            break;
                        }                      
                    }
                    if(emptyTextbox == false)
                    {
                        foreach(ComboBox c in comboBoxes)
                        {
                            if(c.SelectedItem == null)
                            {
                                c.Focus();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO HackK21Su2332.Person(NameFirst, NameLast, Address1, Address2, Address3," +
                                                               " City, State, Zipcode, Email, PhonePrimary, UserName, Password, AccountType," +
                                                               " SecurityQuestion1, SecurityAnswer1, SecurityQuestion2, SecurityAnswer2," +
                                                               " SecurityQuestion3, SecurityAnswer3)" +
                                                               " VALUES(@NameFirst, @NameLast, @Address1, @Address2, @Address3," +
                                                               " @City, @State, @Zipcode, @Email, @PhonePrimary, @UserName, @Password, @AccountType," +
                                                               " @SecurityQuestion1, @SecurityAnswer1, @SecurityQuestion2, @SecurityAnswer2, @SecurityQuestion3, @SecurityAnswer3)"))
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
                            cmd.Parameters.AddWithValue("@SecurityQuestion1", cmboSecurity1.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@SecurityAnswer1", txtAnswer1.Text);
                            cmd.Parameters.AddWithValue("@SecurityQuestion2", cmboSecurity2.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@SecurityAnswer2", txtAnswer2.Text);
                            cmd.Parameters.AddWithValue("@SecurityQuestion3", cmboSecurity3.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@SecurityAnswer3", txtAnswer3.Text);

                            cmd.Connection = con;
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            changesMade = true;
        }

        private void txtLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            changesMade = true;
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
            changesMade = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(changesMade == false)
            {
                this.Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("All changes will be discarded. Are you sure you want to cancel?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
