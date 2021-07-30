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
    public partial class frmManagerMain : Form
    {
        public frmManagerMain()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmInventory frmInventory = new frmInventory();
            this.Hide();
            frmInventory.ShowDialog();
            this.Show();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            frmDiscountCodes frmCodes = new frmDiscountCodes();
            this.Hide();
            frmCodes.ShowDialog();
            this.Show();
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            frmAddEmployee frmAddEmployee = new frmAddEmployee();
            this.Hide();
            frmAddEmployee.ShowDialog();
            this.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            this.Hide();
            frmManageUsers.ShowDialog();
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReports frmReports = new frmReports();
            this.Hide();
            frmReports.ShowDialog();
            this.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Main_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmManagerSettings frmSettings = new frmManagerSettings();
            this.Hide();
            frmSettings.ShowDialog();
            this.Show();
        }
    }
}
