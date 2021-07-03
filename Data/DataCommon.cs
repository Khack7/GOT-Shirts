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
    class DataCommon
    {
        public static SqlConnection StartConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;
            var con = new SqlConnection(constr);
            con.Open();
            return con;
            
        }

        public static SqlCommand StartTextCommand(SqlConnection con, string sql, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Transaction = transaction;
            return cmd;
        }
    }
}
