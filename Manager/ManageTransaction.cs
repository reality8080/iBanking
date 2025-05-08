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

namespace iBanking.Manager
{
    public partial class ManageTransaction : System.Windows.Forms.Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=BANKINGAPP; user id=sa; Password=123456789;";
        public ManageTransaction()
        {
            InitializeComponent();
        }

        private void ManageTransaction_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1); 
            dateTimePickerEnd.Value = DateTime.Now; 

            LoadCashiers();

        }
        private void LoadCashiers()
        {
            try
            {
             
                comboBoxCashier.Items.Add("Tất cả");

                string query = "SELECT DISTINCT cashier FROM [Deposit]"; 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                  
                        comboBoxCashier.Items.Add(reader["cashier"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách thu ngân: " + ex.Message);
            }
        }
        private void LoadTransactionHistory(DateTime startDate, DateTime endDate, string cashierName)
        {
            try
            {
                string query = @"
                                   SELECT [user],cashier,created_at,total
                                   FROM [Deposit]
                                   WHERE created_at >= @startDate AND created_at <= @endDate";

                // Nếu tên thu ngân được chỉ định và không phải "Tất cả", thêm điều kiện lọc theo thu ngân
                if (!string.IsNullOrEmpty(cashierName) && cashierName != "Tất cả")
                {
                    query += " AND cashier = @cashier";
                }

                query += " ORDER BY created_at DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    if (!string.IsNullOrEmpty(cashierName) && cashierName != "Tất cả")
                    {
                        command.Parameters.AddWithValue("@cashier", cashierName);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable transactionTable = new DataTable();
                    adapter.Fill(transactionTable);

                    dataGridViewTransactions.DataSource = transactionTable;

                    dataGridViewTransactions.CellFormatting += DataGridViewTransactions_CellFormatting;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu giao dịch: " + ex.Message);
            }

        }
        private void DataGridViewTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        
            if (e.ColumnIndex == dataGridViewTransactions.Columns["total"].Index && e.Value != null)
            {
               
                e.Value = string.Format("{0:N0} ", e.Value); 
                e.FormattingApplied = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string cashierName = comboBoxCashier.SelectedItem?.ToString();

            // Kiểm tra nếu ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }

            // Nếu chọn "Tất cả" cho thu ngân thì không lọc theo thu ngân
            if (cashierName == "Tất cả")
            {
                cashierName = null;
            }

            // Tải lịch sử giao dịch dựa trên thời gian và thu ngân đã chọn
            LoadTransactionHistory(startDate, endDate, cashierName);
        }

       
    }
}
