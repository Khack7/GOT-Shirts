
namespace SU21_Final_Project
{
    partial class frmRegister
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
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboStates
            // 
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(95, 279);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(155, 21);
            this.cboStates.TabIndex = 56;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(95, 429);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(155, 20);
            this.txtUsername.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "UserName*";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(360, 429);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(155, 20);
            this.txtPassword.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Password*";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(15, 504);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 44);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(368, 504);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(147, 44);
            this.btnRegister.TabIndex = 50;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(360, 350);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(155, 20);
            this.txtPhone.TabIndex = 49;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(274, 353);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 48;
            this.lblPhone.Text = "Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 353);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(155, 20);
            this.txtEmail.TabIndex = 47;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(11, 353);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 46;
            this.lblEmail.Text = "Email";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(360, 278);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(155, 20);
            this.txtZip.TabIndex = 45;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(360, 202);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(155, 20);
            this.txtCity.TabIndex = 44;
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCity_KeyPress);
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(360, 57);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(155, 20);
            this.txtLast.TabIndex = 43;
            this.txtLast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLast_KeyPress);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(95, 131);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(155, 20);
            this.txtAddress1.TabIndex = 42;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(95, 57);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(155, 20);
            this.txtFirst.TabIndex = 41;
            this.txtFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirst_KeyPress);
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZip.Location = new System.Drawing.Point(274, 279);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(64, 17);
            this.lblZip.TabIndex = 40;
            this.lblZip.Text = "Zipcode*";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(12, 279);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 17);
            this.lblState.TabIndex = 39;
            this.lblState.Text = "State*";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(274, 205);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(36, 17);
            this.lblCity.TabIndex = 38;
            this.lblCity.Text = "City*";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(10, 131);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 17);
            this.lblAddress.TabIndex = 37;
            this.lblAddress.Text = "Address*";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.Location = new System.Drawing.Point(275, 57);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(81, 17);
            this.lblLName.TabIndex = 36;
            this.lblLName.Text = "Last Name*";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.Location = new System.Drawing.Point(12, 57);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(81, 17);
            this.lblFName.TabIndex = 35;
            this.lblFName.Text = "First Name*";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(515, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Please fill out all that apply. The fields with \" * \" are required";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(360, 126);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(155, 20);
            this.txtAddress2.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Address2";
            // 
            // txtAddress3
            // 
            this.txtAddress3.Location = new System.Drawing.Point(95, 205);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(155, 20);
            this.txtAddress3.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Address3";
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 556);
            this.Controls.Add(this.txtAddress3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboStates);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblFName);
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStates;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.Label label6;
    }
}