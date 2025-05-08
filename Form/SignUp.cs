
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

        private readonly ISerUser _serUser;
        private readonly ISerEmployee _serEmployee;
        private readonly ILogger<SignUp> _logger;
        public SignUp(ISerUser _serUser, ILogger<SignUp> _logger, ISerEmployee _serEmployee)
        {
            InitializeComponent();
            this._serUser = _serUser ?? throw new ArgumentNullException(nameof(_serUser));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            this._serEmployee = _serEmployee ?? throw new ArgumentNullException(nameof(_serEmployee));
        }

        private async void signUpBtn_Click(object sender, EventArgs e)
        {
            if (typeOfACCgCB.Text == "User")
            {
                await userSignUp();
            }
            else
            {
                await employeeSignUp();
            }
            typeOfACCgCB.Text = "";
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

        private async Task employeeSignUp()
        {
            try
            {
                bool create = false;
                if (string.IsNullOrEmpty( idManagerTXT.Text) )
                {
                    create = await _serEmployee.createEm(userNamegTBox.Text, pwsGTxb.Text, emailGTBox.Text, null);
                }
                else
                {
                   create = await _serEmployee.createEm(userNamegTBox.Text, pwsGTxb.Text, emailGTBox.Text, Convert.ToInt32(idManagerTXT.Text));
                }
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
                idManagerTXT?.Clear();
                pwsGTxb.Clear();
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.LogError($"Loi khi dang ky: {ex}", ex);
            }
        }
        private async Task userSignUp()
        {
            try
            {
                bool create = await _serUser.createUser(userNamegTBox.Text, pwsGTxb.Text, emailGTBox.Text);
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

        private void LayoutGPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void typeOfACCgCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((typeOfACCgCB.SelectedItem?.ToString() == "Admin") || (typeOfACCgCB.SelectedItem?.ToString() =="User"))
            {
                idManagerTXT.Enabled = false;
            }
            else
            {
                idManagerTXT.Enabled = true;
            }
        }
    }
}
