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
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int QuantityOnHand { get; set; }
        public double Cost { get; set; }
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

        public static void SaveProduct(DataProduct product)
        {

            using (SqlConnection con = DataCommon.StartConnection())
            {
                string sql;
                if (product.PersonID == 0)
                {
                    sql = "INSERT INTO HackK21Su2332.Person(NameFirst, NameLast, Address1, Address2, Address3," +
                            " City, State, Zipcode, Email, PhonePrimary, UserName, Password, AccountType," +
                            " SecurityQuestion1, SecurityAnswer1, SecurityQuestion2, SecurityAnswer2," +
                            " SecurityQuestion3, SecurityAnswer3)" +
                            " VALUES(@NameFirst, @NameLast, @Address1, @Address2, @Address3," +
                            " @City, @State, @Zipcode, @Email, @PhonePrimary, @UserName, @Password, @AccountType," +
                            " @SecurityQuestion1, @SecurityAnswer1, @SecurityQuestion2, @SecurityAnswer2, @SecurityQuestion3, @SecurityAnswer3);" +
                            "SELECT PersonID = SCOPE_IDENTITY()";
                }
                else
                {
                    sql = "UPDATE HackK21Su2332.Person SET NameFirst = @NameFirst, NameLast = @NameLast, Address1 = @Address1, " +
                          "Address2 = @Address2, Address3 = @Address3, City = @City, State = @State, " +
                          "Zipcode = @Zipcode, Email = @Email, PhonePrimary = @PhonePrimary, UserName = @UserName, " +
                          "Password = @Password, AccountType = @AccountType, SecurityQuestion1 = @SecurityQuestion1, SecurityAnswer1 = @SecurityAnswer1, " +
                          "SecurityQuestion2 = @SecurityQuestion2, SecurityAnswer2 = @SecurityAnswer2, SecurityQuestion3 = @SecurityQuestion3, SecurityAnswer3 = @SecurityAnswer3 " +
                          "WHERE PersonID = @PersonID";
                }
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (product.PersonID != 0)
                    {
                        cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
                    }
                    cmd.Parameters.AddWithValue("@NameFirst", person.NameFirst);
                    cmd.Parameters.AddWithValue("@NameLast", person.NameLast);
                    cmd.Parameters.AddWithValue("@Address1", person.Address1);
                    cmd.Parameters.AddWithValue("@Address2", person.Address2);
                    cmd.Parameters.AddWithValue("@Address3", person.Address3);
                    cmd.Parameters.AddWithValue("@City", person.City);
                    cmd.Parameters.AddWithValue("@State", person.State);
                    cmd.Parameters.AddWithValue("@Zipcode", person.Zipcode);
                    cmd.Parameters.AddWithValue("@Email", person.Email);
                    cmd.Parameters.AddWithValue("@PhonePrimary", person.PhonePrimary);
                    cmd.Parameters.AddWithValue("@UserName", person.UserName);
                    cmd.Parameters.AddWithValue("@Password", person.Password);
                    cmd.Parameters.AddWithValue("@AccountType", "Customer");
                    cmd.Parameters.AddWithValue("@SecurityQuestion1", person.SecurityQuestion1);
                    cmd.Parameters.AddWithValue("@SecurityAnswer1", person.SecurityAnswer1);
                    cmd.Parameters.AddWithValue("@SecurityQuestion2", person.SecurityQuestion2);
                    cmd.Parameters.AddWithValue("@SecurityAnswer2", person.SecurityAnswer2);
                    cmd.Parameters.AddWithValue("@SecurityQuestion3", person.SecurityQuestion3);
                    cmd.Parameters.AddWithValue("@SecurityAnswer3", person.SecurityAnswer3);

                    if (product.PersonID > 0)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                int.TryParse(sdr["PersonID"].ToString(), out int ID);
                                product.PersonID = ID;
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
