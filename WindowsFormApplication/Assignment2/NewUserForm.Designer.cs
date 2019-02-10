namespace Assignment2
{
    partial class NewUserForm
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
            this.labelNewUsername = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelReEnterPassword = new System.Windows.Forms.Label();
            this.labelNewFirstname = new System.Windows.Forms.Label();
            this.labelNewLastname = new System.Windows.Forms.Label();
            this.labelNewDateOfBirth = new System.Windows.Forms.Label();
            this.labelNewUsertype = new System.Windows.Forms.Label();
            this.textBoxNewUsername = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxReEnterPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewFirstname = new System.Windows.Forms.TextBox();
            this.textBoxNewLastname = new System.Windows.Forms.TextBox();
            this.NewDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelNewUsername
            // 
            this.labelNewUsername.AutoSize = true;
            this.labelNewUsername.Location = new System.Drawing.Point(13, 35);
            this.labelNewUsername.Name = "labelNewUsername";
            this.labelNewUsername.Size = new System.Drawing.Size(55, 13);
            this.labelNewUsername.TabIndex = 0;
            this.labelNewUsername.Text = "Username";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(13, 74);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(53, 13);
            this.labelNewPassword.TabIndex = 1;
            this.labelNewPassword.Text = "Password";
            // 
            // labelReEnterPassword
            // 
            this.labelReEnterPassword.AutoSize = true;
            this.labelReEnterPassword.Location = new System.Drawing.Point(13, 114);
            this.labelReEnterPassword.Name = "labelReEnterPassword";
            this.labelReEnterPassword.Size = new System.Drawing.Size(98, 13);
            this.labelReEnterPassword.TabIndex = 2;
            this.labelReEnterPassword.Text = "Re-Enter Password";
            // 
            // labelNewFirstname
            // 
            this.labelNewFirstname.AutoSize = true;
            this.labelNewFirstname.Location = new System.Drawing.Point(13, 153);
            this.labelNewFirstname.Name = "labelNewFirstname";
            this.labelNewFirstname.Size = new System.Drawing.Size(57, 13);
            this.labelNewFirstname.TabIndex = 3;
            this.labelNewFirstname.Text = "First Name";
            // 
            // labelNewLastname
            // 
            this.labelNewLastname.AutoSize = true;
            this.labelNewLastname.Location = new System.Drawing.Point(13, 193);
            this.labelNewLastname.Name = "labelNewLastname";
            this.labelNewLastname.Size = new System.Drawing.Size(58, 13);
            this.labelNewLastname.TabIndex = 4;
            this.labelNewLastname.Text = "Last Name";
            // 
            // labelNewDateOfBirth
            // 
            this.labelNewDateOfBirth.AutoSize = true;
            this.labelNewDateOfBirth.Location = new System.Drawing.Point(13, 233);
            this.labelNewDateOfBirth.Name = "labelNewDateOfBirth";
            this.labelNewDateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.labelNewDateOfBirth.TabIndex = 5;
            this.labelNewDateOfBirth.Text = "Date of Birth";
            // 
            // labelNewUsertype
            // 
            this.labelNewUsertype.AutoSize = true;
            this.labelNewUsertype.Location = new System.Drawing.Point(13, 273);
            this.labelNewUsertype.Name = "labelNewUsertype";
            this.labelNewUsertype.Size = new System.Drawing.Size(56, 13);
            this.labelNewUsertype.TabIndex = 6;
            this.labelNewUsertype.Text = "User Type";
            // 
            // textBoxNewUsername
            // 
            this.textBoxNewUsername.Location = new System.Drawing.Point(16, 51);
            this.textBoxNewUsername.Name = "textBoxNewUsername";
            this.textBoxNewUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewUsername.TabIndex = 7;
            this.textBoxNewUsername.TextChanged += new System.EventHandler(this.TextBoxNewUsername_TextChanged);
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(16, 90);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPassword.TabIndex = 8;
            this.textBoxNewPassword.TextChanged += new System.EventHandler(this.TextBoxNewPassword_TextChanged);
            // 
            // textBoxReEnterPassword
            // 
            this.textBoxReEnterPassword.Location = new System.Drawing.Point(16, 130);
            this.textBoxReEnterPassword.Name = "textBoxReEnterPassword";
            this.textBoxReEnterPassword.PasswordChar = '*';
            this.textBoxReEnterPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxReEnterPassword.TabIndex = 9;
            this.textBoxReEnterPassword.TextChanged += new System.EventHandler(this.TextBoxReEnterPassword_TextChanged);
            // 
            // textBoxNewFirstname
            // 
            this.textBoxNewFirstname.Location = new System.Drawing.Point(16, 170);
            this.textBoxNewFirstname.Name = "textBoxNewFirstname";
            this.textBoxNewFirstname.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewFirstname.TabIndex = 10;
            this.textBoxNewFirstname.TextChanged += new System.EventHandler(this.TextBoxNewFirstname_TextChanged);
            // 
            // textBoxNewLastname
            // 
            this.textBoxNewLastname.Location = new System.Drawing.Point(16, 210);
            this.textBoxNewLastname.Name = "textBoxNewLastname";
            this.textBoxNewLastname.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewLastname.TabIndex = 11;
            this.textBoxNewLastname.TextChanged += new System.EventHandler(this.TextBoxNewLastname_TextChanged);
            // 
            // NewDateTimePicker
            // 
            this.NewDateTimePicker.Location = new System.Drawing.Point(16, 250);
            this.NewDateTimePicker.Name = "NewDateTimePicker";
            this.NewDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.NewDateTimePicker.TabIndex = 12;
            this.NewDateTimePicker.Value = new System.DateTime(2018, 10, 7, 1, 29, 44, 0);
            this.NewDateTimePicker.ValueChanged += new System.EventHandler(this.NewDateTimePicker_ValueChanged);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(13, 327);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(75, 23);
            this.ButtonSubmit.TabIndex = 15;
            this.ButtonSubmit.Text = "Submit";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(141, 327);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 16;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "View",
            "Edit"});
            this.comboBox1.Location = new System.Drawing.Point(16, 289);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 366);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.NewDateTimePicker);
            this.Controls.Add(this.textBoxNewLastname);
            this.Controls.Add(this.textBoxNewFirstname);
            this.Controls.Add(this.textBoxReEnterPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxNewUsername);
            this.Controls.Add(this.labelNewUsertype);
            this.Controls.Add(this.labelNewDateOfBirth);
            this.Controls.Add(this.labelNewLastname);
            this.Controls.Add(this.labelNewFirstname);
            this.Controls.Add(this.labelReEnterPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelNewUsername);
            this.Name = "NewUserForm";
            this.Text = "New User";
            this.Load += new System.EventHandler(this.NewUserWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewUsername;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelReEnterPassword;
        private System.Windows.Forms.Label labelNewFirstname;
        private System.Windows.Forms.Label labelNewLastname;
        private System.Windows.Forms.Label labelNewDateOfBirth;
        private System.Windows.Forms.Label labelNewUsertype;
        private System.Windows.Forms.TextBox textBoxNewUsername;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxReEnterPassword;
        private System.Windows.Forms.TextBox textBoxNewFirstname;
        private System.Windows.Forms.TextBox textBoxNewLastname;
        private System.Windows.Forms.DateTimePicker NewDateTimePicker;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}