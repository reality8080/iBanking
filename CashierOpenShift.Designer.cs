namespace iBanking
{
    partial class CashierOpenShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierOpenShift));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            dgvTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            lblCashier = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // btnXacNhan
            // 
            btnXacNhan.CustomizableEdges = customizableEdges1;
            btnXacNhan.DisabledState.BorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXacNhan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXacNhan.FillColor = Color.SeaGreen;
            btnXacNhan.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Image = (Image)resources.GetObject("btnXacNhan.Image");
            btnXacNhan.ImageSize = new Size(30, 30);
            btnXacNhan.Location = new Point(868, 440);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnXacNhan.Size = new Size(225, 56);
            btnXacNhan.TabIndex = 0;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // dgvTransactions
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.ColumnHeadersHeight = 4;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactions.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.Location = new Point(225, 183);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(868, 206);
            dgvTransactions.TabIndex = 1;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvTransactions.ThemeStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvTransactions.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactions.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTransactions.ThemeStyle.HeaderStyle.Height = 4;
            dgvTransactions.ThemeStyle.ReadOnly = false;
            dgvTransactions.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvTransactions.ThemeStyle.RowsStyle.Height = 29;
            dgvTransactions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTransactions.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // lblCashier
            // 
            lblCashier.BackColor = Color.Transparent;
            lblCashier.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCashier.Location = new Point(105, 43);
            lblCashier.Name = "lblCashier";
            lblCashier.Size = new Size(93, 32);
            lblCashier.TabIndex = 2;
            lblCashier.Text = "Xin Chào";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(225, 131);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(358, 32);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "Các giao dịch đã thực hiện hôm nay";
            // 
            // CashierOpenShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1507, 906);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(lblCashier);
            Controls.Add(dgvTransactions);
            Controls.Add(btnXacNhan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CashierOpenShift";
            Text = "CashierOpenShift";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCashier;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}