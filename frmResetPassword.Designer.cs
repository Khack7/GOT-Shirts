
namespace SU21_Final_Project
{
    partial class frmResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetPassword));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.lblAnswer3 = new System.Windows.Forms.Label();
            this.lblSecurity3 = new System.Windows.Forms.Label();
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.lblSecurity2 = new System.Windows.Forms.Label();
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.lblSecurity1 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtSecurity3 = new System.Windows.Forms.TextBox();
            this.txtSecurity2 = new System.Windows.Forms.TextBox();
            this.txtSecurity1 = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(155, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(155, 374);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(306, 20);
            this.txtPassword.TabIndex = 15;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Enabled = false;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(16, 378);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(98, 16);
            this.lblPass.TabIndex = 14;
            this.lblPass.Text = "&New Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(9, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(74, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "&UserName";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Enabled = false;
            this.txtConfirmPass.Location = new System.Drawing.Point(155, 426);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '•';
            this.txtConfirmPass.Size = new System.Drawing.Size(306, 20);
            this.txtConfirmPass.TabIndex = 17;
            this.txtConfirmPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPass_KeyDown);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Enabled = false;
            this.lblConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(12, 430);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(116, 16);
            this.lblConfirm.TabIndex = 16;
            this.lblConfirm.Text = "Confirm &Password";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(357, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 36);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAnswer3
            // 
            this.txtAnswer3.Enabled = false;
            this.txtAnswer3.Location = new System.Drawing.Point(155, 322);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(306, 20);
            this.txtAnswer3.TabIndex = 13;
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Enabled = false;
            this.txtAnswer2.Location = new System.Drawing.Point(155, 218);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(306, 20);
            this.txtAnswer2.TabIndex = 9;
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Enabled = false;
            this.txtAnswer1.Location = new System.Drawing.Point(155, 115);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(306, 20);
            this.txtAnswer1.TabIndex = 5;
            // 
            // lblAnswer3
            // 
            this.lblAnswer3.AutoSize = true;
            this.lblAnswer3.Enabled = false;
            this.lblAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer3.Location = new System.Drawing.Point(12, 324);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(67, 16);
            this.lblAnswer3.TabIndex = 12;
            this.lblAnswer3.Text = "Answer &3*";
            // 
            // lblSecurity3
            // 
            this.lblSecurity3.AutoSize = true;
            this.lblSecurity3.Enabled = false;
            this.lblSecurity3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity3.Location = new System.Drawing.Point(12, 270);
            this.lblSecurity3.Name = "lblSecurity3";
            this.lblSecurity3.Size = new System.Drawing.Size(127, 16);
            this.lblSecurity3.TabIndex = 10;
            this.lblSecurity3.Text = "Security Question 3*";
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Enabled = false;
            this.lblAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer2.Location = new System.Drawing.Point(12, 218);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(67, 16);
            this.lblAnswer2.TabIndex = 8;
            this.lblAnswer2.Text = "Answer &2*";
            // 
            // lblSecurity2
            // 
            this.lblSecurity2.AutoSize = true;
            this.lblSecurity2.Enabled = false;
            this.lblSecurity2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity2.Location = new System.Drawing.Point(12, 166);
            this.lblSecurity2.Name = "lblSecurity2";
            this.lblSecurity2.Size = new System.Drawing.Size(127, 16);
            this.lblSecurity2.TabIndex = 6;
            this.lblSecurity2.Text = "Security Question 2*";
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Enabled = false;
            this.lblAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer1.Location = new System.Drawing.Point(12, 114);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(67, 16);
            this.lblAnswer1.TabIndex = 4;
            this.lblAnswer1.Text = "Answer &1*";
            // 
            // lblSecurity1
            // 
            this.lblSecurity1.AutoSize = true;
            this.lblSecurity1.Enabled = false;
            this.lblSecurity1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity1.Location = new System.Drawing.Point(8, 62);
            this.lblSecurity1.Name = "lblSecurity1";
            this.lblSecurity1.Size = new System.Drawing.Size(127, 16);
            this.lblSecurity1.TabIndex = 2;
            this.lblSecurity1.Text = "Security Question 1*";
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(15, 487);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(104, 36);
            this.btnEnter.TabIndex = 18;
            this.btnEnter.Text = "&Load";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtSecurity3
            // 
            this.txtSecurity3.Enabled = false;
            this.txtSecurity3.Location = new System.Drawing.Point(155, 270);
            this.txtSecurity3.Name = "txtSecurity3";
            this.txtSecurity3.ReadOnly = true;
            this.txtSecurity3.Size = new System.Drawing.Size(306, 20);
            this.txtSecurity3.TabIndex = 11;
            // 
            // txtSecurity2
            // 
            this.txtSecurity2.Enabled = false;
            this.txtSecurity2.Location = new System.Drawing.Point(155, 166);
            this.txtSecurity2.Name = "txtSecurity2";
            this.txtSecurity2.ReadOnly = true;
            this.txtSecurity2.Size = new System.Drawing.Size(306, 20);
            this.txtSecurity2.TabIndex = 7;
            // 
            // txtSecurity1
            // 
            this.txtSecurity1.Enabled = false;
            this.txtSecurity1.Location = new System.Drawing.Point(155, 62);
            this.txtSecurity1.Name = "txtSecurity1";
            this.txtSecurity1.ReadOnly = true;
            this.txtSecurity1.Size = new System.Drawing.Size(306, 20);
            this.txtSecurity1.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(186, 487);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(104, 36);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowPass.BackgroundImage")));
            this.btnShowPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowPass.Enabled = false;
            this.btnShowPass.Location = new System.Drawing.Point(436, 398);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(25, 22);
            this.btnShowPass.TabIndex = 41;
            this.btnShowPass.UseVisualStyleBackColor = false;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // frmResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 543);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtSecurity1);
            this.Controls.Add(this.txtSecurity2);
            this.Controls.Add(this.txtSecurity3);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtAnswer3);
            this.Controls.Add(this.txtAnswer2);
            this.Controls.Add(this.txtAnswer1);
            this.Controls.Add(this.lblAnswer3);
            this.Controls.Add(this.lblSecurity3);
            this.Controls.Add(this.lblAnswer2);
            this.Controls.Add(this.lblSecurity2);
            this.Controls.Add(this.lblAnswer1);
            this.Controls.Add(this.lblSecurity1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Reset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.Label lblAnswer3;
        private System.Windows.Forms.Label lblSecurity3;
        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.Label lblSecurity2;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.Label lblSecurity1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtSecurity3;
        private System.Windows.Forms.TextBox txtSecurity2;
        private System.Windows.Forms.TextBox txtSecurity1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnShowPass;
    }
}