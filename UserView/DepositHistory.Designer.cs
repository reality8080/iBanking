namespace iBanking.UserView
{
    partial class DepositHistory
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
            pnlDeposit = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnlDeposit
            // 
            pnlDeposit.AutoScroll = true;
            pnlDeposit.Dock = DockStyle.Fill;
            pnlDeposit.Location = new Point(0, 0);
            pnlDeposit.Name = "pnlDeposit";
            pnlDeposit.Size = new Size(800, 450);
            pnlDeposit.TabIndex = 0;
            pnlDeposit.Paint += pnlDeposit_Paint;
            // 
            // DepositHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlDeposit);
            Name = "DepositHistory";
            Text = "DepositHistory";
            Load += DepositHistory_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlDeposit;
    }
}