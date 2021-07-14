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
    }
}
