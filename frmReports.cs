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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSetReports.Orders' table. You can move, or remove it, as needed.
                this.ordersTableAdapter.Fill(this.dataSetReports.Orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnViewToday_Click(object sender, EventArgs e)
        {
            view = currentView.ViewDay;

            DataView dv;
            dv = new DataView(dataSetReports.Tables[0], $"OrderDate = '{DateTime.Today}'", "OrderNum Desc", DataViewRowState.CurrentRows);
            dgvReports.DataSource = dv;
        }

        private void btnViewWeek_Click(object sender, EventArgs e)
        {
            view = currentView.ViewWeek;

            DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            var endOfWeek = startOfWeek.AddDays(7);

            try
            {
                DataView dv;
                dv = new DataView(dataSetReports.Tables[0], $"OrderDate >= '{startOfWeek}' AND OrderDate < '{endOfWeek}'", "OrderNum Desc", DataViewRowState.CurrentRows);
                dgvReports.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //REFERENCE: https://stackoverflow.com/questions/2821035/c-sharp-get-start-date-and-last-date-based-on-current-date
        private void btnViewMonth_Click(object sender, EventArgs e)
        {
            view = currentView.ViewMonth;

            var thisMonthStart = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            var thisMonthEnd = thisMonthStart.AddMonths(1);
            try
            {
                DataView dv;
                dv = new DataView(dataSetReports.Tables[0], $"OrderDate >= '{thisMonthStart}' AND OrderDate < '{thisMonthEnd}'", "OrderNum Desc", DataViewRowState.CurrentRows);
                dgvReports.DataSource = dv;
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
            //TODO
        }

        enum currentView
        {
            ViewAll,
            ViewDay,
            ViewWeek,
            ViewMonth
        };

        currentView view = currentView.ViewAll;


        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr;

                bool bolEmptyFolder = false;
                string strPath = "";
                bool bolStopLoop = false;

                SaveFileDialog sfdFile = new SaveFileDialog();

                switch (view)
                {
                    case currentView.ViewAll:
                        dr = MessageBox.Show("You are about to print all sales reports. This can take quite a while and may cause system issues. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            dgvReports.SelectAll();

                            foreach (DataGridViewRow row in dgvReports.SelectedRows)
                            {
                                sfdFile.FileName = $"GOT Shirts-Receipt-{row.Cells[0].Value.ToString()}.html";

                                while (bolEmptyFolder == false)
                                {
                                    sfdFile.Title = "Select save location. Empty Folder Required";
                                    sfdFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                                    if (sfdFile.ShowDialog() == DialogResult.OK)
                                    {
                                        strPath = sfdFile.FileName;
                                        string strTrimPath = strPath.Replace($@"\\GOT Shirts-Receipt-{row.Cells[0].Value.ToString()}.html", "");
                                        
                                        if (IsDirectoryEmpty(strTrimPath))
                                        {
                                            MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            bolEmptyFolder = false;
                                        }
                                        else
                                        {
                                            bolEmptyFolder = true;
                                        }
                                    }
                                    else
                                    {
                                        bolStopLoop = true;
                                        break;
                                    }
                                }
                                if(bolStopLoop == true)
                                {
                                    dgvReports.ClearSelection();
                                    break;
                                }
                                using (FileStream fs = new FileStream(strPath, FileMode.Create))
                                {
                                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                    {
                                        if (row.Cells[8].Value != null)
                                        {
                                            w.Write(row.Cells[8].Value.ToString());
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                            }
                            dgvReports.ClearSelection();
                        }
                        break;
                    case currentView.ViewDay:
                        dr = MessageBox.Show($"You are about to print all sales reports for today: {DateTime.Today}. Are you sure?.", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            dgvReports.SelectAll();

                            //TODO
                        }
                        break;
                    case currentView.ViewWeek:
                        dr = MessageBox.Show("You are about to print all sales reports for this week. Are you sure?.", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            dgvReports.SelectAll();

                            //TODO
                        }
                        break;
                    case currentView.ViewMonth:
                        dr = MessageBox.Show("You are about to print all sales reports for this month. Are you sure?.", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            dgvReports.SelectAll();

                            //TODO
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string strOrderNum;
        public static string strHTML = "";
        int intTotalRows = 0;

        private void btnShowInvoice_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReports.SelectedRows)
            {
                intTotalRows++;
                strOrderNum = row.Cells[0].Value.ToString();
                strHTML = row.Cells[8].Value.ToString();
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
                frmInvoiceView frmInvoice = new frmInvoiceView();
                frmInvoice.Text = $"Invoice #{strOrderNum}";
                this.Hide();
                frmInvoice.ShowDialog();
                this.Show();
            }
        }
    }
}
