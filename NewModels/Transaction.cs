using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iBanking.LIB;
using Microsoft.Data.SqlClient;

namespace iBanking.NewModels
{
    public class Transaction
    {
        public int Payer {  get; set; }
        public int Payee { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total {  get; set; }
        public string Content { get; set; }
        #region Constructors
        public Transaction()
        {
            this.CreatedAt = DateTime.Now;
            this.Total = 0;
            this.Payer = 0;
            this.Payee = 0;
            this.Content = string.Empty;
        }
        public Transaction(int payer, int payee, decimal total)
        {
            this.Payer = payer;
            this.Payee = payee;
            this.Total = total;
            this.CreatedAt = DateTime.Now;
            this.Content = string.Empty;
        }
        public Transaction(int payer, int payee, decimal total, string content)
        {
            Payer = payer;
            Payee = payee;
            CreatedAt = DateTime.Now;
            Total = total;
            Content = content;
        }
        #endregion
        public static Transaction CreateNewTransaction(int payer, int payee, decimal total, string content)
        {
            Transaction transaction = new Transaction(payer, payee, total, content);
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    // Truy vấn SQL tạo Transaction mới
                    string query = @"
                        INSERT INTO [Transaction] (payer, payee, created_at, total, content)
                        VALUES (@payer, @payee, @created_at, @total, @content);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@payer", payer);
                        command.Parameters.AddWithValue("@payee", payee);
                        command.Parameters.AddWithValue("@total", total);
                        command.Parameters.AddWithValue("@created_at", transaction.CreatedAt);
                        command.Parameters.AddWithValue("@content", content);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi tạo Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return transaction;
        }
        // Phương thức xóa đối tượng trong cơ sở dữ liệu
        public Transaction Del()
        {
            // Xoá trong đối tượng trong CSDL và trả về null nếu không thành công trả về chính nó
            try
            {
                // Kết nối đến cơ sở dữ liệu và cập nhật thông tin
                using (SqlConnection connection = new SqlConnection(SQLHandling.connectionString))
                {
                    connection.Open();
                    // Truy vấn SQL tạo Transaction mới
                    string query = @"
                        DELETE FROM [TRANSACTION]
                        WHERE PAYER=@payer AND PAYEE=@payee AND CREATED_AT=@created_at
                        ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@payer", this.Payer );
                        command.Parameters.AddWithValue("@payee", this.Payee );
                        command.Parameters.AddWithValue("@created_at", this.CreatedAt);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi xóa Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return this;
            }
            return null;
        }
    }
}