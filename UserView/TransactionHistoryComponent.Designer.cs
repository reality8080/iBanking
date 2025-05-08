namespace iBanking.UserView
{
    partial class TransactionHistoryComponent
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
            pnlTransaction = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnlTransaction
            // 
            pnlTransaction.AutoScroll = true;
            pnlTransaction.BackColor = Color.FromArgb(240, 240, 240);
            pnlTransaction.Dock = DockStyle.Fill;
            pnlTransaction.Location = new Point(0, 0);
            pnlTransaction.Name = "pnlTransaction";
            pnlTransaction.Size = new Size(993, 674);
            pnlTransaction.TabIndex = 1;
            pnlTransaction.Paint += pnlTransaction_Paint;
            // 
            // TransactionHistoryComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlTransaction);
            Name = "TransactionHistoryComponent";
            Size = new Size(993, 674);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlTransaction;
    }
}
