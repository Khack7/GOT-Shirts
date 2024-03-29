﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the manager can view, update, alter, or add new inventory itmes
//*******************************************
//*******************************************
using SU21_Final_Project.Classes;
using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmInventory : Form
    {
        private List<DataProduct> _lstProducts;
        public frmInventory()
        {
            InitializeComponent();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _lstProducts = DataProduct.ListProducts();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (bolChangesMade == true)
            {
                DialogResult dr = MessageBox.Show("Any and all changes made will be discarded", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                {
                    cboColor.Items.Add(lstColors[intIndex]);
                }
                for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                {
                    cboSize.Items.Add(lstSizes[intIndex]);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool bolChangesMade = false;

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedItem != null)
            {
                cboSize.Enabled = true;
                bolChangesMade = true;
            }
            else
            {
                cboSize.Enabled = false;
            }

            if (cboColor.SelectedItem != null && cboSize.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string strSelectedColor = (string)cboColor.SelectedItem;
                    string strSelectedSize = (string)cboSize.SelectedItem;
                    var product = _lstProducts.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();

                    if (product == null)
                    {
                        cboSize.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        throw new CustomException("There is currently no product in this size");
                    }

                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString("C2");
                    txtCost.Text = product.Cost.ToString("C2");

                    if (!bool.TryParse(product.Deleted.ToString(), out bool bolDeleted))
                    {
                        bolDeleted = false;
                    }

                    if (bolDeleted == false)
                    {
                        lblStatus.Text = "Available";
                    }
                    else
                    {
                        lblStatus.Text = "Unavailable";
                    }
                    //TO BE USED FOR INVOICE
                    intOldQuantity = product.QuantityOnHand;
                    dblNewPrice = product.Price;
                    dblNewCost = product.Cost;

                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                    Cursor.Current = Cursors.Default;
                }
                catch (CustomException ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        double dblNewPrice = 0.00, dblNewCost = 0.00;
        int intOldQuantity = 0, intNewQuantity = 0;
        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedItem != null)
            {
                txtAmount.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtCost.ReadOnly = false;
                bolChangesMade = true;
                btnRemove.Enabled = true;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string strSelectedColor = (string)cboColor.SelectedItem;
                    string strSelectedSize = (string)cboSize.SelectedItem;
                    var product = _lstProducts.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();

                    if (product == null)
                    {
                        cboSize.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        throw new CustomException("There is currently no product in this size");
                    }

                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString("C2");
                    txtCost.Text = product.Cost.ToString("C2");

                    if (!bool.TryParse(product.Deleted.ToString(), out bool bolDeleted))
                    {
                        bolDeleted = true;
                    }

                    if (bolDeleted == false)
                    {
                        lblStatus.Text = "Available";
                    }
                    else
                    {
                        lblStatus.Text = "Unavailable";
                    }

                    //TO BE USED FOR INVOICE
                    intOldQuantity = product.QuantityOnHand;
                    dblNewPrice = product.Price;
                    dblNewCost = product.Cost;

                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                    Cursor.Current = Cursors.Default;
                }
                catch (CustomException ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cboSize.SelectedItem == null || cboSize.Enabled == false)
            {
                txtAmount.ReadOnly = true;
                txtAmount.Clear();
                txtPrice.ReadOnly = true;
                txtPrice.Clear();
                txtCost.ReadOnly = true;
                txtCost.Clear();
                btnRemove.Enabled = false;
                lblStatus.Text = string.Empty;
            }
        }
        private class CustomException : Exception
        {
            public CustomException() { }

            public CustomException(string strException) : base(strException)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "" || txtPrice.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                List<TextBox> lstTextBoxes = new List<TextBox>();
                lstTextBoxes.Add(txtCost);
                lstTextBoxes.Add(txtAmount);
                lstTextBoxes.Add(txtPrice);

                foreach (TextBox t in lstTextBoxes)
                {
                    if (t.Text == "")
                    {
                        t.Focus();
                        break;
                    }
                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    decimal decParsedMoney = 0.00m;

                    DataProduct product = DataProduct.GetProduct(cboColor.SelectedItem.ToString(), cboSize.SelectedItem.ToString()); ;

                    decParsedMoney = Decimal.Parse(txtAmount.Text, NumberStyles.Currency);

                    if (int.TryParse(decParsedMoney.ToString(), out int intAmount))
                    {
                        product.QuantityOnHand = intAmount;
                        intNewQuantity = intAmount;
                    }

                    decParsedMoney = Decimal.Parse(txtPrice.Text, NumberStyles.Currency);

                    if (double.TryParse(decParsedMoney.ToString(), out double dblPrice))
                    {
                        product.Price = Math.Round(dblPrice, 2);
                        dblNewPrice = product.Price;
                    }

                    decParsedMoney = Decimal.Parse(txtCost.Text, NumberStyles.Currency);

                    if (double.TryParse(decParsedMoney.ToString(), out double dblCost))
                    {
                        product.Cost = Math.Round(dblCost, 2);
                        dblNewCost = product.Cost;
                    }

                    DataProduct.SaveProduct(product);

                    MessageBox.Show("Updates saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (intOldQuantity < intAmount)
                    {
                        //PRINT OUT REPORT HERE
                        PrintReceipt(product);
                    }

                    bolChangesMade = false;
                    txtAmount.Clear();
                    txtCost.Clear();
                    txtPrice.Clear();
                    txtAmount.ReadOnly = true;
                    txtCost.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    cboColor.SelectedIndex = -1;
                    cboSize.SelectedIndex = -1;
                    pbxShirt.Image = null;
                    lblStatus.Text = string.Empty;

                    _lstProducts = DataProduct.ListProducts();
                    List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                    List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                    cboSize.Items.Clear();
                    cboColor.Items.Clear();

                    for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                    {
                        cboColor.Items.Add(lstColors[intIndex]);
                    }
                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        cboSize.Items.Add(lstSizes[intIndex]);
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            bolChangesMade = true;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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
            bolChangesMade = true;
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
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
            bolChangesMade = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string strColor, strSize;

                SaveFileDialog sfdFile = new SaveFileDialog();

                DataProduct product = null;

                string strFileName = "";

                _lstProducts = DataProduct.ListProducts();
                List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                List<DataProduct> lstDataProducts = new List<DataProduct>();

                strFileName = $"GOT Shirts-Current-Inventory-{DateTime.Today.ToString("dd_MM_yyyy")}.html";

                Cursor.Current = Cursors.Default;
                sfdFile.FileName = strFileName;
                sfdFile.Title = "Select save location";
                sfdFile.InitialDirectory = strPath;

                if (sfdFile.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    strPath = Path.GetDirectoryName(sfdFile.FileName);

                    for (int intIndexColors = 0; intIndexColors < lstColors.Count; intIndexColors++)
                    {
                        strColor = lstColors[intIndexColors].ToString();

                        for (int intIndexSize = 0; intIndexSize < lstSizes.Count; intIndexSize++)
                        {

                            strSize = lstSizes[intIndexSize].ToString();

                            strFileName = Path.Combine(strPath, strFileName);

                            product = DataProduct.GetProduct(strColor, strSize);

                            if (product != null)
                            {
                                lstDataProducts.Add(product);
                            }
                        }
                    }
                    GenerateReport(lstDataProducts, strFileName);
                    Cursor.Current = Cursors.Default;
                    System.Diagnostics.Process.Start(strFileName);
                }                 
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerateReport(List<DataProduct> lstProducts, string strFileName)
        {
            string strReport = Receipt.LoadInventoryReportTemplate();

            strReport = strReport.Replace("{Date}", DateTime.Now.ToString());

            StringBuilder itemHTML = new StringBuilder();

            for (int intIndex = 0; intIndex < lstProducts.Count; intIndex++)
            {
                if (lstProducts[intIndex].QuantityOnHand < 1)
                {
                    lstProducts[intIndex].QuantityOnHand = 0;
                }

                itemHTML.AppendFormat("<tr>");
                itemHTML.AppendFormat("    <td>{0} {1}</td>", lstProducts[intIndex].Color, lstProducts[intIndex].Size);
                itemHTML.AppendFormat("    <td>{0}</td>", lstProducts[intIndex].QuantityOnHand);
                itemHTML.AppendFormat("    <td>{0:C2}</td>", lstProducts[intIndex].Cost);
                itemHTML.AppendFormat("    <td>{0:C2}</td>", lstProducts[intIndex].Price);
                itemHTML.AppendFormat("</tr>");
            }



            strReport = strReport.Replace("{Items}", itemHTML.ToString());

            using (FileStream fs = new FileStream(strFileName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(strReport);
                }
            }
        }

        public static string strUpdatingColor = "";
        public static bool bolWantsUpdate = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboColor.SelectedIndex != -1)
            {
                DialogResult dr = MessageBox.Show("Do you want to update the currently selected item?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    strUpdatingColor = cboColor.SelectedItem.ToString();
                    bolWantsUpdate = true;
                }
            }
            frmAddProduct frmNewProduct = new frmAddProduct();
            this.Hide();
            frmNewProduct.ShowDialog();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _lstProducts = DataProduct.ListProducts();
                List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                cboSize.Items.Clear();
                cboColor.Items.Clear();
                txtAmount.Clear();
                txtPrice.Clear();
                txtCost.Clear();
                pbxShirt.Image = null;
                lblStatus.Text = string.Empty;

                for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                {
                    cboColor.Items.Add(lstColors[intIndex]);
                }
                for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                {
                    cboSize.Items.Add(lstSizes[intIndex]);
                }
                cboSize.Enabled = false;
                txtAmount.ReadOnly = true;
                txtCost.ReadOnly = true;
                txtPrice.ReadOnly = true;
                btnRemove.Enabled = false;
                bolWantsUpdate = false;
                strUpdatingColor = "";
                this.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                DataProduct product = DataProduct.GetProduct(cboColor.SelectedItem.ToString(), cboSize.SelectedItem.ToString());

                if (product.Deleted == false)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to remove this product?", "WARNING!!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        product.Deleted = true;

                        DataProduct.DeleteOrRestoreProduct(product);

                        MessageBox.Show("Item Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        bolChangesMade = false;
                        txtAmount.Clear();
                        txtCost.Clear();
                        txtPrice.Clear();
                        txtAmount.ReadOnly = true;
                        txtCost.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        cboColor.SelectedIndex = -1;
                        cboSize.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        btnRemove.Enabled = false;
                        lblStatus.Text = string.Empty;

                        _lstProducts = DataProduct.ListProducts();
                        List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                        List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                        cboSize.Items.Clear();
                        cboColor.Items.Clear();

                        for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                        {
                            cboColor.Items.Add(lstColors[intIndex]);
                        }
                        for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                        {
                            cboSize.Items.Add(lstSizes[intIndex]);
                        }
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to recover this product?", "WARNING!!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        product.Deleted = false;

                        DataProduct.DeleteOrRestoreProduct(product);

                        MessageBox.Show("Item Recovered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        bolChangesMade = false;
                        txtAmount.Clear();
                        txtCost.Clear();
                        txtPrice.Clear();
                        txtAmount.ReadOnly = true;
                        txtCost.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        cboColor.SelectedIndex = -1;
                        cboSize.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        btnRemove.Enabled = false;
                        lblStatus.Text = string.Empty;

                        _lstProducts = DataProduct.ListProducts();
                        List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                        List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                        cboSize.Items.Clear();
                        cboColor.Items.Clear();

                        for (int intIndex = 0; intIndex < lstColors.Count; intIndex++)
                        {
                            cboColor.Items.Add(lstColors[intIndex]);
                        }
                        for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                        {
                            cboSize.Items.Add(lstSizes[intIndex]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Inventory_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt(DataProduct product)
        {
            try
            {
                string strReceipt = Receipt.LoadInventoryTemplate();
                strReceipt = strReceipt.Replace("{Date}", DateTime.Now.ToString("MM/dd/yyyy - hh:mm"));
                strReceipt = strReceipt.Replace("{AdjustmentDate}", DateTime.Now.ToString("MM-dd-yyyy"));

                StringBuilder itemHTML = new StringBuilder();

                itemHTML.AppendFormat("<tr>");
                itemHTML.AppendFormat("    <td>{0} {1}</td>", cboColor.SelectedItem.ToString(), cboSize.SelectedItem.ToString());
                itemHTML.AppendFormat("    <td>{0}</td>", (intNewQuantity - intOldQuantity).ToString());
                itemHTML.AppendFormat("    <td>{0:C2}</td>", txtCost.Text);
                itemHTML.AppendFormat("    <td>{0:C2}</td>", dblNewCost * (intNewQuantity - intOldQuantity));
                itemHTML.AppendFormat("</tr>");

                DataMoney tax = DataMoney.GetValues("TaxRate");

                if (!double.TryParse(tax.SettingValue, out double dblTax))
                {
                    dblTax = 0;
                }
                double dblSubtotal = dblNewCost * (intNewQuantity - intOldQuantity);
                double dblTaxCost = dblTax * dblSubtotal;
                double dblTotalCost = dblTaxCost + dblSubtotal;

                strReceipt = strReceipt.Replace("{Items}", itemHTML.ToString());
                strReceipt = strReceipt.Replace("{SubTotal}", dblSubtotal.ToString("C2"));
                strReceipt = strReceipt.Replace("{TaxTotal}", dblTaxCost.ToString("C2"));
                strReceipt = strReceipt.Replace("{OrderTotal}", dblTotalCost.ToString("C2"));

                //GET USERS SELECTED PATH
                string strPath = "";
                bool bolPathSelected = false;

                while (bolPathSelected == false)
                {
                    SaveFileDialog sfdFile = new SaveFileDialog();
                    sfdFile.Title = "Select save location";
                    sfdFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    sfdFile.FileName = $"GOT Shirts-Inv.Update-{DateTime.Now.ToString("MM-dd-yyyy--") + product.Size + "_" + product.Color}.html";

                    if (sfdFile.ShowDialog() == DialogResult.OK)
                    {
                        strPath = sfdFile.FileName;
                        bolPathSelected = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Please select a folder to save your receipt", "Please choose a folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bolPathSelected = false;
                    }

                }

                using (FileStream fsStream = new FileStream(strPath, FileMode.Create))
                {
                    using (StreamWriter swWriter = new StreamWriter(fsStream, Encoding.UTF8))
                    {
                        swWriter.Write(strReceipt);
                    }
                }
                System.Diagnostics.Process.Start(strPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
