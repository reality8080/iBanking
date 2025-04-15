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

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public ForgotPass()
        {
            InitializeComponent();
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
    }
}
