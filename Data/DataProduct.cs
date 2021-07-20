using System;
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

            int.TryParse(sdr["ProductID"].ToString(), out int p);
            int.TryParse(sdr["QuantityOnHand"].ToString(), out int q);
            double.TryParse(sdr["Cost"].ToString(), out double cost);
            double.TryParse(sdr["Price"].ToString(), out double price);
            object img = sdr["ProductImage"];
            Image image = null;
            if(img != DBNull.Value)
            {
                byte[] imgData = (byte[])img;
                image = GetImageFromData(imgData);
            }
            product = new DataProduct
            {
                ProductID = p,
                QuantityOnHand = q,
                Color = sdr["Color"].ToString(),
                Size = sdr["Size"].ToString(),
                Cost = cost,
                Price = price,
                ProductImage = image
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
        //USED ONCE DURING DEVELOPMENT. NOT USED NORMAL USE
        //HOWEVER WITH ALTERATION TO THE PROGRAM CAN BE USED TO IMPLEMENT NEW PRODUCTS
        public static void SaveImage(Image image, string color)
        {
            string sql;

            sql = "UPDATE HackK21Su2332.Products SET ProductImage = @ProductImage " +
                  "WHERE Color = @Color";

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    byte[] imgData = DataProduct.GetImageData(image);
                    cmd.Parameters.Add("@ProductImage", SqlDbType.Image, imgData.Length).Value = imgData;
                    cmd.Parameters.AddWithValue("@Color", color);

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
