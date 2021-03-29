namespace Player_Card_System_CIS411
{
    partial class EmailTransHistory
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
            this.radMostRecent = new System.Windows.Forms.RadioButton();
            this.radLastFive = new System.Windows.Forms.RadioButton();
            this.radLastMonth = new System.Windows.Forms.RadioButton();
            this.radLastSixMonths = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radMostRecent
            // 
            this.radMostRecent.AutoSize = true;
            this.radMostRecent.Location = new System.Drawing.Point(54, 15);
            this.radMostRecent.Name = "radMostRecent";
            this.radMostRecent.Size = new System.Drawing.Size(145, 17);
            this.radMostRecent.TabIndex = 0;
            this.radMostRecent.TabStop = true;
            this.radMostRecent.Text = "Most Recent Transaction";
            this.radMostRecent.UseVisualStyleBackColor = true;
            // 
            // radLastFive
            // 
            this.radLastFive.AutoSize = true;
            this.radLastFive.Location = new System.Drawing.Point(54, 51);
            this.radLastFive.Name = "radLastFive";
            this.radLastFive.Size = new System.Drawing.Size(132, 17);
            this.radLastFive.TabIndex = 1;
            this.radLastFive.TabStop = true;
            this.radLastFive.Text = "Last Five Transactions";
            this.radLastFive.UseVisualStyleBackColor = true;
            // 
            // radLastMonth
            // 
            this.radLastMonth.AutoSize = true;
            this.radLastMonth.Location = new System.Drawing.Point(54, 91);
            this.radLastMonth.Name = "radLastMonth";
            this.radLastMonth.Size = new System.Drawing.Size(147, 17);
            this.radLastMonth.TabIndex = 2;
            this.radLastMonth.TabStop = true;
            this.radLastMonth.Text = "Last Months Transactions";
            this.radLastMonth.UseVisualStyleBackColor = true;
            // 
            // radLastSixMonths
            // 
            this.radLastSixMonths.AutoSize = true;
            this.radLastSixMonths.Location = new System.Drawing.Point(54, 130);
            this.radLastSixMonths.Name = "radLastSixMonths";
            this.radLastSixMonths.Size = new System.Drawing.Size(164, 17);
            this.radLastSixMonths.TabIndex = 3;
            this.radLastSixMonths.TabStop = true;
            this.radLastSixMonths.Text = "Last Six Months Transactions";
            this.radLastSixMonths.UseVisualStyleBackColor = true;
            // 
            // EmailTransHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 263);
            this.Controls.Add(this.radLastSixMonths);
            this.Controls.Add(this.radLastMonth);
            this.Controls.Add(this.radLastFive);
            this.Controls.Add(this.radMostRecent);
            this.Name = "EmailTransHistory";
            this.Text = "Email Transaction History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radMostRecent;
        private System.Windows.Forms.RadioButton radLastFive;
        private System.Windows.Forms.RadioButton radLastMonth;
        private System.Windows.Forms.RadioButton radLastSixMonths;
    }
}