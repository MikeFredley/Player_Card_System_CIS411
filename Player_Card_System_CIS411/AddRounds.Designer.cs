namespace Player_Card_System_CIS411
{
    partial class AddRounds
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
            this.dgvAddRounds = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddRounds
            // 
            this.dgvAddRounds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddRounds.Location = new System.Drawing.Point(12, 12);
            this.dgvAddRounds.Name = "dgvAddRounds";
            this.dgvAddRounds.Size = new System.Drawing.Size(639, 215);
            this.dgvAddRounds.TabIndex = 0;
            this.dgvAddRounds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddRounds_CellClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(266, 233);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AddRounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 274);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvAddRounds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddRounds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Rounds";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRounds_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddRounds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddRounds;
        private System.Windows.Forms.Button btnExit;
    }
}