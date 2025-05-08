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
            SetRoundedRegion(20);
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

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(txtSoTien.Text.Replace(".", "").Replace(",", ""), out long soTien))
            {
                lblSoTien.Text = string.Format("{0:N0} VNĐ", soTien);
            }
            else
            {
                lblSoTien.Text = "Lỗi"; 
            }
        }
    }
}
