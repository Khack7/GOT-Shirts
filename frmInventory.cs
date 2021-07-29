using SU21_Final_Project.Classes;
using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                _lstProducts = DataProduct.ListProducts();
            }
            catch (Exception ex)
            {
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

                for (int intI = 0; intI < lstColors.Count; intI++)
                {
                    cboColor.Items.Add(lstColors[intI]);
                }
                for (int intI = 0; intI < lstSizes.Count; intI++)
                {
                    cboSize.Items.Add(lstSizes[intI]);
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
                        cboColor.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        throw new Exception("There is currently no product in this size");
                    }

                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString();
                    txtCost.Text = product.Cost.ToString();

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
                    dblNewCost = product.Price;

                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
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
                        cboColor.SelectedIndex = -1;
                        pbxShirt.Image = null;
                        throw new Exception("There is currently no product in this size");
                    }

                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString();
                    txtCost.Text = product.Cost.ToString();
                    
                    if(!bool.TryParse(product.Deleted.ToString(), out bool bolDeleted))
                    {
                        bolDeleted = true;
                    }

                    if(bolDeleted == false)
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
                    dblNewCost = product.Price;

                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
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
                    DataProduct product = DataProduct.GetProduct(cboColor.SelectedItem.ToString(), cboSize.SelectedItem.ToString()); ;
                    if (int.TryParse(txtAmount.Text, out int intAmount))
                    {
                        product.QuantityOnHand = intAmount;
                        intNewQuantity = intAmount;
                    }
                    if (double.TryParse(txtPrice.Text, out double dblPrice))
                    {
                        product.Price = Math.Round(dblPrice, 2);
                        dblNewPrice = product.Price;
                    }
                    if (double.TryParse(txtCost.Text, out double dblCost))
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
                }
                catch (Exception ex)
                {
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

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                bool bolEmptyFolder = false;
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bool bolStopLoop = false;

                string strColor, strSize;

                SaveFileDialog sfdFile = new SaveFileDialog();

                DataProduct product = null;

                _lstProducts = DataProduct.ListProducts();
                List<string> lstColors = _lstProducts.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> lstSizes = _lstProducts.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();


                for (int intIndexColors = 0; intIndexColors < lstColors.Count; intIndexColors++)
                {
                    strColor = lstColors[intIndexColors].ToString();
                    for (int intIndexSize = 0; intIndexSize < lstSizes.Count; intIndexSize++)
                    {
                        string strFileName = $"GOT Shirts-Current-Inventory-{lstSizes[intIndexSize].ToString() + "_" + lstColors[intIndexColors].ToString()}.html";

                        strSize = lstSizes[intIndexSize].ToString();

                        while (bolEmptyFolder == false)
                        {
                            sfdFile.FileName = strFileName;
                            sfdFile.Title = "Select save location. Empty Folder Required";
                            sfdFile.InitialDirectory = strPath;

                            if (sfdFile.ShowDialog() == DialogResult.OK)
                            {
                                strPath = Path.GetDirectoryName(sfdFile.FileName);

                                bolEmptyFolder = IsDirectoryEmpty(strPath);
                                if (!bolEmptyFolder)
                                {
                                    MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                bolStopLoop = true;
                                break;
                            }
                        }
                        if (bolStopLoop == true)
                        {
                            break;
                        }

                        strFileName = Path.Combine(strPath, strFileName);

                        product = DataProduct.GetProduct(strColor, strSize);

                        if(product != null)
                        {
                            GenerateReport(product, strFileName);
                        }
                    }
                    if (bolStopLoop == true)
                    {
                        break;
                    }
                }
                System.Diagnostics.Process.Start(strPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerateReport(DataProduct product, string strFileName)
        {
            string strReport = Receipt.LoadInventoryReportTemplate();

            strReport = strReport.Replace("{Date}", DateTime.Now.ToString());
            strReport = strReport.Replace("{Product}", product.Size + " " + product.Color);

            StringBuilder itemHTML = new StringBuilder();

            if(product.QuantityOnHand < 1)
            {
                product.QuantityOnHand = 0;
            }

            itemHTML.AppendFormat("<tr>");
            itemHTML.AppendFormat("    <td>{0} {1}</td>", product.Color, product.Size);
            itemHTML.AppendFormat("    <td>{0}</td>", product.QuantityOnHand);
            itemHTML.AppendFormat("    <td>{0:C2}</td>", product.Cost);
            itemHTML.AppendFormat("    <td>{0:C2}</td>", product.Price);
            itemHTML.AppendFormat("</tr>");

            strReport = strReport.Replace("{Items}", itemHTML.ToString());

            using (FileStream fs = new FileStream(strFileName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(strReport);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddProduct frmNewProduct = new frmAddProduct();
            this.Hide();
            frmNewProduct.ShowDialog();
            try
            {
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
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataProduct product = DataProduct.GetProduct(cboColor.SelectedItem.ToString(), cboSize.SelectedItem.ToString());
            try
            {
                if(product.Deleted == false)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Manager_Inventory_Help.html");
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
                var person = DataPerson.GetPerson(frmManageSignIn.intID);
                strReceipt = strReceipt.Replace("{AddressName}", $"{person.NameFirst} {person.NameLast}");

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
                    sfdFile.FileName = $"GOT Shirts-Inv.Update-{DateTime.Now.ToString("MM-dd-yyyy--hh_mm")}.html";

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
