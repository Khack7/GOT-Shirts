using SU21_Final_Project.Data;
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
    public partial class frmEmpCodes : Form
    {
        private List<DataCodes> _activeCodes, _inactiveCodes;
        public frmEmpCodes()
        {
            InitializeComponent();
            _activeCodes = DataCodes.ListActiveOnlyCodes();
            _inactiveCodes = DataCodes.ListInactiveCodes();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpCodes_Load(object sender, EventArgs e)
        {
            List<string> ActiveCodes = _activeCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();
            List<string> InactiveCodes = _inactiveCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

            for (int i = 0; i < ActiveCodes.Count; i++)
            {
                lstActive.Items.Add(ActiveCodes[i]);
            }
            for (int i = 0; i < InactiveCodes.Count; i++)
            {
                lstInactive.Items.Add(InactiveCodes[i]);
            }
        }
    }
}
