
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
            this.lblInactive.Location = new System.Drawing.Point(251, 7);
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
            // 
            // lstInactive
            // 
            this.lstInactive.FormattingEnabled = true;
            this.lstInactive.Location = new System.Drawing.Point(251, 33);
            this.lstInactive.Name = "lstInactive";
            this.lstInactive.ScrollAlwaysVisible = true;
            this.lstInactive.Size = new System.Drawing.Size(127, 134);
            this.lstInactive.TabIndex = 5;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(142, 137);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(103, 30);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmEmpCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 202);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lstInactive);
            this.Controls.Add(this.lstActive);
            this.Controls.Add(this.lblInactive);
            this.Controls.Add(this.lblActive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount Codes";
            this.Load += new System.EventHandler(this.frmEmpCodes_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblInactive;
        private System.Windows.Forms.ListBox lstActive;
        private System.Windows.Forms.ListBox lstInactive;
        private System.Windows.Forms.Button btnReturn;
    }
}