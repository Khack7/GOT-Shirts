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
    public partial class frmManagerEditUser : Form
    {
        public frmManagerEditUser()
        {
            InitializeComponent();
        }

        private void frmManagerEditUser_Load(object sender, EventArgs e)
        {
            cboAccountType.Items.Add("Customer");
            cboAccountType.Items.Add("Employee");
            cboAccountType.Items.Add("Manager");

            lblPersonID.Text = frmManageUsers.intPersonID.ToString();
            txtFirstName.Text = frmManageUsers.strFirstName;
            txtLastName.Text = frmManageUsers.strLastName;
            txtUsername.Text = frmManageUsers.strUserName;
            txtEmail.Text = frmManageUsers.strEmail;
            txtPhone.Text = frmManageUsers.strPhone;
            cboAccountType.SelectedItem = frmManageUsers.strAccountType;         

            if(frmManageUsers.strAccountType == "Manager")
            {
                cboAccountType.Enabled = false;
            }   
        }

        bool bolEditsSaved = false;
        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult dr;

            if(txtPhone.Text == "" && txtEmail.Text == "" && frmManageUsers.strAccountType != "Customer")
            {
                MessageBox.Show("Employees and Managers require at least 1 mehtod of contact", "Email or Phone required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!txtPhone.MaskCompleted)
                {
                    dr = MessageBox.Show("You don't have a valid phone number. Continue without one?", "Invalid phone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dr = MessageBox.Show("Are you sure all edits are correct?", "Please ensure all changes are correct!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                DataPerson person = DataPerson.GetPerson(frmManageUsers.strUserName);

                                if (!double.TryParse(txtPayRate.Text, out double dblPay))
                                {
                                    throw new Exception("Invalid Payrate!");
                                }

                                if (cboAccountType.SelectedItem.ToString() == "Manager" || cboAccountType.SelectedItem.ToString() == "Employee")
                                {
                                    person.PayRate = dblPay;
                                }
                                else
                                {
                                    dblPay = 0;
                                }

                                if (txtUsername.Text != frmManageUsers.strUserName)
                                {
                                    if (person.UserName != null)
                                    {
                                        MessageBox.Show("This Username is already taken", "Name in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        if (CheckEmail(txtEmail.Text) == true)
                                        {
                                            person.NameFirst = txtFirstName.Text;
                                            person.NameLast = txtLastName.Text;
                                            person.UserName = txtUsername.Text;
                                            person.Email = txtEmail.Text;
                                            person.PhonePrimary = "";
                                            person.AccountType = cboAccountType.SelectedItem.ToString();
                                            person.PayRate = dblPay;

                                            DataPerson.SavePerson(person);
                                            MessageBox.Show("Changes Saved Successfully!", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            bolEditsSaved = true;
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
                                    if (CheckEmail(txtEmail.Text) == true)
                                    {
                                        person.NameFirst = txtFirstName.Text;
                                        person.NameLast = txtLastName.Text;
                                        person.UserName = txtUsername.Text;
                                        person.Email = txtEmail.Text;
                                        person.PhonePrimary = "";
                                        person.AccountType = cboAccountType.SelectedItem.ToString();
                                        person.PayRate = dblPay;

                                        DataPerson.SavePerson(person);
                                        MessageBox.Show("Changes Saved Successfully!", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bolEditsSaved = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    dr = MessageBox.Show("Are you sure all edits are correct?", "Please ensure all changes are correct!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            DataPerson person = DataPerson.GetPerson(frmManageUsers.strUserName);

                            if (!double.TryParse(txtPayRate.Text, out double dblPay))
                            {
                                throw new Exception("Invalid Payrate!");
                            }

                            if (cboAccountType.SelectedItem.ToString() == "Manager" || cboAccountType.SelectedItem.ToString() == "Employee")
                            {
                                person.PayRate = dblPay;
                            }
                            else
                            {
                                dblPay = 0;
                            }

                            if (txtUsername.Text != frmManageUsers.strUserName)
                            {
                                if (person.UserName != null)
                                {
                                    MessageBox.Show("This Username is already taken", "Name in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    if (CheckEmail(txtEmail.Text) == true)
                                    {
                                        person.NameFirst = txtFirstName.Text;
                                        person.NameLast = txtLastName.Text;
                                        person.UserName = txtUsername.Text;
                                        person.Email = txtEmail.Text;
                                        person.PhonePrimary = txtPhone.Text;
                                        person.AccountType = cboAccountType.SelectedItem.ToString();
                                        person.PayRate = dblPay;

                                        DataPerson.SavePerson(person);
                                        MessageBox.Show("Changes Saved Successfully!", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bolEditsSaved = true;
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
                                if (CheckEmail(txtEmail.Text) == true)
                                {
                                    person.NameFirst = txtFirstName.Text;
                                    person.NameLast = txtLastName.Text;
                                    person.UserName = txtUsername.Text;
                                    person.Email = txtEmail.Text;
                                    person.PhonePrimary = txtPhone.Text;
                                    person.AccountType = cboAccountType.SelectedItem.ToString();
                                    person.PayRate = dblPay;

                                    DataPerson.SavePerson(person);
                                    MessageBox.Show("Changes Saved Successfully!", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bolEditsSaved = true;
                                    this.Close();
                                }
                                else
                                {
                                    throw new Exception("Invalid email inserted. Please enter a vailid email or make sure no text is in the email field");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }                       
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManage = new frmManageUsers();
            this.Close();
            frmManage.ShowDialog();
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtPhone.MaxLength = 10;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space || e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void frmManagerEditUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(bolEditsSaved == false)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to exit? Any and all changes made will be discarded!", "Unsaved Changes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == DialogResult.Yes)
                {
                    bolEditsSaved = true;
                    this.Close();
                }
                else
                {
                    e.Cancel = true;
                }
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
        }

        private void cboAccountType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboAccountType.SelectedItem.ToString() == "Customer")
            {
                txtPayRate.Text = "0";
            }
            else
            {
                DataPerson person = DataPerson.GetPerson(frmManageUsers.strUserName);
                txtPayRate.Visible = true;
                lblPay.Visible = true;
                txtPayRate.Text = person.PayRate.ToString();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Manager_Edit_User_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CheckEmail(string email)
        {
            bool result;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",

            RegexOptions.CultureInvariant | RegexOptions.Singleline);

            bool isValidEmail = regex.IsMatch(email);
            if(email == "")
            {
                result = true;
            }
            else
            {
                if (!isValidEmail)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.SelectAll();
            this.txtPhone.Select(0, 0);
        }
    }
}