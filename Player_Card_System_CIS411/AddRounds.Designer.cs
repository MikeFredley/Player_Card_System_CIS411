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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRounds));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTransHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.oceanVillagePlayerCardDataSet = new Player_Card_System_CIS411.OceanVillagePlayerCardDataSet();
            this.eMPLOYEEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eMPLOYEETableAdapter = new Player_Card_System_CIS411.OceanVillagePlayerCardDataSetTableAdapters.EMPLOYEETableAdapter();
            this.pERSONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pERSONTableAdapter = new Player_Card_System_CIS411.OceanVillagePlayerCardDataSetTableAdapters.PERSONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oceanVillagePlayerCardDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERSONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(833, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnTransHistory
            // 
            this.btnTransHistory.Location = new System.Drawing.Point(12, 324);
            this.btnTransHistory.Name = "btnTransHistory";
            this.btnTransHistory.Size = new System.Drawing.Size(132, 40);
            this.btnTransHistory.TabIndex = 1;
            this.btnTransHistory.Text = "View Transaction History";
            this.btnTransHistory.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(713, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(132, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(833, 97);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Rounds";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // oceanVillagePlayerCardDataSet
            // 
            this.oceanVillagePlayerCardDataSet.DataSetName = "OceanVillagePlayerCardDataSet";
            this.oceanVillagePlayerCardDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eMPLOYEEBindingSource
            // 
            this.eMPLOYEEBindingSource.DataMember = "EMPLOYEE";
            this.eMPLOYEEBindingSource.DataSource = this.oceanVillagePlayerCardDataSet;
            // 
            // eMPLOYEETableAdapter
            // 
            this.eMPLOYEETableAdapter.ClearBeforeFill = true;
            // 
            // pERSONBindingSource
            // 
            this.pERSONBindingSource.DataMember = "PERSON";
            this.pERSONBindingSource.DataSource = this.oceanVillagePlayerCardDataSet;
            // 
            // pERSONTableAdapter
            // 
            this.pERSONTableAdapter.ClearBeforeFill = true;
            // 
            // AddRounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTransHistory);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AddRounds";
            this.Text = "AddRounds";
            this.Load += new System.EventHandler(this.AddRounds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oceanVillagePlayerCardDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERSONBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTransHistory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private OceanVillagePlayerCardDataSet oceanVillagePlayerCardDataSet;
        private System.Windows.Forms.BindingSource eMPLOYEEBindingSource;
        private OceanVillagePlayerCardDataSetTableAdapters.EMPLOYEETableAdapter eMPLOYEETableAdapter;
        private System.Windows.Forms.BindingSource pERSONBindingSource;
        private OceanVillagePlayerCardDataSetTableAdapters.PERSONTableAdapter pERSONTableAdapter;
    }
}