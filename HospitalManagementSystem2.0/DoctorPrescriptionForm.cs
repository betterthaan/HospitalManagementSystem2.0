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
using HospitalManagementSystem.DB;
using HospitalManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem2._0
{
    public partial class DoctorPrescriptionForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.ConString);
        int _patientId = 0;
        public DoctorPrescriptionForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
            {
                try
                {
                    string query = "SELECT PatientId, PCode FROM Patient";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Patient");
                    patientComboBox.DisplayMember = "PCode";
                    patientComboBox.ValueMember = "PatientId";
                    patientComboBox.DataSource = ds.Tables["Patient"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm form = new PatientForm();
            form.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnViewPrescription_Click(object sender, EventArgs e)
        {
            _patientId = Convert.ToInt32(patientComboBox.SelectedValue);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK && _patientId > 0)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Patient patient = new Patient();
            List<Medicine> medicines = new List<Medicine>();

            _patientId = Convert.ToInt32(patientComboBox.SelectedValue);
            if (_patientId > 0)
            {
                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM View_Patient WHERE PatientId='{0}'", _patientId);
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                sqlCon.Close();

                patient = this.GetPatientInfo(dataTable);


                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                query = string.Format(@"SELECT * FROM Medicine WHERE PatientId='{0}'", _patientId);
                sda = new SqlDataAdapter(query, sqlCon);
                dataTable = new DataTable();
                sda.Fill(dataTable);
                sqlCon.Close();

                medicines = this.GetMedicinesInfo(dataTable);



                e.Graphics.DrawString("==Prescription==", new Font("Century", 22, FontStyle.Bold), Brushes.Red, new Point(200, 40));

                e.Graphics.DrawString("Patient :" + patient.Name, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
                e.Graphics.DrawString("Gender : " + patient.Gender, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
                e.Graphics.DrawString("Age : " + patient.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
                e.Graphics.DrawString("Blood : " + patient.BloodGroup, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
                e.Graphics.DrawString("P-Code : " + patient.PCode, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
                e.Graphics.DrawString("Contact : " + patient.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));
                e.Graphics.DrawString("Address : " + patient.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 225));
                e.Graphics.DrawString("Doctor : " + patient.DoctorName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 245));

                e.Graphics.DrawString("Medicines", new Font("Century", 18, FontStyle.Bold), Brushes.Red, new Point(200, 265));


                int rowGap = 20,
                lastPoint = 265;
                foreach (var medicine in medicines)
                {
                    lastPoint += rowGap + 10;
                    e.Graphics.DrawString(medicine.MedicineName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, lastPoint));

                }
            }
        }


        private Patient GetPatientInfo(DataTable dt)
        {
            Patient patient = (from rw in dt.AsEnumerable()
                               select new Patient()
                               {
                                   Name = Convert.ToString(rw["Name"]),
                                   Address = Convert.ToString(rw["Address"]),
                                   Contact = Convert.ToString(rw["Contact"]),
                                   Age = Convert.ToInt32(rw["Age"]),
                                   Gender = Convert.ToString(rw["Gender"]),
                                   BloodGroup = Convert.ToString(rw["BloodGroup"]),
                                   PCode = Convert.ToString(rw["PCode"]),
                                   DoctorName = Convert.ToString(rw["DoctorName"])
                               }).ToList().FirstOrDefault();
            return patient;
        }
        private List<Medicine> GetMedicinesInfo(DataTable dt)
        {
            List<Medicine> medicines = (from rw in dt.AsEnumerable()
                                        select new Medicine()
                                        {
                                            MedicineName = Convert.ToString(rw["MedicineName"])
                                        }).ToList();
            return medicines;
        }
    }
}
