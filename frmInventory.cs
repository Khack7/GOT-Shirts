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
            this.Close();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> colors = _products.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();
                List<string> sizes = _products.Select(p => p.Size).Distinct().OrderBy(s => s).ToList();

                for(int i = 0; i < colors.Count; i++)
                {
                    cboColor.Items.Add(colors[i]);
                }
                for (int i = 0; i < sizes.Count; i++)
                {
                    cboSize.Items.Add(sizes[i]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboColor.SelectedItem != null)
            {
                cboSize.Enabled = true;
            }
            else
            {
                cboSize.Enabled = false;
            }

            if(cboColor.SelectedItem != null && cboSize.SelectedItem != null)
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
            if(cboSize.SelectedItem != null)
            {
                txtAmount.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtCost.ReadOnly = false;

                string strSelectedColor = (string)cboColor.SelectedItem;
                string strSelectedSize = (string)cboSize.SelectedItem;
                var product = _products.Where(p => p.Color == strSelectedColor && p.Size == strSelectedSize).SingleOrDefault();
                txtAmount.Text = product.QuantityOnHand.ToString();
                txtPrice.Text = product.Price.ToString();
                txtCost.Text = product.Cost.ToString();
                //product.Price = newPrice;
                //DataProduct.SaveProduct(product);
            }
            else if(cboSize.SelectedItem == null || cboSize.Enabled == false)
            {
                txtAmount.ReadOnly = false;
                txtAmount.Clear();
                txtPrice.ReadOnly = false;
                txtPrice.Clear();
                txtCost.ReadOnly = false;
                txtCost.Clear();
            }
        }
    }
}
