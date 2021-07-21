using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmInventory : Form
    {
        private List<DataProduct> _products;
        public frmInventory()
        {
            InitializeComponent();
            _products = DataProduct.ListProducts();
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
                List<string> lstColors = _products.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> lstSizes = _products.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                for (int intI = 0; intI < lstColors.Count; intI++)
                {
                    cboColor.Items.Add(lstColors[intI]);
                }
                for (int intI = 0; intI < lstSizes.Count; intI++)
                {
                    cboSize.Items.Add(lstSizes[intI]);
                }
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
                string strSelectedColor = (string)cboColor.SelectedItem;
                string strSelectedSize = (string)cboSize.SelectedItem;
                var product = _products.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                txtAmount.Text = product.QuantityOnHand.ToString();
                txtPrice.Text = product.Price.ToString();
                txtCost.Text = product.Cost.ToString();
                try
                {
                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedItem != null)
            {
                txtAmount.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtCost.ReadOnly = false;
                bolChangesMade = true;

                string strSelectedColor = (string)cboColor.SelectedItem;
                string strSelectedSize = (string)cboSize.SelectedItem;
                var product = _products.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                txtAmount.Text = product.QuantityOnHand.ToString();
                txtPrice.Text = product.Price.ToString();
                txtCost.Text = product.Cost.ToString();
                try
                {
                    DataProduct productImage = DataProduct.GetProduct(strSelectedColor, strSelectedSize);
                    pbxShirt.Image = productImage.ProductImage;
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
                    if (int.TryParse(txtAmount.Text, out int A))
                    {
                        product.QuantityOnHand = A;
                    }
                    if (double.TryParse(txtPrice.Text, out double P))
                    {
                        product.Price = Math.Round(P, 2);
                    }
                    if (double.TryParse(txtCost.Text, out double C))
                    {
                        product.Cost = Math.Round(C, 2);
                    }

                    DataProduct.SaveProduct(product);

                    MessageBox.Show("Updates saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    List<string> lstColors = _products.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                    List<string> lstSizes = _products.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                    cboSize.Items.Clear();
                    cboColor.Items.Clear();

                    for (int intI = 0; intI < lstColors.Count; intI++)
                    {
                        cboColor.Items.Add(lstColors[intI]);
                    }
                    for (int intI = 0; intI < lstSizes.Count; intI++)
                    {
                        cboSize.Items.Add(lstSizes[intI]);
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

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
