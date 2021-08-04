//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where new customers will create an account
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
using System.Text.RegularExpressions;
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

        bool bolChangesMade = false;
        bool bolComplete = false;

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
            bool bolAcceptedPassword = false;

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
                bolAcceptedPassword = false;
                intPasswordRequirements = 0;
            }

            if (intPasswordRequirements < 3)
            {
                MessageBox.Show("Password must be at least 8 charactors long and contain at least 3 of the following: lower case letter, upper case letter, number, or special charactor(ex: !, @, #, $)", "Missing password requirement", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                bolAcceptedPassword = true;
            }

            if (bolAcceptedPassword == true)
            {
                try
                {
                    List<TextBox> lstTextBoxes = new List<TextBox>();
                    lstTextBoxes.Add(txtFirst);
                    lstTextBoxes.Add(txtLast);
                    lstTextBoxes.Add(txtAddress1);
                    lstTextBoxes.Add(txtCity);
                    lstTextBoxes.Add(txtZip);
                    lstTextBoxes.Add(txtUsername);
                    lstTextBoxes.Add(txtPassword);
                    lstTextBoxes.Add(txtAnswer1);
                    lstTextBoxes.Add(txtAnswer2);
                    lstTextBoxes.Add(txtAnswer3);

                    List<ComboBox> lstComboBoxes = new List<ComboBox>();
                    lstComboBoxes.Add(cboStates);
                    lstComboBoxes.Add(cmboSecurity1);
                    lstComboBoxes.Add(cmboSecurity2);
                    lstComboBoxes.Add(cmboSecurity3);

                    bool bolEmptyTextbox = false;

                    if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress1.Text == "" ||
                       txtCity.Text.Length < 3 || cboStates.SelectedItem == null ||
                       txtZip.Text == "" || txtZip.Text.Length < 5 || txtUsername.Text == "" || txtPassword.Text == "" ||
                       cmboSecurity1.SelectedItem == null || cmboSecurity2.SelectedItem == null ||
                       cmboSecurity3.SelectedItem == null || txtAnswer1.Text == "" || txtAnswer2.Text == ""
                       || txtAnswer3.Text == "")
                    {
                        if (txtZip.Text.Length < 5)
                        {
                            txtZip.Focus();
                            MessageBox.Show("Zipcode must be a valid 5 digit number", "Invalid Zipcode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (txtCity.Text.Length < 3)
                        {
                            txtCity.Focus();
                            MessageBox.Show("There are no city names with less than 3 charactors", "Invalid City", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Feilds with ' * ' are required", "Please fill out all required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (TextBox t in lstTextBoxes)
                            {
                                if (t.Text == null || t.Text == "")
                                {
                                    bolEmptyTextbox = true;
                                    t.Focus();
                                    break;
                                }
                            }
                            if (bolEmptyTextbox == false)
                            {
                                foreach (ComboBox c in lstComboBoxes)
                                {
                                    if (c.SelectedItem == null)
                                    {
                                        c.Focus();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                        if (person != null)
                        {
                            MessageBox.Show("This Username is already taken", "Name in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (!txtPhone.MaskCompleted)
                            {
                                DialogResult dr = MessageBox.Show("You don't have a valid phone number. Continue without one?", "Invalid phone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    string strEmptyPhone = "";

                                    if (CheckEmail(txtEmail.Text) == true)
                                    {
                                        person = new DataPerson
                                        {
                                            NameFirst = txtFirst.Text,
                                            NameLast = txtLast.Text,
                                            Address1 = txtAddress1.Text,
                                            Address2 = txtAddress2.Text,
                                            Address3 = txtAddress3.Text,
                                            City = txtCity.Text,
                                            State = cboStates.SelectedItem.ToString(),
                                            Zipcode = txtZip.Text,
                                            Email = txtEmail.Text,
                                            PhonePrimary = strEmptyPhone,
                                            UserName = txtUsername.Text,
                                            Password = txtPassword.Text,
                                            AccountType = "Customer",
                                            SecurityQuestion1 = cmboSecurity1.SelectedItem.ToString(),
                                            SecurityAnswer1 = txtAnswer1.Text,
                                            SecurityQuestion2 = cmboSecurity2.SelectedItem.ToString(),
                                            SecurityAnswer2 = txtAnswer2.Text,
                                            SecurityQuestion3 = cmboSecurity3.SelectedItem.ToString(),
                                            SecurityAnswer3 = txtAnswer3.Text,
                                            Deleted = false
                                        };
                                        DataPerson.SavePerson(person);
                                        MessageBox.Show("Account Succesfully Created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bolComplete = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                                    }

                                }
                            }
                            else
                            {
                                if(CheckEmail(txtEmail.Text) == true)
                                {
                                    person = new DataPerson
                                    {
                                        NameFirst = txtFirst.Text,
                                        NameLast = txtLast.Text,
                                        Address1 = txtAddress1.Text,
                                        Address2 = txtAddress2.Text,
                                        Address3 = txtAddress3.Text,
                                        City = txtCity.Text,
                                        State = cboStates.SelectedItem.ToString(),
                                        Zipcode = txtZip.Text,
                                        Email = txtEmail.Text,
                                        PhonePrimary = txtPhone.Text,
                                        UserName = txtUsername.Text,
                                        Password = txtPassword.Text,
                                        AccountType = "Customer",
                                        SecurityQuestion1 = cmboSecurity1.SelectedItem.ToString(),
                                        SecurityAnswer1 = txtAnswer1.Text,
                                        SecurityQuestion2 = cmboSecurity2.SelectedItem.ToString(),
                                        SecurityAnswer2 = txtAnswer2.Text,
                                        SecurityQuestion3 = cmboSecurity3.SelectedItem.ToString(),
                                        SecurityAnswer3 = txtAnswer3.Text,
                                        Deleted = false
                                    };
                                    DataPerson.SavePerson(person);
                                    MessageBox.Show("Account Succesfully Created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bolComplete = true;
                                    this.Close();
                                }
                                else
                                {
                                    throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            bolChangesMade = true;
        }

        private void txtLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            bolChangesMade = true;
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
            bolChangesMade = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bolChangesMade == false)
            {
                this.Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("All changes will be discarded. Are you sure you want to cancel?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bolComplete = true;
                    this.Close();
                }
            }
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            bolChangesMade = true;
            txtZip.MaxLength = 5;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.MaxLength = 10;
            bolChangesMade = true;
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.MaxLength = 30;
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtAnswer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtAnswer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void txtAnswer3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bolChangesMade == true && bolComplete == false)
            {
                DialogResult dr = MessageBox.Show("All changes will be discarded. Are you sure you want to cancel?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space || e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        bool bolShowPass = true;

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (bolShowPass == true)
            {
                txtPassword.PasswordChar = '\0';
                bolShowPass = false;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                bolShowPass = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
        }

        public bool CheckEmail(string strEmail)
        {
            bool bolResult;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",

            RegexOptions.CultureInvariant | RegexOptions.Singleline);

            bool isValidEmail = regex.IsMatch(strEmail);
            if (strEmail == "")
            {
                bolResult = true;
            }
            else
            {
                if (!isValidEmail)
                {
                    bolResult = false;
                }
                else
                {
                    bolResult = true;
                }
            }
            return bolResult;
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.SelectAll();
            this.txtPhone.Select(0, 0);
        }
    }
}
