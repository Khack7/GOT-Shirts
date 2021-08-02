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
            try
            {
                DataView dv;
                dv = new DataView(dataSetReports.Tables[0], $"OrderDate = '{DateTime.Today}'", "OrderNum Desc", DataViewRowState.CurrentRows);
                dgvReports.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnViewWeek_Click(object sender, EventArgs e)
        {
            view = currentView.ViewWeek;

            try
            {
                DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                var endOfWeek = startOfWeek.AddDays(7);
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

            try
            {
                var thisMonthStart = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                var thisMonthEnd = thisMonthStart.AddMonths(1);
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
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                System.Diagnostics.Process.Start($"{strPath}\\HelpFiles\\Manager_Reports_Help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        enum currentView
        {
            ViewAll,
            ViewDay,
            ViewWeek,
            ViewMonth,
            ViewLastMonth
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
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bool bolStopLoop = false;

                SaveFileDialog sfdFile = new SaveFileDialog();

                int intSelectedRows = 0;

                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                {
                    intSelectedRows++;
                }

                if (intSelectedRows == 0)
                {
                    MessageBox.Show("Please select a row or select Daily, Weekly, or monthly report", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    switch (view)
                    {
                        case currentView.ViewAll:
                            dr = MessageBox.Show("You are about to print all sales reports. This can take quite a while and may cause system issues. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dr == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                dgvReports.SelectAll();

                                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                                {
                                    string strFileName = $"GOT Shirts-Order#-{row.Cells[0].Value.ToString()}.html";

                                    Cursor.Current = Cursors.Default;

                                    while (bolEmptyFolder == false)
                                    {
                                        sfdFile.FileName = strFileName;
                                        sfdFile.Title = "Select save location. Empty Folder Required";
                                        sfdFile.InitialDirectory = strPath;

                                        if (sfdFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Cursor.Current = Cursors.WaitCursor;

                                            strPath = Path.GetDirectoryName(sfdFile.FileName);

                                            bolEmptyFolder = IsDirectoryEmpty(strPath);
                                            if (!bolEmptyFolder)
                                            {
                                                Cursor.Current = Cursors.Default;
                                                MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            bolStopLoop = true;
                                            Cursor.Current = Cursors.Default;
                                            break;
                                        }
                                    }
                                    if (bolStopLoop == true)
                                    {
                                        Cursor.Current = Cursors.Default;
                                        dgvReports.ClearSelection();
                                        break;
                                    }

                                    strFileName = Path.Combine(strPath, strFileName);
                                    using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            if (row.Cells[8].Value != null)
                                            {
                                                w.Write(row.Cells[8].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                                dgvReports.ClearSelection();
                                Cursor.Current = Cursors.Default;
                            }
                            break;
                        case currentView.ViewDay:
                            dr = MessageBox.Show("You are about to print Today's sales reports. This could take a while. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dr == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                dgvReports.SelectAll();

                                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                                {
                                    string strFileName = $"GOT Shirts-Order#-{row.Cells[0].Value.ToString()}.html";

                                    while (bolEmptyFolder == false)
                                    {
                                        Cursor.Current = Cursors.Default;
                                        sfdFile.FileName = strFileName;
                                        sfdFile.Title = "Select save location. Empty Folder Required";
                                        sfdFile.InitialDirectory = strPath;

                                        if (sfdFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Cursor.Current = Cursors.WaitCursor;

                                            strPath = Path.GetDirectoryName(sfdFile.FileName);

                                            bolEmptyFolder = IsDirectoryEmpty(strPath);
                                            if (!bolEmptyFolder)
                                            {
                                                Cursor.Current = Cursors.Default;
                                                MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            Cursor.Current = Cursors.Default;
                                            bolStopLoop = true;
                                            break;
                                        }
                                    }
                                    if (bolStopLoop == true)
                                    {
                                        Cursor.Current = Cursors.Default;
                                        dgvReports.ClearSelection();
                                        break;
                                    }

                                    strFileName = Path.Combine(strPath, strFileName);
                                    using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            if (row.Cells[8].Value != null)
                                            {
                                                w.Write(row.Cells[8].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                                dgvReports.ClearSelection();
                                Cursor.Current = Cursors.Default;
                            }
                            break;
                        case currentView.ViewWeek:
                            dr = MessageBox.Show("You are about to print this week's sales reports. This could take a while and may cause system issues. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dr == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                dgvReports.SelectAll();

                                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                                {
                                    string strFileName = $"GOT Shirts-Order#-{row.Cells[0].Value.ToString()}.html";

                                    while (bolEmptyFolder == false)
                                    {
                                        Cursor.Current = Cursors.Default;

                                        sfdFile.FileName = strFileName;
                                        sfdFile.Title = "Select save location. Empty Folder Required";
                                        sfdFile.InitialDirectory = strPath;

                                        if (sfdFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Cursor.Current = Cursors.WaitCursor;

                                            strPath = Path.GetDirectoryName(sfdFile.FileName);

                                            bolEmptyFolder = IsDirectoryEmpty(strPath);
                                            if (!bolEmptyFolder)
                                            {
                                                MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            bolStopLoop = true;
                                            Cursor.Current = Cursors.Default;
                                            break;
                                        }
                                    }
                                    if (bolStopLoop == true)
                                    {
                                        dgvReports.ClearSelection();
                                        Cursor.Current = Cursors.Default;
                                        break;
                                    }

                                    strFileName = Path.Combine(strPath, strFileName);
                                    using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            if (row.Cells[8].Value != null)
                                            {
                                                w.Write(row.Cells[8].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                                dgvReports.ClearSelection();
                                Cursor.Current = Cursors.Default;
                            }
                            break;
                        case currentView.ViewMonth:
                            dr = MessageBox.Show("You are about to print this month's sales reports. This could take quite a while and may cause system issues. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dr == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                dgvReports.SelectAll();

                                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                                {
                                    string strFileName = $"GOT Shirts-Order#-{row.Cells[0].Value.ToString()}.html";

                                    while (bolEmptyFolder == false)
                                    {
                                        Cursor.Current = Cursors.Default;

                                        sfdFile.FileName = strFileName;
                                        sfdFile.Title = "Select save location. Empty Folder Required";
                                        sfdFile.InitialDirectory = strPath;

                                        if (sfdFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Cursor.Current = Cursors.WaitCursor;

                                            strPath = Path.GetDirectoryName(sfdFile.FileName);

                                            bolEmptyFolder = IsDirectoryEmpty(strPath);
                                            if (!bolEmptyFolder)
                                            {
                                                MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            Cursor.Current = Cursors.Default;
                                            bolStopLoop = true;
                                            break;
                                        }
                                    }
                                    if (bolStopLoop == true)
                                    {
                                        Cursor.Current = Cursors.Default;
                                        dgvReports.ClearSelection();
                                        break;
                                    }

                                    strFileName = Path.Combine(strPath, strFileName);
                                    using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            if (row.Cells[8].Value != null)
                                            {
                                                w.Write(row.Cells[8].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                                dgvReports.ClearSelection();
                                Cursor.Current = Cursors.Default;
                            }
                            break;
                        case currentView.ViewLastMonth:
                            dr = MessageBox.Show("You are about to print last month's sales reports. This could take quite a while and may cause system issues. Continue?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dr == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                dgvReports.SelectAll();

                                foreach (DataGridViewRow row in dgvReports.SelectedRows)
                                {
                                    string strFileName = $"GOT Shirts-Order#-{row.Cells[0].Value.ToString()}.html";

                                    while (bolEmptyFolder == false)
                                    {
                                        Cursor.Current = Cursors.Default;

                                        sfdFile.FileName = strFileName;
                                        sfdFile.Title = "Select save location. Empty Folder Required";
                                        sfdFile.InitialDirectory = strPath;

                                        if (sfdFile.ShowDialog() == DialogResult.OK)
                                        {
                                            Cursor.Current = Cursors.WaitCursor;

                                            strPath = Path.GetDirectoryName(sfdFile.FileName);

                                            bolEmptyFolder = IsDirectoryEmpty(strPath);
                                            if (!bolEmptyFolder)
                                            {
                                                MessageBox.Show("Please select an empty folder", "Empty Folder Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            Cursor.Current = Cursors.Default;
                                            bolStopLoop = true;
                                            break;
                                        }
                                    }
                                    if (bolStopLoop == true)
                                    {
                                        Cursor.Current = Cursors.Default;
                                        dgvReports.ClearSelection();
                                        break;
                                    }

                                    strFileName = Path.Combine(strPath, strFileName);
                                    using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                                    {
                                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                                        {
                                            if (row.Cells[8].Value != null)
                                            {
                                                w.Write(row.Cells[8].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                System.Diagnostics.Process.Start(strPath);
                                dgvReports.ClearSelection();
                                Cursor.Current = Cursors.Default;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string strOrderNum;
        public static string strHTML = "";
        int intTotalRows = 0;

        private void btnShowInvoice_Click(object sender, EventArgs e)
        {
            try
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
                    if (strHTML == null)
                    {
                        MessageBox.Show("No Invoice Available", "No Invoice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                intTotalRows = 0;
                dgvReports.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            view = currentView.ViewLastMonth;

            try
            {
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                DataView dv;
                dv = new DataView(dataSetReports.Tables[0], $"OrderDate >= '{first}' AND OrderDate < '{last}'", "OrderNum Desc", DataViewRowState.CurrentRows);
                dgvReports.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
