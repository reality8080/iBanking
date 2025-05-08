using Guna.UI2.WinForms.Suite;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace iBanking.Manager
{
    public partial class ManageDeposit : System.Windows.Forms.Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=BANKINGAPP" +
            ";user id=sa;Password=123456789;MultipleActiveResultSets=True;";
        public ManageDeposit()
        {

            InitializeComponent();
            this.Load += ManageDeposit_Load;
        }

        private void ManageDeposit_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();

        }
        private void InitializeDataGridView()
        {
  
            dataGridViewDeposit.ColumnCount = 2;
            dataGridViewDeposit.Columns[0].Name = "Date";
            dataGridViewDeposit.Columns[1].Name = "Total Deposits";  

            dataGridViewDeposit.Columns[1].DefaultCellStyle.Format = "N0"; 
        }
        private void LoadRevenueData(DateTime startDate, DateTime endDate)
        {
            try
            {
                dataGridViewDeposit.Rows.Clear();  // Xóa dữ liệu cũ trong DataGridView

                string query = @"
                    SELECT CAST(created_at AS DATE) AS Date, SUM(total) AS TotalDeposit
                    FROM [Deposit]
                    WHERE created_at >= @StartDate AND created_at <= @EndDate
                    GROUP BY CAST(created_at AS DATE)
                    ORDER BY Date";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1)); // Bao gồm cả cuối ngày

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime date = Convert.ToDateTime(reader["Date"]);
                        decimal total = Convert.ToDecimal(reader["TotalDeposit"]);
                        dataGridViewDeposit.Rows.Add(date.ToShortDateString(), total);
                    }
                }

                if (dataGridViewDeposit.Rows.Count == 0)
                {
                    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giao dịch: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                return;
            }

            LoadRevenueData(startDate, endDate);
        }
    }
}
