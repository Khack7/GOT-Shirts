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
    class DataOrderItem
    {
        public int intOrderItemID { get; set; }

        public int intOrderNum { get; set; }

        public int intProductID { get; set; }

        public int intQuantity { get; set; }

        public static void SaveItems(SqlConnection con, List<DataOrderItem> items, SqlTransaction transaction)
        {

            string sql = "INSERT INTO HackK21Su2332.OrderItem(OrderNum, ProductID, Quantity)" +
                        " VALUES(@OrderNum, @ProductID, @Quantity);" +
                        " SELECT OrderItemID = SCOPE_IDENTITY()";

            using (SqlCommand cmd = DataCommon.StartTextCommand(con, sql, transaction))
            {

                cmd.Parameters.Add("@OrderNum", SqlDbType.Int);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int);

                for (int i = 0; i < items.Count; i++)
                {
                    cmd.Parameters["@OrderNum"].Value = items[i].intOrderNum;
                    cmd.Parameters["@Quantity"].Value = items[i].intQuantity;
                    cmd.Parameters["@ProductID"].Value = items[i].intProductID;

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            int.TryParse(sdr["OrderItemID"].ToString(), out int num);
                            items[i].intOrderItemID = num;
                        }
                    }
                }

            }
        }
    }
}
