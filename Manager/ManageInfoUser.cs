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
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace iBanking.Manager
{
    public partial class ManageInfoUser : System.Windows.Forms.Form
    {
        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog = BANKING_APP; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";

        public ManageInfoUser()
        {

            InitializeComponent();
        }

        private void ManageInfoUser_Load(object sender, EventArgs e)
        {

        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUserId.Text.Trim(), out int userId))
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ.");
                return;
            }

            string query = @"
                    SELECT name, email, balance, start_at
                    FROM [User]
                    WHERE id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTen.Text = reader["name"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtSoDu.Text = string.Format("{0:N0} VNĐ", reader["balance"]);
                        txtStartAt.Text = Convert.ToDateTime(reader["start_at"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy người dùng với ID đã nhập.");
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
                    ClearTextBoxes();
                }
            }
        }
        private void ClearTextBoxes()
        {
            txtTen.Text = "";
            txtEmail.Text = "";
            txtSoDu.Text = "";
            txtStartAt.Text = "";
        }
    }
}
