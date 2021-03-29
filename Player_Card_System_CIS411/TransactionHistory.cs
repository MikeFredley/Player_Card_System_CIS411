using System;
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
        public TransactionHistory(int pID, EditAccount pEditAccount)
        {
            ID = pID;
            InitializeComponent();
            InitializeDataGridView();
            editAccount = pEditAccount;
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
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));

            foreach (Transaction trans in Database.Transaction)
            {
                if (trans.ResidentID == ID)
                {
                    dt.Rows.Add(trans.DateTime, trans.TypeTrans, trans.TotalRounds, trans.EmailedTo, trans.EmployeeID, trans.ResidentID, trans.Comments);
                }
            }

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
        }

        private void dgvTransactionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(e.RowIndex.ToString());
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactionHistory.SelectedRows)
            {
                Console.WriteLine(row.Index.ToString());
            }
        }
    }
}
