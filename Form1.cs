using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace iBanking
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
        }

        private void controlPageGunaPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void mainDashGPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void exitGImageBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void minusGIBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void controlLGP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, (IntPtr)0X2, IntPtr.Zero);
            }
        }

        //private void homeGbtn_MouseClick(object sender, MouseEventArgs e)
        //{
        //    homeGbtn.BackColor = Color.FromArgb(14, 126, 254);
        //}
    }
}
