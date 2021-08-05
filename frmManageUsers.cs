//*******************************************
//*******************************************
// Programmer: Kevin Hack
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: A t-shirts selling application used to sell and ship shirts across the U.S.
//*******************************************
// Form Purpose: This is the form where the manager can view all users and delete/alter them as needed
//*******************************************
//*******************************************
using SU21_Final_Project.Classes;
using SU21_Final_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                try
                {
                    this.personTableAdapter.Fill(this.dataSetPerson.Person);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        enum View
        {
            All,
            Employee,
            Customer
        }

        View view = View.All;
        int intTotalRows = 0;

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPerson.SelectedRows)
            {
                intTotalRows++;
            }
            if (intTotalRows == 0)
            {
                MessageBox.Show("No row selected", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (intTotalRows > 1)
            {
                MessageBox.Show("Please only select 1 row", "Too many selected!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (view == View.Employee)
                {
                    try
                    {
                        string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        int intSelectedRows = 0;
                        string strFileName = "";

                        SaveFileDialog sfdFile = new SaveFileDialog();

                        foreach (DataGridViewRow row in dgvPerson.SelectedRows)
                        {
                            intSelectedRows++;
                        }

                        if (intSelectedRows == 0)
                        {
                            MessageBox.Show("Please select a row", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            foreach (DataGridViewRow row in dgvPerson.SelectedRows)
                            {
                                strFileName = $"GOT Shirts-{row.Cells[6].Value}-{row.Cells[2].Value.ToString()}-{row.Cells[1].Value}.html";


                                sfdFile.FileName = strFileName;
                                sfdFile.Title = "Select save location.";
                                sfdFile.InitialDirectory = strPath;

                                if (sfdFile.ShowDialog() == DialogResult.OK)
                                {
                                    Cursor.Current = Cursors.WaitCursor;

                                    strPath = Path.GetDirectoryName(sfdFile.FileName);

                                    strFileName = Path.Combine(strPath, strFileName);

                                    DataPerson person = DataPerson.GetPerson(row.Cells[5].Value.ToString()); ;

                                    GenerateReport(person, strFileName);

                                    System.Diagnostics.Process.Start(strFileName);
                                }
                            }
                        }
                        intSelectedRows = 0;
                        intTotalRows = 0;
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an employee", "No employee selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateReport(DataPerson person, string strFileName)
        {
            string strReport = Receipt.LoadPersonInfoTemplate();

            strReport = strReport.Replace("{Date}", DateTime.Now.ToString());
            strReport = strReport.Replace("{ID}", person.PersonID.ToString());

            StringBuilder itemHTML = new StringBuilder();

            itemHTML.AppendFormat("<tr>");
            itemHTML.AppendFormat("    <td>{0}</td>", person.NameFirst);
            itemHTML.AppendFormat("    <td>{0}</td>", person.NameLast);
            itemHTML.AppendFormat("    <td>{0:C2}</td>", person.PayRate);
            itemHTML.AppendFormat("    <td>{0}</td>", person.AccountType);
            itemHTML.AppendFormat("    <td>{0}</td>", person.Email);
            itemHTML.AppendFormat("    <td>{0}</td>", person.PhonePrimary);
            itemHTML.AppendFormat("</tr>");

            strReport = strReport.Replace("{Info}", itemHTML.ToString());

            using (FileStream fs = new FileStream(strFileName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(strReport);
                }
            }
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                view = View.Employee;
                btnViewEmployee.Enabled = true;
                DataView dv;
                dv = new DataView(dataSetPerson.Tables[0], "AccountType = 'Employee' OR AccountType = 'Manager'", "AccountType Desc", DataViewRowState.CurrentRows);
                dgvPerson.DataSource = dv;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                view = View.Customer;
                btnViewEmployee.Enabled = false;
                DataView dv;
                dv = new DataView(dataSetPerson.Tables[0], "AccountType = 'Customer'", "AccountType Desc", DataViewRowState.CurrentRows);
                dgvPerson.DataSource = dv;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static int intPersonID;
        bool bolIsDeleted = false;
        private void dgvPerson_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
