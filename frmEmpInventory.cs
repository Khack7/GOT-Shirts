﻿using SU21_Final_Project.Data;
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
                    string strSelectedColor = (string)cboColor.SelectedItem;
                    string strSelectedSize = (string)cboSize.SelectedItem;
                    var product = _lstProducts.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString();
                    txtCost.Text = product.Cost.ToString();

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
                try
                {
                    string strSelectedColor = (string)cboColor.SelectedItem;
                    string strSelectedSize = (string)cboSize.SelectedItem;
                    var product = _lstProducts.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                    txtAmount.Text = product.QuantityOnHand.ToString();
                    txtPrice.Text = product.Price.ToString();
                    txtCost.Text = product.Cost.ToString();
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
                txtAmount.Clear();
                txtPrice.Clear();
                txtCost.Clear();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{path}\\HelpFiles\\Employee_Inventory_Help.html");
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
