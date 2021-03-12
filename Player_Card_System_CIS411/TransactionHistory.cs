﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player_Card_System_CIS411
{
    public partial class TransactionHistory : Form
    {
        DataTable dt;
        int ID;
        public TransactionHistory(int pID)
        {
            ID = pID;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Transaction Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Emailed", typeof(string)));
            dt.Columns.Add(new DataColumn("Employee ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Resident ID", typeof(int)));

            for (int i = 0; i < Database.Transaction.Count; i++)
            {
                if (Database.Transaction[i].ResidentID == ID)
                {
                    dt.Rows.Add(Database.Transaction[i].DateTime, Database.Transaction[i].TypeTrans, Database.Transaction[i].TotalRounds, Database.Transaction[i].NoEmail,
                    Database.Transaction[i].EmployeeID, Database.Transaction[i].ResidentID);
                }          
            }

            dgvTransactionHistory.DataSource = dt;
            dgvTransactionHistory.ReadOnly = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}