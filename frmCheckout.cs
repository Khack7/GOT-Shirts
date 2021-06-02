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

            cmboMonth.Items.Add("01");
            cmboMonth.Items.Add("02");
            cmboMonth.Items.Add("03");
            cmboMonth.Items.Add("04");
            cmboMonth.Items.Add("05");
            cmboMonth.Items.Add("06");
            cmboMonth.Items.Add("07");
            cmboMonth.Items.Add("08");
            cmboMonth.Items.Add("09");
            cmboMonth.Items.Add("10");
            cmboMonth.Items.Add("11");
            cmboMonth.Items.Add("12");

            for(int i = 0; i < 12; i++)
            {
                years[i] = (Convert.ToInt32(DateTime.Now.Year) + i).ToString();
            }
            for(int y = 0; y < years.Length; y++)
            {
                cmboYear.Items.Add(years[y]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
