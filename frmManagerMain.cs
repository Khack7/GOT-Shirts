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
            frmInventory inventory = new frmInventory();
            this.Hide();
            inventory.ShowDialog();
            this.Show();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            frmDiscountCodes codes = new frmDiscountCodes();
            this.Hide();
            codes.ShowDialog();
            this.Show();
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            frmAddEmployee addEmployee = new frmAddEmployee();
            this.Hide();
            addEmployee.ShowDialog();
            this.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            this.Hide();
            manageUsers.ShowDialog();
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Manager_Main_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmManagerSettings settings = new frmManagerSettings();
            this.Hide();
            settings.ShowDialog();
            this.Show();
        }
    }
}
