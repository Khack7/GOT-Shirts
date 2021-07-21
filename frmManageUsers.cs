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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.dataSet1.Person);

        }
    }
}
