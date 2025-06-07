namespace HospitalManagementSystem2._0
{
    partial class PatientForm
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
            doctorComboBox = new ComboBox();
            genderComboBox = new ComboBox();
            contactTextBox = new TextBox();
            btnAddSymptom = new Button();
            labelPCode = new Label();
            label2 = new Label();
            symptomComboBox = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            bloodComboBox = new ComboBox();
            patientIdTextBox = new TextBox();
            pictureBoxLogout = new PictureBox();
            otherSymptomTextBox = new TextBox();
            btnSave = new Button();
            btnGetPrescription = new Button();
            ageTextBox = new TextBox();
            panel1 = new Panel();
            Name = new DataGridViewTextBoxColumn();
            Serial = new DataGridViewTextBoxColumn();
            symptomDataGridView = new DataGridView();
            addressTextBox = new TextBox();
            nameTextBox = new TextBox();
            btnCsv = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            OutputtextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtDiagnosis = new Label();
            txtConfidence = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)symptomDataGridView).BeginInit();
            SuspendLayout();
            // 
            // doctorComboBox
            // 
            doctorComboBox.FormattingEnabled = true;
            doctorComboBox.Location = new Point(295, 261);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(233, 33);
            doctorComboBox.TabIndex = 58;
            doctorComboBox.Text = "Select Doctor";
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female", "Other" });
            genderComboBox.Location = new Point(159, 213);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(120, 33);
            genderComboBox.TabIndex = 56;
            genderComboBox.Text = "Gender";
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(295, 214);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.PlaceholderText = "CONTACT";
            contactTextBox.Size = new Size(233, 31);
            contactTextBox.TabIndex = 55;
            contactTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddSymptom
            // 
            btnAddSymptom.AutoEllipsis = true;
            btnAddSymptom.BackColor = SystemColors.GradientActiveCaption;
            btnAddSymptom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddSymptom.ForeColor = SystemColors.HighlightText;
            btnAddSymptom.Location = new Point(1040, 159);
            btnAddSymptom.Name = "btnAddSymptom";
            btnAddSymptom.Size = new Size(126, 49);
            btnAddSymptom.TabIndex = 54;
            btnAddSymptom.Text = "ADD";
            btnAddSymptom.UseVisualStyleBackColor = false;
            btnAddSymptom.Click += btnAddSymptom_Click;
            // 
            // labelPCode
            // 
            labelPCode.AutoSize = true;
            labelPCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPCode.ForeColor = Color.Red;
            labelPCode.Location = new Point(395, 743);
            labelPCode.Name = "labelPCode";
            labelPCode.Size = new Size(112, 25);
            labelPCode.TabIndex = 53;
            labelPCode.Text = "0000000000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(311, 743);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 52;
            label2.Text = "P-Code:";
            // 
            // symptomComboBox
            // 
            symptomComboBox.FormattingEnabled = true;
            symptomComboBox.Items.AddRange(new object[] { "Судороги и эпилептические приступы", "Головные боли и мигрени", "Головокружение и проблемы с равновесием", "Нарушения чувствительности", "Нарушения речи", "Проблемы со зрением", "Нарушения глотания (дисфагия)", "Недержание мочи или кала", "Нарушения памяти", "Нарушения внимания и концентрации", "Дезориентация во времени и пространстве", "Агнозия", "Апраксия", "Other" });
            symptomComboBox.Location = new Point(295, 168);
            symptomComboBox.Name = "symptomComboBox";
            symptomComboBox.Size = new Size(461, 33);
            symptomComboBox.TabIndex = 51;
            symptomComboBox.Text = "Symptom";
            symptomComboBox.SelectedValueChanged += symptomComboBox_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(426, 104);
            label3.Name = "label3";
            label3.Size = new Size(101, 30);
            label3.TabIndex = 6;
            label3.Text = "PATIENT";
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
            // bloodComboBox
            // 
            bloodComboBox.FormattingEnabled = true;
            bloodComboBox.IntegralHeight = false;
            bloodComboBox.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-" });
            bloodComboBox.Location = new Point(24, 261);
            bloodComboBox.Name = "bloodComboBox";
            bloodComboBox.Size = new Size(255, 33);
            bloodComboBox.TabIndex = 57;
            bloodComboBox.Text = "Blood";
            // 
            // patientIdTextBox
            // 
            patientIdTextBox.Location = new Point(378, 799);
            patientIdTextBox.Name = "patientIdTextBox";
            patientIdTextBox.ReadOnly = true;
            patientIdTextBox.Size = new Size(150, 31);
            patientIdTextBox.TabIndex = 50;
            patientIdTextBox.Visible = false;
            // 
            // pictureBoxLogout
            // 
            pictureBoxLogout.Image = Properties.Resources.Logout;
            pictureBoxLogout.Location = new Point(1138, 814);
            pictureBoxLogout.Name = "pictureBoxLogout";
            pictureBoxLogout.Size = new Size(42, 39);
            pictureBoxLogout.TabIndex = 48;
            pictureBoxLogout.TabStop = false;
            pictureBoxLogout.Click += pictureBoxLogout_Click;
            // 
            // otherSymptomTextBox
            // 
            otherSymptomTextBox.BackColor = SystemColors.Menu;
            otherSymptomTextBox.Location = new Point(785, 168);
            otherSymptomTextBox.Name = "otherSymptomTextBox";
            otherSymptomTextBox.PlaceholderText = "Other Symptom";
            otherSymptomTextBox.Size = new Size(175, 31);
            otherSymptomTextBox.TabIndex = 47;
            otherSymptomTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.AutoEllipsis = true;
            btnSave.BackColor = SystemColors.GradientActiveCaption;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.HighlightText;
            btnSave.Location = new Point(24, 738);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(255, 34);
            btnSave.TabIndex = 46;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnGetPrescription
            // 
            btnGetPrescription.BackColor = SystemColors.GradientActiveCaption;
            btnGetPrescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGetPrescription.ForeColor = SystemColors.HighlightText;
            btnGetPrescription.Location = new Point(24, 784);
            btnGetPrescription.Name = "btnGetPrescription";
            btnGetPrescription.Size = new Size(327, 46);
            btnGetPrescription.TabIndex = 45;
            btnGetPrescription.Text = "Get Prescription";
            btnGetPrescription.UseVisualStyleBackColor = false;
            btnGetPrescription.Click += btnGetPrescription_Click;
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(24, 213);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.PlaceholderText = "AGE";
            ageTextBox.Size = new Size(119, 31);
            ageTextBox.TabIndex = 44;
            ageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1191, 150);
            panel1.TabIndex = 41;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 8;
            Name.Name = "Name";
            Name.Width = 150;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial";
            Serial.MinimumWidth = 8;
            Serial.Name = "Serial";
            Serial.Width = 150;
            // 
            // symptomDataGridView
            // 
            symptomDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            symptomDataGridView.Columns.AddRange(new DataGridViewColumn[] { Serial, Name });
            symptomDataGridView.Location = new Point(568, 214);
            symptomDataGridView.Name = "symptomDataGridView";
            symptomDataGridView.RowHeadersWidth = 62;
            symptomDataGridView.Size = new Size(598, 362);
            symptomDataGridView.TabIndex = 49;
            symptomDataGridView.CellFormatting += symptomDataGridView_CellFormatting;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(24, 313);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.PlaceholderText = "ADDRESS";
            addressTextBox.Size = new Size(478, 102);
            addressTextBox.TabIndex = 43;
            addressTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(24, 168);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Patient Name";
            nameTextBox.Size = new Size(255, 31);
            nameTextBox.TabIndex = 42;
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCsv
            // 
            btnCsv.BackColor = SystemColors.GradientActiveCaption;
            btnCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCsv.Location = new Point(217, 431);
            btnCsv.Name = "btnCsv";
            btnCsv.Size = new Size(101, 44);
            btnCsv.TabIndex = 59;
            btnCsv.Text = "EEG";
            btnCsv.UseVisualStyleBackColor = false;
            btnCsv.Click += btnCsv_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(24, 481);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(478, 16);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 60;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = SystemColors.Info;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(128, 255, 128);
            lblStatus.Location = new Point(235, 500);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 25);
            lblStatus.TabIndex = 61;
            lblStatus.Text = "Done";
            // 
            // OutputtextBox
            // 
            OutputtextBox.Location = new Point(24, 539);
            OutputtextBox.Multiline = true;
            OutputtextBox.Name = "OutputtextBox";
            OutputtextBox.PlaceholderText = "OUTPUT";
            OutputtextBox.Size = new Size(478, 179);
            OutputtextBox.TabIndex = 62;
            OutputtextBox.Text = "Результат анализа:";
            OutputtextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(67, 584);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 63;
            label4.Text = "Диагноз:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(67, 609);
            label5.Name = "label5";
            label5.Size = new Size(128, 25);
            label5.TabIndex = 64;
            label5.Text = "Вероятность:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(67, 634);
            label6.Name = "label6";
            label6.Size = new Size(159, 25);
            label6.TabIndex = 65;
            label6.Text = "Характеристики:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ButtonHighlight;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(67, 659);
            label7.Name = "label7";
            label7.Size = new Size(384, 25);
            label7.TabIndex = 66;
            label7.Text = "- Рекомендация: Консультация невролога";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.AutoSize = true;
            txtDiagnosis.BackColor = SystemColors.ButtonHighlight;
            txtDiagnosis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtDiagnosis.ForeColor = Color.Black;
            txtDiagnosis.Location = new Point(261, 584);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(0, 25);
            txtDiagnosis.TabIndex = 67;
            // 
            // txtConfidence
            // 
            txtConfidence.AutoSize = true;
            txtConfidence.BackColor = SystemColors.ButtonHighlight;
            txtConfidence.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtConfidence.ForeColor = Color.Black;
            txtConfidence.Location = new Point(261, 609);
            txtConfidence.Name = "txtConfidence";
            txtConfidence.Size = new Size(0, 25);
            txtConfidence.TabIndex = 68;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1192, 865);
            Controls.Add(txtConfidence);
            Controls.Add(txtDiagnosis);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(OutputtextBox);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(btnCsv);
            Controls.Add(doctorComboBox);
            Controls.Add(genderComboBox);
            Controls.Add(contactTextBox);
            Controls.Add(btnAddSymptom);
            Controls.Add(labelPCode);
            Controls.Add(label2);
            Controls.Add(symptomComboBox);
            Controls.Add(bloodComboBox);
            Controls.Add(patientIdTextBox);
            Controls.Add(pictureBoxLogout);
            Controls.Add(otherSymptomTextBox);
            Controls.Add(btnSave);
            Controls.Add(btnGetPrescription);
            Controls.Add(ageTextBox);
            Controls.Add(panel1);
            Controls.Add(symptomDataGridView);
            Controls.Add(addressTextBox);
            Controls.Add(nameTextBox);
            ForeColor = SystemColors.Window;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientForm";
            Load += PatientForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)symptomDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox doctorComboBox;
        private ComboBox genderComboBox;
        private TextBox contactTextBox;
        private Button btnAddSymptom;
        private Label labelPCode;
        private Label label2;
        private ComboBox symptomComboBox;
        private Label label3;
        private Label label1;
        private ComboBox bloodComboBox;
        private TextBox patientIdTextBox;
        private PictureBox pictureBoxLogout;
        private TextBox otherSymptomTextBox;
        private Button btnSave;
        private Button btnGetPrescription;
        private TextBox ageTextBox;
        private Panel panel1;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Serial;
        private DataGridView symptomDataGridView;
        private TextBox addressTextBox;
        private TextBox nameTextBox;
        private Button btnCsv;
        private ProgressBar progressBar;
        private Label lblStatus;
        private TextBox OutputtextBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label txtDiagnosis;
        private Label txtConfidence;
    }
}