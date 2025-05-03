using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking.Form
{
    public partial class ForgotPass : System.Windows.Forms.Form
    {
        private readonly IServiceProvider _serviceProvider;
        //private readonly OtpUControl _otpUControl;
        private readonly ILogger<ForgotPass> _logger;
        private readonly ISerUser _serUser;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //, IRepoUserAuth repoUserAuth
        public ForgotPass(IServiceProvider _serviceProvider, ISerUser _serUser,ILogger<ForgotPass> logger)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._serUser = _serUser ?? throw new ArgumentNullException(nameof(_serUser));
            //this._repoUserAuth = repoUserAuth ?? throw new ArgumentNullException(nameof(repoUserAuth));
            otpPanel.Visible = false;
            //this._otpUControl = _otpUControl ?? throw new ArgumentNullException(nameof(_otpUControl));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private void exitGIBtn_Click(object sender, EventArgs e)
        {
            this._logger.LogInformation("Exit application");
            Application.Exit();
        }

        private void exitGBtn_Click(object sender, EventArgs e)
        {
            this._logger.LogInformation("Exit application");
            this.Close();
        }

        private void layoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        private void addUserControl(UserControl uc)
        {
            otpPanel.Visible = true;
            uc.Dock = DockStyle.Fill;
            otpPanel.Controls.Clear();
            otpPanel.Controls.Add(uc);
            uc.BringToFront();
            //uc.Show();
            //otpPanel.BringToFront();
        }

        private async void takeOTPCodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var Check = await _serUser.CheckEmailAndUserName(userNamegTBox.Text, gmailGTxb.Text);
                if (Check != null)
                {
                    var otpCode = _serUser.randomNumBAcc();

                    //_otpUControl = _serviceProvider.GetRequiredService<OtpUControl>();
                    var otpControl = new OtpUControl(_serviceProvider, Check, otpCode);
                    addUserControl(otpControl);
                    //MessageBox.Show($"OTP code: {otpCode}");

                }
                else
                {
                    MessageBox.Show("Invalid username or email");
                    _logger.LogWarning("Invalid username or email");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error taking OTP code");
                MessageBox.Show(ex.Message);
            }
        }

        private void userNamegTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !(e.KeyChar == '_'))
            {
                e.Handled = true;
            }
        }

        private void gmailGTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !(e.KeyChar == '@') && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}
