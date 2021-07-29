
namespace SU21_Final_Project
{
    partial class frmAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduct));
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.pbxShirt = new System.Windows.Forms.PictureBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnUpdateImage = new System.Windows.Forms.Button();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(12, 276);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(116, 45);
            this.btnUpload.TabIndex = 13;
            this.btnUpload.Text = "&Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(12, 225);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 45);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search &Image";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(168, 225);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(116, 45);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(168, 276);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(116, 45);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(302, 199);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(36, 17);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "C&ost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(401, 196);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.ShortcutsEnabled = false;
            this.txtCost.Size = new System.Drawing.Size(186, 20);
            this.txtCost.TabIndex = 9;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(298, 137);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Pric&e";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(401, 135);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.ShortcutsEnabled = false;
            this.txtPrice.Size = new System.Drawing.Size(186, 20);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(298, 75);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(61, 17);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "&Quantity";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(401, 74);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.ShortcutsEnabled = false;
            this.txtAmount.Size = new System.Drawing.Size(186, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(298, 13);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(82, 17);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "&Color Name";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(401, 13);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.ShortcutsEnabled = false;
            this.txtColor.Size = new System.Drawing.Size(186, 20);
            this.txtColor.TabIndex = 3;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColor_KeyPress);
            // 
            // pbxShirt
            // 
            this.pbxShirt.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pbxShirt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxShirt.Location = new System.Drawing.Point(12, 12);
            this.pbxShirt.Name = "pbxShirt";
            this.pbxShirt.Size = new System.Drawing.Size(272, 207);
            this.pbxShirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShirt.TabIndex = 28;
            this.pbxShirt.TabStop = false;
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Enabled = false;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(401, 257);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(186, 21);
            this.cboSize.TabIndex = 11;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(302, 261);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 17);
            this.lblSize.TabIndex = 10;
            this.lblSize.Text = "&Size";
            // 
            // btnUpdateImage
            // 
            this.btnUpdateImage.Enabled = false;
            this.btnUpdateImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateImage.Location = new System.Drawing.Point(401, 284);
            this.btnUpdateImage.Name = "btnUpdateImage";
            this.btnUpdateImage.Size = new System.Drawing.Size(186, 37);
            this.btnUpdateImage.TabIndex = 12;
            this.btnUpdateImage.Text = "Upd&ate Image";
            this.btnUpdateImage.UseVisualStyleBackColor = true;
            this.btnUpdateImage.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.Location = new System.Drawing.Point(305, 300);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(84, 21);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "Up&dating";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 327);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.btnUpdateImage);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pbxShirt);
            this.Controls.Add(this.btnUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShirt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pbxShirt;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnUpdateImage;
        private System.Windows.Forms.CheckBox chkUpdate;
    }
}