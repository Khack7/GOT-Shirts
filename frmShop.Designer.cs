
namespace SU21_Final_Project
{
    partial class frmShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShop));
            this.btnAccount = new System.Windows.Forms.Button();
            this.numUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCode = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTotalPointer = new System.Windows.Forms.Label();
            this.rdoLarge = new System.Windows.Forms.RadioButton();
            this.rdoMedium = new System.Windows.Forms.RadioButton();
            this.rdoSmall = new System.Windows.Forms.RadioButton();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnPurple = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.lblItemPricePointer = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblColorPointer = new System.Windows.Forms.Label();
            this.pbxShirt = new System.Windows.Forms.PictureBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.lblOtherColors = new System.Windows.Forms.Label();
            this.lblCodePointer = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(568, 45);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(106, 23);
            this.btnAccount.TabIndex = 26;
            this.btnAccount.Text = "Accoun&t";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // numUDQuantity
            // 
            this.numUDQuantity.Location = new System.Drawing.Point(347, 175);
            this.numUDQuantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numUDQuantity.Name = "numUDQuantity";
            this.numUDQuantity.Size = new System.Drawing.Size(52, 20);
            this.numUDQuantity.TabIndex = 15;
            this.numUDQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "&Quantity";
            // 
            // btnCode
            // 
            this.btnCode.Location = new System.Drawing.Point(568, 83);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(106, 23);
            this.btnCode.TabIndex = 27;
            this.btnCode.Text = "Ha&ve a code?";
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(359, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 41);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "L&og Out";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.Enabled = false;
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(526, 234);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(148, 41);
            this.btnCheckout.TabIndex = 32;
            this.btnCheckout.Text = "&Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(293, 199);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "&Add To Cart";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(442, 121);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 23);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "&Remove Selected Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(568, 7);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(106, 23);
            this.btnHelp.TabIndex = 25;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(514, 144);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 19);
            this.lblAmount.TabIndex = 24;
            this.lblAmount.Text = "$0.00";
            // 
            // lblTotalPointer
            // 
            this.lblTotalPointer.AutoSize = true;
            this.lblTotalPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPointer.Location = new System.Drawing.Point(439, 144);
            this.lblTotalPointer.Name = "lblTotalPointer";
            this.lblTotalPointer.Size = new System.Drawing.Size(69, 17);
            this.lblTotalPointer.TabIndex = 23;
            this.lblTotalPointer.Text = "SubTotal:";
            // 
            // rdoLarge
            // 
            this.rdoLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoLarge.AutoSize = true;
            this.rdoLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLarge.Location = new System.Drawing.Point(214, 216);
            this.rdoLarge.Name = "rdoLarge";
            this.rdoLarge.Size = new System.Drawing.Size(63, 21);
            this.rdoLarge.TabIndex = 13;
            this.rdoLarge.Text = "&Large";
            this.rdoLarge.UseVisualStyleBackColor = true;
            this.rdoLarge.CheckedChanged += new System.EventHandler(this.rdoLarge_CheckedChanged);
            // 
            // rdoMedium
            // 
            this.rdoMedium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoMedium.AutoSize = true;
            this.rdoMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMedium.Location = new System.Drawing.Point(105, 216);
            this.rdoMedium.Name = "rdoMedium";
            this.rdoMedium.Size = new System.Drawing.Size(75, 21);
            this.rdoMedium.TabIndex = 12;
            this.rdoMedium.Text = "&Medium";
            this.rdoMedium.UseVisualStyleBackColor = true;
            this.rdoMedium.CheckedChanged += new System.EventHandler(this.rdoMedium_CheckedChanged);
            // 
            // rdoSmall
            // 
            this.rdoSmall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoSmall.AutoSize = true;
            this.rdoSmall.Checked = true;
            this.rdoSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSmall.Location = new System.Drawing.Point(11, 216);
            this.rdoSmall.Name = "rdoSmall";
            this.rdoSmall.Size = new System.Drawing.Size(60, 21);
            this.rdoSmall.TabIndex = 11;
            this.rdoSmall.TabStop = true;
            this.rdoSmall.Text = "&Small";
            this.rdoSmall.UseVisualStyleBackColor = true;
            this.rdoSmall.CheckedChanged += new System.EventHandler(this.rdoSmall_CheckedChanged);
            // 
            // lstCart
            // 
            this.lstCart.FormattingEnabled = true;
            this.lstCart.Location = new System.Drawing.Point(442, 7);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(120, 108);
            this.lstCart.TabIndex = 21;
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(369, 134);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(30, 29);
            this.btnYellow.TabIndex = 10;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.Location = new System.Drawing.Point(331, 134);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(30, 29);
            this.btnWhite.TabIndex = 9;
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(293, 134);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(30, 29);
            this.btnRed.TabIndex = 8;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnPurple
            // 
            this.btnPurple.BackColor = System.Drawing.Color.Purple;
            this.btnPurple.Location = new System.Drawing.Point(369, 95);
            this.btnPurple.Name = "btnPurple";
            this.btnPurple.Size = new System.Drawing.Size(30, 29);
            this.btnPurple.TabIndex = 7;
            this.btnPurple.UseVisualStyleBackColor = false;
            this.btnPurple.Click += new System.EventHandler(this.btnPurple_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.Pink;
            this.btnPink.Location = new System.Drawing.Point(331, 95);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(30, 29);
            this.btnPink.TabIndex = 6;
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.Orange;
            this.btnOrange.Location = new System.Drawing.Point(293, 95);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(30, 29);
            this.btnOrange.TabIndex = 5;
            this.btnOrange.UseVisualStyleBackColor = false;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Green;
            this.btnGreen.Location = new System.Drawing.Point(369, 56);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(30, 29);
            this.btnGreen.TabIndex = 4;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Location = new System.Drawing.Point(293, 56);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(30, 29);
            this.btnBlack.TabIndex = 2;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(331, 56);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(30, 29);
            this.btnBlue.TabIndex = 3;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // lblItemPricePointer
            // 
            this.lblItemPricePointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPricePointer.Location = new System.Drawing.Point(12, 254);
            this.lblItemPricePointer.Name = "lblItemPricePointer";
            this.lblItemPricePointer.Size = new System.Drawing.Size(76, 17);
            this.lblItemPricePointer.TabIndex = 17;
            this.lblItemPricePointer.Text = "Item Price: ";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(95, 254);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(46, 19);
            this.lblItemPrice.TabIndex = 18;
            this.lblItemPrice.Text = "$0.00";
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(215, 256);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(138, 19);
            this.lblColor.TabIndex = 20;
            // 
            // lblColorPointer
            // 
            this.lblColorPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorPointer.Location = new System.Drawing.Point(162, 256);
            this.lblColorPointer.Name = "lblColorPointer";
            this.lblColorPointer.Size = new System.Drawing.Size(47, 17);
            this.lblColorPointer.TabIndex = 19;
            this.lblColorPointer.Text = "Color:";
            // 
            // pbxShirt
            // 
            this.pbxShirt.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pbxShirt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxShirt.Location = new System.Drawing.Point(12, 12);
            this.pbxShirt.Name = "pbxShirt";
            this.pbxShirt.Size = new System.Drawing.Size(267, 198);
            this.pbxShirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShirt.TabIndex = 27;
            this.pbxShirt.TabStop = false;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(293, 30);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(106, 21);
            this.cboColor.TabIndex = 1;
            this.cboColor.SelectedValueChanged += new System.EventHandler(this.cboColor_SelectedValueChanged);
            // 
            // lblOtherColors
            // 
            this.lblOtherColors.Location = new System.Drawing.Point(293, 2);
            this.lblOtherColors.Name = "lblOtherColors";
            this.lblOtherColors.Size = new System.Drawing.Size(113, 28);
            this.lblOtherColors.TabIndex = 0;
            this.lblOtherColors.Text = "&For more color options click the dropdown";
            this.lblOtherColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodePointer
            // 
            this.lblCodePointer.AutoSize = true;
            this.lblCodePointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodePointer.Location = new System.Drawing.Point(439, 193);
            this.lblCodePointer.Name = "lblCodePointer";
            this.lblCodePointer.Size = new System.Drawing.Size(155, 17);
            this.lblCodePointer.TabIndex = 29;
            this.lblCodePointer.Text = "Discount Code Applied:";
            this.lblCodePointer.Visible = false;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(598, 193);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(70, 17);
            this.lblCode.TabIndex = 30;
            this.lblCode.Text = "codeHere";
            this.lblCode.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(568, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 23);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "Cl&ear Cart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 284);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblCodePointer);
            this.Controls.Add(this.lblOtherColors);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblColorPointer);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemPricePointer);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.numUDQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTotalPointer);
            this.Controls.Add(this.rdoLarge);
            this.Controls.Add(this.rdoMedium);
            this.Controls.Add(this.rdoSmall);
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnPurple);
            this.Controls.Add(this.btnPink);
            this.Controls.Add(this.btnOrange);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.pbxShirt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShop_FormClosing);
            this.Load += new System.EventHandler(this.frmShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.NumericUpDown numUDQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTotalPointer;
        private System.Windows.Forms.RadioButton rdoLarge;
        private System.Windows.Forms.RadioButton rdoMedium;
        private System.Windows.Forms.RadioButton rdoSmall;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnPurple;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.PictureBox pbxShirt;
        public System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Label lblItemPricePointer;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblColorPointer;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblOtherColors;
        private System.Windows.Forms.Label lblCodePointer;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnClear;
    }
}