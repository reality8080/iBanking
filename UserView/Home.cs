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
using Microsoft.Extensions.DependencyInjection;

namespace iBanking.UserView
{
    public partial class Home : System.Windows.Forms.Form
    {
        public User user;
        private readonly IServiceProvider _serviceProvider;

        public Home(User user, IServiceProvider serviceProvider)
        {
            this.user = user;
            InitializeComponent();
            lblName.Text = user.Name;
            if (this.user.IsLocked())
            {
                btnBank.Enabled = false;
            }
            pnlMain.Controls.Clear();
            HomeComponent homeComponent = new HomeComponent(this, this.user);
            homeComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(homeComponent);
            _serviceProvider = serviceProvider??throw new ArgumentNullException(nameof(serviceProvider));
        }
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            BankComponent bankComponent = new BankComponent(this, this.user,_serviceProvider);
            bankComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(bankComponent);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            InformationComponent informationComponent = new InformationComponent(this.user, _serviceProvider);
            informationComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(informationComponent);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            ChangePasswordComponent changePasswordComponent = new ChangePasswordComponent(this.user, _serviceProvider);
            changePasswordComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(changePasswordComponent);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            TransactionHistoryComponent transactionHistoryComponent = new TransactionHistoryComponent(this.user, _serviceProvider);
            transactionHistoryComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(transactionHistoryComponent);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin(_serviceProvider);
            userLogin.Show();
            this.Hide();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            DepositHistoryComponent depositHistoryComponent = new DepositHistoryComponent(this.user);
            depositHistoryComponent.Dock = DockStyle.Fill;
            pnlMain .Controls.Add(depositHistoryComponent);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
        }

        private void btnBank2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBank2_Click(object sender, EventArgs e)
        {
            Bank bank = new Bank(this.user, _serviceProvider);
            bank.Show();
            this.Hide();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            Information information = new Information(this.user, _serviceProvider);
            information.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.user, _serviceProvider);
            changePassword.Show();
            this.Hide();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            TransactionHistory history = new TransactionHistory(this.user);
            history.Show();
            this.Hide();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            DepositHistory deposit = new DepositHistory(this.user);
            deposit.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            HomeComponent homeComponent = new HomeComponent(this, this.user);
            homeComponent.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(homeComponent);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            var login = _serviceProvider.GetService<loginForm>();
            this.Hide();
            if (login != null)
            {
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
            else
            {
                //_logger.LogWarning("Login form could not be created.");
                MessageBox.Show("Login form could not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
