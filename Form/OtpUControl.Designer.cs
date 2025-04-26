namespace iBanking.Form
{
    partial class OtpUControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            loginGBtn = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            otpCodeTxt = new Guna.UI2.WinForms.Guna2TextBox();
            otpCodeLB = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // loginGBtn
            // 
            loginGBtn.BorderColor = Color.FromArgb(14, 126, 254);
            loginGBtn.BorderRadius = 5;
            loginGBtn.BorderThickness = 1;
            loginGBtn.CustomizableEdges = customizableEdges1;
            loginGBtn.DisabledState.BorderColor = Color.DarkGray;
            loginGBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            loginGBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            loginGBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            loginGBtn.FillColor = Color.FromArgb(14, 126, 254);
            loginGBtn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            loginGBtn.ForeColor = Color.White;
            loginGBtn.Location = new Point(259, 139);
            loginGBtn.Name = "loginGBtn";
            loginGBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            loginGBtn.Size = new Size(151, 31);
            loginGBtn.TabIndex = 44;
            loginGBtn.Text = "Lấy mật khẩu";
            loginGBtn.Click += loginGBtn_Click;
            // 
            // guna2Panel5
            // 
            guna2Panel5.BackColor = Color.FromArgb(14, 126, 254);
            guna2Panel5.CustomizableEdges = customizableEdges3;
            guna2Panel5.ForeColor = Color.White;
            guna2Panel5.Location = new Point(49, 115);
            guna2Panel5.Name = "guna2Panel5";
            guna2Panel5.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel5.Size = new Size(361, 1);
            guna2Panel5.TabIndex = 42;
            // 
            // otpCodeTxt
            // 
            otpCodeTxt.BorderRadius = 10;
            otpCodeTxt.BorderThickness = 0;
            otpCodeTxt.CustomizableEdges = customizableEdges5;
            otpCodeTxt.DefaultText = "";
            otpCodeTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            otpCodeTxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            otpCodeTxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            otpCodeTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            otpCodeTxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            otpCodeTxt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            otpCodeTxt.ForeColor = Color.FromArgb(102, 112, 133);
            otpCodeTxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            otpCodeTxt.Location = new Point(49, 78);
            otpCodeTxt.Margin = new Padding(4, 5, 4, 5);
            otpCodeTxt.Name = "otpCodeTxt";
            otpCodeTxt.PlaceholderText = "";
            otpCodeTxt.SelectedText = "";
            otpCodeTxt.ShadowDecoration.CustomizableEdges = customizableEdges6;
            otpCodeTxt.Size = new Size(361, 38);
            otpCodeTxt.TabIndex = 43;
            otpCodeTxt.UseSystemPasswordChar = true;
            // 
            // otpCodeLB
            // 
            otpCodeLB.BackColor = Color.Transparent;
            otpCodeLB.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            otpCodeLB.ForeColor = Color.FromArgb(102, 112, 133);
            otpCodeLB.Location = new Point(49, 37);
            otpCodeLB.Name = "otpCodeLB";
            otpCodeLB.Size = new Size(46, 33);
            otpCodeLB.TabIndex = 41;
            otpCodeLB.Text = "OTP";
            // 
            // OtpUControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(loginGBtn);
            Controls.Add(guna2Panel5);
            Controls.Add(otpCodeTxt);
            Controls.Add(otpCodeLB);
            Name = "OtpUControl";
            Size = new Size(464, 233);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button loginGBtn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2TextBox otpCodeTxt;
        private Guna.UI2.WinForms.Guna2HtmlLabel otpCodeLB;
    }
}
