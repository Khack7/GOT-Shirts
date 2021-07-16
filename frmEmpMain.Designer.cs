
namespace SU21_Final_Project
{
    partial class frmEmpMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpMain));
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSpecials = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(112, 66);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 48);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnSpecials
            // 
            this.btnSpecials.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecials.Location = new System.Drawing.Point(12, 66);
            this.btnSpecials.Name = "btnSpecials";
            this.btnSpecials.Size = new System.Drawing.Size(94, 48);
            this.btnSpecials.TabIndex = 9;
            this.btnSpecials.Text = "View Inventory";
            this.btnSpecials.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(212, 66);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(94, 48);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(212, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(94, 48);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Customer Purchase";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnSchedules
            // 
            this.btnSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedules.Location = new System.Drawing.Point(112, 12);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(94, 48);
            this.btnSchedules.TabIndex = 7;
            this.btnSchedules.Text = "View Active Codes";
            this.btnSchedules.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(12, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(94, 48);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.Text = "View Emp info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // frmEmpMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 121);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSpecials);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSchedules);
            this.Controls.Add(this.btnInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Hub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSpecials;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnInfo;
    }
}