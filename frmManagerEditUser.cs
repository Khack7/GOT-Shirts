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
            DialogResult dr = MessageBox.Show("Are you sure all edits are correct?", "Please ensure all changes are correct!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                try
                {
                    DataPerson person = DataPerson.GetPerson(frmManageUsers.strUserName);
                    person.NameFirst = txtFirstName.Text;
                    person.NameLast = txtLastName.Text;
                    person.UserName = txtUsername.Text;
                    person.Email = txtEmail.Text;
                    person.PhonePrimary = txtPhone.Text;
                    person.AccountType = cboAccountType.SelectedItem.ToString();

                    DataPerson.SavePerson(person);
                    MessageBox.Show("Changes Saved Successfully!", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bolEditsSaved = true;
                    frmManageUsers frmManage = new frmManageUsers();
                    this.Close();
                    frmManage.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.KeyChar == (char)Keys.Space)
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
                    frmManageUsers frmManage = new frmManageUsers();
                    bolEditsSaved = true;
                    this.Close();
                    frmManage.ShowDialog();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}