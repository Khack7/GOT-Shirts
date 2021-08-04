//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the manager can create, activate, and/or deactive discount codes
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
    public partial class frmDiscountCodes : Form
    {
        private List<DataCodes> _lstCodes;
        public frmDiscountCodes()
        {
            InitializeComponent();
            try
            {
                _lstCodes = DataCodes.ListCodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmDiscountCodes_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstCodes = _lstCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

                for (int intIndex = 0; intIndex < lstCodes.Count; intIndex++)
                {
                    cboCodes.Items.Add(lstCodes[intIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartCreation_Click(object sender, EventArgs e)
        {
            grpBxCodes.Enabled = true;
            cboCodes.Enabled = false;
            btnActivate.Enabled = false;
            btnDeactivate.Enabled = false;
            btnStartCreation.Enabled = false;
            txtCode.Focus();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCode.MaxLength = 5;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DataCodes code = DataCodes.GetCode(txtCode.Text.ToUpper());

                if (code != null)
                {
                    MessageBox.Show("This code already exists!", "Code Exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int intPercent = 0;
                    if (int.TryParse(txtPercent.Text, out int intParsedPercent))
                    {
                        intPercent = intParsedPercent;
                    }
                    else
                    {
                        throw new Exception("Incorrect input in Percent off!");
                    }

                    if (intPercent > 90)
                    {
                        MessageBox.Show("Discounts cannot exceed 90% off", "Discount too large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        code = new DataCodes
                        {
                            Active = true,
                            PercentOff = intPercent,
                            DiscountCode = txtCode.Text.ToUpper()
                        };
                        DataCodes.saveCode(code);
                        MessageBox.Show("Code Created", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grpBxCodes.Enabled = false;
                        txtCode.Clear();
                        txtPercent.Clear();
                        cboCodes.Enabled = true;
                        btnActivate.Enabled = true;
                        btnDeactivate.Enabled = true;
                        btnStartCreation.Enabled = true;
                        cboCodes.Focus();
                        lblPercentOff.Text = "";
                        lblStatus.Text = "";
                        //REFRESH CBOCODES TO SHOW NEW CODES AFTER CREATION
                        _lstCodes = DataCodes.ListCodes();
                        List<string> lstCodes = _lstCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

                        cboCodes.Items.Clear();

                        for (int intIndex = 0; intIndex < lstCodes.Count; intIndex++)
                        {
                            cboCodes.Items.Add(lstCodes[intIndex]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpBxCodes.Enabled = false;
            txtCode.Clear();
            txtPercent.Clear();
            cboCodes.Enabled = true;
            btnActivate.Enabled = true;
            btnDeactivate.Enabled = true;
            cboCodes.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSelectedCode = (string)cboCodes.SelectedItem;
                string strStatus = "";

                var code = _lstCodes.Where(c => c.DiscountCode == strSelectedCode).SingleOrDefault();

                lblPercentDisplay.Text = code.PercentOff.ToString();

                if (bool.TryParse(code.Active.ToString(), out bool bolActivity))
                {
                    if (bolActivity == true)
                    {
                        strStatus = "Active";
                    }
                    else
                    {
                        strStatus = "Inactive";
                    }
                }
                lblStatus.Text = strStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtPercent.MaxLength = 2;
        }

        bool bolStatus = false;

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (cboCodes.SelectedItem == null)
            {
                MessageBox.Show("Please select a code first", "No code selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lblStatus.Text == "Active")
                {
                    MessageBox.Show("This code is already active", "Code active", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        bolStatus = true;
                        DataCodes.CodeActivity(cboCodes.SelectedItem.ToString(), bolStatus);
                        _lstCodes = DataCodes.ListCodes();
                        List<string> lstCodes = _lstCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

                        cboCodes.Items.Clear();
                        lblStatus.Text = "";
                        lblPercentDisplay.Text = "";

                        for (int intIndex = 0; intIndex < lstCodes.Count; intIndex++)
                        {
                            cboCodes.Items.Add(lstCodes[intIndex]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (cboCodes.SelectedItem == null)
            {
                MessageBox.Show("Please select a code first", "No code selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (lblStatus.Text == "Inactive")
                {
                    MessageBox.Show("This code is already inactive", "Code inactive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        bolStatus = false;
                        DataCodes.CodeActivity(cboCodes.SelectedItem.ToString(), bolStatus);
                        _lstCodes = DataCodes.ListCodes();
                        List<string> codes = _lstCodes.Select(c => c.DiscountCode).OrderBy(c => c).ToList();

                        cboCodes.Items.Clear();
                        lblStatus.Text = "";
                        lblPercentDisplay.Text = "";

                        for (int intIndex = 0; intIndex < codes.Count; intIndex++)
                        {
                            cboCodes.Items.Add(codes[intIndex]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Codes_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
