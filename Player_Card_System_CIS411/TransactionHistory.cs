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
        EditAccount editAccount;
        string email;
        public TransactionHistory(int pID, EditAccount pEditAccount, string pEmail)
        {           
            InitializeComponent();
            ID = pID;
            editAccount = pEditAccount;
            email = pEmail;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Transaction Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Transaction Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Old Balance", typeof(int)));
            dt.Columns.Add(new DataColumn("New Balance", typeof(int)));
            dt.Columns.Add(new DataColumn("Emailed", typeof(string)));
            dt.Columns.Add(new DataColumn("Employee Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Resident Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));

            string residentName = "";
            foreach (ResidentInfo res in Database.ResidentInfo)
            {
                if (res.ID == ID)
                {
                    residentName = res.FirstName + " " + res.LastName;
                }
            }

            for (int i = Database.Transaction.Count - 1; i >= 0; i--)
            {
                foreach (EmployeeInfo emp in Database.EmployeeInfo)
                {
                    if (emp.ID == Database.Transaction[i].EmployeeID && ID == Database.Transaction[i].ResidentID)
                    {
                        dt.Rows.Add(Database.Transaction[i].DateTime, Database.Transaction[i].TypeTrans, Database.Transaction[i].RoundsChanged,
                        Database.Transaction[i].OldBalance, Database.Transaction[i].TotalRounds, Database.Transaction[i].EmailedTo,
                        emp.FirstName + " " + emp.LastName, residentName, Database.Transaction[i].Comments);
                    }                   
                }
            } 

          /*  foreach (Transaction trans in Database.ResidentTransactions(ID))
            {
                foreach (EmployeeInfo emp in Database.EmployeeInfo)
                {
                    if (emp.ID == trans.EmployeeID)
                    {
                        dt.Rows.Add(trans.DateTime, trans.TypeTrans, trans.RoundsChanged, trans.TotalRounds, trans.EmailedTo, emp.FirstName + " " + emp.LastName, residentName, trans.Comments);
                    }
                }
                
            } */

            dgvTransactionHistory.DataSource = dt;
            dgvTransactionHistory.ReadOnly = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TransactionHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            editAccount.OpenWindow = false;
            editAccount.SetExitButton(true);
            editAccount.SetEditButton(true);
            editAccount.Visible = true;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Email.EmailTransactionHistory(Database.ResidentTransactions(ID), email);
            MessageBox.Show("Email Sent!");
        }
    }
}
