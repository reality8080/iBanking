using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using iBanking.NewModels;

namespace iBanking.UserView
{
    public partial class DepositHistoryComponent : UserControl
    {
        public User user;
        public List<Deposit> deposits;
        public DepositHistoryComponent(User user)
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

                Guna2Panel panel = new Guna2Panel
                {

                    Height = 100,
                    BorderRadius = 20,
                    FillColor = ColorTranslator.FromHtml("#00A9FF"),
                    Padding = new Padding(15),
                    Margin = new Padding(15),
                    BackColor = Color.Transparent,
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
