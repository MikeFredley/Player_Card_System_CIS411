namespace Player_Card_System_CIS411
{
    partial class ViewGolfRounds
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
            this.dgvViewRounds = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddDeal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewRounds
            // 
            this.dgvViewRounds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewRounds.Location = new System.Drawing.Point(12, 12);
            this.dgvViewRounds.Name = "dgvViewRounds";
            this.dgvViewRounds.Size = new System.Drawing.Size(573, 215);
            this.dgvViewRounds.TabIndex = 1;
            this.dgvViewRounds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewRounds_CellClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(249, 233);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(115, 29);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove Deal";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(470, 233);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 29);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddDeal
            // 
            this.btnAddDeal.Location = new System.Drawing.Point(12, 233);
            this.btnAddDeal.Name = "btnAddDeal";
            this.btnAddDeal.Size = new System.Drawing.Size(115, 29);
            this.btnAddDeal.TabIndex = 6;
            this.btnAddDeal.Text = "Add New Deal";
            this.btnAddDeal.UseVisualStyleBackColor = true;
            this.btnAddDeal.Click += new System.EventHandler(this.btnAddDeal_Click);
            // 
            // ViewGolfRounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 274);
            this.Controls.Add(this.btnAddDeal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvViewRounds);
            this.Name = "ViewGolfRounds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Golf Rounds";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewRounds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewRounds;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddDeal;
    }
}