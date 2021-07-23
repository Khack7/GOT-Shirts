using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        bool bolChangesMade = false;
        bool bolComplete = false;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool bolAcceptedPassword = false, bolValidPay = false;

            string strAttemptedPassword = txtPassword.Text;

            int intPasswordRequirements = 0;
            var regex = new Regex(@"[^a-zA-Z0-9\s]");

            double dblPay = 0;

            if (double.TryParse(txtPayRate.Text, out double dblRate))
            {
                if (dblRate < 7.5)
                {
                    bolValidPay = false;
                }
                else
                {
                    bolValidPay = true;
                    dblPay = Math.Round(dblRate, 2);
                }
            }


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
                       txtCity.Text == "" || cboStates.SelectedItem == null ||
                       txtZip.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" ||
                       cmboSecurity1.SelectedItem == null || cmboSecurity2.SelectedItem == null ||
                       cmboSecurity3.SelectedItem == null || txtAnswer1.Text == "" || txtAnswer2.Text == ""
                       || txtAnswer3.Text == "" || bolValidPay == false)
                    {
                        MessageBox.Show("Feilds with ' * ' are required", "Please fill out all required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (txtZip.Text.Length < 5)
                        {
                            txtZip.Focus();
                            MessageBox.Show("Zipcode must be a valid 5 digit number", "Invalid Zipcode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (txtPhone.Text.Length < 10 || txtEmail.Text == "")
                        {
                            MessageBox.Show("Employees are required to have at least one method of contact", "Please fill out a contact field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bolValidPay == false || txtPayRate.Text == "")
                        {
                            MessageBox.Show("Payrate must be above $7.50", "Invalid PayRate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
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
                            string strAccountType = "";
                            if (rdoEmployee.Checked == true)
                            {
                                strAccountType = "Employee";
                            }
                            else if (rdoManager.Checked == true)
                            {
                                strAccountType = "Manager";
                            }
                            else
                            {
                                strAccountType = "Customer";
                            }
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
                                PhonePrimary = String.Format("{0:(###)-###-####}", Convert.ToInt64(txtPhone.Text)),
                                UserName = txtUsername.Text,
                                Password = txtPassword.Text,
                                AccountType = strAccountType,
                                SecurityQuestion1 = cmboSecurity1.SelectedItem.ToString(),
                                SecurityAnswer1 = txtAnswer1.Text,
                                SecurityQuestion2 = cmboSecurity2.SelectedItem.ToString(),
                                SecurityAnswer2 = txtAnswer2.Text,
                                SecurityQuestion3 = cmboSecurity3.SelectedItem.ToString(),
                                SecurityAnswer3 = txtAnswer3.Text,
                                Deleted = false,
                                PayRate = dblPay
                            };
                            DataPerson.SavePerson(person);
                            MessageBox.Show("Account Succesfully Created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bolComplete = true;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
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
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.OemPeriod);
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtPhone.MaxLength = 10;
            bolChangesMade = true;
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
            txtPassword.MaxLength = 10;
            bolChangesMade = true;
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
            txtPassword.MaxLength = 10;
            bolChangesMade = true;
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
            txtPassword.MaxLength = 10;
            bolChangesMade = true;
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
            txtPassword.MaxLength = 10;
            bolChangesMade = true;
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

        private void frmAddEmployee_FormClosing(object sender, FormClosingEventArgs e)
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
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPayRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            bolChangesMade = true;
        }
    }
}
