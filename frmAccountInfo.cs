//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the user will be able to alter their information as needed
//*******************************************
//*******************************************
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
    public partial class frmAccountInfo : Form
    {
        public frmAccountInfo()
        {
            InitializeComponent();
        }

        private void frmAccountInfo_Load(object sender, EventArgs e)
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

            try
            {
                DataPerson person = null;

                person = DataPerson.GetPerson(frmSignIn.strUserName);

                txtFirst.Text = person.NameFirst;
                txtLast.Text = person.NameLast;
                txtAddress1.Text = person.Address1;
                txtAddress2.Text = person.Address2;
                txtAddress3.Text = person.Address3;
                txtCity.Text = person.City;
                txtZip.Text = person.Zipcode;
                txtPhone.Text = person.PhonePrimary;
                txtEmail.Text = person.Email;
                cboStates.SelectedItem = person.State;
                bolChangesMade = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirst.ReadOnly = false;
            txtLast.ReadOnly = false;
            txtAddress1.ReadOnly = false;
            txtAddress2.ReadOnly = false;
            txtAddress3.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtZip.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            cboStates.Enabled = true;

            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;

            lblInfo.Visible = true;

            txtFirst.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirst.Text == "" || txtLast.Text == "" || txtAddress1.Text == "" || txtCity.Text == "" ||
                    txtZip.Text == "" || cboStates.SelectedItem == null)
                {
                    MessageBox.Show("Make sure all required files are filled out", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(txtLast.Text.Length < 2 || txtFirst.Text.Length < 2)
                {
                    MessageBox.Show("Please enter a valid name", "First and/or Last name invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!txtPhone.MaskCompleted)
                {
                    DialogResult dr = MessageBox.Show("You don't have a valid phone number. Continue without one?", "Invalid phone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (txtEmail.Text != "")
                        {
                            string strEmail = txtEmail.Text;

                            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",

                            RegexOptions.CultureInvariant | RegexOptions.Singleline);

                            bool isValidEmail = regex.IsMatch(strEmail);
                            if (!isValidEmail)
                            {
                                throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                            }
                            else
                            {
                                DataPerson person = DataPerson.GetPerson(frmSignIn.strUserName);

                                person.NameFirst = txtFirst.Text;
                                person.NameLast = txtLast.Text;
                                person.Address1 = txtAddress1.Text;
                                person.Address2 = txtAddress2.Text;
                                person.Address3 = txtAddress3.Text;
                                person.City = txtCity.Text;
                                person.State = cboStates.SelectedItem.ToString();
                                person.Zipcode = txtZip.Text;
                                person.PhonePrimary = "";
                                person.Email = txtEmail.Text;

                                DataPerson.SavePerson(person);

                                MessageBox.Show("Changes Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            DataPerson person = DataPerson.GetPerson(frmSignIn.strUserName);

                            person.NameFirst = txtFirst.Text;
                            person.NameLast = txtLast.Text;
                            person.Address1 = txtAddress1.Text;
                            person.Address2 = txtAddress2.Text;
                            person.Address3 = txtAddress3.Text;
                            person.City = txtCity.Text;
                            person.State = cboStates.SelectedItem.ToString();
                            person.Zipcode = txtZip.Text;
                            person.PhonePrimary = txtPhone.Text;
                            person.Email = txtEmail.Text;

                            DataPerson.SavePerson(person);

                            MessageBox.Show("Changes Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (txtEmail.Text != "")
                    {
                        string strEmail = txtEmail.Text;

                        Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",

                        RegexOptions.CultureInvariant | RegexOptions.Singleline);

                        bool isValidEmail = regex.IsMatch(strEmail);
                        if (!isValidEmail)
                        {
                            throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                        }
                        else
                        {
                            DataPerson person = DataPerson.GetPerson(frmSignIn.strUserName);

                            person.NameFirst = txtFirst.Text;
                            person.NameLast = txtLast.Text;
                            person.Address1 = txtAddress1.Text;
                            person.Address2 = txtAddress2.Text;
                            person.Address3 = txtAddress3.Text;
                            person.City = txtCity.Text;
                            person.State = cboStates.SelectedItem.ToString();
                            person.Zipcode = txtZip.Text;
                            person.PhonePrimary = txtPhone.Text;
                            person.Email = txtEmail.Text;

                            DataPerson.SavePerson(person);

                            MessageBox.Show("Changes Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        DataPerson person = DataPerson.GetPerson(frmSignIn.strUserName);

                        person.NameFirst = txtFirst.Text;
                        person.NameLast = txtLast.Text;
                        person.Address1 = txtAddress1.Text;
                        person.Address2 = txtAddress2.Text;
                        person.Address3 = txtAddress3.Text;
                        person.City = txtCity.Text;
                        person.State = cboStates.SelectedItem.ToString();
                        person.Zipcode = txtZip.Text;
                        person.PhonePrimary = txtPhone.Text;
                        person.Email = txtEmail.Text;

                        DataPerson.SavePerson(person);

                        MessageBox.Show("Changes Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool bolChangesMade = false;

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

        private void txtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
        }

        private void txtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
        }

        private void txtAddress3_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
            bolChangesMade = true;
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtZip.MaxLength = 5;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
            if (e.KeyChar == (char)Keys.Space || e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bolChangesMade == true)
            {
                DialogResult dr = MessageBox.Show("You have unsaved changes. Are you sure you want to cancel?", "Unsaved Changes!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void cboStates_SelectedValueChanged(object sender, EventArgs e)
        {
            bolChangesMade = true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            bolChangesMade = true;
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.SelectAll();
            this.txtPhone.Select(0, 0);
        }
    }
}
