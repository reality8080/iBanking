
using iBanking.Interfaces.Ser;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace iBanking.Form
{
    public partial class SignUp : System.Windows.Forms.Form
    {
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
                bool create = await _serUserAuth.addUaBaCr(userNamegTBox.Text, pwdGTBox.Text, "Khach Hang");
                if (!create)
                {
                    MessageBox.Show("Khong the tao tai khoan");
                    _logger.LogWarning("Khong the tao tai khoan");
                    return;
                }
                MessageBox.Show("Tao tai khoan thanh cong");
                _logger.LogInformation("Tao tai khoan thanh cong");
                userNamegTBox.Clear();
                pwdGTBox.Clear();
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
            Application.Exit();
        }

        private void exitGIBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
