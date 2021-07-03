using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU21_Final_Project.Data
{
    public class DataProduct
    {
        public int ProductID {get; set;}
        public string Color {get; set;}
        public string Size {get; set;}
        public int QuantityOnHand {get; set;}
        public double Cost {get; set;}
        public double Price { get; set; }

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
                        LoadFromReader(ref product, sdr);
                    }
                    con.Close();
                }
            }
            return product;
        }

        public static DataProduct GetProduct(int productID)
        {
            DataProduct product = null;
          
            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Products WHERE ProductID = @ProductID"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        LoadFromReader(ref product, sdr);
                    }
                    con.Close();
                }
            }
            return product;
        }
        private static void LoadFromReader(ref DataProduct product, SqlDataReader sdr)
        {
            if (sdr.Read())
            {
                int.TryParse(sdr["ProductID"].ToString(), out int p);
                int.TryParse(sdr["QuantityOnHand"].ToString(), out int q);
                double.TryParse(sdr["Cost"].ToString(), out double cost);
                double.TryParse(sdr["Price"].ToString(), out double price);

                product = new DataProduct
                {
                    ProductID = p,
                    QuantityOnHand = q,
                    Color = sdr["Color"].ToString(),
                    Size = sdr["Size"].ToString(),
                    Cost = cost,
                    Price = price
                };
            }

        }
    }
}
