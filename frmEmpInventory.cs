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
        private List<DataProduct> _products;
        public frmEmpInventory()
        {
            InitializeComponent();
            _products = DataProduct.ListProducts();
        }

        private void frmEmpInventory_Load(object sender, EventArgs e)
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
                string strSelectedColor = (string)cboColor.SelectedItem;
                string strSelectedSize = (string)cboSize.SelectedItem;
                var product = _products.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                txtAmount.Text = product.QuantityOnHand.ToString();
                txtPrice.Text = product.Price.ToString();
                txtCost.Text = product.Cost.ToString();
            }
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedItem != null)
            {
                string strSelectedColor = (string)cboColor.SelectedItem;
                string strSelectedSize = (string)cboSize.SelectedItem;
                var product = _products.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                txtAmount.Text = product.QuantityOnHand.ToString();
                txtPrice.Text = product.Price.ToString();
                txtCost.Text = product.Cost.ToString();
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
