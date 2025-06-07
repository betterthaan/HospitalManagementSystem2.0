using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.Common;

namespace HospitalManagementSystem2._0
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        private void pictureBoxDoctors_Click(object sender, EventArgs e)
        {
            if (Global.UserInfo.UserType != 1)
            {
                MessageBox.Show("Only admin has access");
            }
            else
            {
                this.Hide();
                DoctorForm doctorForm = new DoctorForm();
                doctorForm.Show();
            }

        }

        private void pictureBoxPatients_Click(object sender, EventArgs e)
        {
            if (Global.UserInfo.UserType != 1)
            {
                MessageBox.Show("Only admin has access");
            }
            else
            {
                this.Hide();
                PatientForm patientForm = new PatientForm();
                patientForm.Show();
            }
        }

        private void pictureBoxDiagnosis_Click(object sender, EventArgs e)
        {
            if (Global.UserInfo.UserType != 2)
            {
                MessageBox.Show("Only doctor has access");
            }
            else
            {
                this.Hide();
                DiagnosisForm diagnosisForm = new DiagnosisForm();
                diagnosisForm.Show();
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
