using iBanking.NewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace iBanking.Manager
{
    public partial class ManangeInfoEm : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=BANKINGAPP" +
            ";user id=sa;Password=123456789;MultipleActiveResultSets=True;";
        private int manager;


        public ManangeInfoEm(int manager)
        {
            InitializeComponent();
            this.Load += ManangeInfoEm_Load;
            this.manager = manager;
            this.dataGridViewNhanVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewNhanVien_CellFormatting);
        }

        private void ManangeInfoEm_Load(object sender, EventArgs e)
        {
            LoadEmployees(manager);
        }

        private void LoadEmployees(int manager)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT Id, Name, Email, start_at, Salary, manager
                        FROM Employee
                         WHERE manager = @Manager";
    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Manager", manager);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có nhân viên nào do bạn quản lý.");
                    }

                    dataGridViewNhanVien.AutoGenerateColumns = true;
                    dataGridViewNhanVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        // Sự kiện để định dạng cột Salary
        private void dataGridViewNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là Salary và có giá trị
            if (dataGridViewNhanVien.Columns[e.ColumnIndex].Name == "Salary" && e.Value != null)
            {
                // Chuyển đổi lương thành định dạng VND
                e.Value = string.Format("{0:N0} VNĐ", e.Value);
                e.FormattingApplied = true;
            }
        }

        private void dataGridViewNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
