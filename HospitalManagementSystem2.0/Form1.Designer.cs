namespace HospitalManagementSystem2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTextBox = new TextBox();
            linkLabelCreateUser = new LinkLabel();
            btnLogin = new Button();
            passwordTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(20, 216);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "USERNAME";
            usernameTextBox.Size = new Size(219, 31);
            usernameTextBox.TabIndex = 12;
            usernameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // linkLabelCreateUser
            // 
            linkLabelCreateUser.AutoSize = true;
            linkLabelCreateUser.Font = new Font("Segoe UI", 6F);
            linkLabelCreateUser.Location = new Point(81, 385);
            linkLabelCreateUser.Name = "linkLabelCreateUser";
            linkLabelCreateUser.Size = new Size(106, 15);
            linkLabelCreateUser.TabIndex = 11;
            linkLabelCreateUser.TabStop = true;
            linkLabelCreateUser.Text = "CREATE NEW USER";
            linkLabelCreateUser.LinkClicked += linkLabelCreateUser_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.GradientActiveCaption;
            btnLogin.ForeColor = SystemColors.HighlightText;
            btnLogin.Location = new Point(23, 321);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(219, 34);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(23, 262);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "PASSWORD";
            passwordTextBox.Size = new Size(219, 31);
            passwordTextBox.TabIndex = 9;
            passwordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientActiveCaption;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(85, 23);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 3;
            label3.Text = "HOSPITAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientActiveCaption;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(33, 57);
            label2.Name = "label2";
            label2.Size = new Size(218, 25);
            label2.TabIndex = 1;
            label2.Text = "MANAGEMENT SYSTEM";
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-10, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 204);
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.basic_users;
            pictureBox1.Location = new Point(85, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(258, 433);
            Controls.Add(usernameTextBox);
            Controls.Add(linkLabelCreateUser);
            Controls.Add(btnLogin);
            Controls.Add(passwordTextBox);
            Controls.Add(panel1);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private LinkLabel linkLabelCreateUser;
        private Button btnLogin;
        private TextBox passwordTextBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}
