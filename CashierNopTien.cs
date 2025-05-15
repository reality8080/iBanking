//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace iBanking
//{
//    public partial class CashierNopTien : System.Windows.Forms.Form
//    {
//        private int cashierId;
//        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog=BANKING_APP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
//        public CashierNopTien(int id)
//        {
//            InitializeComponent();
//            cashierId = id;
//            txtSoTien.ForeColor = Color.Gray;
//            txtUserId.ForeColor = Color.Gray;
//            SetRoundedRegion(20);
//        }

//        private void btnXacThuc_Click(object sender, EventArgs e)
//        {
//            string userId = txtUserId.Text.Trim();
//            if (string.IsNullOrEmpty(userId))
//            {
//                MessageBox.Show("Vui lòng nhập ID người dùng!");
//                return;
//            }

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "SELECT name, email, balance FROM [User] WHERE id = @id";
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@id", userId);

//                SqlDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    txtTen.Text = reader["name"].ToString();
//                    txtEmail.Text = reader["email"].ToString();

//                    object balanceValue = reader["balance"];
//                    if (balanceValue == DBNull.Value)
//                    {
//                        txtSoDu.Text = "0 VNĐ"; // Hoặc "N/A VNĐ", "Không có thông tin VNĐ", tùy bạn muốn hiển thị gì
//                    }
//                    else
//                    {
//                        txtSoDu.Text = Convert.ToDecimal(balanceValue).ToString("N0") + " VNĐ";
//                    }

//                    btnNopTien.Enabled = true;
//                }
//                else
//                {
//                    MessageBox.Show("Không tìm thấy người dùng!");
//                    btnNopTien.Enabled = false;
//                    ClearFields();
//                }
//                reader.Close();
//            }
//        }

//        private void CashierNopTien_Load(object sender, EventArgs e)
//        {
//            btnNopTien.Enabled = false;
//        }

//        private void btnNopTien_Click(object sender, EventArgs e)
//        {
//            string userId = txtUserId.Text.Trim();
//            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0)
//            {
//                MessageBox.Show("Số tiền không hợp lệ!");
//                return;
//            }

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                SqlTransaction trans = conn.BeginTransaction();

//                try
//                {
//                    string updateBalance = "UPDATE [User] SET balance = balance + @amount WHERE id = @id";
//                    SqlCommand cmdUpdate = new SqlCommand(updateBalance, conn, trans);
//                    cmdUpdate.Parameters.AddWithValue("@amount", soTien);
//                    cmdUpdate.Parameters.AddWithValue("@id", userId);
//                    cmdUpdate.ExecuteNonQuery();

//                    string insertDeposit = "INSERT INTO Deposit ([user], total, cashier, created_at) VALUES (@user, @total, @cashier, GETDATE())";
//                    SqlCommand cmdInsert = new SqlCommand(insertDeposit, conn, trans);
//                    cmdInsert.Parameters.AddWithValue("@user", userId);
//                    cmdInsert.Parameters.AddWithValue("@total", soTien);
//                    cmdInsert.Parameters.AddWithValue("@cashier", cashierId);
//                    cmdInsert.ExecuteNonQuery();

//                    trans.Commit();
//                    MessageBox.Show("Nộp tiền thành công!");
//                    btnXacThuc_Click(null, null);
//                }
//                catch (Exception ex)
//                {
//                    trans.Rollback();
//                    MessageBox.Show("Lỗi khi nộp tiền: " + ex.Message);
//                }
//            }
//        }
//        private void ClearFields()
//        {
//            txtUserId.Clear();
//            txtTen.Clear();
//            txtEmail.Clear();
//            txtSoDu.Clear();
//            txtSoTien.Clear();
//            btnNopTien.Enabled = false;
//        }

//        private void txtSoTien_Enter(object sender, EventArgs e)
//        {
//            if (txtSoTien.Text == "Nhập số tiền")
//            {
//                txtSoTien.Text = "";
//                txtSoTien.ForeColor = Color.Black;
//            }
//        }

//        private void txtUserId_Enter(object sender, EventArgs e)
//        {
//            if (txtUserId.Text == "Nhập số tài khoản")
//            {
//                txtUserId.Text = "";
//                txtUserId.ForeColor = Color.Black;
//            }
//        }
//        private void SetRoundedRegion(int radius)
//        {
//            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
//            GraphicsPath path = new GraphicsPath();
//            int d = radius * 2;

//            path.StartFigure();
//            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
//            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
//            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
//            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
//            path.CloseFigure();

//            this.Region = new Region(path);
//        }

//        protected override void OnResize(EventArgs e)
//        {
//            base.OnResize(e);
//            SetRoundedRegion(20);
//        }

//        private void txtSoTien_TextChanged(object sender, EventArgs e)
//        {
//            if (long.TryParse(txtSoTien.Text.Replace(".", "").Replace(",", ""), out long soTien))
//            {
//                lblSoTien.Text = string.Format("{0:N0} VNĐ", soTien);
//            }
//            else
//            {
//                lblSoTien.Text = "Lỗi"; 
//            }
//        }
//    }
//}
using Microsoft.Data.SqlClient;
using System;
using System.Data; // Cần cho System.Data.ConnectionState
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks; // Cần cho Task
using System.Windows.Forms;
// using System.Diagnostics; // Thêm để dùng Debug.WriteLine

namespace iBanking
{
    public partial class CashierNopTien : System.Windows.Forms.Form
    {
        private int cashierId;
        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog=BANKING_APP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Các controls giả định từ Designer
        // private TextBox txtUserId;
        // private TextBox txtSoTien;
        // private TextBox txtTen;
        // private TextBox txtEmail;
        // private TextBox txtSoDu;
        // private Button btnNopTien;
        // private Label lblSoTien;

        public CashierNopTien(int id)
        {
            InitializeComponent();
            cashierId = id;
            if (txtSoTien != null)
            {
                txtSoTien.ForeColor = Color.Gray;
            }
            if (txtUserId != null)
            {
                txtUserId.ForeColor = Color.Gray;
            }
            SetRoundedRegion(20);
        }

        private async void btnXacThuc_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine($"btnXacThuc_Click called. Cashier ID: {cashierId}");
            string userIdText = txtUserId.Text.Trim();
            if (string.IsNullOrEmpty(userIdText))
            {
                MessageBox.Show("Vui lòng nhập ID người dùng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(userIdText, out int userIdAsInt))
            {
                MessageBox.Show("ID người dùng không hợp lệ! Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFieldsAndDisableNopTien();
                return;
            }
            // Debug.WriteLine($"Xác thực cho User ID: {userIdAsInt}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    string query = "SELECT name, email, balance FROM [User] WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userIdAsInt);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Debug.WriteLine($"User ID {userIdAsInt} found. Fetching details.");
                                txtTen.Text = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
                                txtEmail.Text = reader["email"] == DBNull.Value ? string.Empty : reader["email"].ToString();

                                object balanceValue = reader["balance"];
                                // Debug.WriteLine($"Raw balance value from DB for User ID {userIdAsInt}: { (balanceValue == DBNull.Value ? "NULL" : balanceValue.ToString()) }");
                                if (balanceValue == DBNull.Value)
                                {
                                    txtSoDu.Text = "0 VNĐ";
                                }
                                else
                                {
                                    txtSoDu.Text = Convert.ToDecimal(balanceValue).ToString("N0") + " VNĐ";
                                }
                                btnNopTien.Enabled = true;
                            }
                            else
                            {
                                // Debug.WriteLine($"User ID {userIdAsInt} NOT found.");
                                MessageBox.Show("Không tìm thấy người dùng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFieldsAndDisableNopTien();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Debug.WriteLine($"Lỗi khi xác thực người dùng: {ex.ToString()}");
                    MessageBox.Show("Lỗi khi xác thực người dùng: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFieldsAndDisableNopTien();
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void CashierNopTien_Load(object sender, EventArgs e)
        {
            if (btnNopTien != null)
            {
                btnNopTien.Enabled = false;
            }
        }

        private async void btnNopTien_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine($"btnNopTien_Click started. Cashier ID: {cashierId}");
            string userIdText = txtUserId.Text.Trim();
            if (!int.TryParse(userIdText, out int userIdAsInt))
            {
                MessageBox.Show("ID người dùng không hợp lệ! Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Debug.WriteLine($"Nộp tiền cho User ID: {userIdAsInt}");

            string soTienText = txtSoTien.Text.Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(soTienText, out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ! Vui lòng nhập số tiền lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Debug.WriteLine($"Số tiền nộp: {soTien}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction trans = null;
                try
                {
                    await conn.OpenAsync();
                    trans = conn.BeginTransaction();
                    // Debug.WriteLine("Transaction started.");

                    // Bước 1: Kiểm tra sự tồn tại của Cashier ID
                    string checkCashierQuery = "SELECT 1 FROM Employee WHERE id = @cashierIdCheck";
                    using (SqlCommand cmdCheckCashier = new SqlCommand(checkCashierQuery, conn, trans))
                    {
                        cmdCheckCashier.Parameters.AddWithValue("@cashierIdCheck", cashierId);
                        object resultCashierCheck = await cmdCheckCashier.ExecuteScalarAsync();
                        if (resultCashierCheck == null || resultCashierCheck == DBNull.Value)
                        {
                            // Debug.WriteLine($"Cashier ID {cashierId} không tồn tại. Rolling back.");
                            MessageBox.Show($"Lỗi: ID nhân viên thu ngân ({cashierId}) không hợp lệ hoặc không tồn tại. Vui lòng kiểm tra lại.", "Lỗi Thu Ngân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            trans.Rollback();
                            return;
                        }
                        // Debug.WriteLine($"Cashier ID {cashierId} is valid.");
                    }

                    // Bước 2: Cập nhật số dư người dùng
                    string updateBalance = "UPDATE [User] SET balance = ISNULL(balance, 0) + @amount WHERE id = @id";
                    // Debug.WriteLine($"Executing Update: {updateBalance} with amount={soTien}, id={userIdAsInt}");
                    using (SqlCommand cmdUpdate = new SqlCommand(updateBalance, conn, trans))
                    {
                        cmdUpdate.Parameters.AddWithValue("@amount", soTien);
                        cmdUpdate.Parameters.AddWithValue("@id", userIdAsInt); // Đảm bảo đây là kiểu int nếu cột id trong DB là int
                        int rowsAffectedUpdate = await cmdUpdate.ExecuteNonQueryAsync();
                        // Debug.WriteLine($"Rows affected by UPDATE: {rowsAffectedUpdate}");
                        if (rowsAffectedUpdate == 0)
                        {
                            // Debug.WriteLine($"Không thể cập nhật số dư cho User ID {userIdAsInt}. Người dùng không tồn tại? Rolling back.");
                            MessageBox.Show($"Không thể cập nhật số dư cho người dùng ID: {userIdAsInt}. Người dùng có thể không tồn tại.", "Lỗi Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            trans.Rollback();
                            return;
                        }
                    }

                    // Bước 3: Chèn bản ghi vào bảng Deposit
                    string insertDeposit = "INSERT INTO Deposit ([user], total, cashier, created_at) VALUES (@user, @total, @cashier, GETDATE())";
                    // Debug.WriteLine($"Executing Insert into Deposit: user={userIdAsInt}, total={soTien}, cashier={cashierId}");
                    using (SqlCommand cmdInsert = new SqlCommand(insertDeposit, conn, trans))
                    {
                        cmdInsert.Parameters.AddWithValue("@user", userIdAsInt); // Đảm bảo đây là kiểu int nếu cột [user] trong DB là int
                        cmdInsert.Parameters.AddWithValue("@total", soTien);
                        cmdInsert.Parameters.AddWithValue("@cashier", cashierId);
                        await cmdInsert.ExecuteNonQueryAsync();
                        // Debug.WriteLine("Insert into Deposit successful.");
                    }

                    trans.Commit();
                    // Debug.WriteLine("Transaction committed.");
                    MessageBox.Show("Nộp tiền thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ***** BƯỚC DEBUG THÊM: ĐỌC LẠI BALANCE NGAY SAU COMMIT *****
                    try
                    {
                        // Debug.WriteLine($"DEBUG: Re-querying balance for User ID {userIdAsInt} immediately after commit.");
                        string recheckQuery = "SELECT balance FROM [User] WHERE id = @id";
                        using (SqlCommand cmdRecheck = new SqlCommand(recheckQuery, conn)) // Không cần transaction ở đây vì chỉ đọc
                        {
                            cmdRecheck.Parameters.AddWithValue("@id", userIdAsInt);
                            object newBalanceObj = await cmdRecheck.ExecuteScalarAsync();
                            if (newBalanceObj == DBNull.Value || newBalanceObj == null)
                            {
                                // Debug.WriteLine($"DEBUG: Balance for User ID {userIdAsInt} is STILL NULL after commit.");
                            }
                            else
                            {
                                // Debug.WriteLine($"DEBUG: Balance for User ID {userIdAsInt} after commit is: {Convert.ToDecimal(newBalanceObj)}");
                            }
                        }
                    }
                    catch (Exception exDebug)
                    {
                        // Debug.WriteLine($"DEBUG: Error re-querying balance: {exDebug.Message}");
                    }
                    // ***** KẾT THÚC BƯỚC DEBUG THÊM *****


                    btnXacThuc_Click(null, null); // Gọi lại để làm mới thông tin trên UI
                    if (txtSoTien != null) txtSoTien.Clear();
                    if (lblSoTien != null) lblSoTien.Text = "0 VNĐ";
                }
                catch (Exception ex)
                {
                    // Debug.WriteLine($"Lỗi khi nộp tiền (trong transaction): {ex.ToString()}");
                    if (trans != null)
                    {
                        try
                        {
                            trans.Rollback();
                            // Debug.WriteLine("Transaction rolled back due to exception.");
                        }
                        catch (Exception exRollback)
                        {
                            // Debug.WriteLine($"Lỗi khi rollback giao dịch: {exRollback.ToString()}");
                            MessageBox.Show("Lỗi khi rollback giao dịch: " + exRollback.Message, "Lỗi Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show("Lỗi khi nộp tiền: " + ex.Message, "Lỗi Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                        // Debug.WriteLine("Connection closed.");
                    }
                }
            }
        }

        private void ClearFields()
        {
            if (txtUserId != null) txtUserId.Clear();
            if (txtTen != null) txtTen.Clear();
            if (txtEmail != null) txtEmail.Clear();
            if (txtSoDu != null) txtSoDu.Clear();
            if (txtSoTien != null) txtSoTien.Clear();
            if (lblSoTien != null) lblSoTien.Text = "0 VNĐ";
        }

        private void ClearFieldsAndDisableNopTien()
        {
            ClearFields();
            if (btnNopTien != null)
            {
                btnNopTien.Enabled = false;
            }
        }

        private void txtSoTien_Enter(object sender, EventArgs e)
        {
            if (txtSoTien != null && txtSoTien.Text == "Nhập số tiền")
            {
                txtSoTien.Text = "";
                txtSoTien.ForeColor = Color.Black;
            }
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            if (txtUserId != null && txtUserId.Text == "Nhập số tài khoản")
            {
                txtUserId.Text = "";
                txtUserId.ForeColor = Color.Black;
            }
        }

        private void SetRoundedRegion(int radius)
        {
            if (this.IsHandleCreated && this.Width > 0 && this.Height > 0)
            {
                Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
                GraphicsPath path = new GraphicsPath();
                int d = radius * 2;

                if (d > 0 && d <= bounds.Width && d <= bounds.Height)
                {
                    path.StartFigure();
                    path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
                    path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
                    path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();
                    this.Region = new Region(path);
                }
                else
                {
                    this.Region = new Region(bounds);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.IsHandleCreated)
            {
                SetRoundedRegion(20);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetRoundedRegion(20);
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTien == null || lblSoTien == null) return;
            string cleanAmount = txtSoTien.Text.Replace(",", "").Replace(".", "");
            if (long.TryParse(cleanAmount, out long soTienValue))
            {
                lblSoTien.Text = string.Format("{0:N0} VNĐ", soTienValue);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    lblSoTien.Text = "0 VNĐ";
                }
                else
                {
                    lblSoTien.Text = "Số không hợp lệ";
                }
            }
        }
    }
}
