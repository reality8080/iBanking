using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace iBanking.Manager
{
    public partial class ManagerInfo : Form
    {
        private int manager;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=BANKINGAPP;user id=sa;Password=123456789;MultipleActiveResultSets=True;";

        public ManagerInfo(int id)
        {
            InitializeComponent();
            manager = id;
        }

        private void ManagerInfo_Load(object sender, EventArgs e)
        {
            txtID.Text = manager.ToString();
            txtID.ReadOnly = true;
            txtSalary.ReadOnly = true;
            LoadManagerInfo(manager);

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int newId))
            {
                LoadManagerInfo(newId);
            }
        }

        private void LoadManagerInfo(int id)
        {
            string query = "SELECT name, email, salary, start_at FROM Employee WHERE id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["name"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtSalary.Text = string.Format("{0:N0} VNĐ", reader["salary"]);
                        txtStartAt.Text = Convert.ToDateTime(reader["start_at"]).ToString("dd/MM/yyyy HH:mm:ss");

                    }
                    else
                    {
                        ClearTextBoxes();
                        MessageBox.Show("Không tìm thấy thông tin quản lý với ID này.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            txtStartAt.Clear();

        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string query = "UPDATE Employee SET name = @name, email = @mail WHERE id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại hoặc không tìm thấy thông tin.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }

        }

        private void lblOld_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
