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
    public partial class frmManageSchedule : Form
    {
        private List<DataPerson> _people;
        public frmManageSchedule()
        {
            InitializeComponent();
            _people = DataPerson.ListEmployees();
        }

        private void frmManageSchedule_Load(object sender, EventArgs e)
        {
            List<int> employees = _people.Select(p => p.PersonID).OrderBy(p => p).ToList();

            for(int i = 0; i < employees.Count; i++)
            {
                cboPersonID.Items.Add(employees[i]);
            }
        }
    }
}
