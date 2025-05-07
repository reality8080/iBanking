using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking
{
    public partial class CashierOpenShift : Form
    {
        private int cashierId;
        private string connectionString = "Data Source=USER\\SQLEXPRESS; Database=BANKING_APP; " +
                                           "User ID=sa; Password=123; MultipleActiveResultSets=True; " +
                                           "Encrypt=False; TrustServerCertificate=True;";
        public CashierOpenShift(int id)
        {
            InitializeComponent();
            cashierId = id;
            SetRoundedRegion(20);
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn mở ca chứ?", "Xác nhận mở ca",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OpenShift(cashierId); 
            }
        }
        private void OpenShift(int cashierId)
        {
            string empQuery = "SELECT name, email FROM Employee WHERE id = @id";
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
                    lblCashier.Text = $"Xin chào, {reader["name"]}";
                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter(transQuery, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", cashierId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dt.Columns["STT"].SetOrdinal(0);
                dgvTransactions.DataSource = dt;
                dgvTransactions.DataSource = dt;
                dgvTransactions.Columns["STT"].HeaderText = "Số thứ tự";
                dgvTransactions.Columns["UserName"].HeaderText = "Tên người dùng";
                dgvTransactions.Columns["total"].HeaderText = "Số tiền nạp";
                dgvTransactions.Columns["created_at"].HeaderText = "Thời gian nạp";
            }
        }
        private void SetRoundedRegion(int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetRoundedRegion(20);
        }
    }
}
