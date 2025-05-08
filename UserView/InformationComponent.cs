using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBanking.LIB;
using iBanking.NewModels;
using Microsoft.Data.SqlClient;

namespace iBanking.UserView
{
    public partial class InformationComponent : UserControl
    {
        public User user;
        public InformationComponent(User user)
        {
            InitializeComponent();
            this.user = user;
            txtID.Text = user.Id.ToString();
            txtName.Text = user.Name.ToString();
            txtBalance.Text = user.Balance.ToString();
            txtEmail.Text = user.Email.ToString();
            txtStartAt.Text = user.CreatedAt.ToString();
        }

        private void InformationComponent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string newName = txtName.Text.Trim();
            string newEmail = txtEmail.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng email (cơ bản)
            if (!newEmail.Contains("@") || !newEmail.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [User] SET name = @name, email = @email WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@email", newEmail);
                        command.Parameters.AddWithValue("@id", user.Id);

                        // Thực thi lệnh UPDATE
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Cập nhật thành công
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại đối tượng user
                            user.Name = newName;
                            user.Email = newEmail;
                            Home home = new Home(this.user);
                            home.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy người dùng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
