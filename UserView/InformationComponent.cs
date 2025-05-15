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
        //public User user;
        //private readonly IServiceProvider _serviceProvider;

        //public InformationComponent(User user,IServiceProvider serviceProvider)
        //{
        //    InitializeComponent();
        //    this.user = user;
        //    txtID.Text = user.Id.ToString();
        //    txtName.Text = user.Name.ToString();
        //    txtBalance.Text = user.Balance.ToString();
        //    txtEmail.Text = user.Email.ToString();
        //    txtStartAt.Text = user.CreatedAt.ToString();
        //    _serviceProvider= serviceProvider;
        //}

        //private void InformationComponent_Load(object sender, EventArgs e)
        //{

        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    // Lấy dữ liệu từ TextBox
        //    string newName = txtName.Text.Trim();
        //    string newEmail = txtEmail.Text.Trim();

        //    // Kiểm tra dữ liệu đầu vào
        //    if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newEmail))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ tên và email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Kiểm tra định dạng email (cơ bản)
        //    if (!newEmail.Contains("@") || !newEmail.Contains("."))
        //    {
        //        MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
        //        using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
        //        {
        //            connection.Open();
        //            string query = "UPDATE [User] SET name = @name, email = @email WHERE id = @id";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                // Thêm tham số để tránh SQL Injection
        //                command.Parameters.AddWithValue("@name", newName);
        //                command.Parameters.AddWithValue("@email", newEmail);
        //                command.Parameters.AddWithValue("@id", user.Id);

        //                // Thực thi lệnh UPDATE
        //                int rowsAffected = command.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    // Cập nhật thành công
        //                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    // Cập nhật lại đối tượng user
        //                    user.Name = newName;
        //                    user.Email = newEmail;
        //                    Home home = new Home(this.user,_serviceProvider);
        //                    home.Show();
        //                    this.Hide();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không tìm thấy người dùng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public User user; // Đối tượng User hiện tại
        private readonly IServiceProvider _serviceProvider; // Dịch vụ provider (nếu cần cho các tác vụ khác)

        public InformationComponent(User user, IServiceProvider serviceProvider)
        {
            InitializeComponent(); // Khởi tạo các controls trên UserControl
            this.user = user;
            _serviceProvider = serviceProvider;

            // Hiển thị thông tin người dùng lên các TextBox
            // Sử dụng null-conditional operator ?. để tránh lỗi nếu user hoặc các thuộc tính là null (tùy thiết kế User class)
            txtID.Text = user?.Id.ToString();
            txtName.Text = user?.Name;
            txtBalance.Text = user?.Balance.ToString();
            txtEmail.Text = user?.Email;
            txtStartAt.Text = user?.CreatedAt.ToString();
        }

        private void InformationComponent_Load(object sender, EventArgs e)
        {
            // Logic cần thực thi khi UserControl được load (nếu có)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox và loại bỏ khoảng trắng thừa
            string newName = txtName.Text.Trim();
            string newEmail = txtEmail.Text.Trim();

            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và email!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu dữ liệu không hợp lệ
            }

            // 2. Kiểm tra định dạng email (cơ bản)
            // Để kiểm tra kỹ hơn, bạn có thể sử dụng Regex: System.Text.RegularExpressions.Regex.IsMatch(newEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            if (!newEmail.Contains("@") || !newEmail.Contains("."))
            {
                MessageBox.Show("Định dạng email không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu email không hợp lệ
            }

            try
            {
                // 3. Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                // Đảm bảo SQLHandling.connectionString đã được cấu hình đúng
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open(); // Mở kết nối

                    // Câu lệnh SQL UPDATE, đảm bảo tên bảng và cột chính xác
                    // Ví dụ: Nếu bảng tên là "Users" thì dùng "UPDATE [Users] SET ..."
                    string query = "UPDATE [User] SET name = @newName, email = @newEmail WHERE id = @userId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection và đảm bảo kiểu dữ liệu đúng
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newEmail);
                        command.Parameters.AddWithValue("@userId", user.Id); // Giả sử user.Id không null

                        // Thực thi lệnh UPDATE và lấy số dòng bị ảnh hưởng
                        int rowsAffected = command.ExecuteNonQuery();

                        // 4. Xử lý kết quả cập nhật
                        if (rowsAffected > 0)
                        {
                            // Cập nhật thành công
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại đối tượng user cục bộ với thông tin mới
                            user.Name = newName;
                            user.Email = newEmail;

                            // PHẦN ĐÃ SỬA: Loại bỏ việc tạo Home form mới và ẩn UserControl này
                            // Home home = new Home(this.user,_serviceProvider);
                            // home.Show();
                            // this.Hide();
                            // Nếu Form cha (ví dụ Home) cần cập nhật giao diện,
                            // nên sử dụng cơ chế event/delegate hoặc callback.
                        }
                        else
                        {
                            // Không có dòng nào được cập nhật (có thể do ID không tồn tại hoặc dữ liệu không thay đổi)
                            MessageBox.Show("Không tìm thấy người dùng để cập nhật hoặc thông tin không có gì thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex) // Bắt lỗi cụ thể từ SQL Server
            {
                // Log lỗi (ví dụ: Console.WriteLine(ex.ToString()); ) để debug
                MessageBox.Show($"Lỗi tương tác với cơ sở dữ liệu: {ex.Message}", "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Bắt các lỗi không mong muốn khác
            {
                // Log lỗi để debug
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
