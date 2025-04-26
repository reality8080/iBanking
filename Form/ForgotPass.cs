using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly ISerUserAuth _serUserAuth;
        //private readonly OtpUControl _otpUControl;
        //private readonly IRepoUserAuth _repoUserAuth;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //, IRepoUserAuth repoUserAuth
        public ForgotPass(IServiceProvider _serviceProvider, ISerUserAuth _serUserAuth)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._serUserAuth = _serUserAuth ?? throw new ArgumentNullException(nameof(_serUserAuth));
            //this._repoUserAuth = repoUserAuth ?? throw new ArgumentNullException(nameof(repoUserAuth));
            otpPanel.Visible = false;
            //this._otpUControl = _otpUControl ?? throw new ArgumentNullException(nameof(_otpUControl));
        }

        private void exitGIBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitGBtn_Click(object sender, EventArgs e)
        {
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
                var Check = await _serUserAuth.CheckEmailAndUserName(userNamegTBox.Text, gmailGTxb.Text);
                if (Check!=null)
                {
                    var otpCode = _serUserAuth.randomNumBAcc();

                    //_otpUControl = _serviceProvider.GetRequiredService<OtpUControl>();
                    var otpControl=new OtpUControl(_serviceProvider, Check, otpCode);
                    addUserControl(otpControl);
                    //MessageBox.Show($"OTP code: {otpCode}");

                }
                else
                {
                    MessageBox.Show("Invalid username or email");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
