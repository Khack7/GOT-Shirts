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
    public partial class frmInvoiceView : Form
    {
        public frmInvoiceView()
        {
            InitializeComponent();
        }

        private void frmInvoiceView_Load(object sender, EventArgs e)
        {
            InvoiceBrowser.DocumentText = frmReports.strHTML;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
