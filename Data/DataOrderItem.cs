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

        public DataProduct Product { get; set; }

        public static void SaveItems(SqlConnection con, List<DataOrderItem> lstItems, SqlTransaction transaction)
        {

            string sql = "INSERT INTO HackK21Su2332.OrderItem(OrderNum, ProductID, Quantity)" +
                        " VALUES(@OrderNum, @ProductID, @Quantity);" +
                        " SELECT OrderItemID = SCOPE_IDENTITY()";

            using (SqlCommand cmd = DataCommon.StartTextCommand(con, sql, transaction))
            {

                cmd.Parameters.Add("@OrderNum", SqlDbType.Int);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int);

                for (int intIndex = 0; intIndex < lstItems.Count; intIndex++)
                {
                    cmd.Parameters["@OrderNum"].Value = lstItems[intIndex].intOrderNum;
                    cmd.Parameters["@Quantity"].Value = lstItems[intIndex].intQuantity;
                    cmd.Parameters["@ProductID"].Value = lstItems[intIndex].intProductID;

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            if(!int.TryParse(sdr["OrderItemID"].ToString(), out int intItemID))
                            {

                            }
                            lstItems[intIndex].intOrderItemID = intItemID;
                        }
                    }
                }

            }
        }
    }
}
