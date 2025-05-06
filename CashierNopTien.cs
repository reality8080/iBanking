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
    public partial class CashierNopTien : Form
    {
        private int cashierId;
        private string connectionString = "Data Source=USER\\SQLEXPRESS; Database=BANKING_APP; " +
                                  "User ID=sa; Password=123; Encrypt=False; TrustServerCertificate=True;";
        public CashierNopTien(int id)
        {
            InitializeComponent();
            cashierId = id;
            txtSoTien.ForeColor = Color.Gray;
            txtUserId.ForeColor = Color.Gray;
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Vui lòng nhập ID người dùng!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name, email, balance FROM [User] WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTen.Text = reader["name"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtSoDu.Text = Convert.ToDecimal(reader["balance"]).ToString("N0") + " VNĐ";
                    btnNopTien.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng!");
                    btnNopTien.Enabled = false;
                    ClearFields();
                }
                reader.Close();
            }
        }

        private void CashierNopTien_Load(object sender, EventArgs e)
        {
            btnNopTien.Enabled = false;
        }

        private void btnNopTien_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string updateBalance = "UPDATE [User] SET balance = balance + @amount WHERE id = @id";
                    SqlCommand cmdUpdate = new SqlCommand(updateBalance, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@amount", soTien);
                    cmdUpdate.Parameters.AddWithValue("@id", userId);
                    cmdUpdate.ExecuteNonQuery();

                    string insertDeposit = "INSERT INTO Deposit ([user], total, cashier, created_at) VALUES (@user, @total, @cashier, GETDATE())";
                    SqlCommand cmdInsert = new SqlCommand(insertDeposit, conn, trans);
                    cmdInsert.Parameters.AddWithValue("@user", userId);
                    cmdInsert.Parameters.AddWithValue("@total", soTien);
                    cmdInsert.Parameters.AddWithValue("@cashier", cashierId);
                    cmdInsert.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Nộp tiền thành công!");
                    btnXacThuc_Click(null, null);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi nộp tiền: " + ex.Message);
                }
            }
        }
        private void ClearFields()
        {
            txtUserId.Clear();
            txtTen.Clear();
            txtEmail.Clear();
            txtSoDu.Clear();
            txtSoTien.Clear();
            btnNopTien.Enabled = false;
        }

        private void txtSoTien_Enter(object sender, EventArgs e)
        {
            if (txtSoTien.Text == "Nhập số tiền")
            {
                txtSoTien.Text = "";
                txtSoTien.ForeColor = Color.Black;
            }
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            if (txtUserId.Text == "Nhập số tài khoản")
            {
                txtUserId.Text = "";
                txtUserId.ForeColor = Color.Black;
            }
        }
    }
}
