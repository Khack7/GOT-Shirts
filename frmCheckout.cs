//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the selected item(s) are displayed, the pricings,
// and the payment options.
//*******************************************
//*******************************************using System;
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
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void frmCheckout_Load(object sender, System.EventArgs e)
        {

            string[] years = new string[12];

            cboMonth.Items.Add("01");
            cboMonth.Items.Add("02");
            cboMonth.Items.Add("03");
            cboMonth.Items.Add("04");
            cboMonth.Items.Add("05");
            cboMonth.Items.Add("06");
            cboMonth.Items.Add("07");
            cboMonth.Items.Add("08");
            cboMonth.Items.Add("09");
            cboMonth.Items.Add("10");
            cboMonth.Items.Add("11");
            cboMonth.Items.Add("12");

            for(int i = 0; i < 12; i++)
            {
                int.TryParse(DateTime.Now.Year.ToString(), out int y);
                years[i] = (y + i).ToString();
            }
            for(int y = 0; y < years.Length; y++)
            {
                cboYear.Items.Add(years[y]);
            }
        }
    }
}
