
namespace SU21_Final_Project
{
    partial class frmEmpInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpInfo));
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStates = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(556, 43);
            this.lblInfo.TabIndex = 25;
            this.lblInfo.Text = "Current Employee info. The fields with \" * \" are able to be changed. If any other" +
    "s need to be changed, please contact one of the Managers";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(233, 422);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 46);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(451, 422);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 46);
            this.btnUpdate.TabIndex = 46;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(15, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 46);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAddress3
            // 
            this.txtAddress3.Location = new System.Drawing.Point(119, 202);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.ReadOnly = true;
            this.txtAddress3.Size = new System.Drawing.Size(155, 20);
            this.txtAddress3.TabIndex = 35;
            this.txtAddress3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress3_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Address3*";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(403, 127);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.ReadOnly = true;
            this.txtAddress2.Size = new System.Drawing.Size(155, 20);
            this.txtAddress2.TabIndex = 33;
            this.txtAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(304, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Address2*";
            // 
            // cboStates
            // 
            this.cboStates.DropDownHeight = 75;
            this.cboStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStates.Enabled = false;
            this.cboStates.FormattingEnabled = true;
            this.cboStates.IntegralHeight = false;
            this.cboStates.Location = new System.Drawing.Point(119, 275);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(155, 21);
            this.cboStates.TabIndex = 39;
            this.cboStates.SelectedValueChanged += new System.EventHandler(this.cboStates_SelectedValueChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(119, 354);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(155, 20);
            this.txtPhone.TabIndex = 43;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(12, 355);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(54, 17);
            this.lblPhone.TabIndex = 42;
            this.lblPhone.Text = "Phone*";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(403, 354);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(155, 20);
            this.txtEmail.TabIndex = 45;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(300, 355);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 17);
            this.lblEmail.TabIndex = 44;
            this.lblEmail.Text = "Email*";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(403, 275);
            this.txtZip.Name = "txtZip";
            this.txtZip.ReadOnly = true;
            this.txtZip.Size = new System.Drawing.Size(155, 20);
            this.txtZip.TabIndex = 41;
            this.txtZip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZip_KeyPress);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(403, 202);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(155, 20);
            this.txtCity.TabIndex = 37;
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCity_KeyPress);
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(403, 55);
            this.txtLast.Name = "txtLast";
            this.txtLast.ReadOnly = true;
            this.txtLast.Size = new System.Drawing.Size(155, 20);
            this.txtLast.TabIndex = 29;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(119, 127);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(155, 20);
            this.txtAddress1.TabIndex = 31;
            this.txtAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress1_KeyPress);
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(119, 55);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.ReadOnly = true;
            this.txtFirst.Size = new System.Drawing.Size(155, 20);
            this.txtFirst.TabIndex = 27;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZip.Location = new System.Drawing.Point(300, 280);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(64, 17);
            this.lblZip.TabIndex = 40;
            this.lblZip.Text = "Zipcode*";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(12, 280);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 17);
            this.lblState.TabIndex = 38;
            this.lblState.Text = "State*";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(304, 205);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(36, 17);
            this.lblCity.TabIndex = 36;
            this.lblCity.Text = "City*";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(12, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 17);
            this.lblAddress.TabIndex = 30;
            this.lblAddress.Text = "Address*";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.Location = new System.Drawing.Point(300, 55);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(76, 17);
            this.lblLName.TabIndex = 28;
            this.lblLName.Text = "Last Name";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.Location = new System.Drawing.Point(12, 55);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(76, 17);
            this.lblFName.TabIndex = 26;
            this.lblFName.Text = "First Name";
            // 
            // frmEmpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 478);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAddress3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboStates);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmpInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Info";
            this.Load += new System.EventHandler(this.frmEmpInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStates;
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
    }
}