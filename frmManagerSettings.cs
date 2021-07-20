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
    public partial class frmManagerSettings : Form
    {
        private List<DataSettings> _lstSettings;
        public frmManagerSettings()
        {
            InitializeComponent();
            _lstSettings = DataSettings.ListSettings();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManagerSettings_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstNames = _lstSettings.Select(n => n.SettingName).Distinct().OrderBy(n => n).ToList();
                
                for(int i = 0; i < lstNames.Count; i++)
                {
                    cboSettingNames.Items.Add(lstNames[i]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSettingNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSettingNames.SelectedItem != null)
            {
                btnEdit.Enabled = true;
                txtValue.ReadOnly = true;
                btnApply.Enabled = false;

                string selectedSetting = cboSettingNames.SelectedItem.ToString();
                var setting = _lstSettings.Where(s => s.SettingName == selectedSetting).SingleOrDefault();
                txtValue.Text = setting.SettingValue;
            }
            else
            {
                txtValue.Text = "";
                txtValue.ReadOnly = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnApply.Enabled = true;
            txtValue.ReadOnly = false;
            txtValue.Focus();
            txtValue.SelectAll();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(txtValue.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataSettings settingUpdate = DataSettings.GetSettings(cboSettingNames.SelectedItem.ToString());

                    if(double.TryParse(txtValue.Text, out double dblSettingValue))
                    {
                        settingUpdate.SettingValue = dblSettingValue.ToString();
                    }
                    else
                    {
                        throw new Exception("Invalid Value inputed. Please enter a money value");
                    }

                    DataSettings.SaveSetting(settingUpdate);
                    MessageBox.Show("Updates saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboSettingNames.SelectedItem = null;
                    txtValue.Text = "";
                    txtValue.ReadOnly = true;
                    btnApply.Enabled = false;

                    cboSettingNames.Items.Clear();
                    _lstSettings = DataSettings.ListSettings();
                    List<string> lstNames = _lstSettings.Select(n => n.SettingName).Distinct().OrderBy(n => n).ToList();

                    for (int i = 0; i < lstNames.Count; i++)
                    {
                        cboSettingNames.Items.Add(lstNames[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
