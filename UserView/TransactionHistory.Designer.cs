namespace iBanking.UserView
{
    partial class TransactionHistory
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
            pnlTransaction = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnlTransaction
            // 
            pnlTransaction.AutoScroll = true;
            pnlTransaction.Dock = DockStyle.Fill;
            pnlTransaction.Location = new Point(0, 0);
            pnlTransaction.Name = "pnlTransaction";
            pnlTransaction.Size = new Size(800, 450);
            pnlTransaction.TabIndex = 0;
            pnlTransaction.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            pnlTransaction.Paint += pnlTransaction_Paint;
            // 
            // TransactionHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlTransaction);
            Name = "TransactionHistory";
            Text = "History";
            Load += History_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlTransaction;
    }
}