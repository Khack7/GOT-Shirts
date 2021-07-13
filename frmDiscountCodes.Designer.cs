
namespace SU21_Final_Project
{
    partial class frmDiscountCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountCodes));
            this.cboCodes = new System.Windows.Forms.ComboBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblStatusPointer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnStartCreation = new System.Windows.Forms.Button();
            this.grpBxCodes = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblPercentOff = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.lblNewCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblPercentDisplay = new System.Windows.Forms.Label();
            this.lblPercentPointer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.grpBxCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCodes
            // 
            this.cboCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCodes.FormattingEnabled = true;
            this.cboCodes.ItemHeight = 16;
            this.cboCodes.Location = new System.Drawing.Point(15, 60);
            this.cboCodes.MaxDropDownItems = 7;
            this.cboCodes.Name = "cboCodes";
            this.cboCodes.Size = new System.Drawing.Size(121, 24);
            this.cboCodes.TabIndex = 1;
            this.cboCodes.SelectedIndexChanged += new System.EventHandler(this.cboCodes_SelectedIndexChanged);
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(12, 12);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(121, 23);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusPointer
            // 
            this.lblStatusPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPointer.Location = new System.Drawing.Point(164, 12);
            this.lblStatusPointer.Name = "lblStatusPointer";
            this.lblStatusPointer.Size = new System.Drawing.Size(121, 23);
            this.lblStatusPointer.TabIndex = 2;
            this.lblStatusPointer.Text = "Status";
            this.lblStatusPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(164, 61);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(121, 23);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status Here";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(167, 103);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(121, 33);
            this.btnActivate.TabIndex = 6;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(316, 103);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(121, 33);
            this.btnDeactivate.TabIndex = 7;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnStartCreation
            // 
            this.btnStartCreation.Location = new System.Drawing.Point(12, 225);
            this.btnStartCreation.Name = "btnStartCreation";
            this.btnStartCreation.Size = new System.Drawing.Size(121, 33);
            this.btnStartCreation.TabIndex = 8;
            this.btnStartCreation.Text = "Create New Code";
            this.btnStartCreation.UseVisualStyleBackColor = true;
            this.btnStartCreation.Click += new System.EventHandler(this.btnStartCreation_Click);
            // 
            // grpBxCodes
            // 
            this.grpBxCodes.Controls.Add(this.btnCancel);
            this.grpBxCodes.Controls.Add(this.btnCreate);
            this.grpBxCodes.Controls.Add(this.lblPercentOff);
            this.grpBxCodes.Controls.Add(this.txtPercent);
            this.grpBxCodes.Controls.Add(this.lblNewCode);
            this.grpBxCodes.Controls.Add(this.txtCode);
            this.grpBxCodes.Enabled = false;
            this.grpBxCodes.Location = new System.Drawing.Point(12, 264);
            this.grpBxCodes.Name = "grpBxCodes";
            this.grpBxCodes.Size = new System.Drawing.Size(417, 136);
            this.grpBxCodes.TabIndex = 9;
            this.grpBxCodes.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(290, 22);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 33);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblPercentOff
            // 
            this.lblPercentOff.AutoSize = true;
            this.lblPercentOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentOff.Location = new System.Drawing.Point(6, 93);
            this.lblPercentOff.Name = "lblPercentOff";
            this.lblPercentOff.Size = new System.Drawing.Size(84, 17);
            this.lblPercentOff.TabIndex = 2;
            this.lblPercentOff.Text = "Percent Off:";
            this.lblPercentOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(96, 92);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(100, 20);
            this.txtPercent.TabIndex = 3;
            this.txtPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercent_KeyPress);
            // 
            // lblNewCode
            // 
            this.lblNewCode.AutoSize = true;
            this.lblNewCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCode.Location = new System.Drawing.Point(6, 22);
            this.lblNewCode.Name = "lblNewCode";
            this.lblNewCode.Size = new System.Drawing.Size(45, 17);
            this.lblNewCode.TabIndex = 0;
            this.lblNewCode.Text = "Code:";
            this.lblNewCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(96, 22);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // lblPercentDisplay
            // 
            this.lblPercentDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPercentDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentDisplay.Location = new System.Drawing.Point(316, 61);
            this.lblPercentDisplay.Name = "lblPercentDisplay";
            this.lblPercentDisplay.Size = new System.Drawing.Size(121, 23);
            this.lblPercentDisplay.TabIndex = 5;
            this.lblPercentDisplay.Text = "Percent off Here";
            this.lblPercentDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercentPointer
            // 
            this.lblPercentPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentPointer.Location = new System.Drawing.Point(316, 12);
            this.lblPercentPointer.Name = "lblPercentPointer";
            this.lblPercentPointer.Size = new System.Drawing.Size(121, 23);
            this.lblPercentPointer.TabIndex = 4;
            this.lblPercentPointer.Text = "Percent off";
            this.lblPercentPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(319, 225);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(121, 33);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmDiscountCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 410);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPercentDisplay);
            this.Controls.Add(this.lblPercentPointer);
            this.Controls.Add(this.grpBxCodes);
            this.Controls.Add(this.btnStartCreation);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStatusPointer);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.cboCodes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiscountCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code management";
            this.Load += new System.EventHandler(this.frmDiscountCodes_Load);
            this.grpBxCodes.ResumeLayout(false);
            this.grpBxCodes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCodes;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblStatusPointer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnStartCreation;
        private System.Windows.Forms.GroupBox grpBxCodes;
        private System.Windows.Forms.Label lblNewCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblPercentOff;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label lblPercentDisplay;
        private System.Windows.Forms.Label lblPercentPointer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCancel;
    }
}