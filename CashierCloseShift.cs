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

namespace iBanking
{
    public partial class CashierCloseShift : Form
    {
        private int cashierId;
        public CashierCloseShift(int id)
        {
            InitializeComponent();
            cashierId = id;
            dgvTransactions.AutoGenerateColumns = true;
        }
        private string connectionString = "Data Source=USER\\SQLEXPRESS; Database=BANKING_APP; " +
                                  "User ID=sa; Password=123; MultipleActiveResultSets=True; " +
                                  "Encrypt=False; TrustServerCertificate=True;";
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng ca chứ?", "Xác nhận đóng ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CloseShift(cashierId);
            }
        }
        private void CloseShift(int cashierId)
        {
            string empQuery = "SELECT name FROM Employee WHERE id = @id";
            string transQuery = @"SELECT U.name AS UserName, D.total, D.created_at
                          FROM Deposit D
                          JOIN [User] U ON D.[user] = U.id
                          WHERE D.cashier = @id AND CAST(D.created_at AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdEmp = new SqlCommand(empQuery, conn);
                cmdEmp.Parameters.AddWithValue("@id", cashierId);
                SqlDataReader reader = cmdEmp.ExecuteReader();
                if (reader.Read())
                {
                    lblCashier.Text = $"Tạm biệt, {reader["name"]}";
                }
                reader.Close();

                SqlDataAdapter adapter = new SqlDataAdapter(transQuery, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", cashierId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                decimal doanhThu = 0;
                foreach (DataRow row in dt.Rows)
                {
                    doanhThu += Convert.ToDecimal(row["total"]);
                }
                txtDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";

                dt.Columns.Add("STT", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dt.Columns["STT"].SetOrdinal(0); 
                dgvTransactions.DataSource = dt;
                dgvTransactions.Columns["STT"].HeaderText = "Số thứ tự";
                dgvTransactions.Columns["UserName"].HeaderText = "Tên người dùng";
                dgvTransactions.Columns["total"].HeaderText = "Số tiền nạp";
                dgvTransactions.Columns["created_at"].HeaderText = "Thời gian nạp";
            }
        }
    }
}
