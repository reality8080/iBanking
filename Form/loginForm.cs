using iBanking.Form;
using iBanking.Interfaces.Ser;

//using iBanking.Interfaces.Ser;
//using iBanking.Service;
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

namespace iBanking
    //Tiep tuc thuc hien DI, goi ham cho form dang nhap
{
    public partial class loginForm : System.Windows.Forms.Form
    {


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly IServiceProvider _serviceProvider;
        private readonly ISerUser _serUser;
        private readonly ILogger<loginForm> _logger;
        public loginForm(IServiceProvider _serviceProvider, ISerUser _serUser, ILogger<loginForm> _logger)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._serUser = _serUser ?? throw new ArgumentNullException(nameof(_serUser));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void loginGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(userNamegTBox.Text) || string.IsNullOrEmpty(passGTxb.Text))
                {
                    _logger.LogWarning("Khong duoc de trong tai khoan hoac mat khau");
                    MessageBox.Show("Khong duoc de trong tai khoan hoac mat khau");
                    return;
                }
                bool check = await _serUser.CheckPass(userNamegTBox.Text, passGTxb.Text);
                if (!check)
                {
                    _logger.LogWarning("Dang nhap that bai");
                    MessageBox.Show("Dang nhap that bai");

                    return;
                }

                _logger.LogInformation("Dang nhap thanh cong");

                var form1 = _serviceProvider.GetService<mainForm>();

                if (form1 != null)
                {
                    this.Hide();
                    _serviceProvider.GetService<mainForm>()?.Show();
                }
                else
                {
                    _logger.LogWarning("Dang nhap that bai, loi tuyen tai");
                    MessageBox.Show("Dang nhap that bai, loi truyen tai");

                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return;
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitGIBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void layoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, (IntPtr)0X2, IntPtr.Zero);
            }
        }

        private void exitGBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forgetPWDLLB_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var fogotpassForm = _serviceProvider.GetService<ForgotPass>();
            if (fogotpassForm != null)
            {
                fogotpassForm.FormClosed += (s, args) => this.Show();
                fogotpassForm.Show();
            }
            else
            {
                _logger.LogWarning("Form quen mat khau khong ton tai");
                MessageBox.Show("Form quen mat khau khong ton tai");
            }
        }

        private void noAccountLLB_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var signUpForm = _serviceProvider.GetService<SignUp>();
            if (signUpForm != null)
            {
                signUpForm.FormClosed += (s, args) => this.Show();
                signUpForm.Show();
            }
            else
            {
                _logger.LogWarning("Form dang ky khong ton tai");
                MessageBox.Show("Form dang ky khong ton tai");
            }
        }

        private void passGTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == (char)Keys.Enter)
            //{
            //    loginGBtn_Click(sender, e);
            //}
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !(e.KeyChar == '_'))
            {
                e.Handled = true;
            }
        }

        private void userNamegTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !(e.KeyChar == '_'))
            {
                e.Handled = true;
            }
        }
    }
}
