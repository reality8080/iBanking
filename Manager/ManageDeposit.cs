//using Guna.UI2.WinForms.Suite;
//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

//namespace iBanking.Manager
//{
//    public partial class ManageDeposit : System.Windows.Forms.Form
//    {
//        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog = BANKING_APP; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
//        public ManageDeposit()
//        {

//            InitializeComponent();
//            this.Load += ManageDeposit_Load;
//        }

//        private void ManageDeposit_Load(object sender, EventArgs e)
//        {
//            InitializeDataGridView();

//        }
//        private void InitializeDataGridView()
//        {

//            dataGridViewDeposit.ColumnCount = 2;
//            dataGridViewDeposit.Columns[0].Name = "Date";
//            dataGridViewDeposit.Columns[1].Name = "Total Deposits";  

//            dataGridViewDeposit.Columns[1].DefaultCellStyle.Format = "N0"; 
//        }
//        private void LoadRevenueData(DateTime startDate, DateTime endDate)
//        {
//            try
//            {
//                dataGridViewDeposit.Rows.Clear();  // Xóa dữ liệu cũ trong DataGridView

//                string query = @"
//                    SELECT CAST(created_at AS DATE) AS Date, SUM(total) AS TotalDeposit
//                    FROM [Deposit]
//                    WHERE created_at >= @StartDate AND created_at <= @EndDate
//                    GROUP BY CAST(created_at AS DATE)
//                    ORDER BY Date";

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    SqlCommand command = new SqlCommand(query, connection);
//                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
//                    command.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1)); // Bao gồm cả cuối ngày

//                    connection.Open();
//                    SqlDataReader reader = command.ExecuteReader();

//                    while (reader.Read())
//                    {
//                        DateTime date = Convert.ToDateTime(reader["Date"]);
//                        decimal total = Convert.ToDecimal(reader["TotalDeposit"]);
//                        dataGridViewDeposit.Rows.Add(date.ToShortDateString(), total);
//                    }
//                }

//                if (dataGridViewDeposit.Rows.Count == 0)
//                {
//                    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải dữ liệu giao dịch: " + ex.Message);
//            }
//        }

//        private void guna2Button1_Click(object sender, EventArgs e)
//        {
//            DateTime startDate = dateTimePickerStart.Value;
//            DateTime endDate = dateTimePickerEnd.Value;

//            if (startDate > endDate)
//            {
//                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
//                return;
//            }

//            LoadRevenueData(startDate, endDate);
//        }
//    }
//}
using Microsoft.Data.SqlClient; // Hoặc System.Data.SqlClient tùy thuộc vào thư viện bạn dùng
using System;
using System.Windows.Forms;
// using Guna.UI2.WinForms.Suite; // Đảm bảo bạn đã tham chiếu thư viện này nếu dùng control Guna

// Namespace của bạn (ví dụ: iBanking.Manager)
namespace iBanking.Manager
{
    public partial class ManageDeposit : System.Windows.Forms.Form // Đảm bảo Form của bạn được đặt tên đúng trong file .Designer.cs
    {
        // Thay thế bằng chuỗi kết nối thực tế của bạn nếu cần
        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog = BANKING_APP; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";

        public ManageDeposit()
        {
            InitializeComponent();
            // Đăng ký sự kiện Load cho Form
            this.Load += ManageDeposit_Load;
        }

        private void ManageDeposit_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            // Tùy chọn: Tải dữ liệu cho một khoảng mặc định khi form load, ví dụ 7 ngày gần nhất
            // DateTime today = DateTime.Today;
            // LoadRevenueData(today.AddDays(-6), today);
        }

        private void InitializeDataGridView()
        {
            dataGridViewDeposit.Rows.Clear(); // Xóa các dòng cũ nếu có
            dataGridViewDeposit.Columns.Clear(); // Xóa các cột cũ nếu có

            dataGridViewDeposit.ColumnCount = 2;
            dataGridViewDeposit.Columns[0].Name = "Date";
            dataGridViewDeposit.Columns[0].HeaderText = "Ngày"; // Tiêu đề cột hiển thị
            dataGridViewDeposit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động điều chỉnh độ rộng

            dataGridViewDeposit.Columns[1].Name = "Total Deposits";
            dataGridViewDeposit.Columns[1].HeaderText = "Tổng Tiền Gửi"; // Tiêu đề cột hiển thị
            dataGridViewDeposit.Columns[1].DefaultCellStyle.Format = "N0"; // Định dạng số, ví dụ: 1,000,000
            dataGridViewDeposit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động điều chỉnh độ rộng
        }

        private void LoadRevenueData(DateTime startDate, DateTime endDate)
        {
            try
            {
                dataGridViewDeposit.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView

                string query = @"
                    SELECT CAST(created_at AS DATE) AS DepositDate, SUM(total) AS TotalAmount
                    FROM [Deposit]
                    WHERE created_at >= @StartDate AND created_at < @EndDatePlusOne
                    GROUP BY CAST(created_at AS DATE)
                    ORDER BY DepositDate";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thiết lập tham số @StartDate là đầu ngày của startDate
                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    // Thiết lập tham số @EndDatePlusOne là đầu ngày của ngày sau endDate
                    // Điều này đảm bảo bao gồm tất cả các giao dịch trong ngày endDate
                    // Ví dụ: nếu endDate là 15/05/2025, @EndDatePlusOne sẽ là 16/05/2025 00:00:00
                    // và điều kiện WHERE created_at < @EndDatePlusOne sẽ bao gồm tất cả đến 15/05/2025 23:59:59.999...
                    command.Parameters.AddWithValue("@EndDatePlusOne", endDate.Date.AddDays(1));

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        DateTime date = Convert.ToDateTime(reader["DepositDate"]);
                        decimal total;

                        if (reader["TotalAmount"] == DBNull.Value)
                        {
                            total = 0; // Nếu SUM(total) là NULL, coi như tổng là 0
                        }
                        else
                        {
                            total = Convert.ToDecimal(reader["TotalAmount"]);
                        }
                        dataGridViewDeposit.Rows.Add(date.ToShortDateString(), total);
                    }
                    reader.Close(); // Luôn đóng SqlDataReader sau khi sử dụng
                }

                //if (!hasRows)
                //{
                //    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (SqlException sqlEx) // Bắt lỗi cụ thể của SQL Server
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message + "\nSố lỗi: " + sqlEx.Number, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Bắt các lỗi chung khác
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Giả sử tên button của bạn là guna2Button1
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            // Optional: Dùng để debug giá trị ngày tháng được chọn
            // MessageBox.Show($"Tìm kiếm từ: {startDate:yyyy-MM-dd HH:mm:ss} đến: {endDate:yyyy-MM-dd HH:mm:ss}");

            if (startDate.Date > endDate.Date) // So sánh phần ngày, bỏ qua giờ giấc
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadRevenueData(startDate, endDate);
        }

        // Đảm bảo các controls (dataGridViewDeposit, dateTimePickerStart, dateTimePickerEnd, guna2Button1)
        // đã được khai báo trong file ManageDeposit.Designer.cs và được khởi tạo trong InitializeComponent().
        // Ví dụ, trong file ManageDeposit.Designer.cs, bạn sẽ có:
        // private System.Windows.Forms.DataGridView dataGridViewDeposit;
        // private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        // private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        // private Guna.UI2.WinForms.Guna2Button guna2Button1; (Nếu bạn dùng Guna)
        // hoặc private System.Windows.Forms.Button guna2Button1; (Nếu bạn dùng Button chuẩn)
    }
}