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
    class DataMoney
    {
        public string SettingName { get; set; }

        public string SettingValue { get; set; }

        public static DataMoney GetValues(string name)
        {
            DataMoney result = null;

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Settings WHERE SettingName = @SettingName"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SettingName", name);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            if(!double.TryParse(sdr["SettingValue"].ToString(), out double dblAmount))
                            {
                                dblAmount = 0;
                            }

                            result = new DataMoney
                            {
                                SettingName = name,
                                SettingValue = dblAmount.ToString()
                            };
                        }
                    }
                }
                con.Close();
            }
            return result;
        }
    }
}
