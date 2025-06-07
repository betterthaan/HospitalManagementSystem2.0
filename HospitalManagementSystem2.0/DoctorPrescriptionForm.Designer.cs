namespace HospitalManagementSystem2._0
{
    partial class DoctorPrescriptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorPrescriptionForm));
            pictureBoxLogout = new PictureBox();
            btnViewPrescription = new Button();
            label3 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            patientComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxLogout
            // 
            pictureBoxLogout.Image = Properties.Resources.Logout;
            pictureBoxLogout.Location = new Point(854, 546);
            pictureBoxLogout.Name = "pictureBoxLogout";
            pictureBoxLogout.Size = new Size(42, 39);
            pictureBoxLogout.TabIndex = 32;
            pictureBoxLogout.TabStop = false;
            pictureBoxLogout.Click += pictureBoxLogout_Click;
            // 
            // btnViewPrescription
            // 
            btnViewPrescription.BackColor = SystemColors.GradientActiveCaption;
            btnViewPrescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewPrescription.ForeColor = SystemColors.HighlightText;
            btnViewPrescription.Location = new Point(360, 348);
            btnViewPrescription.Name = "btnViewPrescription";
            btnViewPrescription.Size = new Size(255, 48);
            btnViewPrescription.TabIndex = 31;
            btnViewPrescription.Text = "VIEW PRESCTIPTION";
            btnViewPrescription.UseVisualStyleBackColor = false;
            btnViewPrescription.Click += btnViewPrescription_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(326, 102);
            label3.Name = "label3";
            label3.Size = new Size(261, 30);
            label3.TabIndex = 6;
            label3.Text = "PATIENT PRESCTIPTION";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 150);
            panel1.TabIndex = 30;
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
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // patientComboBox
            // 
            patientComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            patientComboBox.ForeColor = SystemColors.ScrollBar;
            patientComboBox.FormattingEnabled = true;
            patientComboBox.Location = new Point(360, 305);
            patientComboBox.Name = "patientComboBox";
            patientComboBox.Size = new Size(255, 36);
            patientComboBox.TabIndex = 33;
            patientComboBox.Text = "Patient Code";
            // 
            // DoctorPrescriptionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(903, 595);
            Controls.Add(pictureBoxLogout);
            Controls.Add(btnViewPrescription);
            Controls.Add(panel1);
            Controls.Add(patientComboBox);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoctorPrescriptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorPrescriptionForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogout).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLogout;
        private Button btnViewPrescription;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private ComboBox patientComboBox;
    }
}