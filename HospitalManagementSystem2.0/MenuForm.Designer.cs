namespace HospitalManagementSystem2._0
{
    partial class MenuForm
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
            panel1 = new Panel();
            label1 = new Label();
            pictureBoxDiagnosis = new PictureBox();
            pictureBoxPatients = new PictureBox();
            pictureBoxLogout = new PictureBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBoxDoctors = new PictureBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDiagnosis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDoctors).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-11, -22);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 150);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(4, 48);
            label1.Name = "label1";
            label1.Size = new Size(779, 62);
            label1.TabIndex = 0;
            label1.Text = "HOSPITAL MANAGEMENT SYSTEM";
            // 
            // pictureBoxDiagnosis
            // 
            pictureBoxDiagnosis.Image = Properties.Resources.Diagnosis;
            pictureBoxDiagnosis.Location = new Point(486, 241);
            pictureBoxDiagnosis.Name = "pictureBoxDiagnosis";
            pictureBoxDiagnosis.Size = new Size(164, 163);
            pictureBoxDiagnosis.TabIndex = 19;
            pictureBoxDiagnosis.TabStop = false;
            pictureBoxDiagnosis.Click += pictureBoxDiagnosis_Click;
            // 
            // pictureBoxPatients
            // 
            pictureBoxPatients.Image = Properties.Resources.Patient;
            pictureBoxPatients.Location = new Point(292, 241);
            pictureBoxPatients.Name = "pictureBoxPatients";
            pictureBoxPatients.Size = new Size(164, 163);
            pictureBoxPatients.TabIndex = 18;
            pictureBoxPatients.TabStop = false;
            pictureBoxPatients.Click += pictureBoxPatients_Click;
            // 
            // pictureBoxLogout
            // 
            pictureBoxLogout.Image = Properties.Resources.Logout;
            pictureBoxLogout.Location = new Point(712, 445);
            pictureBoxLogout.Name = "pictureBoxLogout";
            pictureBoxLogout.Size = new Size(42, 39);
            pictureBoxLogout.TabIndex = 17;
            pictureBoxLogout.TabStop = false;
            pictureBoxLogout.Click += pictureBoxLogout_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = SystemColors.GradientActiveCaption;
            label5.Location = new Point(500, 210);
            label5.Name = "label5";
            label5.Size = new Size(120, 28);
            label5.TabIndex = 16;
            label5.Text = "DIAGNOSIS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = SystemColors.GradientActiveCaption;
            label4.Location = new Point(321, 210);
            label4.Name = "label4";
            label4.Size = new Size(104, 28);
            label4.TabIndex = 15;
            label4.Text = "PATIENTS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.GradientActiveCaption;
            label3.Location = new Point(136, 210);
            label3.Name = "label3";
            label3.Size = new Size(104, 28);
            label3.TabIndex = 14;
            label3.Text = "DOCTORS";
            // 
            // pictureBoxDoctors
            // 
            pictureBoxDoctors.Image = Properties.Resources.Doctor;
            pictureBoxDoctors.Location = new Point(103, 241);
            pictureBoxDoctors.Name = "pictureBoxDoctors";
            pictureBoxDoctors.Size = new Size(164, 163);
            pictureBoxDoctors.TabIndex = 13;
            pictureBoxDoctors.TabStop = false;
            pictureBoxDoctors.Click += pictureBoxDoctors_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Underline);
            label2.ForeColor = SystemColors.GradientActiveCaption;
            label2.Location = new Point(206, 140);
            label2.Name = "label2";
            label2.Size = new Size(334, 41);
            label2.TabIndex = 12;
            label2.Text = "CHOOSE ANY OPTION";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(765, 493);
            Controls.Add(panel1);
            Controls.Add(pictureBoxDiagnosis);
            Controls.Add(pictureBoxPatients);
            Controls.Add(pictureBoxLogout);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBoxDoctors);
            Controls.Add(label2);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDiagnosis).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBoxDiagnosis;
        private PictureBox pictureBoxPatients;
        private PictureBox pictureBoxLogout;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox pictureBoxDoctors;
        private Label label2;
    }
}