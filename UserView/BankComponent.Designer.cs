namespace iBanking.UserView
{
    partial class BankComponent
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnBank = new Guna.UI2.WinForms.Guna2Button();
            lblTotal = new Krypton.Toolkit.KryptonLabel();
            lblPayee = new Krypton.Toolkit.KryptonLabel();
            txtContent = new Guna.UI2.WinForms.Guna2TextBox();
            txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            txtPayee = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 95, 247);
            label3.Location = new Point(108, 411);
            label3.Name = "label3";
            label3.Size = new Size(776, 51);
            label3.TabIndex = 21;
            label3.Text = "Nội dung chuyển tiền";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 95, 247);
            label2.Location = new Point(108, 258);
            label2.Name = "label2";
            label2.Size = new Size(776, 51);
            label2.TabIndex = 22;
            label2.Text = "Nhập số tiền cần chuyển";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 95, 247);
            label1.Location = new Point(108, 105);
            label1.Name = "label1";
            label1.Size = new Size(776, 51);
            label1.TabIndex = 23;
            label1.Text = "Chọn số tài khoản bạn muốn chuyển tiền";
            // 
            // btnBank
            // 
            btnBank.BorderRadius = 12;
            btnBank.CustomizableEdges = customizableEdges1;
            btnBank.DisabledState.BorderColor = Color.DarkGray;
            btnBank.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBank.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBank.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBank.FillColor = Color.FromArgb(0, 169, 255);
            btnBank.Font = new Font("STHupo", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnBank.ForeColor = Color.White;
            btnBank.Location = new Point(108, 517);
            btnBank.Name = "btnBank";
            btnBank.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBank.Size = new Size(776, 53);
            btnBank.TabIndex = 20;
            btnBank.Text = "BANK";
            btnBank.Click += btnBank_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = false;
            lblTotal.Location = new Point(108, 364);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(776, 44);
            lblTotal.TabIndex = 18;
            lblTotal.Values.Text = "";
            // 
            // lblPayee
            // 
            lblPayee.AutoSize = false;
            lblPayee.Location = new Point(108, 211);
            lblPayee.Name = "lblPayee";
            lblPayee.Size = new Size(776, 44);
            lblPayee.TabIndex = 19;
            lblPayee.Values.Text = "";
            // 
            // txtContent
            // 
            txtContent.BorderRadius = 20;
            txtContent.CustomizableEdges = customizableEdges3;
            txtContent.DefaultText = "";
            txtContent.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtContent.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtContent.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtContent.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtContent.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContent.Font = new Font("Segoe UI", 9F);
            txtContent.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContent.Location = new Point(108, 466);
            txtContent.Margin = new Padding(3, 4, 3, 4);
            txtContent.Name = "txtContent";
            txtContent.PlaceholderText = "";
            txtContent.SelectedText = "";
            txtContent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtContent.Size = new Size(776, 44);
            txtContent.TabIndex = 15;
            txtContent.TextChanged += txtContent_TextChanged;
            // 
            // txtTotal
            // 
            txtTotal.BorderRadius = 20;
            txtTotal.CustomizableEdges = customizableEdges5;
            txtTotal.DefaultText = "";
            txtTotal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTotal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTotal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTotal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTotal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTotal.Font = new Font("Segoe UI", 9F);
            txtTotal.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTotal.Location = new Point(108, 313);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.PlaceholderText = "Nhập số tiền";
            txtTotal.SelectedText = "";
            txtTotal.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtTotal.Size = new Size(776, 44);
            txtTotal.TabIndex = 16;
            txtTotal.TextChanged += txtTotal_TextChanged;
            // 
            // txtPayee
            // 
            txtPayee.BorderRadius = 20;
            txtPayee.CustomizableEdges = customizableEdges7;
            txtPayee.DefaultText = "";
            txtPayee.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPayee.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPayee.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPayee.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPayee.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayee.Font = new Font("Segoe UI", 9F);
            txtPayee.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayee.Location = new Point(108, 160);
            txtPayee.Margin = new Padding(3, 4, 3, 4);
            txtPayee.Name = "txtPayee";
            txtPayee.PlaceholderText = "Điền số tài khoản vào đây";
            txtPayee.SelectedText = "";
            txtPayee.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPayee.Size = new Size(776, 44);
            txtPayee.TabIndex = 17;
            txtPayee.TextChanged += txtPayee_TextChanged;
            // 
            // BankComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBank);
            Controls.Add(lblTotal);
            Controls.Add(lblPayee);
            Controls.Add(txtContent);
            Controls.Add(txtTotal);
            Controls.Add(txtPayee);
            Name = "BankComponent";
            Size = new Size(993, 674);
            Load += BankComponent_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnBank;
        private Krypton.Toolkit.KryptonLabel lblTotal;
        private Krypton.Toolkit.KryptonLabel lblPayee;
        private Guna.UI2.WinForms.Guna2TextBox txtContent;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private Guna.UI2.WinForms.Guna2TextBox txtPayee;
    }
}
