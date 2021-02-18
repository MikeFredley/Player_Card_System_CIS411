
namespace Player_Card_System_CIS411
{
    partial class EmployeeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeWindow));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pcbExampleGraph = new System.Windows.Forms.PictureBox();
            this.btnEditTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExampleGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(696, 46);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(86, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(309, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 32);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Search Account:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hello";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Employee Name";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(9, 79);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(777, 328);
            this.dataGridView2.TabIndex = 23;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(481, 46);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(103, 23);
            this.btnAddAccount.TabIndex = 24;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Admin";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pcbExampleGraph
            // 
            this.pcbExampleGraph.Image = ((System.Drawing.Image)(resources.GetObject("pcbExampleGraph.Image")));
            this.pcbExampleGraph.Location = new System.Drawing.Point(9, 79);
            this.pcbExampleGraph.Name = "pcbExampleGraph";
            this.pcbExampleGraph.Size = new System.Drawing.Size(563, 227);
            this.pcbExampleGraph.TabIndex = 26;
            this.pcbExampleGraph.TabStop = false;
            // 
            // btnEditTest
            // 
            this.btnEditTest.Location = new System.Drawing.Point(309, 12);
            this.btnEditTest.Name = "btnEditTest";
            this.btnEditTest.Size = new System.Drawing.Size(75, 23);
            this.btnEditTest.TabIndex = 27;
            this.btnEditTest.Text = "Edit Test";
            this.btnEditTest.UseVisualStyleBackColor = true;
            this.btnEditTest.Click += new System.EventHandler(this.btnEditTest_Click);
            // 
            // EmployeeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 408);
            this.Controls.Add(this.btnEditTest);
            this.Controls.Add(this.pcbExampleGraph);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Name = "EmployeeWindow";
            this.Text = "Employee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeWindow_FormClosing);
            this.Load += new System.EventHandler(this.Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExampleGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pcbExampleGraph;
        private System.Windows.Forms.Button btnEditTest;
    }
}