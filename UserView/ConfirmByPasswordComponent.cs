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
    public partial class ConfirmByPasswordComponent : UserControl
    {
        public Transaction transaction;
        public User user;
        public User payee;
        public int count = 0;
        public Home home;
        private readonly IServiceProvider _serviceProvider;

        public ConfirmByPasswordComponent(Home home, Transaction transaction, User user, User payee, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.transaction = transaction;
            this.user = user;
            this.payee = payee;
            this.home = home;
            _serviceProvider = serviceProvider;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmByPasswordComponent_Load(object sender, EventArgs e)
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
            this.home.pnlMain.Controls.Clear();
            TransactionHistoryComponent transactionHistoryComponent = new TransactionHistoryComponent(this.user,_serviceProvider);
            transactionHistoryComponent.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(transactionHistoryComponent);
        }
    }
}
