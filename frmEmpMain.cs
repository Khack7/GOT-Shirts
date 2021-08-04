//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the employees can choose what they'd like to do/view
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
    public partial class frmEmpMain : Form
    {
        public frmEmpMain()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmEmpInfo frmInfo = new frmEmpInfo();
            this.Hide();
            frmInfo.ShowDialog();
            this.Show();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            frmEmpCodes frmCodes = new frmEmpCodes();
            this.Hide();
            frmCodes.ShowDialog();
            this.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmEmpInventory frmInventoryEmp = new frmEmpInventory();
            this.Hide();
            frmInventoryEmp.ShowDialog();
            this.Show();

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmEmpPOS frmPOS = new frmEmpPOS();
            this.Hide();
            frmPOS.ShowDialog();
            this.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Employee_Main_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
