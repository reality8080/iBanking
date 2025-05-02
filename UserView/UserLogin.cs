using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBanking.NewModels;
using Microsoft.Data.SqlClient;

namespace iBanking.UserView
{
    public partial class UserLogin : Form
    {
        private string connectionString = "Server=LAPTOP-MRP876OS\\SQLEXPRESS;Database=BANKING_APP;Trusted_Connection=True;TrustServerCertificate=True;";
        public UserLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
        private User AuthenticateUser(int id, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn lấy thông tin người dùng
                    string query = "SELECT * FROM [User] WHERE id = @id AND password = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo đối tượng User từ dữ liệu
                                User user = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Password = reader.GetString(reader.GetOrdinal("password")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Balance = reader.GetDecimal(reader.GetOrdinal("balance")),
                                    Email = reader.GetString(reader.GetOrdinal("email"))
                                };
                                return user;
                            }
                            else
                            {
                                // Không tìm thấy người dùng
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có vấn đề với cơ sở dữ liệu
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string idText = txtID.Text;
            string password = txtPassword.Text;
            // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(idText) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ ID và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem ID có phải là số nguyên hợp lệ không
            if (!int.TryParse(idText, out int id))
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Gọi phương thức kiểm tra đăng nhập và lấy đối tượng User
            User loggedInUser = AuthenticateUser(id, password);

            if (loggedInUser != null)
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển hướng đến UserHomeForm và truyền đối tượng User
                Home userHomeForm = new Home(loggedInUser);
                userHomeForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("ID hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
