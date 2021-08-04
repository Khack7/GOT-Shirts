//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where employees can view the current inventory
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
    public partial class frmEmpInventory : Form
    {
        private List<DataProduct> _lstProducts;
        public frmEmpInventory()
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

        private void frmEmpInventory_Load(object sender, EventArgs e)
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

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedItem != null)
            {
                cboSize.Enabled = true;
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

                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                    Cursor.Current = Cursors.Default;
                }
                catch(CustomException ex)
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

        private class CustomException : Exception
        {
            public CustomException() { }

            public CustomException(string strException) : base(strException)
            {

            }
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedItem != null)
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
                    txtPrice.Text = product.Price.ToString();
                    txtCost.Text = product.Cost.ToString();

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
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cboSize.SelectedItem == null || cboSize.Enabled == false)
            {
                txtAmount.Clear();
                txtPrice.Clear();
                txtCost.Clear();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Employee_Inventory_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
