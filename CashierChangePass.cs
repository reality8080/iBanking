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
    public partial class CashierChangePass : Form
    {
        private int cashierId;
        private string connectionString = "Data Source=USER\\SQLEXPRESS; Database=BANKING_APP; " +
                                          "User ID=sa; Password=123; MultipleActiveResultSets=True; " +
                                          "Encrypt=False; TrustServerCertificate=True;";

        public CashierChangePass(int id)
        {
            InitializeComponent();
            cashierId = id;
            SetRoundedRegion(20);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Employee WHERE id = @id AND password = @oldpass";
                SqlCommand cmdCheck = new SqlCommand(checkQuery, conn);
                cmdCheck.Parameters.AddWithValue("@id", cashierId);
                cmdCheck.Parameters.AddWithValue("@oldpass", oldPass);
                int count = (int)cmdCheck.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateQuery = "UPDATE Employee SET password = @newpass WHERE id = @id";
                SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn);
                cmdUpdate.Parameters.AddWithValue("@newpass", newPass);
                cmdUpdate.Parameters.AddWithValue("@id", cashierId);
                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();
            }
        }

        private void txtOldPass_Enter(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "Nhập mật khẩu cũ")
            {
                txtOldPass.Text = "";
                txtOldPass.PasswordChar = '*';
            }
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "Nhập mật khẩu mới")
            {
                txtNewPass.Text = "";
                txtNewPass.PasswordChar = '*';
            }
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            if(txtConfirmPass.Text == "Nhập lại mật khẩu mới")
            {
                txtConfirmPass.Text = "";
                txtConfirmPass.PasswordChar = '*';
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
