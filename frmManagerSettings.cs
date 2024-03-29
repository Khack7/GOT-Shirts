﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the manager can alter shipping or tax rates
//*******************************************
//*******************************************
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
            try
            {
                _lstSettings = DataSettings.ListSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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

                for (int intIndex = 0; intIndex < lstNames.Count; intIndex++)
                {
                    cboSettingNames.Items.Add(lstNames[intIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSettingNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cboSettingNames.SelectedIndex != -1)
                {
                    string strSelectedSetting = cboSettingNames.SelectedItem.ToString();
                    var setting = _lstSettings.Where(s => s.SettingName == strSelectedSetting).SingleOrDefault();

                    if (cboSettingNames.SelectedItem != null && cboSettingNames.SelectedItem.ToString() != "TaxRate")
                    {
                        btnEdit.Enabled = true;
                        txtValue.ReadOnly = true;
                        btnApply.Enabled = false;
                        lblPercentSign.Visible = false;

                        if (double.TryParse(setting.SettingValue, out double dblSetting))
                        {
                            txtValue.Text = dblSetting.ToString("C2");
                        }
                        else
                        {
                            cboSettingNames.SelectedIndex = -1;
                            throw new Exception("Something went wrong. Please try again");
                        }
                    }
                    else if (cboSettingNames.SelectedItem.ToString() == "TaxRate")
                    {
                        btnEdit.Enabled = true;
                        txtValue.ReadOnly = true;
                        btnApply.Enabled = false;
                        lblPercentSign.Visible = true;

                        txtValue.Text = setting.SettingValue;
                    }
                    else
                    {
                        txtValue.Text = "";
                        txtValue.ReadOnly = true;
                        lblPercentSign.Visible = false;
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtValue.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataSettings settingUpdate = DataSettings.GetSettings(cboSettingNames.SelectedItem.ToString());

                    double dblTax = 0;

                    if (settingUpdate.SettingName == "TaxRate")
                    {
                        if (double.TryParse(txtValue.Text, out double dblSettingValue))
                        {
                            dblTax = dblSettingValue;
                        }
                        else
                        {
                            throw new Exception("Invalid Value inputed. Please enter a money value");
                        }

                        if (dblTax > 1 || dblTax == 0)
                        {
                            MessageBox.Show("Please input tax percentage as a decimal. Example: 8% = 0.08", "Wrong Format Or Value Of Zero", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                        }
                        else
                        {
                            settingUpdate.SettingValue = dblTax.ToString();
                            DataSettings.SaveSetting(settingUpdate);
                            MessageBox.Show("Updates saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cboSettingNames.SelectedItem = null;
                            txtValue.Text = "";
                            txtValue.ReadOnly = true;
                            btnApply.Enabled = false;
                            lblPercentSign.Visible = false;

                            cboSettingNames.Items.Clear();
                            _lstSettings = DataSettings.ListSettings();
                            List<string> lstNames = _lstSettings.Select(n => n.SettingName).Distinct().OrderBy(n => n).ToList();

                            for (int intIndex = 0; intIndex < lstNames.Count; intIndex++)
                            {
                                cboSettingNames.Items.Add(lstNames[intIndex]);
                            }
                        }
                    }
                    else
                    {
                        if (double.TryParse(txtValue.Text, out double dblSettingValue))
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

                        for (int intIndex = 0; intIndex < lstNames.Count; intIndex++)
                        {
                            cboSettingNames.Items.Add(lstNames[intIndex]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Settings_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
