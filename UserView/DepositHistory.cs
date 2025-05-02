using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBanking.Models;
using iBanking.NewModels;
using Microsoft.Data.SqlClient;

namespace iBanking.UserView
{
    public partial class DepositHistory : Form
    {
        public User user;
        public List<Deposit> deposits;
        public DepositHistory(User user)
        {
            InitializeComponent();
            this.user = user;
            this.deposits = new List<Deposit>();
            LoadDeposit();
        }
        private void LoadDeposit()
        {
            pnlDeposit.Controls.Clear();
            deposits = this.user.GetDeposits();
            foreach (Deposit deposit in deposits)
            {

                Panel panel = new Panel
                {
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = ColorTranslator.FromHtml("#ffffff"),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                panel.Width = pnlDeposit.ClientSize.Width - panel.Margin.Horizontal;

                Label lblTitle = new Label
                {
                    Text = $"{deposit.CreatedAt}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                Label lblContent = new Label
                {
                    Text = $"Nhân viên thu ngân: {deposit.Cashier}",
                    AutoSize = true,
                    Top = lblTitle.Bottom + 5
                };

                Label lblTotal = new Label
                {
                    Text = $"Tổng: {deposit.Total}",
                    AutoSize = true,
                    Top = lblContent.Bottom + 5,
                    Font = new Font("Segoe UI", 10)
                };
                panel.Controls.Add(lblTitle);
                panel.Controls.Add(lblContent);
                panel.Controls.Add(lblTotal);

                pnlDeposit.Controls.Add(panel);
            }
        }

        private void pnlDeposit_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
