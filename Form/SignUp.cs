
using iBanking.Interfaces.Ser;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace iBanking.Form
{
    public partial class SignUp : System.Windows.Forms.Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly ISerUserAuth _serUserAuth;
        private readonly ILogger<SignUp> _logger;
        public SignUp(ISerUserAuth _serUserAuth, ILogger<SignUp> _logger)
        {
            InitializeComponent();
            this._serUserAuth = _serUserAuth ?? throw new ArgumentNullException(nameof(_serUserAuth));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        private async void signUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool create = await _serUserAuth.addUaBaCr(userNamegTBox.Text, emailGTBox.Text, pwsGTxb.Text, "Khach Hang");
                if (!create)
                {
                    MessageBox.Show("Khong the tao tai khoan");
                    _logger.LogWarning("Khong the tao tai khoan");
                    return;
                }
                MessageBox.Show("Tao tai khoan thanh cong");
                _logger.LogInformation("Tao tai khoan thanh cong");
                userNamegTBox.Clear();
                emailGTBox.Clear();
                pwsGTxb.Clear();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.LogError($"Loi khi dang ky: {ex}");
            }
        }

        private void exitGBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitGIBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void layoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void exitGIBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
