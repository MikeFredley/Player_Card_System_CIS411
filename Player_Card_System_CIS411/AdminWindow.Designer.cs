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
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnExportAccounts = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnExportTransactions = new System.Windows.Forms.Button();
            this.btnResetSeason = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewEmployees = new System.Windows.Forms.Button();
            this.btnNewDeals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(40, 12);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(83, 52);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnExportAccounts
            // 
            this.btnExportAccounts.Location = new System.Drawing.Point(145, 12);
            this.btnExportAccounts.Name = "btnExportAccounts";
            this.btnExportAccounts.Size = new System.Drawing.Size(83, 52);
            this.btnExportAccounts.TabIndex = 0;
            this.btnExportAccounts.Text = "Export Accounts";
            this.btnExportAccounts.UseVisualStyleBackColor = true;
            this.btnExportAccounts.Click += new System.EventHandler(this.btnExportAccounts_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(40, 88);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(83, 49);
            this.btnRestore.TabIndex = 0;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // btnExportTransactions
            // 
            this.btnExportTransactions.Location = new System.Drawing.Point(145, 88);
            this.btnExportTransactions.Name = "btnExportTransactions";
            this.btnExportTransactions.Size = new System.Drawing.Size(83, 49);
            this.btnExportTransactions.TabIndex = 0;
            this.btnExportTransactions.Text = "Export Transactions";
            this.btnExportTransactions.UseVisualStyleBackColor = true;
            this.btnExportTransactions.Click += new System.EventHandler(this.btnExportTransactions_Click);
            // 
            // btnResetSeason
            // 
            this.btnResetSeason.Location = new System.Drawing.Point(250, 12);
            this.btnResetSeason.Name = "btnResetSeason";
            this.btnResetSeason.Size = new System.Drawing.Size(83, 52);
            this.btnResetSeason.TabIndex = 0;
            this.btnResetSeason.Text = "Reset Season";
            this.btnResetSeason.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(250, 163);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 49);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewEmployees
            // 
            this.btnViewEmployees.Location = new System.Drawing.Point(250, 88);
            this.btnViewEmployees.Name = "btnViewEmployees";
            this.btnViewEmployees.Size = new System.Drawing.Size(83, 49);
            this.btnViewEmployees.TabIndex = 2;
            this.btnViewEmployees.Text = "View Employees";
            this.btnViewEmployees.UseVisualStyleBackColor = true;
            this.btnViewEmployees.Click += new System.EventHandler(this.btnViewEmployees_Click);
            // 
            // btnNewDeals
            // 
            this.btnNewDeals.Location = new System.Drawing.Point(40, 163);
            this.btnNewDeals.Name = "btnNewDeals";
            this.btnNewDeals.Size = new System.Drawing.Size(83, 49);
            this.btnNewDeals.TabIndex = 3;
            this.btnNewDeals.Text = "View Golf Deals";
            this.btnNewDeals.UseVisualStyleBackColor = true;
            this.btnNewDeals.Click += new System.EventHandler(this.btnNewDeals_Click);
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 224);
            this.Controls.Add(this.btnNewDeals);
            this.Controls.Add(this.btnViewEmployees);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResetSeason);
            this.Controls.Add(this.btnExportTransactions);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnExportAccounts);
            this.Controls.Add(this.btnBackup);
            this.Name = "AdminWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnExportAccounts;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnExportTransactions;
        private System.Windows.Forms.Button btnResetSeason;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewEmployees;
        private System.Windows.Forms.Button btnNewDeals;
    }
}