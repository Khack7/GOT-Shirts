
namespace SU21_Final_Project
{
    partial class frmEmpCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpCodes));
            this.lblActive = new System.Windows.Forms.Label();
            this.lblInactive = new System.Windows.Forms.Label();
            this.lstActive = new System.Windows.Forms.ListBox();
            this.lstInactive = new System.Windows.Forms.ListBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblActivePointer = new System.Windows.Forms.Label();
            this.lblInactivePointer = new System.Windows.Forms.Label();
            this.lblActiveDiscount = new System.Windows.Forms.Label();
            this.lblInactiveDiscount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblActive
            // 
            this.lblActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Location = new System.Drawing.Point(16, 9);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(120, 23);
            this.lblActive.TabIndex = 1;
            this.lblActive.Text = "Active Codes";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInactive
            // 
            this.lblInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactive.Location = new System.Drawing.Point(330, 7);
            this.lblInactive.Name = "lblInactive";
            this.lblInactive.Size = new System.Drawing.Size(127, 23);
            this.lblInactive.TabIndex = 3;
            this.lblInactive.Text = "Inactive Codes";
            this.lblInactive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstActive
            // 
            this.lstActive.FormattingEnabled = true;
            this.lstActive.Location = new System.Drawing.Point(16, 33);
            this.lstActive.Name = "lstActive";
            this.lstActive.ScrollAlwaysVisible = true;
            this.lstActive.Size = new System.Drawing.Size(120, 134);
            this.lstActive.TabIndex = 4;
            this.lstActive.SelectedValueChanged += new System.EventHandler(this.lstActive_SelectedValueChanged);
            // 
            // lstInactive
            // 
            this.lstInactive.FormattingEnabled = true;
            this.lstInactive.Location = new System.Drawing.Point(330, 33);
            this.lstInactive.Name = "lstInactive";
            this.lstInactive.ScrollAlwaysVisible = true;
            this.lstInactive.Size = new System.Drawing.Size(127, 134);
            this.lstInactive.TabIndex = 5;
            this.lstInactive.SelectedValueChanged += new System.EventHandler(this.lstInactive_SelectedValueChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(142, 137);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(182, 30);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblActivePointer
            // 
            this.lblActivePointer.AutoSize = true;
            this.lblActivePointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivePointer.Location = new System.Drawing.Point(137, 33);
            this.lblActivePointer.Name = "lblActivePointer";
            this.lblActivePointer.Size = new System.Drawing.Size(109, 17);
            this.lblActivePointer.TabIndex = 7;
            this.lblActivePointer.Text = "Active Discount:";
            // 
            // lblInactivePointer
            // 
            this.lblInactivePointer.AutoSize = true;
            this.lblInactivePointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactivePointer.Location = new System.Drawing.Point(137, 97);
            this.lblInactivePointer.Name = "lblInactivePointer";
            this.lblInactivePointer.Size = new System.Drawing.Size(119, 17);
            this.lblInactivePointer.TabIndex = 8;
            this.lblInactivePointer.Text = "Inactive Discount:";
            // 
            // lblActiveDiscount
            // 
            this.lblActiveDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActiveDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveDiscount.Location = new System.Drawing.Point(258, 33);
            this.lblActiveDiscount.Name = "lblActiveDiscount";
            this.lblActiveDiscount.Size = new System.Drawing.Size(65, 20);
            this.lblActiveDiscount.TabIndex = 9;
            // 
            // lblInactiveDiscount
            // 
            this.lblInactiveDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInactiveDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactiveDiscount.Location = new System.Drawing.Point(258, 97);
            this.lblInactiveDiscount.Name = "lblInactiveDiscount";
            this.lblInactiveDiscount.Size = new System.Drawing.Size(65, 20);
            this.lblInactiveDiscount.TabIndex = 10;
            // 
            // frmEmpCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 182);
            this.Controls.Add(this.lblInactiveDiscount);
            this.Controls.Add(this.lblActiveDiscount);
            this.Controls.Add(this.lblInactivePointer);
            this.Controls.Add(this.lblActivePointer);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lstInactive);
            this.Controls.Add(this.lstActive);
            this.Controls.Add(this.lblInactive);
            this.Controls.Add(this.lblActive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmpCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount Codes";
            this.Load += new System.EventHandler(this.frmEmpCodes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblInactive;
        private System.Windows.Forms.ListBox lstActive;
        private System.Windows.Forms.ListBox lstInactive;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblActivePointer;
        private System.Windows.Forms.Label lblInactivePointer;
        private System.Windows.Forms.Label lblActiveDiscount;
        private System.Windows.Forms.Label lblInactiveDiscount;
    }
}