namespace Player_Card_System_CIS411
{
    partial class AdminWindow
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
            this.backupBtn = new System.Windows.Forms.Button();
            this.eAccountsBtn = new System.Windows.Forms.Button();
            this.restoreBtn = new System.Windows.Forms.Button();
            this.eTransactionsBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backupBtn
            // 
            this.backupBtn.Location = new System.Drawing.Point(40, 12);
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.Size = new System.Drawing.Size(83, 52);
            this.backupBtn.TabIndex = 0;
            this.backupBtn.Text = "Backup";
            this.backupBtn.UseVisualStyleBackColor = true;
            // 
            // eAccountsBtn
            // 
            this.eAccountsBtn.Location = new System.Drawing.Point(250, 12);
            this.eAccountsBtn.Name = "eAccountsBtn";
            this.eAccountsBtn.Size = new System.Drawing.Size(83, 52);
            this.eAccountsBtn.TabIndex = 0;
            this.eAccountsBtn.Text = "Export Accounts";
            this.eAccountsBtn.UseVisualStyleBackColor = true;
            // 
            // restoreBtn
            // 
            this.restoreBtn.Location = new System.Drawing.Point(40, 88);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(83, 49);
            this.restoreBtn.TabIndex = 0;
            this.restoreBtn.Text = "Restore";
            this.restoreBtn.UseVisualStyleBackColor = true;
            // 
            // eTransactionsBtn
            // 
            this.eTransactionsBtn.Location = new System.Drawing.Point(250, 88);
            this.eTransactionsBtn.Name = "eTransactionsBtn";
            this.eTransactionsBtn.Size = new System.Drawing.Size(83, 49);
            this.eTransactionsBtn.TabIndex = 0;
            this.eTransactionsBtn.Text = "Export Transactions";
            this.eTransactionsBtn.UseVisualStyleBackColor = true;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(145, 12);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(83, 52);
            this.resetBtn.TabIndex = 0;
            this.resetBtn.Text = "Reset Season";
            this.resetBtn.UseVisualStyleBackColor = true;
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 149);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.eTransactionsBtn);
            this.Controls.Add(this.restoreBtn);
            this.Controls.Add(this.eAccountsBtn);
            this.Controls.Add(this.backupBtn);
            this.Name = "AdminWindow";
            this.Text = "AdminWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backupBtn;
        private System.Windows.Forms.Button eAccountsBtn;
        private System.Windows.Forms.Button restoreBtn;
        private System.Windows.Forms.Button eTransactionsBtn;
        private System.Windows.Forms.Button resetBtn;
    }
}