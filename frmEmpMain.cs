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
            frmEmpInfo empInfo = new frmEmpInfo();
            this.Hide();
            empInfo.ShowDialog();
            this.Show();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            frmEmpCodes empCodes = new frmEmpCodes();
            this.Hide();
            empCodes.ShowDialog();
            this.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmEmpInventory empInventory = new frmEmpInventory();
            this.Hide();
            empInventory.ShowDialog();
            this.Show();

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmEmpPOS pos = new frmEmpPOS();
            this.Hide();
            pos.ShowDialog();
            this.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Employee_Main_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
