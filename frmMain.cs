//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the main menu to be used to either go shopping or to manage the
// employees, orders, inventory, ect.
//*******************************************
//*******************************************
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            frmSignIn frmCustomerSignIn = new frmSignIn();
            this.Hide();
            frmCustomerSignIn.ShowDialog();
            this.Show();
        }

        private void mnuManage_Click(object sender, EventArgs e)
        {
            frmManageSignIn frmManEmpSignIn = new frmManageSignIn();
            this.Hide();
            frmManEmpSignIn.ShowDialog();
            this.Show();
        }
    }
}