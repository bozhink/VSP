namespace PasswordGenerator
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSrcString = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPassLength = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSrcString);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPassLength);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generator";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(277, 123);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Source String";
            // 
            // cmbSrcString
            // 
            this.cmbSrcString.FormattingEnabled = true;
            this.cmbSrcString.Items.AddRange(new object[] {
            "ss1",
            "ss2",
            "ss3",
            "ss4",
            "ss5",
            "ss6",
            "ss7",
            "ss8",
            "ss9"});
            this.cmbSrcString.Location = new System.Drawing.Point(118, 125);
            this.cmbSrcString.Name = "cmbSrcString";
            this.cmbSrcString.Size = new System.Drawing.Size(121, 21);
            this.cmbSrcString.TabIndex = 3;
            this.cmbSrcString.SelectedValueChanged += new System.EventHandler(this.cmbSrcString_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password Length";
            // 
            // cmbPassLength
            // 
            this.cmbPassLength.FormattingEnabled = true;
            this.cmbPassLength.Items.AddRange(new object[] {
            "4",
            "8",
            "12",
            "16",
            "24",
            "32",
            "36",
            "64"});
            this.cmbPassLength.Location = new System.Drawing.Point(118, 85);
            this.cmbPassLength.Name = "cmbPassLength";
            this.cmbPassLength.Size = new System.Drawing.Size(121, 21);
            this.cmbPassLength.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(26, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(313, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblDescription);
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(22, 31);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Password Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSrcString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPassLength;
        private System.Windows.Forms.TextBox txtPassword;

        //
        // Source Strings
        //

        private const System.String ss1 = "0123456789";
        private const System.String ss2 = "abcdefghijklmnopqrstuvwxyz";
        private const System.String ss3 = "ABCDEFGHIJKLMNOPQRSYUVWXYZ";
        private const System.String ss4 = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const System.String ss5 = "ABCDEFGHIJKLMNOPQRSYUVWXYZ0123456789";
        private const System.String ss6 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSYUVWXYZ0123456789";
        private const System.String ss7 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSYUVWXYZ0123456789_";
        private const System.String ss8 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSYUVWXYZ0123456789_.-";
        private const System.String ss9 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSYUVWXYZ0123456789_.@#$%&-*+";
    }
}

