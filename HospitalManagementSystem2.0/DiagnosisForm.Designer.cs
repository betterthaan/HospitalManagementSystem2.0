namespace HospitalManagementSystem2._0
{
    partial class DiagnosisForm
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
            medicineDataGridView = new DataGridView();
            Serial = new DataGridViewTextBoxColumn();
            MedicineName = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            btnAddSymptom = new Button();
            symptomsDataGridView = new DataGridView();
            medicineTextBox = new TextBox();
            pCodeTextBox = new TextBox();
            genderTextBox = new TextBox();
            ageTextBox = new TextBox();
            bloodTextBox = new TextBox();
            patientComboBox = new ComboBox();
            patientIdTextBox = new TextBox();
            pictureBoxLogout = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            label1 = new Label();
            contactTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)medicineDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)symptomsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // medicineDataGridView
            // 
            medicineDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            medicineDataGridView.Columns.AddRange(new DataGridViewColumn[] { Serial, MedicineName });
            medicineDataGridView.Location = new Point(356, 279);
            medicineDataGridView.Name = "medicineDataGridView";
            medicineDataGridView.RowHeadersWidth = 62;
            medicineDataGridView.Size = new Size(515, 324);
            medicineDataGridView.TabIndex = 96;
            medicineDataGridView.CellDoubleClick += medicineDataGridView_CellDoubleClick;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial";
            Serial.MinimumWidth = 8;
            Serial.Name = "Serial";
            Serial.Width = 150;
            // 
            // MedicineName
            // 
            MedicineName.HeaderText = "Medicine Name";
            MedicineName.MinimumWidth = 8;
            MedicineName.Name = "MedicineName";
            MedicineName.Width = 200;
            // 
            // btnSave
            // 
            btnSave.AutoEllipsis = true;
            btnSave.BackColor = SystemColors.GradientActiveCaption;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.HighlightText;
            btnSave.Location = new Point(717, 214);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 40);
            btnSave.TabIndex = 95;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddSymptom
            // 
            btnAddSymptom.AutoEllipsis = true;
            btnAddSymptom.BackColor = SystemColors.GradientActiveCaption;
            btnAddSymptom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddSymptom.ForeColor = SystemColors.HighlightText;
            btnAddSymptom.Location = new Point(562, 214);
            btnAddSymptom.Name = "btnAddSymptom";
            btnAddSymptom.Size = new Size(126, 40);
            btnAddSymptom.TabIndex = 94;
            btnAddSymptom.Text = "ADD";
            btnAddSymptom.UseVisualStyleBackColor = false;
            btnAddSymptom.Click += btnAddSymptom_Click;
            // 
            // symptomsDataGridView
            // 
            symptomsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            symptomsDataGridView.Location = new Point(36, 333);
            symptomsDataGridView.Name = "symptomsDataGridView";
            symptomsDataGridView.RowHeadersWidth = 62;
            symptomsDataGridView.Size = new Size(292, 270);
            symptomsDataGridView.TabIndex = 93;
            // 
            // medicineTextBox
            // 
            medicineTextBox.Location = new Point(301, 214);
            medicineTextBox.Name = "medicineTextBox";
            medicineTextBox.PlaceholderText = "MEDICINE";
            medicineTextBox.Size = new Size(239, 31);
            medicineTextBox.TabIndex = 92;
            medicineTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // pCodeTextBox
            // 
            pCodeTextBox.Location = new Point(36, 261);
            pCodeTextBox.Name = "pCodeTextBox";
            pCodeTextBox.PlaceholderText = "PATIENT CODE";
            pCodeTextBox.Size = new Size(255, 31);
            pCodeTextBox.TabIndex = 91;
            pCodeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // genderTextBox
            // 
            genderTextBox.BackColor = SystemColors.Menu;
            genderTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            genderTextBox.Location = new Point(644, 170);
            genderTextBox.Name = "genderTextBox";
            genderTextBox.PlaceholderText = "Gender";
            genderTextBox.Size = new Size(135, 31);
            genderTextBox.TabIndex = 90;
            genderTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ageTextBox
            // 
            ageTextBox.BackColor = SystemColors.Menu;
            ageTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ageTextBox.Location = new Point(477, 170);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.PlaceholderText = "Age";
            ageTextBox.Size = new Size(135, 31);
            ageTextBox.TabIndex = 89;
            ageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // bloodTextBox
            // 
            bloodTextBox.BackColor = SystemColors.Menu;
            bloodTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bloodTextBox.Location = new Point(314, 170);
            bloodTextBox.Name = "bloodTextBox";
            bloodTextBox.PlaceholderText = "Blood";
            bloodTextBox.Size = new Size(135, 31);
            bloodTextBox.TabIndex = 88;
            bloodTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // patientComboBox
            // 
            patientComboBox.FormattingEnabled = true;
            patientComboBox.Location = new Point(36, 168);
            patientComboBox.Name = "patientComboBox";
            patientComboBox.Size = new Size(255, 33);
            patientComboBox.TabIndex = 87;
            patientComboBox.Text = "Patients";
            patientComboBox.SelectedValueChanged += patientComboBox_SelectedValueChanged;
            // 
            // patientIdTextBox
            // 
            patientIdTextBox.Location = new Point(64, 626);
            patientIdTextBox.Name = "patientIdTextBox";
            patientIdTextBox.ReadOnly = true;
            patientIdTextBox.Size = new Size(264, 31);
            patientIdTextBox.TabIndex = 85;
            patientIdTextBox.Visible = false;
            // 
            // pictureBoxLogout
            // 
            pictureBoxLogout.Image = Properties.Resources.Logout;
            pictureBoxLogout.Location = new Point(853, 618);
            pictureBoxLogout.Name = "pictureBoxLogout";
            pictureBoxLogout.Size = new Size(42, 39);
            pictureBoxLogout.TabIndex = 84;
            pictureBoxLogout.TabStop = false;
            pictureBoxLogout.Click += pictureBoxLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 150);
            panel1.TabIndex = 83;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(426, 104);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 6;
            label3.Text = "DIAGNOSIS";
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
            // contactTextBox
            // 
            contactTextBox.Location = new Point(36, 214);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.PlaceholderText = "CONTACT";
            contactTextBox.Size = new Size(255, 31);
            contactTextBox.TabIndex = 86;
            contactTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // DiagnosisForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(906, 669);
            Controls.Add(medicineDataGridView);
            Controls.Add(btnSave);
            Controls.Add(btnAddSymptom);
            Controls.Add(symptomsDataGridView);
            Controls.Add(medicineTextBox);
            Controls.Add(pCodeTextBox);
            Controls.Add(genderTextBox);
            Controls.Add(ageTextBox);
            Controls.Add(bloodTextBox);
            Controls.Add(patientComboBox);
            Controls.Add(patientIdTextBox);
            Controls.Add(pictureBoxLogout);
            Controls.Add(panel1);
            Controls.Add(contactTextBox);
            ForeColor = SystemColors.Info;
            FormBorderStyle = FormBorderStyle.None;
            Name = "DiagnosisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiagnosisForm";
            ((System.ComponentModel.ISupportInitialize)medicineDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)symptomsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView medicineDataGridView;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn MedicineName;
        private Button btnSave;
        private Button btnAddSymptom;
        private DataGridView symptomsDataGridView;
        private TextBox medicineTextBox;
        private TextBox pCodeTextBox;
        private TextBox genderTextBox;
        private TextBox ageTextBox;
        private TextBox bloodTextBox;
        private ComboBox patientComboBox;
        private TextBox patientIdTextBox;
        private PictureBox pictureBoxLogout;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private TextBox contactTextBox;
    }
}