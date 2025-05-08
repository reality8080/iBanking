using iBanking.Form;
using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Manager;
using iBanking.NewModels;
using iBanking.UserView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly ISerEmployee _serEmployee;
        private readonly ILogger<loginForm> _logger;
        private readonly IRepoUser _repoUser;
        private readonly IRepoEmployee _repoEmployee;
        public loginForm(IServiceProvider _serviceProvider, ISerUser _serUser, ISerEmployee _serEmployee, ILogger<loginForm> _logger, IRepoUser _repoUser, IRepoEmployee repoEmployee)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._serUser = _serUser ?? throw new ArgumentNullException(nameof(_serUser));
            this._serEmployee = _serEmployee ?? throw new ArgumentNullException(nameof(_serEmployee));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            this._repoUser = _repoUser ?? throw new ArgumentNullException(nameof(_repoUser));
            _repoEmployee = repoEmployee??throw new ArgumentNullException(nameof(repoEmployee));
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void loginGBtn_Click(object sender, EventArgs e)
        {
            if (typeOfACCgCB.Text == "User")
            {
                await userLogin();
            }
            else if(typeOfACCgCB.Text == "Employee")
            {
                await employeeLogin();
            }
            else
            {
                await managerLogin();
            }
            typeOfACCgCB.Text = string.Empty;
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
        private async Task employeeLogin()
        {
            if (string.IsNullOrEmpty(idgTBox.Text) || string.IsNullOrEmpty(passGTxb.Text))
            {
                _logger.LogWarning("Khong duoc de trong tai khoan hoac mat khau");
                MessageBox.Show("Khong duoc de trong tai khoan hoac mat khau");
                return;
            }
            
            try
            {
                bool check = await _serEmployee.CheckPass(idgTBox.Text, passGTxb.Text);
                if (!check)
                {
                    _logger.LogWarning("Dang nhap that bai");
                    MessageBox.Show("Dang nhap that bai");

                    return;
                }

                _logger.LogInformation("Dang nhap thanh cong");

                //var form1 = _serviceProvider.GetService<mainForm>();
                Employee e = await _repoEmployee.readEmployeeById(Convert.ToInt32(idgTBox.Text));
                var f1 = _serviceProvider.GetRequiredService<CashierHome>();

                if (f1 != null)
                {
                    this.Hide();
                    //_serviceProvider.GetService<mainForm>()?.Show();
                    f1.Show();

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
        private async Task userLogin()
        {
            try
            {
                if (string.IsNullOrEmpty(idgTBox.Text) || string.IsNullOrEmpty(passGTxb.Text))
                {
                    _logger.LogWarning("Khong duoc de trong tai khoan hoac mat khau");
                    MessageBox.Show("Khong duoc de trong tai khoan hoac mat khau");
                    return;
                }

                bool check = await _serUser.CheckPass(idgTBox.Text, passGTxb.Text);
                if (!check)
                {
                    _logger.LogWarning("Dang nhap that bai");
                    MessageBox.Show("Dang nhap that bai");

                    return;
                }

                _logger.LogInformation("Dang nhap thanh cong");
                User user = await _repoUser.readUserById(Convert.ToInt32( idgTBox.Text));


                var form1 = new Home(user, _serviceProvider);

                // Chạy ứng dụng với form

                if (form1 != null)
                {
                    this.Hide();
                    //_serviceProvider.GetService<Home>()?.Show();
                    form1.Show();
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

        private async Task managerLogin()
        {
            try
            {
                if (string.IsNullOrEmpty(idgTBox.Text) || string.IsNullOrEmpty(passGTxb.Text))
                {
                    _logger.LogWarning("Khong duoc de trong tai khoan hoac mat khau");
                    MessageBox.Show("Khong duoc de trong tai khoan hoac mat khau");
                    return;
                }

                bool check = await _serUser.CheckPass(idgTBox.Text, passGTxb.Text);
                if (!check)
                {
                    _logger.LogWarning("Dang nhap that bai");
                    MessageBox.Show("Dang nhap that bai");

                    return;
                }

                _logger.LogInformation("Dang nhap thanh cong");
                //Employee e = await _repoEmployee.readEmployeeById(Convert.ToInt32(idgTBox.Text));

                var mform = new ManageHome(Convert.ToInt32(idgTBox.Text)); 

                // Chạy ứng dụng với form

                if (mform != null)
                {
                    this.Hide();
                    //_serviceProvider.GetService<Home>()?.Show();
                    mform.Show();
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
    }
}
