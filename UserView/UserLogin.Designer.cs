namespace iBanking.UserView
{
    partial class UserLogin
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

        #region Windows Form Designer generated code

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
            lblID = new Krypton.Toolkit.KryptonLabel();
            txtID = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Krypton.Toolkit.KryptonLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = false;
            lblID.Location = new Point(12, 12);
            lblID.Name = "lblID";
            lblID.Size = new Size(776, 24);
            lblID.TabIndex = 0;
            lblID.Values.Text = "Số tài khoản";
            // 
            // txtID
            // 
            txtID.CustomizableEdges = customizableEdges1;
            txtID.DefaultText = "";
            txtID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Font = new Font("Segoe UI", 9F);
            txtID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Location = new Point(12, 43);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.PlaceholderText = "";
            txtID.SelectedText = "";
            txtID.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtID.Size = new Size(776, 60);
            txtID.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = false;
            lblPassword.Location = new Point(12, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(776, 24);
            lblPassword.TabIndex = 0;
            lblPassword.Values.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(12, 141);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(776, 60);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(12, 208);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(776, 49);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 271);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtID);
            Controls.Add(lblPassword);
            Controls.Add(lblID);
            Name = "UserLogin";
            Text = "UserLogin";
            Load += UserLogin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblID;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Krypton.Toolkit.KryptonLabel lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
    }
}