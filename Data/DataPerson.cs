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
    class DataPerson
    {
        public int PersonID { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string PhonePrimary { get; set; }
        public string PhoneSecondary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer3 { get; set; }

        public static DataPerson GetPerson(string UserName)
        {
            DataPerson result = null;
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Person WHERE UserName = @UserName"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Connection = con;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                int.TryParse(sdr["PersonID"].ToString(), out int p);

                                result = new DataPerson
                                {
                                    PersonID = p,
                                    NameFirst = sdr["NameFirst"].ToString(),
                                    NameLast = sdr["NameLast"].ToString(),
                                    Address1 = sdr["Address1"].ToString(),
                                    Address2 = sdr["Address2"].ToString(),
                                    Address3 = sdr["Address3"].ToString(),
                                    City = sdr["City"].ToString(),
                                    Zipcode = sdr["Zipcode"].ToString(),
                                    State = sdr["State"].ToString(),
                                    Email = sdr["Email"].ToString(),
                                    PhonePrimary = sdr["PhonePrimary"].ToString(),
                                    PhoneSecondary = sdr["PhoneSecondary"].ToString(),
                                    UserName = sdr["UserName"].ToString(),
                                    Password = sdr["Password"].ToString(),
                                    AccountType = sdr["AccountType"].ToString(),
                                    SecurityQuestion1 = sdr["SecurityQuestion1"].ToString(),
                                    SecurityAnswer1 = sdr["SecurityAnswer1"].ToString(),
                                    SecurityQuestion2 = sdr["SecurityQuestion2"].ToString(),
                                    SecurityAnswer2 = sdr["SecurityAnswer2"].ToString(),
                                    SecurityQuestion3 = sdr["SecurityQuestion3"].ToString(),
                                    SecurityAnswer3 = sdr["SecurityAnswer3"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static void SavePerson(DataPerson person)
        {
            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql;
                    if (person.PersonID == 0)
                    {
                        sql = "INSERT INTO HackK21Su2332.Person(NameFirst, NameLast, Address1, Address2, Address3," +
                                " City, State, Zipcode, Email, PhonePrimary, UserName, Password, AccountType," +
                                " SecurityQuestion1, SecurityAnswer1, SecurityQuestion2, SecurityAnswer2," +
                                " SecurityQuestion3, SecurityAnswer3)" +
                                " VALUES(@NameFirst, @NameLast, @Address1, @Address2, @Address3," +
                                " @City, @State, @Zipcode, @Email, @PhonePrimary, @UserName, @Password, @AccountType," +
                                " @SecurityQuestion1, @SecurityAnswer1, @SecurityQuestion2, @SecurityAnswer2, @SecurityQuestion3, @SecurityAnswer3);" +
                                "SELECT PersonID = SCOPE_IDENTITY()";
                    }
                    else
                    {
                        sql = "UPDATE HackK21Su2332.Person SET NameFirst = @NameFirst, NameLast = @NameLast, Address1 = @Address1, " +
                              "Address2 = @Address2, Address3 = @Address3, City = @City, State = @State, " +
                              "Zipcode = @Zipcode, Email = @Email, PhonePrimary = @PhonePrimary, UserName = @UserName, " +
                              "Password = @Password, AccountType = @AccountType, SecurityQuestion1 = @SecurityQuestion1, SecurityAnswer1 = @SecurityAnswer1, " +
                              "SecurityQuestion2 = @SecurityQuestion2, SecurityAnswer2 = @SecurityAnswer2, SecurityQuestion3 = @SecurityQuestion3, SecurityAnswer3 = @SecurityAnswer3 " +
                              "WHERE PersonID = @PersonID";
                    }
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        if (person.PersonID != 0)
                        {
                            cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
                        }
                        cmd.Parameters.AddWithValue("@NameFirst", person.NameFirst);
                        cmd.Parameters.AddWithValue("@NameLast", person.NameLast);
                        cmd.Parameters.AddWithValue("@Address1", person.Address1);
                        cmd.Parameters.AddWithValue("@Address2", person.Address2);
                        cmd.Parameters.AddWithValue("@Address3", person.Address3);
                        cmd.Parameters.AddWithValue("@City", person.City);
                        cmd.Parameters.AddWithValue("@State", person.State);
                        cmd.Parameters.AddWithValue("@Zipcode", person.Zipcode);
                        cmd.Parameters.AddWithValue("@Email", person.Email);
                        cmd.Parameters.AddWithValue("@PhonePrimary", person.PhonePrimary);
                        cmd.Parameters.AddWithValue("@UserName", person.UserName);
                        cmd.Parameters.AddWithValue("@Password", person.Password);
                        cmd.Parameters.AddWithValue("@AccountType", "Customer");
                        cmd.Parameters.AddWithValue("@SecurityQuestion1", person.SecurityQuestion1);
                        cmd.Parameters.AddWithValue("@SecurityAnswer1", person.SecurityAnswer1);
                        cmd.Parameters.AddWithValue("@SecurityQuestion2", person.SecurityQuestion2);
                        cmd.Parameters.AddWithValue("@SecurityAnswer2", person.SecurityAnswer2);
                        cmd.Parameters.AddWithValue("@SecurityQuestion3", person.SecurityQuestion3);
                        cmd.Parameters.AddWithValue("@SecurityAnswer3", person.SecurityAnswer3);

                        if (person.PersonID > 0)
                        {

                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                if (sdr.Read())
                                {
                                    int.TryParse(sdr["PersonID"].ToString(), out int ID);
                                    person.PersonID = ID;
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
