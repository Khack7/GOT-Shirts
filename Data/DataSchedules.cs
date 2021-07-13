using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU21_Final_Project.Data
{
    class DataSchedules
    {
        public int ScheduleID { get; set; }
        public int PersonID { get; set; }
        public string DayOfWeek { get; set; }
        public string JobDescription { get; set; }

        public static void CreateSchedule(int person)
        {
            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("TODO"))
                {

                }
            }
        }

        //public static List<DataSchedules> ListCodes()
        //{
        //    List<DataSchedules> codes = new List<DataSchedules>();

        //    using (SqlConnection con = DataCommon.StartConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts"))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    DataSchedules code = null;
        //                    LoadFromReader(ref code, sdr);
        //                    codes.Add(code);
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return codes;
        //}

        //private static void LoadFromReader(ref DataSchedules code, SqlDataReader sdr)
        //{
        //    int.TryParse(sdr["PercentOff"].ToString(), out int p);
        //    bool.TryParse(sdr["Active"].ToString(), out bool b);

        //    code = new DataSchedules
        //    {
        //        PercentOff = p,
        //        Active = b,
        //        DiscountCode = sdr["DiscountCode"].ToString(),
        //    };
        //}
    }
}
