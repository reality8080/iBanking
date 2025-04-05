using iBanking.Form;
using iBanking.Interfaces.Ser;
using iBanking.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking
    //Tiep tuc thuc hien DI, goi ham cho form dang nhap
{
    public partial class loginForm : System.Windows.Forms.Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISerUserAuth _auth;
        private readonly ILogger<loginForm> _logger;
        public loginForm(IServiceProvider _serviceProvider, ISerUserAuth auth, ILogger<loginForm> _logger)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
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
                bool check = await _auth.CheckPass(userNamegTBox.Text, pwdGTBox.Text);
                if (!check)
                {
                    _logger.LogWarning("Khong dang nhap duoc");
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
                    _logger.LogWarning("Form 1 co loi");
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

        private void noAccountLLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var signUpForm = _serviceProvider.GetService<SignUp>();
            if (signUpForm != null)
            {
                signUpForm.Show();
            }
            else
            {
                _logger.LogWarning("Form dang ky khong ton tai");
            }
        }
    }
}
