namespace OTPVerificationApp
{
    partial class MainForm
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
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnGenerateOTP = new System.Windows.Forms.Button();
            this.lblOTP = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(12, 15);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 0;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(99, 12);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(150, 20);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // btnGenerateOTP
            // 
            this.btnGenerateOTP.Location = new System.Drawing.Point(15, 61);
            this.btnGenerateOTP.Name = "btnGenerateOTP";
            this.btnGenerateOTP.Size = new System.Drawing.Size(113, 23);
            this.btnGenerateOTP.TabIndex = 2;
            this.btnGenerateOTP.Text = "Generate OTP";
            this.btnGenerateOTP.UseVisualStyleBackColor = true;
            this.btnGenerateOTP.Click += new System.EventHandler(this.btnGenerateOTP_Click);
            // 
            // lblOTP
            // 
            this.lblOTP.AutoSize = true;
            this.lblOTP.Location = new System.Drawing.Point(12, 41);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(32, 13);
            this.lblOTP.TabIndex = 3;
            this.lblOTP.Text = "OTP:";
            // 
            // txtOTP
            // 
            this.txtOTP.Location = new System.Drawing.Point(99, 38);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(150, 20);
            this.txtOTP.TabIndex = 4;
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.Location = new System.Drawing.Point(134, 61);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(115, 23);
            this.btnVerifyOTP.TabIndex = 5;
            this.btnVerifyOTP.Text = "Verify OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = true;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 94);
            this.Controls.Add(this.btnVerifyOTP);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblOTP);
            this.Controls.Add(this.btnGenerateOTP);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EC2Guard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnGenerateOTP;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
    }
}
