namespace iBanking.Manager
{
    partial class ManageTransaction
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            comboBoxCashier = new Guna.UI2.WinForms.Guna2ComboBox();
            dateTimePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateTimePickerEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dataGridViewTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            btnSearch = new Guna.UI2.WinForms.Guna2Button();
            lblOld = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCashier
            // 
            comboBoxCashier.BackColor = Color.Transparent;
            comboBoxCashier.CustomizableEdges = customizableEdges1;
            comboBoxCashier.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxCashier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCashier.FocusedColor = Color.FromArgb(94, 148, 255);
            comboBoxCashier.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboBoxCashier.Font = new Font("Segoe UI", 10F);
            comboBoxCashier.ForeColor = Color.FromArgb(68, 88, 112);
            comboBoxCashier.ItemHeight = 30;
            comboBoxCashier.Location = new Point(774, 55);
            comboBoxCashier.Name = "comboBoxCashier";
            comboBoxCashier.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboBoxCashier.Size = new Size(270, 36);
            comboBoxCashier.TabIndex = 0;
            comboBoxCashier.Tag = "CashierId";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Checked = true;
            dateTimePickerStart.CustomizableEdges = customizableEdges3;
            dateTimePickerStart.FillColor = Color.FromArgb(34, 52, 119);
            dateTimePickerStart.Font = new Font("Segoe UI", 9F);
            dateTimePickerStart.Format = DateTimePickerFormat.Long;
            dateTimePickerStart.Location = new Point(171, 37);
            dateTimePickerStart.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePickerStart.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dateTimePickerStart.Size = new Size(317, 71);
            dateTimePickerStart.TabIndex = 1;
            dateTimePickerStart.Value = new DateTime(2025, 5, 6, 16, 38, 37, 125);
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Checked = true;
            dateTimePickerEnd.CustomizableEdges = customizableEdges5;
            dateTimePickerEnd.FillColor = Color.FromArgb(34, 52, 119);
            dateTimePickerEnd.Font = new Font("Segoe UI", 9F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Long;
            dateTimePickerEnd.Location = new Point(171, 163);
            dateTimePickerEnd.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePickerEnd.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dateTimePickerEnd.Size = new Size(317, 61);
            dateTimePickerEnd.TabIndex = 2;
            dateTimePickerEnd.Value = new DateTime(2025, 5, 6, 16, 38, 48, 329);
            // 
            // dataGridViewTransactions
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTransactions.ColumnHeadersHeight = 4;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTransactions.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewTransactions.Location = new Point(54, 267);
            dataGridViewTransactions.Name = "dataGridViewTransactions";
            dataGridViewTransactions.RowHeadersVisible = false;
            dataGridViewTransactions.RowHeadersWidth = 62;
            dataGridViewTransactions.Size = new Size(1054, 457);
            dataGridViewTransactions.TabIndex = 3;
            dataGridViewTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridViewTransactions.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridViewTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dataGridViewTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridViewTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridViewTransactions.ThemeStyle.BackColor = Color.White;
            dataGridViewTransactions.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewTransactions.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewTransactions.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewTransactions.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewTransactions.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridViewTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewTransactions.ThemeStyle.HeaderStyle.Height = 4;
            dataGridViewTransactions.ThemeStyle.ReadOnly = false;
            dataGridViewTransactions.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridViewTransactions.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewTransactions.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewTransactions.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewTransactions.ThemeStyle.RowsStyle.Height = 33;
            dataGridViewTransactions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewTransactions.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnSearch
            // 
            btnSearch.CustomizableEdges = customizableEdges7;
            btnSearch.DisabledState.BorderColor = Color.DarkGray;
            btnSearch.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSearch.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSearch.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSearch.FillColor = Color.FromArgb(34, 52, 119);
            btnSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(774, 163);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSearch.Size = new Size(270, 61);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // lblOld
            // 
            lblOld.BackColor = Color.Transparent;
            lblOld.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOld.ForeColor = Color.FromArgb(28, 85, 208);
            lblOld.Location = new Point(30, 37);
            lblOld.Margin = new Padding(4, 0, 4, 0);
            lblOld.Name = "lblOld";
            lblOld.Size = new Size(134, 54);
            lblOld.TabIndex = 20;
            lblOld.Text = "From:";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(28, 85, 208);
            label1.Location = new Point(30, 163);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 54);
            label1.TabIndex = 21;
            label1.Text = "To:";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(28, 85, 208);
            label2.Location = new Point(554, 37);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(191, 54);
            label2.TabIndex = 22;
            label2.Text = "CashierId";
            // 
            // ManageTransaction
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 786);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblOld);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewTransactions);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(comboBoxCashier);
            Name = "ManageTransaction";
            Text = "ManageTransaction";
            Load += ManageTransaction_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBoxCashier;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerEnd;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewTransactions;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Label lblOld;
        private Label label1;
        private Label label2;
    }
}