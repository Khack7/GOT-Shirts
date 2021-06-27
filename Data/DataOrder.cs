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
    class DataOrder
    {
        public int OrderNum { get; set; }

        public int PersonID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        public string DiscountCode { get; set; }

        public double Shipping { get; set; }

        public string CardType { get; set; }

        public int CardNumber { get; set; }

        public string CardExperation { get; set; }

        public static void SaveOrder(DataOrder order)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "INSERT INTO HackK21Su2332.Orders(PersonID, OrderDate, DiscountCode, Shipping," +
                            " CardType, CardNumber, CardExperation)" +
                            " VALUES(@PersonID, @OrderDate, @DiscountCode, @Shipping, @CardType, @CardNumber, @CardExperation);" +
                            " SELECT OrderNum = SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    if (order.OrderNum != 0)
                    {
                        cmd.Parameters.AddWithValue("@OrderNum", order.OrderNum);
                    }
                    cmd.Parameters.AddWithValue("@PersonID", order.PersonID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@DiscountCode", order.DiscountCode);
                    cmd.Parameters.AddWithValue("@Shipping", order.Shipping);
                    cmd.Parameters.AddWithValue("@CardType", order.CardType);
                    cmd.Parameters.AddWithValue("@CardNumber", order.CardNumber);
                    cmd.Parameters.AddWithValue("@CardExperation", order.CardExperation);

                    if (order.OrderNum > 0)
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
                                order.OrderNum = num;
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
