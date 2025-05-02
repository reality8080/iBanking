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

namespace iBanking.UserView
{
    public partial class Home : Form
    {
        public User user;
        public Home(User user)
        {
            this.user = user;
            InitializeComponent();
            lblBalance.Text = MoneyHandling.Formatted(this.user.Balance);
            lblName.Text = user.Name;
            lblID.Text = user.Id.ToString();
            if (this.user.IsLocked())
            {
                btnBank.Enabled = false;
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Bank bank = new Bank(this.user);
            bank.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Information information = new Information(this.user);
            information.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.user);
            changePassword.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TransactionHistory history = new TransactionHistory(this.user);
            history.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DepositHistory deposit = new DepositHistory(this.user);
            deposit.Show();
            this.Hide();
        }
    }
}
