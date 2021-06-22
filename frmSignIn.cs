﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the sign in form where returning users can sign in
// new users can register, or the user can just shop as a guest
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        public static string CustomerType { get; set; }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CustomerType = "Guest";
            frmShop shop = new frmShop();
            this.Hide();
            this.Close();
            shop.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }

        public static int ID { get; set; }
        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                DataPerson person = DataPerson.GetPerson(txtUsername.Text);
                if (person != null)
                {

                    if (txtPassword.Text == person.Password)
                    {
                        CustomerType = "Customer";

                        ID = person.PersonID;

                        frmShop shop = new frmShop();
                        this.Hide();
                        shop.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPassword.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("This account doesn't exist", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            frmResetPassword reset = new frmResetPassword();
            reset.ShowDialog();
        }
    }
}
