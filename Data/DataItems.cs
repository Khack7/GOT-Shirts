using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project.Data
{
    class DataItems
    {
        public int OrderNum { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public static void SaveItems(DataItems items)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = "INSERT INTO HackK21Su2332.OrderItem(OrderNum, ProductID, Quantity, Price)" +
                                " VALUES(@OrderNum, @ProductID, @Quantity, @Price);" +
                                " SELECT OrderItemID = SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;

                        if (items.OrderNum != 0)
                        {
                            cmd.Parameters.AddWithValue("@OrderNum", items.OrderNum);
                        }
                        cmd.Parameters.AddWithValue("ProductID", items.ProductID);
                        cmd.Parameters.AddWithValue("Quantity", items.Quantity);
                        cmd.Parameters.AddWithValue("Price", items.Price);

                        if (items.OrderNum > 0)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    int.TryParse(sdr["OrderNum"].ToString(), out int num);
                                    items.OrderNum = num;
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
