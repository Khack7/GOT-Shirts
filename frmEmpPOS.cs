﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the employee can input a customer's username to shop on
// their behalf
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmEmpPOS : Form
    {
        public frmEmpPOS()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool bolEmpShopping = false;

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                if (person != null)
                {
                    if (person.Deleted == true)
                    {
                        MessageBox.Show("This account has been suspended. If you'd like to reactivate this account, please click on the help file and contact the supervisor via their email", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmSignIn.strCustomerType = person.AccountType;

                        frmSignIn.intID = person.PersonID;
                        frmSignIn.strUserName = txtUsername.Text;
                        bolEmpShopping = true;

                        frmShop frmShopping = new frmShop();
                        this.Hide();
                        frmShopping.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("This account doesn't exist or is incorrect", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Employee_POS_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSign.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
