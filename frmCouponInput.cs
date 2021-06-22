using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmCouponInput : Form
    {
        public frmCouponInput()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string CouponCode;
        public static int percentOff;
        public static bool CodeUsed = false;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;

            string constr = ConfigurationManager.ConnectionStrings["SU21_Final_Project.Properties.Settings.ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM HackK21Su2332.Discounts"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                //code == sdr["DiscountCode"].ToString() <- previous iteration
                                if (code.Equals(sdr["DiscountCode"].ToString(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    int.TryParse(sdr["Active"].ToString(), out int check);

                                    if(check == 1)
                                    {
                                        CouponCode = txtCode.Text;
                                        MessageBox.Show("Code accepted! Your discount will be applied at checkout", "Accepted!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        int.TryParse(sdr["PercentOff"].ToString(), out int p);
                                        percentOff = p;
                                        CodeUsed = true;
                                        
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("This code is currently inactive", "Code unavailable for use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("This code doesn't exist", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are currently no coupons created", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCouponInput_Load(object sender, EventArgs e)
        {
            txtCode.MaxLength = 5;
        }
    }
}
