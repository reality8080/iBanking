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
        public CashierHome()
        {
            InitializeComponent();
        }

        private void btnMoCa_Click(object sender, EventArgs e)
        {
            CashierOpenShift cashierOpenShift = new CashierOpenShift(2);
            OpenChildForm(cashierOpenShift);
        }

        private void btnDongCa_Click(object sender, EventArgs e)
        {
            CashierCloseShift cashierCloseShift = new CashierCloseShift(2);
            OpenChildForm(cashierCloseShift);
        }

        private void btnNopTien_Click(object sender, EventArgs e)
        {
            CashierNopTien cashierNopTien = new CashierNopTien(2);
            OpenChildForm(cashierNopTien);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            CashierInfo cashierInfo = new CashierInfo(2); //dang gia su la 2
            OpenChildForm(cashierInfo);
        }

        private void btnDoiMk_Click(object sender, EventArgs e)
        {
            CashierChangePass cashierChangePass = new CashierChangePass(2); //dang gia su la 2
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
    }
}
