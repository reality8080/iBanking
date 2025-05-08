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
    public partial class ChangePasswordComponent : UserControl
    {
        public User user;

        public ChangePasswordComponent(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void ChangePasswordComponent_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOld.Text;
            string newPassword = txtNew.Text;
            string confirmPassword = txtConfirm.Text;
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            if (!oldPassword.Equals(this.user.Password))
            {
                MessageBox.Show(
                    "Mật khẩu cũ không chính xác",
                    "Sai mật khẩu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show(
                    "Mật khẩu mới không khớp",
                    "Mật khẩu không khớp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [User] SET password = @password WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@password", newPassword);
                        command.Parameters.AddWithValue("@id", user.Id);

                        // Thực thi lệnh UPDATE
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Cập nhật thành công
                            MessageBox.Show(
                                "Cập nhật mật khẩu thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );

                            // Cập nhật lại đối tượng user
                            user.Password = newPassword;
                            UserLogin userLogin = new UserLogin();
                            userLogin.Show();
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
