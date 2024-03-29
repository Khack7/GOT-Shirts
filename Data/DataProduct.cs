﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SU21_Final_Project.Data
{
    public class DataProduct
    {
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int QuantityOnHand { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public Image ProductImage { get; set; }
        public bool Deleted { get; set; }

        public static DataProduct GetProduct(string color, string size)
        {
            DataProduct product = null;

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Products WHERE Color = @Color AND Size = @Size"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Color", color);
                    cmd.Parameters.AddWithValue("@Size", size);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            LoadFromReader(ref product, sdr);
                        }
                    }
                    con.Close();
                }
            }
            return product;
        }

        public static void ReduceProductQuantity(SqlConnection con, int productID, int qtyToReduce, SqlTransaction transaction)
        {
            string sql = "UPDATE HackK21Su2332.Products SET QuantityOnHand = QuantityOnHand - @QuantityToReduce " +
                                                   "WHERE ProductID = @ProductID";

            using (SqlCommand cmd = DataCommon.StartTextCommand(con, sql, transaction))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@QuantityToReduce", qtyToReduce);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }

        public static List<DataProduct> ListProducts()
        {
            List<DataProduct> products = new List<DataProduct>();

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Products"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DataProduct product = null;
                            LoadFromReader(ref product, sdr);
                            products.Add(product);
                        }
                    }
                    con.Close();
                }
            }
            return products;
        }

        private static void LoadFromReader(ref DataProduct product, SqlDataReader sdr)
        {

            if(!int.TryParse(sdr["ProductID"].ToString(), out int intProduct))
            {
                intProduct = 0;
            }
            if(!int.TryParse(sdr["QuantityOnHand"].ToString(), out int intQuantity))
            {
                intQuantity = 0;
            }
            if(!double.TryParse(sdr["Cost"].ToString(), out double dblCost))
            {
                dblCost = 0;
            }
            if(!double.TryParse(sdr["Price"].ToString(), out double dblPrice))
            {
                dblPrice = 0;
            }
            if (!bool.TryParse(sdr["Deleted"].ToString(), out bool bolStatus))
            {
                bolStatus = true;
            }
            object objImage = sdr["ProductImage"];
            Image image = null;
            if(objImage != DBNull.Value)
            {
                byte[] bytImgData = (byte[])objImage;
                image = GetImageFromData(bytImgData);
            }
            product = new DataProduct
            {
                ProductID = intProduct,
                QuantityOnHand = intQuantity,
                Color = sdr["Color"].ToString(),
                Size = sdr["Size"].ToString(),
                Cost = dblCost,
                Price = dblPrice,
                ProductImage = image,
                Deleted = bolStatus
            };
        }

        public static void SaveProduct(DataProduct product)
        {

            using (SqlConnection con = DataCommon.StartConnection())
            {
                string sql;

                sql = "UPDATE HackK21Su2332.Products SET QuantityOnHand = @QuantityOnHand, " +
                      "Cost = @Cost, Price = @Price WHERE Color = @Color AND Size = @Size";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Color", product.Color);
                    cmd.Parameters.AddWithValue("@Size", product.Size);
                    cmd.Parameters.AddWithValue("@QuantityOnHand", product.QuantityOnHand);
                    cmd.Parameters.AddWithValue("@Cost", product.Cost);
                    cmd.Parameters.AddWithValue("@Price", product.Price);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        //ALLOWS USER TO UPDATE PRODUCT IMAGES IF/WHEN NEEDED
        public static void SaveImage(Image image, string strColor)
        {
            string strSQL;

            strSQL = "UPDATE HackK21Su2332.Products SET ProductImage = @ProductImage " +
                  "WHERE Color = @Color";

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    byte[] imgData = DataProduct.GetImageData(image);
                    cmd.Parameters.Add("@ProductImage", SqlDbType.Image, imgData.Length).Value = imgData;
                    cmd.Parameters.AddWithValue("@Color", strColor);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public static void AddProduct(DataProduct product)
        {
            string strSQL;

            strSQL = "INSERT INTO HackK21Su2332.Products(Color, Size, QuantityOnHand, Cost, Price, ProductImage, Deleted) " +
                     "VALUES(@Color, @Size, @QuantityOnHand, @Cost, @Price, @ProductImage, @Deleted)";

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    byte[] imgData = DataProduct.GetImageData(product.ProductImage);

                    cmd.Parameters.AddWithValue("@Color", product.Color);
                    cmd.Parameters.AddWithValue("@Size", product.Size);
                    cmd.Parameters.AddWithValue("@QuantityOnHand", product.QuantityOnHand);
                    cmd.Parameters.AddWithValue("@Cost", product.Cost);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.Add("@ProductImage", SqlDbType.Image, imgData.Length).Value = imgData;
                    cmd.Parameters.AddWithValue("@Deleted", false);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public static void DeleteOrRestoreProduct(DataProduct product)
        {
            string strSQL;

            strSQL = "UPDATE HackK21Su2332.Products SET Deleted = @Deleted WHERE Color = @Color AND Size = @Size";

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Color", product.Color);
                    cmd.Parameters.AddWithValue("@Size", product.Size);
                    cmd.Parameters.AddWithValue("@Deleted", product.Deleted);
                    
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public static byte[] GetImageData(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, ImageFormat.Png);
                return mStream.ToArray();
            }
        }

        public static Image GetImageFromData(byte[] imgData)
        {
            using (MemoryStream mStream = new MemoryStream(imgData))
            {
                return Image.FromStream(mStream);
            }
        }
    }
}
