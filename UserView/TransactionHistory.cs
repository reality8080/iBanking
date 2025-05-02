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
using static Guna.UI2.Native.WinApi;

namespace iBanking.UserView
{
    public partial class TransactionHistory : Form
    {
        public User user;
        public List<Transaction> transactions;
        public TransactionHistory(User user)
        {
            this.user = user;
            this.transactions = new List<Transaction>();
            InitializeComponent();
            LoadTransaction();
        }
        private void LoadTransaction()
        {
            pnlTransaction.Controls.Clear();
            transactions = this.user.GetTransactions();
            foreach (Transaction transaction in transactions)
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
                panel.Width = pnlTransaction.ClientSize.Width - panel.Margin.Horizontal;

                Label lblTitle = new Label
                {
                    Text = $"{transaction.CreatedAt}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                Label lblContent = new Label
                {
                    Text = $"Nội dung: {transaction.Content}",
                    AutoSize = true,
                    Top = lblTitle.Bottom + 5
                };

                decimal totalValue;
                if (transaction.Payee==this.user.Id)
                {
                    totalValue = transaction.Total;
                }
                else
                {
                    totalValue = -transaction.Total;
                }
                Label lblTotal = new Label
                {
                    Text = $"Tổng: {totalValue}",
                    AutoSize = true,
                    Top = lblContent.Bottom + 5,
                    Font = new Font("Segoe UI", 10)
                };
                panel.Controls.Add(lblTitle);
                panel.Controls.Add(lblContent);
                panel.Controls.Add(lblTotal);

                pnlTransaction.Controls.Add(panel);
            }
        }
        private void History_Load(object sender, EventArgs e)
        {

        }

        private void pnlTransaction_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
