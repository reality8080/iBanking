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
    public partial class Bank : System.Windows.Forms.Form
    {
        public User user;
        public User payee;
        public decimal total;
        public string content;
        public Transaction transaction;
        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog=BANKING_APP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly IServiceProvider _serviceProvider;

        public Bank(IServiceProvider _serviceProvider)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider;
        }
        public Bank(User user,IServiceProvider _serviceProvider)
        {
            InitializeComponent();
            this.user = user;
            this.txtTotal.Enabled = false;
            this.btnBank.Enabled = false;
            this.txtContent.Text = user.Name + "Chuyển khoản";
            this.content = this.txtContent.Text;
            this._serviceProvider= _serviceProvider;
        }

        private void Bank_Load(object sender, EventArgs e)
        {

        }
        private Transaction CreateNewTransaction()
        {
            return Transaction.CreateNewTransaction(user.Id, payee.Id, total, content);

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Xử lý và tạo đối tượng Transaction mới
            this.transaction = CreateNewTransaction();
            //this.user.BalanceChange(-total);
            //this.payee.BalanceChange(total);
            if (transaction != null)
            {
                ConfirmByPassword confirmByPassword = new ConfirmByPassword(transaction, user, payee,_serviceProvider);
                confirmByPassword.Show();
                this.Hide();
            }
        }
        private User FindPayee(int payeeId)
        {
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn lấy thông tin người dùng
                    string query = "SELECT * FROM [User] WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@id", payeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo đối tượng User từ dữ liệu
                                User user = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Password = reader.GetString(reader.GetOrdinal("password")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Balance = reader.GetDecimal(reader.GetOrdinal("balance")),
                                    Email = reader.GetString(reader.GetOrdinal("email"))
                                };
                                return user;
                            }
                            else
                            {
                                // Không tìm thấy người dùng
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            bool checkTypeId = int.TryParse(txtPayee.Text, out int payeeId);
            if (!checkTypeId)
            {
                txtTotal.Enabled = false;
                lblPayee.Text = "ID không hợp lệ";
                return;
            }
            if (payeeId == user.Id)
            {
                txtTotal.Enabled = false;
                lblPayee.Text = "Tài khoản của chính bạn";
                return;
            }
            this.payee = FindPayee(payeeId);
            if (payee == null)
            {
                txtTotal.Enabled = false;
                lblPayee.Text = "Không tìm thấy người dùng";
                return;
            }
            lblPayee.Text = payee.ToString();
            txtTotal.Enabled = true;
        }

        private void lblPayee_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            bool checkTotal = decimal.TryParse(txtTotal.Text, out decimal total);
            if (!checkTotal)
            {
                lblTotal.Text = "Số tiền nhập vào không hợp lệ";
                btnBank.Enabled = false;
                return;
            }
            if (total > user.Balance)
            {
                lblTotal.Text = "Vượt quá số dư";
                btnBank.Enabled = false;
                return;
            }
            this.total = total;
            lblTotal.Text = MoneyHandling.Formatted(total);
            btnBank.Enabled = true;
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            this.content = txtContent.Text;
            Console.WriteLine(this.content); // Debug
        }
    }
}
