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
    class DataMoney
    {
        public string SettingName { get; set; }

        public string SettingValue { get; set; }

        public static DataMoney GetValues(string name)
        {
            DataMoney result = null;

            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Settings WHERE SettingName = @SettingName"))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SettingName", name);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            double.TryParse(sdr["SettingValue"].ToString(), out double amount);

                            result = new DataMoney
                            {
                                SettingName = name,
                                SettingValue = amount.ToString()
                            };
                        }
                    }
                }
            }
            return result;
        }

        //TODO: CREATE METHOD TO BE USED BY MANAGER TO ADJUST SETTINGS
    }
}
