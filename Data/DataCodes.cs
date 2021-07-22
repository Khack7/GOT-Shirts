using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU21_Final_Project.Data
{
    class DataCodes
    {
        public bool Active { get; set; }

        public int PercentOff { get; set; }

        public string DiscountCode { get; set; }

        public static DataCodes GetCode(string code)
        {
            DataCodes result = null;

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts WHERE DiscountCode = @DiscountCode"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DiscountCode", code);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        result = LoadCode(sdr);
                    }
                }
                con.Close();
            }

            return result;
        }

        private static DataCodes LoadCode(SqlDataReader sdr)
        {
            bool bolActive = false;
            int intPercent = 0;

            DataCodes result = null;
            if (sdr.Read())
            {
                if (bool.TryParse(sdr["Active"].ToString(), out bool A))
                {
                    bolActive = A;
                }
                else
                {
                    bolActive = false;
                }

                if (int.TryParse(sdr["PercentOff"].ToString(), out int P))
                {
                    intPercent = P;
                }
                else
                {
                    intPercent = 0;
                }
                result = new DataCodes
                {
                    DiscountCode = sdr["DiscountCode"].ToString(),
                    Active = bolActive,
                    PercentOff = intPercent
                };
            }
            return result;
        }

        public static void saveCode(DataCodes code)
        {
            using (SqlConnection con = DataCommon.StartConnection())
            {
                string sql;

                sql = "INSERT INTO HackK21Su2332.Discounts(Active, PercentOff, DiscountCode) " +
                      "VALUES(@Active, @PercentOff, @DiscountCode)";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Active", code.Active);
                    cmd.Parameters.AddWithValue("@PercentOff", code.PercentOff);
                    cmd.Parameters.AddWithValue("@DiscountCode", code.DiscountCode);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public static List<DataCodes> ListCodes()
        {
            List<DataCodes> codes = new List<DataCodes>();

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DataCodes code = null;
                            LoadFromReader(ref code, sdr);
                            codes.Add(code);
                        }
                    }
                    con.Close();
                }
            }
            return codes;
        }

        public static List<DataCodes> ListActiveOnlyCodes()
        {
            List<DataCodes> codes = new List<DataCodes>();

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts WHERE Active = @Active"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Active", true);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DataCodes code = null;
                            LoadFromReader(ref code, sdr);
                            codes.Add(code);
                        }
                    }
                    con.Close();
                }
            }
            return codes;
        }

        public static List<DataCodes> ListInactiveCodes()
        {
            List<DataCodes> codes = new List<DataCodes>();

            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts WHERE Active = @Active"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Active", false);
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DataCodes code = null;
                            LoadFromReader(ref code, sdr);
                            codes.Add(code);
                        }
                    }
                    con.Close();
                }
            }
            return codes;
        }

        private static void LoadFromReader(ref DataCodes code, SqlDataReader sdr)
        {
            if(!int.TryParse(sdr["PercentOff"].ToString(), out int intPercent))
            {
                intPercent = 0;
            }
            if(!bool.TryParse(sdr["Active"].ToString(), out bool bolStatus))
            {
                bolStatus = false;
            }

            code = new DataCodes
            {
                PercentOff = intPercent,
                Active = bolStatus,
                DiscountCode = sdr["DiscountCode"].ToString(),
            };
        }

        public static void CodeActivity(string code, bool bolStatus)
        {
            using (SqlConnection con = DataCommon.StartConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE HackK21Su2332.Discounts " +
                                                       "SET Active = @Active WHERE DiscountCode = @DiscountCode"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Active", bolStatus);
                    cmd.Parameters.AddWithValue("@DiscountCode", code);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}


