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
using System.Drawing.Drawing2D;

namespace iBanking
{
    public partial class CashierInfo : System.Windows.Forms.Form
    {
        private int cashierId;
        private string connectionString = "Data Source=(localdb)\\localThienPhu;Initial Catalog=BANKING_APP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public CashierInfo(int id)
        {
            InitializeComponent();
            cashierId = id;
            LoadCashierInfo();
            SetRoundedRegion(20);
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
