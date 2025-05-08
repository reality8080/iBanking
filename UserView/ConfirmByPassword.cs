using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBanking.NewModels;

namespace iBanking.UserView
{
    public partial class ConfirmByPassword : System.Windows.Forms.Form
    {
        public Transaction transaction;
        public User user;
        public User payee;
        public int count = 0;
        private readonly IServiceProvider _serviceProvider;

        public ConfirmByPassword(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        public ConfirmByPassword(Transaction transaction, User user, User payee,IServiceProvider serviceProvider)

        {
            InitializeComponent();
            this.transaction = transaction;
            this.user = user;
            this.payee = payee;
            _serviceProvider= serviceProvider;
        }

        private void ConfirmByPassword_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            if (!password.Equals(this.user.Password))
            {
                count++;
                lblAnnounce.Text = "Nhập sai mật khẩu lần " + count;
            }
            if (count >= 3)
            {
                this.user.SetLockedTime(DateTime.Now);
                MessageBox.Show(
                    "Nhập sai quá 3 lần, tài khoản tạm khóa 1 giờ",
                    "Tạm khóa tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                // Xóa giao dịch trong CSDL
                this.transaction = transaction.Del();
                UserLogin userLogin = new UserLogin(_serviceProvider);
                userLogin.Show();
                this.Hide();
                return;
            }
            // tăng giảm số dư sau khi xác nhận thành công
            this.user.BalanceChange(-transaction.Total);
            this.payee.BalanceChange(transaction.Total);
            TransactionHistory history = new TransactionHistory(this.user);
            history.Show();
            this.Hide();
        }
    }
}
