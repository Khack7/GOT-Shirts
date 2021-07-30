using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSetPerson.Person' table. You can move, or remove it, as needed.
                this.personTableAdapter.Fill(this.dataSetPerson.Person);
                dgvPerson.Columns[7].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //VARIABLES THAT CAN BE EDITED. ID STORED JUST FOR REFERENCE SHOULD ANY MAJOR CHANGES HAPPEN
        public static string strFirstName, strLastName, strUserName, strAccountType, strPhone, strEmail;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bolIsDeleted == true)
            {
                MessageBox.Show("This user has been deleted", "Deleted user", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (strAccountType == "Manager")
            {
                try
                {
                    DataPerson person = DataPerson.GetPerson(strUserName);

                    frmEditManagerPopUp frmPopUp = new frmEditManagerPopUp();
                    frmPopUp.ShowDialog();

                    if (string.Equals(frmEditManagerPopUp.strSelectedUserName, person.UserName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        frmManagerEditUser frmEditUser = new frmManagerEditUser();
                        this.Hide();
                        frmEditUser.ShowDialog();
                        this.Show();
                        this.personTableAdapter.Fill(this.dataSetPerson.Person);
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission to alter this account", "Access Denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                frmManagerEditUser frmEditUser = new frmManagerEditUser();
                this.Hide();
                frmEditUser.ShowDialog();
                this.Show();
                this.personTableAdapter.Fill(this.dataSetPerson.Person);
            }
        }

        private void btnDeleteOrRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DataPerson person = DataPerson.GetPerson(strUserName);

                if (person.Deleted == false)
                {
                    if (strAccountType == "Manager")
                    {
                        frmEditManagerPopUp frmPopUp = new frmEditManagerPopUp();
                        frmPopUp.ShowDialog();

                        if (frmEditManagerPopUp.strSelectedUserName == person.UserName)
                        {
                            DialogResult dr = MessageBox.Show("Are you sure you want to delete this user?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                person.Deleted = true;
                                DataPerson.SavePerson(person);
                                this.personTableAdapter.Fill(this.dataSetPerson.Person);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You do not have permission to alter this account", "Access Denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete this user?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            person.Deleted = true;
                            DataPerson.SavePerson(person);
                            MessageBox.Show("Account has been Deleted", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.personTableAdapter.Fill(this.dataSetPerson.Person);
                        }
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to recover this user?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        person.Deleted = false;
                        DataPerson.SavePerson(person);
                        MessageBox.Show("Account has been restored", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.personTableAdapter.Fill(this.dataSetPerson.Person);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Manage_Users_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataView dv;
            dv = new DataView(dataSetPerson.Tables[0], "AccountType = 'Employee' OR AccountType = 'Manager'", "AccountType Desc", DataViewRowState.CurrentRows);
            dgvPerson.DataSource = dv;
            Cursor.Current = Cursors.Default;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataView dv;
            dv = new DataView(dataSetPerson.Tables[0], "AccountType = 'Customer'", "AccountType Desc", DataViewRowState.CurrentRows);
            dgvPerson.DataSource = dv;
            Cursor.Current = Cursors.Default;
        }

        public static int intPersonID;
        bool bolIsDeleted = false;
        private void dgvPerson_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPerson.SelectedRows)
            {
                if (!int.TryParse(row.Cells[0].Value.ToString(), out int intID))
                {
                    MessageBox.Show("Error occurred while getting selected ID. Please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPerson.ClearSelection();
                    btnEdit.Enabled = false;
                    btnEdit.Enabled = false;
                    break;
                }
                if (!bool.TryParse(row.Cells[8].Value.ToString(), out bool bolStatus))
                {
                    dgvPerson.ClearSelection();
                    MessageBox.Show("Error occurred while getting person's account status. Please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEdit.Enabled = false;
                    btnEdit.Enabled = false;
                    break;
                }
                intPersonID = intID;
                strFirstName = row.Cells[1].Value.ToString();
                strLastName = row.Cells[2].Value.ToString();
                strEmail = row.Cells[3].Value.ToString();
                strPhone = row.Cells[4].Value.ToString();
                strUserName = row.Cells[5].Value.ToString();
                strAccountType = row.Cells[6].Value.ToString();
                bolIsDeleted = bolStatus;

                btnEdit.Enabled = true;
                btnDeleteOrRestore.Enabled = true;
            }
        }
    }
}
