
namespace SU21_Final_Project
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.orderNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardExperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReports = new SU21_Final_Project.DataSetReports();
            this.ordersTableAdapter = new SU21_Final_Project.DataSetReportsTableAdapters.OrdersTableAdapter();
            this.btnViewToday = new System.Windows.Forms.Button();
            this.btnViewWeek = new System.Windows.Forms.Button();
            this.btnViewMonth = new System.Windows.Forms.Button();
            this.btnShowInvoice = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLastMonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AutoGenerateColumns = false;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumDataGridViewTextBoxColumn,
            this.personIDDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.discountCodeDataGridViewTextBoxColumn,
            this.shippingDataGridViewTextBoxColumn,
            this.cardTypeDataGridViewTextBoxColumn,
            this.cardNumberDataGridViewTextBoxColumn,
            this.cardExperationDataGridViewTextBoxColumn,
            this.Invoice});
            this.dgvReports.DataSource = this.ordersBindingSource;
            this.dgvReports.Location = new System.Drawing.Point(2, 1);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(1053, 347);
            this.dgvReports.TabIndex = 0;
            // 
            // orderNumDataGridViewTextBoxColumn
            // 
            this.orderNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.orderNumDataGridViewTextBoxColumn.DataPropertyName = "OrderNum";
            this.orderNumDataGridViewTextBoxColumn.HeaderText = "Order Number";
            this.orderNumDataGridViewTextBoxColumn.Name = "orderNumDataGridViewTextBoxColumn";
            this.orderNumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // personIDDataGridViewTextBoxColumn
            // 
            this.personIDDataGridViewTextBoxColumn.DataPropertyName = "PersonID";
            this.personIDDataGridViewTextBoxColumn.HeaderText = "Person ID";
            this.personIDDataGridViewTextBoxColumn.Name = "personIDDataGridViewTextBoxColumn";
            this.personIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "Order Date";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountCodeDataGridViewTextBoxColumn
            // 
            this.discountCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.discountCodeDataGridViewTextBoxColumn.DataPropertyName = "DiscountCode";
            this.discountCodeDataGridViewTextBoxColumn.HeaderText = "Discount Code";
            this.discountCodeDataGridViewTextBoxColumn.Name = "discountCodeDataGridViewTextBoxColumn";
            this.discountCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountCodeDataGridViewTextBoxColumn.Width = 94;
            // 
            // shippingDataGridViewTextBoxColumn
            // 
            this.shippingDataGridViewTextBoxColumn.DataPropertyName = "Shipping";
            this.shippingDataGridViewTextBoxColumn.HeaderText = "Shipping Cost";
            this.shippingDataGridViewTextBoxColumn.Name = "shippingDataGridViewTextBoxColumn";
            this.shippingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardTypeDataGridViewTextBoxColumn
            // 
            this.cardTypeDataGridViewTextBoxColumn.DataPropertyName = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.HeaderText = "Card Type";
            this.cardTypeDataGridViewTextBoxColumn.Name = "cardTypeDataGridViewTextBoxColumn";
            this.cardTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardNumberDataGridViewTextBoxColumn
            // 
            this.cardNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardNumberDataGridViewTextBoxColumn.DataPropertyName = "CardNumber";
            this.cardNumberDataGridViewTextBoxColumn.HeaderText = "Card Number";
            this.cardNumberDataGridViewTextBoxColumn.Name = "cardNumberDataGridViewTextBoxColumn";
            this.cardNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardExperationDataGridViewTextBoxColumn
            // 
            this.cardExperationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardExperationDataGridViewTextBoxColumn.DataPropertyName = "CardExperation";
            this.cardExperationDataGridViewTextBoxColumn.HeaderText = "Card Experation";
            this.cardExperationDataGridViewTextBoxColumn.Name = "cardExperationDataGridViewTextBoxColumn";
            this.cardExperationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Invoice
            // 
            this.Invoice.DataPropertyName = "Invoice";
            this.Invoice.HeaderText = "Invoice";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            this.Invoice.Visible = false;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.dataSetReports;
            // 
            // dataSetReports
            // 
            this.dataSetReports.DataSetName = "DataSetReports";
            this.dataSetReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // btnViewToday
            // 
            this.btnViewToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewToday.Location = new System.Drawing.Point(12, 366);
            this.btnViewToday.Name = "btnViewToday";
            this.btnViewToday.Size = new System.Drawing.Size(107, 44);
            this.btnViewToday.TabIndex = 1;
            this.btnViewToday.Text = "View &Today\'s";
            this.btnViewToday.UseVisualStyleBackColor = true;
            this.btnViewToday.Click += new System.EventHandler(this.btnViewToday_Click);
            // 
            // btnViewWeek
            // 
            this.btnViewWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewWeek.Location = new System.Drawing.Point(143, 366);
            this.btnViewWeek.Name = "btnViewWeek";
            this.btnViewWeek.Size = new System.Drawing.Size(107, 44);
            this.btnViewWeek.TabIndex = 2;
            this.btnViewWeek.Text = "View This &Week\'s";
            this.btnViewWeek.UseVisualStyleBackColor = true;
            this.btnViewWeek.Click += new System.EventHandler(this.btnViewWeek_Click);
            // 
            // btnViewMonth
            // 
            this.btnViewMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMonth.Location = new System.Drawing.Point(274, 366);
            this.btnViewMonth.Name = "btnViewMonth";
            this.btnViewMonth.Size = new System.Drawing.Size(107, 44);
            this.btnViewMonth.TabIndex = 3;
            this.btnViewMonth.Text = "View This &Month\'s";
            this.btnViewMonth.UseVisualStyleBackColor = true;
            this.btnViewMonth.Click += new System.EventHandler(this.btnViewMonth_Click);
            // 
            // btnShowInvoice
            // 
            this.btnShowInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInvoice.Location = new System.Drawing.Point(667, 366);
            this.btnShowInvoice.Name = "btnShowInvoice";
            this.btnShowInvoice.Size = new System.Drawing.Size(107, 44);
            this.btnShowInvoice.TabIndex = 7;
            this.btnShowInvoice.Text = "View &Order\'s Invoice";
            this.btnShowInvoice.UseVisualStyleBackColor = true;
            this.btnShowInvoice.Click += new System.EventHandler(this.btnShowInvoice_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(798, 366);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(107, 44);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(929, 366);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(107, 44);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(536, 366);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 44);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastMonth.Location = new System.Drawing.Point(405, 366);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(107, 44);
            this.btnLastMonth.TabIndex = 11;
            this.btnLastMonth.Text = "View &Last Month\'s";
            this.btnLastMonth.UseVisualStyleBackColor = true;
            this.btnLastMonth.Click += new System.EventHandler(this.btnLastMonth_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 425);
            this.Controls.Add(this.btnLastMonth);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnShowInvoice);
            this.Controls.Add(this.btnViewMonth);
            this.Controls.Add(this.btnViewWeek);
            this.Controls.Add(this.btnViewToday);
            this.Controls.Add(this.dgvReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReports;
        private DataSetReports dataSetReports;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private DataSetReportsTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.Button btnViewToday;
        private System.Windows.Forms.Button btnViewWeek;
        private System.Windows.Forms.Button btnViewMonth;
        private System.Windows.Forms.Button btnShowInvoice;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardExperationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.Button btnLastMonth;
    }
}