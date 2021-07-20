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
        private List<DataCodes> _lstActiveCodes, _lstInactiveCodes;
        public frmEmpCodes()
        {
            InitializeComponent();
            _lstActiveCodes = DataCodes.ListActiveOnlyCodes();
            _lstInactiveCodes = DataCodes.ListInactiveCodes();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpCodes_Load(object sender, EventArgs e)
        {
            List<string> lstActiveCodes = _lstActiveCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();
            List<string> lstInactiveCodes = _lstInactiveCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

            for (int intI = 0; intI < lstActiveCodes.Count; intI++)
            {
                lstActive.Items.Add(lstActiveCodes[intI]);
            }
            for (int intI = 0; intI < lstInactiveCodes.Count; intI++)
            {
                lstInactive.Items.Add(lstInactiveCodes[intI]);
            }
        }
    }
}
