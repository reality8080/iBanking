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
    public partial class CashierInfo : Form
    {
        private int cashierId;
        private string connectionString = "Data Source=USER\\SQLEXPRESS; Database=BANKING_APP; " +
                                           "User ID=sa; Password=123; MultipleActiveResultSets=True; " +
                                           "Encrypt=False; TrustServerCertificate=True;";
        public CashierInfo(int id)
        {
            InitializeComponent();
            cashierId = id;
            LoadCashierInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE Employee SET name = @name, email = @mail WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id", cashierId);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");
            }
        }
        private void LoadCashierInfo()
        {
            string query = "SELECT name, email, salary, start_at, manager, password FROM Employee WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", cashierId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtID.Text = cashierId.ToString();
                    txtName.Text = reader["name"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtSalary.Text = string.Format("{0:N0} VNĐ", reader["salary"]);
                    txtStartAt.Text = Convert.ToDateTime(reader["start_at"]).ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
    }
}
