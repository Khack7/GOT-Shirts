﻿
namespace SU21_Final_Project
{
    partial class frmCheckout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckout));
            this.lblShippingPointer = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.rdoDiscover = new System.Windows.Forms.RadioButton();
            this.rdoMasterCard = new System.Windows.Forms.RadioButton();
            this.rdoVisa = new System.Windows.Forms.RadioButton();
            this.lblTotalPointer = new System.Windows.Forms.Label();
            this.lblTaxPointer = new System.Windows.Forms.Label();
            this.lblSubTotalPointer = new System.Windows.Forms.Label();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.rdoSecondDay = new System.Windows.Forms.RadioButton();
            this.rdoNextDay = new System.Windows.Forms.RadioButton();
            this.rdoStandard = new System.Windows.Forms.RadioButton();
            this.lblShippingMethod = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblShipping = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblShippingPointer
            // 
            this.lblShippingPointer.AutoSize = true;
            this.lblShippingPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingPointer.Location = new System.Drawing.Point(201, 103);
            this.lblShippingPointer.Name = "lblShippingPointer";
            this.lblShippingPointer.Size = new System.Drawing.Size(67, 17);
            this.lblShippingPointer.TabIndex = 40;
            this.lblShippingPointer.Text = "Shipping:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(256, 377);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(102, 47);
            this.btnConfirm.TabIndex = 39;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 47);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(65, 219);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(266, 20);
            this.txtCard.TabIndex = 37;
            this.txtCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCard_KeyPress);
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard.Location = new System.Drawing.Point(9, 222);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(50, 17);
            this.lblCard.TabIndex = 36;
            this.lblCard.Text = "Card #";
            // 
            // rdoDiscover
            // 
            this.rdoDiscover.AutoSize = true;
            this.rdoDiscover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiscover.Location = new System.Drawing.Point(250, 187);
            this.rdoDiscover.Name = "rdoDiscover";
            this.rdoDiscover.Size = new System.Drawing.Size(81, 21);
            this.rdoDiscover.TabIndex = 35;
            this.rdoDiscover.Text = "Discover";
            this.rdoDiscover.UseVisualStyleBackColor = true;
            // 
            // rdoMasterCard
            // 
            this.rdoMasterCard.AutoSize = true;
            this.rdoMasterCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMasterCard.Location = new System.Drawing.Point(108, 187);
            this.rdoMasterCard.Name = "rdoMasterCard";
            this.rdoMasterCard.Size = new System.Drawing.Size(99, 21);
            this.rdoMasterCard.TabIndex = 34;
            this.rdoMasterCard.Text = "MasterCard";
            this.rdoMasterCard.UseVisualStyleBackColor = true;
            // 
            // rdoVisa
            // 
            this.rdoVisa.AutoSize = true;
            this.rdoVisa.Checked = true;
            this.rdoVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoVisa.Location = new System.Drawing.Point(12, 187);
            this.rdoVisa.Name = "rdoVisa";
            this.rdoVisa.Size = new System.Drawing.Size(53, 21);
            this.rdoVisa.TabIndex = 33;
            this.rdoVisa.TabStop = true;
            this.rdoVisa.Text = "Visa";
            this.rdoVisa.UseVisualStyleBackColor = true;
            // 
            // lblTotalPointer
            // 
            this.lblTotalPointer.AutoSize = true;
            this.lblTotalPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPointer.Location = new System.Drawing.Point(201, 143);
            this.lblTotalPointer.Name = "lblTotalPointer";
            this.lblTotalPointer.Size = new System.Drawing.Size(44, 17);
            this.lblTotalPointer.TabIndex = 32;
            this.lblTotalPointer.Text = "Total:";
            // 
            // lblTaxPointer
            // 
            this.lblTaxPointer.AutoSize = true;
            this.lblTaxPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxPointer.Location = new System.Drawing.Point(201, 53);
            this.lblTaxPointer.Name = "lblTaxPointer";
            this.lblTaxPointer.Size = new System.Drawing.Size(35, 17);
            this.lblTaxPointer.TabIndex = 31;
            this.lblTaxPointer.Text = "Tax:";
            // 
            // lblSubTotalPointer
            // 
            this.lblSubTotalPointer.AutoSize = true;
            this.lblSubTotalPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalPointer.Location = new System.Drawing.Point(201, 8);
            this.lblSubTotalPointer.Name = "lblSubTotalPointer";
            this.lblSubTotalPointer.Size = new System.Drawing.Size(69, 17);
            this.lblSubTotalPointer.TabIndex = 30;
            this.lblSubTotalPointer.Text = "SubTotal:";
            // 
            // lstCart
            // 
            this.lstCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCart.FormattingEnabled = true;
            this.lstCart.ItemHeight = 16;
            this.lstCart.Location = new System.Drawing.Point(12, 12);
            this.lstCart.Name = "lstCart";
            this.lstCart.ScrollAlwaysVisible = true;
            this.lstCart.Size = new System.Drawing.Size(183, 148);
            this.lstCart.TabIndex = 29;
            // 
            // rdoSecondDay
            // 
            this.rdoSecondDay.AutoSize = true;
            this.rdoSecondDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSecondDay.Location = new System.Drawing.Point(252, 19);
            this.rdoSecondDay.Name = "rdoSecondDay";
            this.rdoSecondDay.Size = new System.Drawing.Size(100, 21);
            this.rdoSecondDay.TabIndex = 43;
            this.rdoSecondDay.Text = "2nd Day Air";
            this.rdoSecondDay.UseVisualStyleBackColor = true;
            this.rdoSecondDay.CheckedChanged += new System.EventHandler(this.rdoSecondDay_CheckedChanged);
            // 
            // rdoNextDay
            // 
            this.rdoNextDay.AutoSize = true;
            this.rdoNextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNextDay.Location = new System.Drawing.Point(123, 19);
            this.rdoNextDay.Name = "rdoNextDay";
            this.rdoNextDay.Size = new System.Drawing.Size(104, 21);
            this.rdoNextDay.TabIndex = 42;
            this.rdoNextDay.Text = "Next Day Air";
            this.rdoNextDay.UseVisualStyleBackColor = true;
            this.rdoNextDay.CheckedChanged += new System.EventHandler(this.rdoNextDay_CheckedChanged);
            // 
            // rdoStandard
            // 
            this.rdoStandard.AutoSize = true;
            this.rdoStandard.Checked = true;
            this.rdoStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStandard.Location = new System.Drawing.Point(14, 19);
            this.rdoStandard.Name = "rdoStandard";
            this.rdoStandard.Size = new System.Drawing.Size(84, 21);
            this.rdoStandard.TabIndex = 41;
            this.rdoStandard.TabStop = true;
            this.rdoStandard.Text = "Standard";
            this.rdoStandard.UseVisualStyleBackColor = true;
            this.rdoStandard.CheckedChanged += new System.EventHandler(this.rdoStandard_CheckedChanged);
            // 
            // lblShippingMethod
            // 
            this.lblShippingMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingMethod.Location = new System.Drawing.Point(13, 298);
            this.lblShippingMethod.Name = "lblShippingMethod";
            this.lblShippingMethod.Size = new System.Drawing.Size(318, 23);
            this.lblShippingMethod.TabIndex = 44;
            this.lblShippingMethod.Text = "Select Shipping Method";
            this.lblShippingMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoStandard);
            this.groupBox1.Controls.Add(this.rdoNextDay);
            this.groupBox1.Controls.Add(this.rdoSecondDay);
            this.groupBox1.Location = new System.Drawing.Point(0, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 54);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiration.Location = new System.Drawing.Point(9, 255);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(69, 17);
            this.lblExpiration.TabIndex = 46;
            this.lblExpiration.Text = "Exp. Date";
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(84, 251);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(49, 21);
            this.cboMonth.TabIndex = 47;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(146, 251);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(49, 21);
            this.cboYear.TabIndex = 48;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(276, 8);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(55, 17);
            this.lblSubtotal.TabIndex = 49;
            this.lblSubtotal.Text = "$0.00";
            // 
            // lblTax
            // 
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(276, 53);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(55, 17);
            this.lblTax.TabIndex = 50;
            this.lblTax.Text = "$0.00";
            // 
            // lblShipping
            // 
            this.lblShipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipping.Location = new System.Drawing.Point(276, 103);
            this.lblShipping.Name = "lblShipping";
            this.lblShipping.Size = new System.Drawing.Size(55, 17);
            this.lblShipping.TabIndex = 51;
            this.lblShipping.Text = "$0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(276, 143);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(55, 17);
            this.lblTotal.TabIndex = 52;
            this.lblTotal.Text = "$0.00";
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 436);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblShipping);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblShippingMethod);
            this.Controls.Add(this.lblShippingPointer);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.rdoDiscover);
            this.Controls.Add(this.rdoMasterCard);
            this.Controls.Add(this.rdoVisa);
            this.Controls.Add(this.lblTotalPointer);
            this.Controls.Add(this.lblTaxPointer);
            this.Controls.Add(this.lblSubTotalPointer);
            this.Controls.Add(this.lstCart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShippingPointer;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.RadioButton rdoDiscover;
        private System.Windows.Forms.RadioButton rdoMasterCard;
        private System.Windows.Forms.RadioButton rdoVisa;
        private System.Windows.Forms.Label lblTotalPointer;
        private System.Windows.Forms.Label lblTaxPointer;
        private System.Windows.Forms.Label lblSubTotalPointer;
        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.RadioButton rdoSecondDay;
        private System.Windows.Forms.RadioButton rdoNextDay;
        private System.Windows.Forms.RadioButton rdoStandard;
        private System.Windows.Forms.Label lblShippingMethod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblShipping;
        private System.Windows.Forms.Label lblTotal;
    }
}