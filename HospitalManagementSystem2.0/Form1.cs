using HospitalManagementSystem.Common;
using System.Data;
using HospitalManagementSystem.DB;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem2._0
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.ConString);

        public Form1()
        {
            InitializeComponent();
            DBCommon.StartServer(); // «апускаем сервер при инициализации формы
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Enter username & password");
                usernameTextBox.Focus();
            }
            else
            {
                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM View_UserInfo WHERE Username='{0}' AND UserPassword='{1}'", usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    this.Hide();
                    MenuForm form = new MenuForm();
                    form.Show();

                    CmnMethods.GetUserInfo(dataTable);
                }
                else
                {
                    MessageBox.Show("Invalid username & password");
                    usernameTextBox.Focus();
                }
            }

        }

        private void linkLabelCreateUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (usernameTextBox.Text.Trim() == "" || passwordTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Fill username and password.");
                usernameTextBox.Focus();
            }
            else
            {
                sqlCon = CmnMethods.OpenConnectionString(sqlCon);
                string query = @"INSERT INTO UserInfo (Username, UserPassword, UserType, AddedDate, AddedBy) VALUES (@Username, @UserPassword, @UserType, @AddedDate, @AddedBy)";
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
                command.Parameters.AddWithValue("@UserPassword", passwordTextBox.Text.Trim());
                command.Parameters.AddWithValue("@UserType", 1); //1 Means Admin
                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                command.ExecuteNonQuery();
                MessageBox.Show("Signup Successfully. Now login.");
                sqlCon.Close();
            }
        }
    }
}
