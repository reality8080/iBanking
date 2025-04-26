using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking.Form
{
    public partial class OtpUControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        //private readonly IRepoUserAuth _repoUserAuth;
        private readonly string _otpCode;
        private readonly UserAuth _userAuth;
        //private Guid _idAU;
        //public OtpUControl()
        //{
        //    InitializeComponent();
        //}

        public OtpUControl(IServiceProvider _serviceProvider, UserAuth _ua, string _otpCode)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._userAuth = _ua ?? throw new ArgumentNullException(nameof(_ua));
            //this._repoUserAuth = _repoUserAuth ?? throw new ArgumentNullException(nameof(_repoUserAuth));
            //this._idAU = _idAU == Guid.Empty ? throw new ArgumentNullException(nameof(_idAU)) : _idAU;
            this._otpCode = _otpCode ?? throw new ArgumentNullException(nameof(_otpCode));
            otpCodeTxt.Text = _otpCode;


        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void loginGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(otpCodeTxt.Text))
                {
                    MessageBox.Show("Please enter OTP code");
                    return;
                }
                if (otpCodeTxt.Text != _otpCode)
                {
                    MessageBox.Show("OTP code is incorrect");
                    return;
                }
                //var ua=_repoUserAuth.GetByIdUser(_idAU);
                MessageBox.Show($"OTP code is correct, please change your password {_userAuth.password}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
