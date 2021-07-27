using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtColor.Text == "" || txtAmount.Text == "" || txtCost.Text == "" ||
                   txtPrice.Text == "" || pbxShirt.Image == null)
                {
                    MessageBox.Show("Please fill out all fields", "Missing Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataProduct product = new DataProduct();

                    List<string> lstSizes = new List<string>();
                    lstSizes.Add("Small");
                    lstSizes.Add("Medium");
                    lstSizes.Add("Large");

                    string strColor = "";

                    for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                    {
                        strColor = txtColor.Text;

                        strColor.ToLower();

                        strColor = char.ToUpper(strColor[0]) + strColor.Substring(1);

                        product.Color = strColor;

                        if (!double.TryParse(txtPrice.Text, out double dblPrice))
                        {
                            throw new Exception("Invalid price inputted");
                        }
                        if (!double.TryParse(txtCost.Text, out double dblCost))
                        {
                            throw new Exception("Invalid cost inputted");
                        }
                        if(!int.TryParse(txtAmount.Text, out int intQuantity))
                        {
                            throw new Exception("Invalid quantity inputted");
                        }

                        product.QuantityOnHand = intQuantity;
                        product.Size = lstSizes[intIndex];
                        product.Price = dblPrice;
                        product.Cost = dblCost;
                        product.ProductImage = pbxShirt.Image;

                        DataProduct.AddProduct(product);
                    }
                    MessageBox.Show("Product Added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnUpload.Enabled = false;
                    txtAmount.Clear();
                    txtColor.Clear();
                    txtPrice.Clear();
                    txtCost.Clear();

                    txtAmount.ReadOnly = true;
                    txtColor.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtCost.ReadOnly = true;

                    pbxShirt.Image.Dispose();
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strPath;
            
            try
            {
                OpenFileDialog ofdFile = new OpenFileDialog();
                ofdFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofdFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                ofdFile.Title = "Select an image";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    strPath = ofdFile.FileName;

                    pbxShirt.Image = new Bitmap(strPath);
                    btnUpload.Enabled = true;
                    txtColor.ReadOnly = false;
                    txtAmount.ReadOnly = false;
                    txtCost.ReadOnly = false;
                    txtPrice.ReadOnly = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
