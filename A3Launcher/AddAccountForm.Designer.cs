namespace A3Launcher
    {
    partial class AddAccountForm
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
            this.AddAccountUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddAccountPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddAccountUserID
            // 
            this.AddAccountUserID.Location = new System.Drawing.Point(72, 18);
            this.AddAccountUserID.Name = "AddAccountUserID";
            this.AddAccountUserID.Size = new System.Drawing.Size(127, 20);
            this.AddAccountUserID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // AddAccountPassword
            // 
            this.AddAccountPassword.Location = new System.Drawing.Point(72, 44);
            this.AddAccountPassword.Name = "AddAccountPassword";
            this.AddAccountPassword.PasswordChar = '*';
            this.AddAccountPassword.Size = new System.Drawing.Size(127, 20);
            this.AddAccountPassword.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(72, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddAccountForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 108);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddAccountPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddAccountUserID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddAccountForm";
            this.Text = "Add Account";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

            public System.Windows.Forms.TextBox AddAccountUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox AddAccountPassword;
        private System.Windows.Forms.Button button1;
        }
    }