using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace iBanking
{
    public partial class mainForm : System.Windows.Forms.Form
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private List<Guna.UI2.WinForms.Guna2Button>? buttons;

        public mainForm()
        {
            InitializeComponent();

        }

        private void exitGImageBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void minusGIBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void controlLGP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, (IntPtr)0X2, IntPtr.Zero);
            }
        }

        private void homeGbtn_Click(object sender, EventArgs e)
        {
            setActiveBtns(homeGbtn, "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\White\\homeWhite.png");
            tabControlBank.SelectedIndex = 0;
        }

        private void myBanksGbtn_Click(object sender, EventArgs e)
        {
            setActiveBtns(myBanksGbtn, "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\White\\dollar512White.png");
            tabControlBank.SelectedIndex = 1;
        }

        private void historyGbtn_Click(object sender, EventArgs e)
        {
            setActiveBtns(historyGbtn, "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\White\\historical512White.png");
            tabControlBank.SelectedIndex = 2;

        }

        private void transferGBtn_Click(object sender, EventArgs e)
        {
            setActiveBtns(transferGBtn, "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\White\\prepaidCards512White.png");
            tabControlBank.SelectedIndex = 3;
        }

        private void conncetBankGBtn_Click(object sender, EventArgs e)
        {
            setActiveBtns(conncetBankGBtn, "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\White\\cards-icon-size_512White.png");
            tabControlBank.SelectedIndex = 4;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new List<Guna.UI2.WinForms.Guna2Button>
                {
                    homeGbtn,myBanksGbtn,historyGbtn,transferGBtn,conncetBankGBtn
                };
        }

        private void ResestButtons()
        {
            buttons?.ForEach(button =>
            {
                foreach (var btn in buttons)
                {
                    btn.FillColor = Color.White;
                    btn.BorderColor = Color.White;
                    btn.ForeColor = Color.FromArgb(102, 112, 133);

                    string iconPath = GetDefaultIconPath(btn);
                    if (!string.IsNullOrEmpty(iconPath))
                    {
                        btn.Image = Image.FromFile(iconPath);
                    }
                }
            });
        }

        private string GetDefaultIconPath(Guna.UI2.WinForms.Guna2Button btn)
        {
            if (btn == homeGbtn) return "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\Gray\\homeGray.png";
            if (btn == myBanksGbtn) return "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\Gray\\dollar512Gray.png";
            if (btn == historyGbtn) return "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\Gray\\historical512Gray.png";
            if (btn == transferGBtn) return "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\Gray\\prepaidCards512Gray.png";
            if (btn == conncetBankGBtn) return "D:\\2024-2025\\HK2\\WindowsForm\\iBanking\\Resources\\Images\\Icon\\Gray\\cards-icon-size_512Gray.png";
            return "";
        }
        private void setActiveBtns(Guna.UI2.WinForms.Guna2Button btn, string activeIconPath)
        {
            ResestButtons();
            btn.FillColor = Color.FromArgb(14, 126, 254);
            btn.BorderColor = Color.FromArgb(14, 126, 254);
            btn.ForeColor = Color.White;

            btn.Image = Image.FromFile(activeIconPath);
        }

        private void controlLGP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
