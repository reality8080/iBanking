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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking
{
    public partial class CashierHome : System.Windows.Forms.Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISerUser _serUser;
        private readonly ISerEmployee _serEmployee;
        private readonly ILogger<loginForm> _logger;
        private readonly IRepoUser _repoUser;
        private readonly IRepoEmployee _repoEmployee;
        private readonly int employeeId;
        public CashierHome(IServiceProvider _serviceProvider, ISerUser _serUser, ISerEmployee _serEmployee, ILogger<loginForm> _logger, IRepoUser _repoUser, IRepoEmployee _repoEmployee,int employeeId)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider;
            this._serUser = _serUser;
            this._serEmployee = _serEmployee;
            this._logger = _logger;
            this._repoUser = _repoUser;
            this._repoEmployee = _repoEmployee;
            this.employeeId = employeeId;
        }

        private void btnMoCa_Click(object sender, EventArgs e)
        {
            CashierOpenShift cashierOpenShift = new CashierOpenShift(employeeId);
            OpenChildForm(cashierOpenShift);
        }

        private void btnDongCa_Click(object sender, EventArgs e)
        {
            CashierCloseShift cashierCloseShift = new CashierCloseShift(employeeId);
            OpenChildForm(cashierCloseShift);
        }

        private void btnNopTien_Click(object sender, EventArgs e)
        {
            CashierNopTien cashierNopTien = new CashierNopTien(employeeId);
            OpenChildForm(cashierNopTien);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            CashierInfo cashierInfo = new CashierInfo(employeeId); //dang gia su la employeeId
            OpenChildForm(cashierInfo);
        }

        private void btnDoiMk_Click(object sender, EventArgs e)
        {
            CashierChangePass cashierChangePass = new CashierChangePass(employeeId); //dang gia su la employeeId
            OpenChildForm(cashierChangePass);
        }
        private System.Windows.Forms.Form currentFormChild;
        private void OpenChildForm(System.Windows.Forms.Form childForm)
        {
            if (childForm == null) throw new ArgumentNullException(nameof(childForm));

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Guna2_PanelBody.Controls.Add(childForm);
            Guna2_PanelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var login = new loginForm(_serviceProvider,_serUser,_serEmployee,_logger,_repoUser,_repoEmployee);
            this.Hide();
            if (login != null)
            {
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
            else
            {
                //_logger.LogWarning("Login form could not be created.");
                MessageBox.Show("Login form could not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
