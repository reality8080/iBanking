namespace iBanking.UserView
{
    partial class ConfirmByPasswordComponent
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
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            lblPass = new Label();
            lblAnnounce = new Label();
            SuspendLayout();
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 12;
            guna2Button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(28, 85, 208);
            guna2Button1.Font = new Font("STHupo", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 134);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(78, 395);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(776, 49);
            guna2Button1.TabIndex = 6;
            guna2Button1.Text = "SUBMIT";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // txtPass
            // 
            txtPass.BorderRadius = 30;
            txtPass.CustomizableEdges = customizableEdges3;
            txtPass.DefaultText = "";
            txtPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPass.Font = new Font("Segoe UI", 9F);
            txtPass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPass.Location = new Point(78, 295);
            txtPass.Margin = new Padding(3, 4, 3, 4);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.PlaceholderText = "";
            txtPass.SelectedText = "";
            txtPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPass.Size = new Size(776, 60);
            txtPass.TabIndex = 5;
            // 
            // lblPass
            // 
            lblPass.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.ForeColor = Color.FromArgb(70, 106, 233);
            lblPass.Location = new Point(78, 247);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(776, 44);
            lblPass.TabIndex = 7;
            lblPass.Text = "Nhập mật khẩu để xác nhận chuyển khoản";
            // 
            // lblAnnounce
            // 
            lblAnnounce.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAnnounce.ForeColor = Color.Red;
            lblAnnounce.Location = new Point(78, 359);
            lblAnnounce.Name = "lblAnnounce";
            lblAnnounce.Size = new Size(776, 33);
            lblAnnounce.TabIndex = 7;
            // 
            // ConfirmByPasswordComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAnnounce);
            Controls.Add(lblPass);
            Controls.Add(guna2Button1);
            Controls.Add(txtPass);
            Name = "ConfirmByPasswordComponent";
            Size = new Size(933, 674);
            Load += ConfirmByPasswordComponent_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
        private Label lblPass;
        private Label lblAnnounce;
    }
}
