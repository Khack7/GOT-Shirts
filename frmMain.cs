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

        //private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
        //        return cp;
        //    }
        //}USE THIS TO DISABLE 'X' BUTTON

        private void btnManage_Click(object sender, EventArgs e)
        {

        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            frmSignIn signIn = new frmSignIn();
            this.Hide();
            signIn.ShowDialog();
            this.Show();
        }
    }
}