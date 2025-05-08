using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using iBanking.LIB;
using iBanking.UserView;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static Guna.UI2.Native.WinApi;

namespace iBanking.NewModels
{
    public class User : Person
    {
        #region Fields
        public decimal Balance { get; set; }
        public DateTime LockedTime { get; set; }
        #endregion

        #region Constructors
        public User() 
        {
            this.Balance = 0;
        }

        public User(int id, string username, string password, decimal balance, string email, DateTime createdAt):base( id,  username,  password,  email,  createdAt)
        {
            Balance= balance;
        }

        public User(string username, string password, string email):base(username,password,email)
        {
        }

        #endregion
        #region Methods
        public override string ToString()
        {
            return this.Name;
        }
        public void SetLockedTime(DateTime time)
        {
            this.LockedTime = time;
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [User] SET LOCKED_TIME = @lockedTime WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@lockedTime", this.LockedTime);
                        command.Parameters.AddWithValue("@id", this.Id);
                        // Thực thi lệnh UPDATE
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool IsLocked()
        {
            TimeSpan duration = DateTime.Now - this.LockedTime;
            return duration.TotalHours < 1;
        }
        public void BalanceChange(decimal amount)
        {
            this.Balance += amount;
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    string query = "UPDATE [User] SET balance = @balance WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection 
                        command.Parameters.AddWithValue("@balance", this.Balance);
                        command.Parameters.AddWithValue("@id", this.Id);
                        // Thực thi lệnh UPDATE
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lấy danh sách giao dịch 
        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            using (SqlConnection conn = new SqlConnection(SQLHandling.connectionString))
            {
                conn.Open();

                string query = @"SELECT PAYER, PAYEE, [TRANSACTION].CREATED_AT, TOTAL, CONTENT
                         FROM [TRANSACTION] 
                         INNER JOIN [USER] ON [TRANSACTION].PAYER = [USER].ID OR [TRANSACTION].PAYEE = [USER].ID 
                         WHERE [USER].ID = @UserId 
                         ORDER BY [TRANSACTION].CREATED_AT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", this.Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactions.Add(new Transaction
                            {
                                Payer = Convert.ToInt32(reader["PAYER"]),
                                Payee = Convert.ToInt32(reader["PAYEE"]),
                                CreatedAt = Convert.ToDateTime(reader["CREATED_AT"]),
                                Total = Convert.ToDecimal(reader["TOTAL"]),
                                Content = reader["CONTENT"].ToString()
                            });
                        }
                    }
                }
            }

            return transactions;
        }
        // Lấy danh sách lịch sử nộp tiền
        public List<Deposit> GetDeposits()
        {
            List<Deposit> deposits = new List<Deposit>();
            using (SqlConnection conn = new SqlConnection(SQLHandling.connectionString))
            {
                conn.Open();
                string query = "SELECT [DEPOSIT].[USER], [DEPOSIT].[CASHIER], [DEPOSIT].[CREATED_AT], [DEPOSIT].[TOTAL] " +
                               "FROM [DEPOSIT] INNER JOIN [USER] ON [DEPOSIT].[USER]= [USER].[ID] " +
                               "WHERE [USER].[ID]=@id " +
                               "ORDER BY [DEPOSIT].[CREATED_AT]";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deposits.Add(new Deposit
                            {
                                User = Convert.ToInt32(reader["user"]),
                                Cashier = Convert.ToInt32(reader["cashier"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                Total = Convert.ToDecimal(reader["total"])
                            });
                        }
                    }
                }
            }
            return deposits;
        }
        #endregion
    }
}