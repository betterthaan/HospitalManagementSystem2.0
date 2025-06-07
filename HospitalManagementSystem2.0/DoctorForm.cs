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
    public partial class DoctorForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.ConString);
        public DoctorForm()
        {
            InitializeComponent();

            usernameTextBox.Visible = false;
            passwordTextBox.Visible = false;
            chkGiveLoginPermission.Checked = true;
            LoadDoctors();
        }
        private void LoadDoctors()
        {
            sqlCon = CmnMethods.OpenConnectionString(sqlCon);
            string query = "SELECT * FROM View_Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            doctorDataGridView.DataSource = dataSet.Tables[0];
            sqlCon.Close();

            doctorDataGridView.Columns[0].Visible = false;
        }

        private void Reset()
        {
            docIdTextBox.Text = 0.ToString();
            userLoginIdTextBox.Text = 0.ToString();
            nameTextBox.Text = "";
            yoeTextBox.Text = "";
            ageTextBox.Text = "";
            contactTextBox.Text = "";
            addressTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";

        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }

        private void chkGiveLoginPermission_CheckedChanged(object sender, EventArgs e)
        {
            HideShowUsernamePassword();
        }

        private void HideShowUsernamePassword()
        {
            usernameTextBox.Visible = chkGiveLoginPermission.Checked;
            passwordTextBox.Visible = chkGiveLoginPermission.Checked;
        }

        private void yoeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  //Only Int
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  //Only Int
        }

        private void doctorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = doctorDataGridView.DefaultCellStyle;
            }
        }

        private void doctorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            docIdTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["DocId"].Value.ToString();
            userLoginIdTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["LoginUserId"].Value.ToString();
            nameTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["DocName"].Value.ToString();
            ageTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Age"].Value.ToString();
            yoeTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["YearOfExperience"].Value.ToString();
            contactTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
            addressTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Address"].Value.ToString();

            int loginUserId = Convert.ToInt32(doctorDataGridView.Rows[e.RowIndex].Cells["LoginUserId"].Value.ToString());
            chkGiveLoginPermission.Checked = loginUserId > 0 ? true : false;
            HideShowUsernamePassword();
            usernameTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            passwordTextBox.Text = doctorDataGridView.Rows[e.RowIndex].Cells["UserPassword"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() == "" || yoeTextBox.Text.Trim() == "" || ageTextBox.Text.Trim() == "" || contactTextBox.Text.Trim() == "Category" || addressTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Fill all fields.");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = "";
                        int userloginId = 0;
                        bool hasError = false;
                        if (chkGiveLoginPermission.Checked)
                        {
                            if (usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
                            {
                                MessageBox.Show("Fill username and password.");
                                hasError = true;
                            }
                            else
                            {
                                query = @"INSERT INTO UserInfo (Username, UserPassword, UserType, AddedDate, AddedBy) VALUES (@Username, @UserPassword, @userType, @AddedDate, @AddedBy); 
                                    SELECT SCOPE_IDENTITY();";
                                SqlCommand command = new SqlCommand(query, conn, transaction);
                                command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@UserPassword", passwordTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@UserType", 2); //UserTypeId 2 means doctor
                                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId); //Login User ID

                                userloginId = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                        if (!hasError)
                        {
                            query = @"INSERT INTO Doctor (DocName, Age, YearOfExperience, Contact, Address, LoginUserId, AddedDate, AddedBy) VALUES (@DocName, @Age, @YearOfExperience, @Contact, @Address, @LoginUserId, @AddedDate, @AddedBy)";
                            SqlCommand command1 = new SqlCommand(query, conn, transaction);
                            command1.Parameters.AddWithValue("@DocName", nameTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Age", ageTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@YearOfExperience", yoeTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Contact", contactTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Address", addressTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@LoginUserId", userloginId);
                            command1.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                            command1.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId); //Login User ID
                            command1.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Doctor Created Successfully.");
                            LoadDoctors();
                            Reset();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (docIdTextBox.Text.Trim() == "" || docIdTextBox.Text.Trim() == 0.ToString())
            {
                MessageBox.Show("Select Doctor");
            }
            if (nameTextBox.Text.Trim() == "" || yoeTextBox.Text.Trim() == "" || ageTextBox.Text.Trim() == "" || contactTextBox.Text.Trim() == "Category" || addressTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string query = "";
                        bool hasError = false;
                        if (chkGiveLoginPermission.Checked)
                        {
                            if (usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
                            {
                                MessageBox.Show("Fill username and password");
                                hasError = true;
                            }
                            else
                            {
                                query = @"UPDATE UserInfo SET Username=@Username, UserPassword=@UserPassword WHERE UserId = @UserId";
                                SqlCommand command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@UserId", userLoginIdTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@UserPassword", passwordTextBox.Text.Trim());
                                command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                                command.Parameters.AddWithValue("@UpdatedBy", Global.UserInfo.UserId);
                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if (userLoginIdTextBox.Text.Trim() == "" || userLoginIdTextBox.Text.Trim() == 0.ToString())
                            {
                                MessageBox.Show("Invalid user login id.");
                                hasError = true;
                            }
                            else
                            {
                                query = @"DELETE FROM UserInfo WHERE UserId = @UserId";
                                SqlCommand command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@UserId", userLoginIdTextBox.Text.Trim());
                                command.ExecuteNonQuery();
                            }
                        }
                        if (!hasError)
                        {
                            query = @"UPDATE Doctor SET DocName = @DocName, Age=@Age, YearOfExperience = @YearOfExperience, Contact=@Contact, Address=@Address WHERE DocId = @DocId";
                            SqlCommand command1 = new SqlCommand(query, conn, transaction);
                            command1.Parameters.AddWithValue("@DocId", docIdTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@DocName", nameTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Age", ageTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@YearOfExperience", yoeTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Contact", contactTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@Address", addressTextBox.Text.Trim());
                            command1.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                            command1.Parameters.AddWithValue("@UpdatedBy", Global.UserInfo.UserId);
                            command1.ExecuteNonQuery();
                            transaction.Commit();


                            MessageBox.Show("Doctor Updated Successfully.");
                            LoadDoctors();
                            Reset();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (docIdTextBox.Text.Trim() == "" || Convert.ToInt32(docIdTextBox.Text) == 0)
            {
                MessageBox.Show("Select a doctor");
            }
            else
            {
                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM Dianosis WHERE DocId={0}", Convert.ToInt32(docIdTextBox.Text));
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var dataSet = new DataSet();
                sda.Fill(dataSet);
                var doctors = dataSet.Tables[0];
                sqlCon.Close();

                if (doctors.Rows != null && doctors.Rows.Count > 0)
                {
                    MessageBox.Show("Already has dianosis of this doctor");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBCommon.ConString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            query = string.Format(@"DELETE FROM Doctor WHERE DocId={0}", Convert.ToInt32(docIdTextBox.Text));
                            SqlCommand command = new SqlCommand(query, conn, transaction);
                            command = new SqlCommand(query, conn, transaction);
                            command.ExecuteNonQuery();

                            query = @"DELETE FROM UserInfo WHERE UserId = @UserId";
                            command = new SqlCommand(query, conn, transaction);
                            command.Parameters.AddWithValue("@UserId", userLoginIdTextBox.Text.Trim());
                            command.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Doctor Deleted Successfully.");
                            LoadDoctors();
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
}
