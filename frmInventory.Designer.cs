
namespace SU21_Final_Project
{
    partial class frmInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbxShirt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(528, 310);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(123, 42);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(12, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 42);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(12, 187);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Pric&e";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(115, 187);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.ShortcutsEnabled = false;
            this.txtPrice.Size = new System.Drawing.Size(186, 20);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(12, 129);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(61, 17);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "&Quantity";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(12, 9);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(94, 17);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Select a &color";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(115, 128);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.ShortcutsEnabled = false;
            this.txtAmount.Size = new System.Drawing.Size(186, 20);
            this.txtAmount.TabIndex = 11;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(115, 8);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(186, 21);
            this.cboColor.TabIndex = 9;
            this.cboColor.SelectedIndexChanged += new System.EventHandler(this.cboColor_SelectedIndexChanged);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(12, 249);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(36, 17);
            this.lblCost.TabIndex = 16;
            this.lblCost.Text = "C&ost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(115, 246);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.ShortcutsEnabled = false;
            this.txtCost.Size = new System.Drawing.Size(186, 20);
            this.txtCost.TabIndex = 17;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(12, 69);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(88, 17);
            this.lblSize.TabIndex = 18;
            this.lblSize.Text = "Select a &size";
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Enabled = false;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(115, 68);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(186, 21);
            this.cboSize.TabIndex = 19;
            this.cboSize.SelectedIndexChanged += new System.EventHandler(this.cboSize_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(399, 310);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(123, 42);
            this.btnHelp.TabIndex = 20;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(141, 310);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(123, 42);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "&Print Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(270, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 42);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "&Add New Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbxShirt
            // 
            this.pbxShirt.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pbxShirt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxShirt.Location = new System.Drawing.Point(317, 8);
            this.pbxShirt.Name = "pbxShirt";
            this.pbxShirt.Size = new System.Drawing.Size(332, 258);
            this.pbxShirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShirt.TabIndex = 28;
            this.pbxShirt.TabStop = false;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 363);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.pbxShirt);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cboColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Adjustment";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.PictureBox pbxShirt;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnAdd;
    }
}