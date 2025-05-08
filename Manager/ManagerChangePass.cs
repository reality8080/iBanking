using iBanking.NewModels;
using iBanking.UserView;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking.Manager
{
    public partial class ManagerChangePass : System.Windows.Forms.Form
    {
        public Employee employee;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=BANKINGAPP;user id=sa;Password=123456789;MultipleActiveResultSets=True;";

        public ManagerChangePass(int managerId)
        {

            InitializeComponent();
            this.employee = employee;
            LoadEmployeeData(managerId);
        }

        private void ManagerChangePass_Load(object sender, EventArgs e)
        {

        }
        private void LoadEmployeeData(int managerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employee WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", managerId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = (int)reader["Id"],
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                    }
                }
            }
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtoldpass.Text;
            string newPassword = txtnewpass.Text;
            string confirmPassword = txtconfirm.Text;
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
            if (!oldPassword.Equals(this.employee.Password))
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [Employee] SET password = @password WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@password", newPassword);
                        command.Parameters.AddWithValue("@id", employee.Id);

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
                            employee.Password = newPassword;
                           
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
