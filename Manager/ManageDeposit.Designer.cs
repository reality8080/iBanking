namespace iBanking.Manager
{
    partial class ManageDeposit
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dateTimePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateTimePickerEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            dataGridViewDeposit = new Guna.UI2.WinForms.Guna2DataGridView();
            lblOld = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeposit).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Checked = true;
            dateTimePickerStart.CustomizableEdges = customizableEdges1;
            dateTimePickerStart.FillColor = Color.FromArgb(34, 52, 119);
            dateTimePickerStart.Font = new Font("Segoe UI", 9F);
            dateTimePickerStart.Format = DateTimePickerFormat.Long;
            dateTimePickerStart.Location = new Point(231, 43);
            dateTimePickerStart.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePickerStart.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dateTimePickerStart.Size = new Size(360, 64);
            dateTimePickerStart.TabIndex = 0;
            dateTimePickerStart.Value = new DateTime(2025, 5, 6, 15, 44, 25, 88);
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Checked = true;
            dateTimePickerEnd.CustomizableEdges = customizableEdges3;
            dateTimePickerEnd.FillColor = Color.FromArgb(34, 52, 119);
            dateTimePickerEnd.Font = new Font("Segoe UI", 9F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Long;
            dateTimePickerEnd.Location = new Point(231, 143);
            dateTimePickerEnd.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateTimePickerEnd.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dateTimePickerEnd.Size = new Size(360, 68);
            dateTimePickerEnd.TabIndex = 1;
            dateTimePickerEnd.Value = new DateTime(2025, 5, 6, 15, 44, 52, 282);
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.RoyalBlue;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(34, 52, 119);
            guna2Button1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(721, 143);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.PressedColor = Color.RoyalBlue;
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(300, 68);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Tìm kiếm";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(360, 217);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 62;
            guna2DataGridView1.Size = new Size(8, 8);
            guna2DataGridView1.TabIndex = 3;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 33;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // dataGridViewDeposit
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewDeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridViewDeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewDeposit.ColumnHeadersHeight = 4;
            dataGridViewDeposit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewDeposit.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewDeposit.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewDeposit.Location = new Point(87, 231);
            dataGridViewDeposit.Name = "dataGridViewDeposit";
            dataGridViewDeposit.RowHeadersVisible = false;
            dataGridViewDeposit.RowHeadersWidth = 62;
            dataGridViewDeposit.Size = new Size(1068, 534);
            dataGridViewDeposit.TabIndex = 4;
            dataGridViewDeposit.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridViewDeposit.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridViewDeposit.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dataGridViewDeposit.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridViewDeposit.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridViewDeposit.ThemeStyle.BackColor = Color.White;
            dataGridViewDeposit.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewDeposit.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewDeposit.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewDeposit.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewDeposit.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridViewDeposit.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewDeposit.ThemeStyle.HeaderStyle.Height = 4;
            dataGridViewDeposit.ThemeStyle.ReadOnly = false;
            dataGridViewDeposit.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridViewDeposit.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDeposit.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewDeposit.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewDeposit.ThemeStyle.RowsStyle.Height = 33;
            dataGridViewDeposit.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewDeposit.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // lblOld
            // 
            lblOld.BackColor = Color.Transparent;
            lblOld.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOld.ForeColor = Color.FromArgb(28, 85, 208);
            lblOld.Location = new Point(87, 43);
            lblOld.Margin = new Padding(4, 0, 4, 0);
            lblOld.Name = "lblOld";
            lblOld.Size = new Size(134, 54);
            lblOld.TabIndex = 19;
            lblOld.Text = "From:";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(28, 85, 208);
            label1.Location = new Point(87, 162);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 54);
            label1.TabIndex = 20;
            label1.Text = "To:";
            // 
            // ManageDeposit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 786);
            Controls.Add(label1);
            Controls.Add(lblOld);
            Controls.Add(dataGridViewDeposit);
            Controls.Add(guna2DataGridView1);
            Controls.Add(guna2Button1);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Name = "ManageDeposit";
            Text = "ManageDeposit";
            Load += ManageDeposit_Load;
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeposit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerEnd;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewDeposit;
        private Label lblOld;
        private Label label1;
    }
}