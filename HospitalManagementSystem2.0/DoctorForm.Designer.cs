namespace HospitalManagementSystem2._0
{
    partial class DoctorForm
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
            userLoginIdTextBox = new TextBox();
            docIdTextBox = new TextBox();
            doctorDataGridView = new DataGridView();
            chkGiveLoginPermission = new CheckBox();
            pictureBoxLogout = new PictureBox();
            passwordTextBox = new TextBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            ageTextBox = new TextBox();
            contactTextBox = new TextBox();
            addressTextBox = new TextBox();
            usernameTextBox = new TextBox();
            nameTextBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            yoeTextBox = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)doctorDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // userLoginIdTextBox
            // 
            userLoginIdTextBox.Location = new Point(262, 536);
            userLoginIdTextBox.Name = "userLoginIdTextBox";
            userLoginIdTextBox.Size = new Size(226, 31);
            userLoginIdTextBox.TabIndex = 32;
            // 
            // docIdTextBox
            // 
            docIdTextBox.Location = new Point(10, 536);
            docIdTextBox.Name = "docIdTextBox";
            docIdTextBox.Size = new Size(226, 31);
            docIdTextBox.TabIndex = 31;
            // 
            // doctorDataGridView
            // 
            doctorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            doctorDataGridView.Location = new Point(295, 220);
            doctorDataGridView.Name = "doctorDataGridView";
            doctorDataGridView.RowHeadersWidth = 62;
            doctorDataGridView.Size = new Size(578, 300);
            doctorDataGridView.TabIndex = 30;
            // 
            // chkGiveLoginPermission
            // 
            chkGiveLoginPermission.AutoSize = true;
            chkGiveLoginPermission.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkGiveLoginPermission.ForeColor = SystemColors.GradientActiveCaption;
            chkGiveLoginPermission.Location = new Point(655, 176);
            chkGiveLoginPermission.Name = "chkGiveLoginPermission";
            chkGiveLoginPermission.Size = new Size(237, 29);
            chkGiveLoginPermission.TabIndex = 29;
            chkGiveLoginPermission.Text = "Give Login Permission ?";
            chkGiveLoginPermission.TextAlign = ContentAlignment.BottomLeft;
            chkGiveLoginPermission.UseVisualStyleBackColor = true;
            chkGiveLoginPermission.CheckedChanged += chkGiveLoginPermission_CheckedChanged;
            // 
            // pictureBoxLogout
            // 
            pictureBoxLogout.Image = Properties.Resources.Logout;
            pictureBoxLogout.Location = new Point(841, 547);
            pictureBoxLogout.Name = "pictureBoxLogout";
            pictureBoxLogout.Size = new Size(42, 39);
            pictureBoxLogout.TabIndex = 28;
            pictureBoxLogout.TabStop = false;
            pictureBoxLogout.Click += pictureBoxLogout_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(469, 174);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(175, 31);
            passwordTextBox.TabIndex = 27;
            passwordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.HighlightText;
            btnDelete.Location = new Point(10, 486);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(255, 34);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.GradientActiveCaption;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = SystemColors.HighlightText;
            btnEdit.Location = new Point(153, 437);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.GradientActiveCaption;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.HighlightText;
            btnSave.Location = new Point(10, 437);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 24;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(146, 220);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.PlaceholderText = "AGE";
            ageTextBox.Size = new Size(119, 31);
            ageTextBox.TabIndex = 23;
            ageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(10, 269);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.PlaceholderText = "CONTACT";
            contactTextBox.Size = new Size(255, 31);
            contactTextBox.TabIndex = 21;
            contactTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(10, 319);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.PlaceholderText = "ADDRESS";
            addressTextBox.Size = new Size(255, 102);
            addressTextBox.TabIndex = 20;
            addressTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(285, 174);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Username";
            usernameTextBox.Size = new Size(175, 31);
            usernameTextBox.TabIndex = 19;
            usernameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(10, 174);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Doc Name";
            nameTextBox.Size = new Size(255, 31);
            nameTextBox.TabIndex = 18;
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(426, 104);
            label3.Name = "label3";
            label3.Size = new Size(103, 30);
            label3.TabIndex = 6;
            label3.Text = "DOCTOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(66, 40);
            label1.Name = "label1";
            label1.Size = new Size(779, 62);
            label1.TabIndex = 0;
            label1.Text = "HOSPITAL MANAGEMENT SYSTEM";
            // 
            // yoeTextBox
            // 
            yoeTextBox.Location = new Point(10, 220);
            yoeTextBox.Name = "yoeTextBox";
            yoeTextBox.PlaceholderText = "YOE";
            yoeTextBox.Size = new Size(119, 31);
            yoeTextBox.TabIndex = 22;
            yoeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-13, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(916, 150);
            panel1.TabIndex = 17;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(902, 608);
            Controls.Add(userLoginIdTextBox);
            Controls.Add(docIdTextBox);
            Controls.Add(doctorDataGridView);
            Controls.Add(chkGiveLoginPermission);
            Controls.Add(pictureBoxLogout);
            Controls.Add(passwordTextBox);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnSave);
            Controls.Add(ageTextBox);
            Controls.Add(contactTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(yoeTextBox);
            Controls.Add(panel1);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)doctorDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userLoginIdTextBox;
        private TextBox docIdTextBox;
        private DataGridView doctorDataGridView;
        private CheckBox chkGiveLoginPermission;
        private PictureBox pictureBoxLogout;
        private TextBox passwordTextBox;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnSave;
        private TextBox ageTextBox;
        private TextBox contactTextBox;
        private TextBox addressTextBox;
        private TextBox usernameTextBox;
        private TextBox nameTextBox;
        private Label label3;
        private Label label1;
        private TextBox yoeTextBox;
        private Panel panel1;
    }
}