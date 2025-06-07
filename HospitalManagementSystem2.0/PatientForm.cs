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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;
using System.Globalization;
using System.Net.Http.Headers;
using System.Globalization;
using Dapper;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;


namespace HospitalManagementSystem2._0
{
    public partial class PatientForm : Form
    {
        //-------------------CSV---------------------------------------------------------------------------------------------------------------
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api";
        //-------------------CSV---------------------------------------------------------------------------------------------------------------

        public PatientForm()
        {
            InitializeComponent();
            labelPCode.Text = DateTime.Now.ToString("ddMMhhmmss");
            LoadDoctors();

            _httpClient = new HttpClient();
            // Увеличиваем таймаут для обработки больших данных
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
        }
        private void LoadDoctors()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
            {
                try
                {
                    string query = "select DocId, DocName from Doctor";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Doctor");
                    doctorComboBox.DisplayMember = "DocName";
                    doctorComboBox.ValueMember = "DocId";
                    doctorComboBox.DataSource = ds.Tables["Doctor"];
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

        private void symptomDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                symptomDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = symptomDataGridView.DefaultCellStyle;
            }
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Reset()
        {
            patientIdTextBox.Text = 0.ToString();
            nameTextBox.Text = "";
            bloodComboBox.Text = "";
            ageTextBox.Text = "";
            genderComboBox.Text = "";
            contactTextBox.Text = "";
            addressTextBox.Text = "";
            symptomComboBox.Text = "";
            otherSymptomTextBox.Text = "";
            symptomDataGridView.Columns.Clear();
        }

        private void symptomComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            otherSymptomTextBox.Text = "";
            otherSymptomTextBox.ReadOnly = true;
            otherSymptomTextBox.Enabled = false;
            if (symptomComboBox.Text == "Other")
            {
                otherSymptomTextBox.ReadOnly = false;
                otherSymptomTextBox.Enabled = true;
            }
        }

        private void btnAddSymptom_Click(object sender, EventArgs e)
        {
            if (symptomComboBox.Text.Trim() == "")
            {
                MessageBox.Show("Select symptom.");
                symptomComboBox.Focus();
            }
            else if (symptomComboBox.Text == "Other" && otherSymptomTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Select symptom.");
                otherSymptomTextBox.Focus();
            }
            else
            {
                string name = symptomComboBox.Text;
                if (symptomComboBox.Text == "Other")
                {
                    name = otherSymptomTextBox.Text;
                }

                int rowIndex = -1;
                var rowsCount = symptomDataGridView.Rows.Count;

                if (rowsCount > 1)
                {
                    for (int i = 0; i < symptomDataGridView.Rows.Count - 1; i++)
                    {
                        if (symptomDataGridView.Rows[i].Cells["Name"].Value.ToString() == name)
                        {
                            rowIndex = symptomDataGridView.Rows[i].Index;
                        }
                        break;
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = symptomDataGridView.Rows.Add();
                }
                symptomDataGridView.Rows[rowIndex].Cells["Serial"].Value = symptomDataGridView.Rows.Count - 1;
                symptomDataGridView.Rows[rowIndex].Cells["Name"].Value = name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() == "" ||
                bloodComboBox.Text.Trim() == "" ||
                ageTextBox.Text.Trim() == "" ||
                ageTextBox.Text.Trim() == 0.ToString() ||
                genderComboBox.Text.Trim() == "" ||
                contactTextBox.Text.Trim() == "" ||
                addressTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else if (doctorComboBox.Text.Trim() == "")
            {
                MessageBox.Show("Select doctor");
            }
            else
            {
                if (symptomDataGridView.Rows.Count <= 1)
                {
                    MessageBox.Show("Give Symptoms");
                }
                else
                {
                    var confirmResult = MessageBox.Show("Are you sure to save this ?? Delete not possible!!", "", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();
                            try
                            {
                                string query = @"INSERT INTO Patient (Name,Address,Contact, Age, Gender, BloodGroup, PCode, DoctorId, AddedDate, AddedBy) VALUES (@Name, @Address, @Contact, @Age, @Gender, @BloodGroup, @PCode, @DoctorId, @AddedDate, @AddedBy);
                                    SELECT SCOPE_IDENTITY();";

                                SqlCommand command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@Address", addressTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@Contact", contactTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@Age", ageTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@Gender", genderComboBox.Text.Trim());
                                command.Parameters.AddWithValue("@BloodGroup", bloodComboBox.Text.Trim());
                                command.Parameters.AddWithValue("@PCode", labelPCode.Text);
                                command.Parameters.AddWithValue("@DoctorId", doctorComboBox.SelectedValue);
                                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                int patientId = Convert.ToInt32(command.ExecuteScalar());

                                if (patientId > 0)
                                {
                                    for (int i = 0; i < symptomDataGridView.Rows.Count - 1; i++)
                                    {
                                        string name = symptomDataGridView.Rows[i].Cells["Name"].Value.ToString();

                                        query = @"INSERT INTO Symptom (Name, PatientId, AddedDate, AddedBy) VALUES (@Name, @PatientId, @AddedDate, @AddedBy);";
                                        command = new SqlCommand(query, conn, transaction);
                                        command.Parameters.AddWithValue("@Name", name);
                                        command.Parameters.AddWithValue("@PatientId", patientId);
                                        command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                        command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                                        command.ExecuteNonQuery();
                                    }
                                }
                                transaction.Commit();
                                MessageBox.Show("Patient information saved");
                                Reset();
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

        private void btnGetPrescription_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorPrescriptionForm from = new DoctorPrescriptionForm();
            from.Show();
        }



        //------------------------------------CSV----------------------------------------------------------------------------------------------------------


        //private async void btnCsv_Click(object sender, EventArgs e)
        //{

        //    // Открываем диалог для выбора файла
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Читаем содержимое файла
        //            string filePath = openFileDialog.FileName;
        //            string fileContent = await File.ReadAllTextAsync(filePath);

        //            // Отправляем данные на сервер
        //            await UploadDataToServer(fileContent);
        //        }
        //    }

        //}

        //private async Task UploadDataToServer(string data)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            // Создаем содержимое запроса
        //            var content = new StringContent(data, Encoding.UTF8, "application/csv");

        //            // Отправляем POST-запрос на сервер
        //            HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/api/upload", content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                MessageBox.Show("Данные успешно загружены!");
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Ошибка при загрузке данных: {response.StatusCode}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Произошла ошибка: {ex.Message}");
        //        }
        //    }
        //}

        private async void btnCsv_Click(object sender, EventArgs e)
        {
            // Открываем диалог для выбора файла
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Читаем содержимое файла
                    string filePath = openFileDialog.FileName;
                    string fileContent = await File.ReadAllTextAsync(filePath);

                    // Отправляем данные на сервер
                    await UploadDataToServer(fileContent);
                }
            }
        }

        private void StartProgress(string status)
        {
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Process...";
            lblStatus.Refresh(); // Обновить текст сразу
        }

        private void StopProgress(string status)
        {
            progressBar.Visible = false;
            lblStatus.Text = "Done";
            lblStatus.Refresh();
        }


        private async Task UploadDataToServer(string data)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Invoke(new Action(() => StartProgress("Загрузка файла...")));

                    var content = new StringContent(data, Encoding.UTF8, "application/csv");

                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/api/upload", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Переходим к предсказанию
                        await PredictDisease(data);
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при загрузке данных: {response.StatusCode}");
                        Invoke(new Action(() => StopProgress("Ошибка загрузки")));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    Invoke(new Action(() => StopProgress("Ошибка")));
                }
            }
        }



        //private async Task PredictDisease(string data)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            // Здесь предполагается, что ваше приложение ожидает JSON-формат.
        //            // Если нужно преобразовать CSV в JSON, сделайте это перед отправкой.
        //            var jsonData = ConvertCsvToJson(data); // Метод для преобразования CSV в JSON

        //            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //            // Отправляем POST-запрос на сервер
        //            HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/api/predict", content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string result = await response.Content.ReadAsStringAsync();
        //                MessageBox.Show($"Предсказание: {result}");
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Ошибка при получении предсказания: {response.StatusCode}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Произошла ошибка: {ex.Message}");
        //        }
        //    }
        //}

        private async Task PredictDisease(string data)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Invoke(new Action(() => StartProgress("Обработка данных...")));

                    var jsonData = ConvertCsvToJson(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/api/predict", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();

                        var prediction = JsonConvert.DeserializeObject<PredictionResult>(responseString);

                        Invoke(new Action(() =>
                        {
                            txtDiagnosis.Text = prediction.diagnosis;
                            txtConfidence.Text = $"{prediction.confidence_percent:F2}%";
                            StopProgress("Готово");
                        }));
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при получении предсказания: {response.StatusCode}");
                        Invoke(new Action(() => StopProgress("Ошибка обработки")));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    Invoke(new Action(() => StopProgress("Ошибка")));
                }
            }
        }


        public class PredictionResult
        {
            public string diagnosis { get; set; }
            public double confidence_percent { get; set; }
        }






        // Пример метода для преобразования CSV в JSON
        private string ConvertCsvToJson(string csvData)
        {
            // Здесь вы можете реализовать логику для преобразования CSV в JSON.
            // Для простоты можно использовать библиотеку Newtonsoft.Json или другую.

            // Пример:
            var csvLines = csvData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var jsonArray = new JArray();

            foreach (var line in csvLines)
            {
                var values = line.Split(',');
                var jsonObject = new JObject();

                // Предположим, что у вас есть заголовки в первой строке
                for (int i = 0; i < values.Length; i++)
                {
                    jsonObject[$"column{i}"] = values[i]; // Замените column{i} на реальные названия колонок
                }

                jsonArray.Add(jsonObject);
            }

            return jsonArray.ToString();
        }


        //------------------------------------------------------------------------НОВОЕ---------------------------------------------------------------------------------------//


        //------------------------------------------------------------------------НОВОЕ---------------------------------------------------------------------------------------//


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------//



        //private void ProcessCSVFile(string filePath)
        //{
        //    try
        //    {
        //        string fileName = Path.GetFileName(filePath);
        //        int fileId = SaveFileInfo(fileName);

        //        string[] lines = File.ReadAllLines(filePath);
        //        if (lines.Length == 0)
        //        {
        //            MessageBox.Show("Файл пуст");
        //            return;
        //        }

        //        //Обработка заголовков
        //        string[] headers = lines[0].Split(',');
        //        Dictionary<string, int> headerIds = ProcessHeaders(headers);

        //        //Обработка данных
        //        for (int i = 1; i < lines.Length; i++)
        //        {
        //            string[] values = lines[i].Split(',');
        //            SaveRowData(fileId, i, headerIds, headers, values);
        //        }

        //        //Обновление представления
        //        RefreshPivotView();

        //        MessageBox.Show($"Файл {fileName} успешно загружен");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при обработке файла: {ex.Message}");
        //    }
        //}

        private int SaveFileInfo(string fileName)
        {
            using (SqlConnection connection = new SqlConnection(DBCommon.ConString))
            {
                connection.Open();

                string query = "INSERT INTO EEGFiles (FileName) VALUES (@FileName); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileName);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private Dictionary<string, int> ProcessHeaders(string[] headers)
        {
            Dictionary<string, int> headerIds = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(DBCommon.ConString))
            {
                connection.Open();

                for (int i = 0; i < headers.Length; i++)
                {
                    string headerName = headers[i].Trim();

                    // Проверяем, существует ли заголовок
                    string checkQuery = "SELECT HeaderID FROM EEGHeaders WHERE HeaderName = @HeaderName";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@HeaderName", headerName);
                        object result = checkCommand.ExecuteScalar();

                        if (result != null)
                        {
                            headerIds[headerName] = Convert.ToInt32(result);
                        }
                        else
                        {
                            // Добавляем новый заголовок
                            string insertQuery = "INSERT INTO EEGHeaders (HeaderName, HeaderPosition) VALUES (@HeaderName, @HeaderPosition); SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@HeaderName", headerName);
                                insertCommand.Parameters.AddWithValue("@HeaderPosition", i);
                                int headerId = Convert.ToInt32(insertCommand.ExecuteScalar());
                                headerIds[headerName] = headerId;
                            }
                        }
                    }
                }
            }

            return headerIds;
        }

        private void SaveRowData(int fileId, int rowNumber, Dictionary<string, int> headerIds, string[] headers, string[] values)
        {
            using (SqlConnection connection = new SqlConnection(DBCommon.ConString))
            {
                connection.Open();

                for (int i = 0; i < Math.Min(headers.Length, values.Length); i++)
                {
                    string headerName = headers[i].Trim();
                    string value = i < values.Length ? values[i] : "";

                    string query = "INSERT INTO EEGData (FileID, RowNumber, HeaderID, ValueString) VALUES (@FileID, @RowNumber, @HeaderID, @ValueString)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FileID", fileId);
                        command.Parameters.AddWithValue("@RowNumber", rowNumber);
                        command.Parameters.AddWithValue("@HeaderID", headerIds[headerName]);
                        command.Parameters.AddWithValue("@ValueString", value);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void RefreshPivotView()
        {
            using (SqlConnection connection = new SqlConnection(DBCommon.ConString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("EXEC sp_RefreshEEGDataPivotView", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void PatientForm_Load(object sender, EventArgs e)
        {

        }

        private void OutputtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void symptomDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
