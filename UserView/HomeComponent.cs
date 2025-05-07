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
    public partial class HomeComponent : UserControl
    {
        public User user;
        public Home home;
        public HomeComponent(Home home, User user)
        {
            InitializeComponent();
            this.user = user;
            lblBalance.Text = "********";
            lblID.Text = user.Id.ToString();
            if (this.user.IsLocked())
            {
                btnBank2.Enabled = false;
            }
            this.home = home;
        }

        private void HomeComponent_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            if (lblBalance.Text.Equals("********"))
            {
                lblBalance.Text = MoneyHandling.Formatted(this.user.Balance);

            }
            else
            {
                lblBalance.Text = "********";
            }
        }

        private void btnBank2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.home.pnlMain.Controls.Clear();
            ChangePasswordComponent changePasswordComponent = new ChangePasswordComponent(this.user);
            changePasswordComponent.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(changePasswordComponent);
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.home.pnlMain.Controls.Clear();
            InformationComponent informationComponent = new InformationComponent(this.user);
            informationComponent.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(informationComponent);
        }

        private void btnBank2_Click(object sender, EventArgs e)
        {
            this.home.pnlMain.Controls.Clear();
            BankComponent bankComponent = new BankComponent(this.home, this.user);
            bankComponent.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(bankComponent);
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            this.home.pnlMain.Controls.Clear();
            TransactionHistoryComponent transactionHistory = new TransactionHistoryComponent(this.user);
            transactionHistory.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(transactionHistory);
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.home.pnlMain.Controls.Clear();
            DepositHistoryComponent depositHistoryComponent = new DepositHistoryComponent(this.user);
            depositHistoryComponent.Dock = DockStyle.Fill;
            this.home.pnlMain.Controls.Add(depositHistoryComponent);
        }
    }
}
