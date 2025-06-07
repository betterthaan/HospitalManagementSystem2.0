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
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem2._0
{
    public partial class DiagnosisForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.ConString);
        public DiagnosisForm()
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
                    string query = "SELECT PatientId, [Name] FROM Patient WHERE DoctorId = " + Global.UserInfo.DoctorId + " AND PatientId NOT IN (SELECT PatientId FROM Dianosis WHERE DoctorId = " + Global.UserInfo.DoctorId + ")";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Patient");
                    patientComboBox.DisplayMember = "Name";
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
            MenuForm form = new MenuForm();
            form.Show();
        }

        private void patientComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPatientInfos();
        }

        private void LoadPatientInfos()
        {

            int patientId = Convert.ToInt32(patientComboBox.SelectedValue);
            if (patientId > 0)
            {
                SqlConnection conn = new SqlConnection(DBCommon.ConString);

                #region Load Patients
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Patient WHERE PatientId=@PatientId", conn);
                command.Parameters.AddWithValue("@PatientId", patientId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bloodTextBox.Text = String.Format("{0}", reader["BloodGroup"]);
                        ageTextBox.Text = String.Format("{0}", reader["Age"]);
                        genderTextBox.Text = String.Format("{0}", reader["Gender"]);
                        contactTextBox.Text = String.Format("{0}", reader["Contact"]);
                        pCodeTextBox.Text = String.Format("{0}", reader["PCode"]);
                    }
                }
                conn.Close();
                #endregion


                #region Load Symptoms
                command = new SqlCommand("SELECT * FROM Symptom WHERE PatientId=@PatientId", conn);
                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM Symptom WHERE PatientId={0}", patientId);
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var dataSet = new DataSet();
                sda.Fill(dataSet);
                symptomsDataGridView.DataSource = dataSet.Tables[0];
                sqlCon.Close();

                symptomsDataGridView.Columns[0].Visible = false;
                symptomsDataGridView.Columns[2].Visible = false;
                symptomsDataGridView.Columns[3].Visible = false;
                symptomsDataGridView.Columns[4].Visible = false;
                symptomsDataGridView.Columns[5].Visible = false;
                symptomsDataGridView.Columns[6].Visible = false;
                #endregion
            }
        }

        private void medicineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.medicineDataGridView.SelectedRows)
            {
                medicineDataGridView.Rows.RemoveAt(item.Index);  //Remove Medicine
            }
        }

        private void btnAddSymptom_Click(object sender, EventArgs e)
        {
            if (medicineTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Type medicine name");
                medicineTextBox.Focus();
            }
            else
            {
                string name = medicineTextBox.Text;

                int rowIndex = -1;
                var rowsCount = medicineDataGridView.Rows.Count;

                if (rowsCount > 1)
                {
                    for (int i = 0; i < medicineDataGridView.Rows.Count - 1; i++)
                    {
                        if (medicineDataGridView.Rows[i].Cells["MedicineName"].Value.ToString() == name)
                        {
                            rowIndex = medicineDataGridView.Rows[i].Index;
                            break;
                        }
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = medicineDataGridView.Rows.Add();
                }
                medicineDataGridView.Rows[rowIndex].Cells["Serial"].Value = medicineDataGridView.Rows.Count - 1;
                medicineDataGridView.Rows[rowIndex].Cells["MedicineName"].Value = name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(patientComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Select Patient");
            }
            else if (medicineDataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Give Medicines");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string query = @"INSERT INTO Dianosis (PatientId, DoctorId, AddedDate, AddedBy) VALUES (@PatientId, @DoctorId,@AddedDate,@AddedBy); 
                                SELECT SCOPE_IDENTITY();";
                        SqlCommand command = new SqlCommand(query, conn, transaction);
                        command.Parameters.AddWithValue("@PatientId", patientComboBox.SelectedValue);
                        command.Parameters.AddWithValue("@DoctorId", Global.UserInfo.UserId);
                        command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                        int dianosisId = Convert.ToInt32(command.ExecuteScalar());


                        if (dianosisId > 0)
                        {
                            for (int i = 0; i < medicineDataGridView.Rows.Count - 1; i++)
                            {
                                string name = medicineDataGridView.Rows[i].Cells["MedicineName"].Value.ToString();
                                query = @"INSERT INTO Medicine (MedicineName, DianosisId, PatientId, AddedDate, AddedBy) VALUES (@MedicineName, @DianosisId, @PatientId, @AddedDate, @AddedBy);";
                                command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@MedicineName", name);
                                command.Parameters.AddWithValue("@DianosisId", dianosisId);
                                command.Parameters.AddWithValue("@PatientId", patientComboBox.SelectedValue);
                                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show("Successfully Saved.");
                        LoadPatients();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
