﻿//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the manager can add new products or update existing ones
//*******************************************
//*******************************************
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

        private Image resizeImage(Image src, int width, int height)
        {
            Image bmpNewImage = new Bitmap(width, height);
            using (Graphics gfxNewImage = Graphics.FromImage(bmpNewImage))
            {
                gfxNewImage.DrawImage(
                    src,
                    new Rectangle(0, 0, bmpNewImage.Width, bmpNewImage.Height),
                    0,
                    0,
                    src.Width,
                    src.Height,
                    GraphicsUnit.Pixel
                );
            }
            return bmpNewImage;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(frmInventory.bolWantsUpdate == true)
                {
                    string strColor = txtColor.Text;
                    Image image = resizeImage(pbxShirt.Image, pbxShirt.Width, pbxShirt.Height);

                    if (txtColor.Text == "")
                    {
                        MessageBox.Show("Please type the color you'd like to update and esure it is spelled correctly", "No color!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to update these shirt's images?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            List<string> lstSizes = new List<string>();
                            lstSizes.Add("Small");
                            lstSizes.Add("Medium");
                            lstSizes.Add("Large");

                            bool bolProductFound = false;

                            for (int intIndex = 0; intIndex < lstSizes.Count; intIndex++)
                            {
                                DataProduct checkProduct = DataProduct.GetProduct(strColor, lstSizes[intIndex]);
                                if (checkProduct != null)
                                {
                                    bolProductFound = true;
                                    break;
                                }
                            }

                            if (bolProductFound == true)
                            {
                                Cursor.Current = Cursors.Default;
                                DataProduct.SaveImage(image, strColor);
                                MessageBox.Show("Image Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("This product doesn't currently exist", "No product(s) found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    if (txtColor.Text == "" || txtAmount.Text == "" || txtCost.Text == "" ||
                   txtPrice.Text == "" || pbxShirt.Image == null)
                    {
                        MessageBox.Show("Please fill out all fields", "Missing Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        DataProduct product = new DataProduct();

                        string strColor = "";

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
                        if (!int.TryParse(txtAmount.Text, out int intQuantity))
                        {
                            throw new Exception("Invalid quantity inputted");
                        }

                        product.QuantityOnHand = intQuantity;
                        product.Size = cboSize.SelectedItem.ToString();
                        product.Price = Math.Round(dblPrice, 2);
                        product.Cost = Math.Round(dblCost, 2);
                        product.ProductImage = resizeImage(pbxShirt.Image, pbxShirt.Width, pbxShirt.Height);
                        product.Deleted = false;

                        DataProduct checkProduct = DataProduct.GetProduct(product.Color, product.Size);

                        if (checkProduct != null)
                        {
                            Cursor.Current = Cursors.Default;
                            DialogResult dr = MessageBox.Show("This product already exists! Would you like to update it?", "Duplicate Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            
                            if(dr == DialogResult.Yes)
                            {
                                DataProduct.SaveImage(product.ProductImage, product.Color);
                                MessageBox.Show("Image Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            DataProduct.AddProduct(product);
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Product Added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        btnUpload.Enabled = false;
                        txtAmount.Clear();
                        txtColor.Clear();
                        txtPrice.Clear();
                        txtCost.Clear();

                        txtAmount.ReadOnly = true;
                        txtColor.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        txtCost.ReadOnly = true;
                        cboSize.Enabled = false;
                        cboSize.SelectedIndex = -1;

                        pbxShirt.Image = null;
                    }
                }               
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
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
                    cboSize.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Add_Product_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            cboSize.Items.Add("Small");
            cboSize.Items.Add("Medium");
            cboSize.Items.Add("Large");

            if(frmInventory.bolWantsUpdate == true)
            {
                txtColor.Text = frmInventory.strUpdatingColor;
                txtColor.ReadOnly = true;
                txtAmount.Enabled = false;
                txtPrice.Enabled = false;
                txtCost.Enabled = false;
                lblPrice.Enabled = false;
                lblQuantity.Enabled = false;
                lblCost.Enabled = false;
                cboSize.Enabled = false;
                lblSize.Enabled = false;
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }      
    }
}
