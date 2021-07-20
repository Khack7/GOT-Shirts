using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU21_Final_Project.Data
{
    class DataSettings
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }

        public static DataSettings GetSettings(string selectedSetting)
        {
            DataSettings settings = null;
            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Settings WHERE SettingName = @SettingName"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("SettingName", selectedSetting);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            LoadFromReader(ref settings, sdr);
                        }
                    }
                    con.Close();
                }
            }
            return settings;
        }

        public static void SaveSetting(DataSettings settings)
        {
            using(SqlConnection con = DataCommon.StartConnection())
            {
                string sql = "UPDATE HackK21Su2332.Settings SET SettingValue = @SettingValue " +
                             "WHERE SettingName = @SettingName";
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("SettingValue", settings.SettingValue);
                    cmd.Parameters.AddWithValue("SettingName", settings.SettingName);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public static List<DataSettings> ListSettings()
        {
            List<DataSettings> settings = new List<DataSettings>();


            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Settings"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DataSettings setting = null;
                            LoadFromReader(ref setting, sdr);
                            settings.Add(setting);
                        }
                    }
                    con.Close();
                }
            }
            return settings;
        }

        private static void LoadFromReader(ref DataSettings settings, SqlDataReader sdr)
        {
            settings = new DataSettings
            {
                SettingName = sdr["SettingName"].ToString(),
                SettingValue = sdr["SettingValue"].ToString()
            };
        }
    }
}
