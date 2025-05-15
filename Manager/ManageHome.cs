using iBanking.Form;
using iBanking.NewModels;
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

namespace iBanking.Manager
{
    public partial class ManageHome : System.Windows.Forms.Form
    {
        public readonly IServiceProvider _serviceProvider;
        public readonly ILogger<ManageHome> _logger;
        public int manager;
        public ManageHome(int manager, IServiceProvider _serviceProvider, ILogger<ManageHome> _logger)
        {
            InitializeComponent();
            this.manager = manager;
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));

        }

        private void btnthongtinnv_Click(object sender, EventArgs e)
        {
            ManangeInfoEm manangeInfoEm = new ManangeInfoEm(manager);
            OpenChildForm(manangeInfoEm);

        }

        private void btnthongtinkh_Click(object sender, EventArgs e)
        {
            ManageInfoUser manageInfoUser = new ManageInfoUser();
            OpenChildForm(manageInfoUser);

        }

        private void btndoithongtin_Click(object sender, EventArgs e)
        {
            ManagerInfo managerInfo = new ManagerInfo(manager);
            OpenChildForm(managerInfo);

        }

        private void ManageHome_Load(object sender, EventArgs e)
        {

        }

        private void btndoanhthu_Click(object sender, EventArgs e)
        {
            ManageDeposit managedeposit = new ManageDeposit();
            OpenChildForm(managedeposit);
        }

        private void btngiaodich_Click(object sender, EventArgs e)
        {
            ManageTransaction managetrasaction = new ManageTransaction();
            OpenChildForm(managetrasaction);
        }

        private void btndoipass_Click(object sender, EventArgs e)
        {
            ManagerChangePass managerChangePass = new ManagerChangePass(this.manager);
            OpenChildForm(managerChangePass);
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

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newAccountLLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _logger.LogWarning("Form dang ky bi loi");
                MessageBox.Show("Form dang ky bi loi");
            }
        }
    }
}
