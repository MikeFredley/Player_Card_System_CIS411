namespace Player_Card_System_CIS411
{
    partial class AdjustBalance
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
            this.lblRounds = new System.Windows.Forms.Label();
            this.btnSubtractRounds = new System.Windows.Forms.Button();
            this.btnAddRounds = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtNumRounds = new System.Windows.Forms.NumericUpDown();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRounds
            // 
            this.lblRounds.AutoSize = true;
            this.lblRounds.Location = new System.Drawing.Point(166, 13);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(13, 13);
            this.lblRounds.TabIndex = 31;
            this.lblRounds.Text = "0";
            // 
            // btnSubtractRounds
            // 
            this.btnSubtractRounds.Location = new System.Drawing.Point(125, 150);
            this.btnSubtractRounds.Name = "btnSubtractRounds";
            this.btnSubtractRounds.Size = new System.Drawing.Size(101, 23);
            this.btnSubtractRounds.TabIndex = 30;
            this.btnSubtractRounds.Text = "Subtract Rounds";
            this.btnSubtractRounds.UseVisualStyleBackColor = true;
            this.btnSubtractRounds.Click += new System.EventHandler(this.btnSubtractRounds_Click);
            // 
            // btnAddRounds
            // 
            this.btnAddRounds.Location = new System.Drawing.Point(15, 150);
            this.btnAddRounds.Name = "btnAddRounds";
            this.btnAddRounds.Size = new System.Drawing.Size(101, 23);
            this.btnAddRounds.TabIndex = 29;
            this.btnAddRounds.Text = "Add Rounds";
            this.btnAddRounds.UseVisualStyleBackColor = true;
            this.btnAddRounds.Click += new System.EventHandler(this.btnAddRounds_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(169, 121);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(167, 20);
            this.txtReason.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Reason:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(235, 150);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 23);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtNumRounds
            // 
            this.txtNumRounds.Location = new System.Drawing.Point(169, 48);
            this.txtNumRounds.Name = "txtNumRounds";
            this.txtNumRounds.Size = new System.Drawing.Size(41, 20);
            this.txtNumRounds.TabIndex = 25;
            this.txtNumRounds.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.txtNumRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(169, 84);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(167, 21);
            this.cmbEmployee.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Transaction Employee: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Number of Rounds: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Current Rounds Avalible:";
            // 
            // AdjustBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 187);
            this.Controls.Add(this.lblRounds);
            this.Controls.Add(this.btnSubtractRounds);
            this.Controls.Add(this.btnAddRounds);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtNumRounds);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AdjustBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjust Balance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdjustBalance_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRounds;
        private System.Windows.Forms.Button btnSubtractRounds;
        private System.Windows.Forms.Button btnAddRounds;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown txtNumRounds;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}