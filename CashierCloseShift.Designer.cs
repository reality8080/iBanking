namespace iBanking
{
    partial class CashierCloseShift
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierCloseShift));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblCashier = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtDoanhThu = new Guna.UI2.WinForms.Guna2TextBox();
            btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // lblCashier
            // 
            lblCashier.BackColor = Color.Transparent;
            lblCashier.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCashier.ForeColor = Color.FromArgb(28, 85, 208);
            lblCashier.Location = new Point(70, 12);
            lblCashier.Name = "lblCashier";
            lblCashier.Size = new Size(92, 33);
            lblCashier.TabIndex = 0;
            lblCashier.Text = "Xin chào";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(28, 85, 208);
            guna2HtmlLabel2.Location = new Point(70, 74);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(475, 33);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Thông tin các giao dịch đã thực hiện hôm nay";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
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
            dgvTransactions.Location = new Point(70, 113);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(794, 211);
            dgvTransactions.TabIndex = 2;
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
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.FromArgb(28, 85, 208);
            guna2HtmlLabel3.Location = new Point(70, 343);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(169, 33);
            guna2HtmlLabel3.TabIndex = 3;
            guna2HtmlLabel3.Text = "Tổng doanh thu";
            // 
            // txtDoanhThu
            // 
            txtDoanhThu.BorderRadius = 10;
            txtDoanhThu.CustomizableEdges = customizableEdges1;
            txtDoanhThu.DefaultText = "";
            txtDoanhThu.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDoanhThu.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDoanhThu.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDoanhThu.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDoanhThu.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDoanhThu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDoanhThu.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDoanhThu.Location = new Point(70, 385);
            txtDoanhThu.Margin = new Padding(4, 6, 4, 6);
            txtDoanhThu.Name = "txtDoanhThu";
            txtDoanhThu.PlaceholderText = "";
            txtDoanhThu.SelectedText = "";
            txtDoanhThu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtDoanhThu.Size = new Size(260, 41);
            txtDoanhThu.TabIndex = 4;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Cursor = Cursors.Hand;
            btnXacNhan.CustomizableEdges = customizableEdges3;
            btnXacNhan.DisabledState.BorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXacNhan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXacNhan.FillColor = Color.SteelBlue;
            btnXacNhan.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Image = (Image)resources.GetObject("btnXacNhan.Image");
            btnXacNhan.ImageSize = new Size(25, 25);
            btnXacNhan.Location = new Point(70, 466);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnXacNhan.Size = new Size(794, 56);
            btnXacNhan.TabIndex = 5;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // CashierCloseShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(943, 581);
            Controls.Add(btnXacNhan);
            Controls.Add(txtDoanhThu);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(dgvTransactions);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(lblCashier);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CashierCloseShift";
            Text = "CashierCloseShift";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblCashier;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactions;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txtDoanhThu;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
    }
}