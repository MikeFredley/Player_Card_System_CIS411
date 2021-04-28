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
    public partial class AddRounds : Form
    {
        DataTable dt;
        Transaction newTransaction;
        int currentRounds, ID, newRounds;
        string email;
        bool noEmail;
        EditAccount editAccount;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public AddRounds(int pCurrentRounds, int pID, string pEmail, bool pNoEmail, EditAccount pEditAccount)
        {
            currentRounds = pCurrentRounds;
            ID = pID;
            editAccount = pEditAccount;
            email = pEmail;
            noEmail = pNoEmail;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void AddRounds_FormClosing(object sender, FormClosingEventArgs e)
        {
            editAccount.OpenWindow = false;
            editAccount.SetExitButton(true);
            editAccount.SetEditButton(true);
        }

        // Adds the golf rounds to the datagridview
        private void InitializeDataGridView()
        {
            decimal costPerRound;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year", typeof(string)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Package Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost Per Round", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Total Cost", typeof(decimal)));

            DataGridViewButtonColumn addRoundsButton = new DataGridViewButtonColumn();
            addRoundsButton.HeaderText = "Add Rounds";
            addRoundsButton.Name = "btnAddRounds";
            addRoundsButton.Text = "Add Rounds";
            addRoundsButton.UseColumnTextForButtonValue = true;

            for (int i = 0; i < Database.GolfRounds.Count; i++)
            {
                costPerRound = Database.GolfRounds[i].TotalCost / Database.GolfRounds[i].TotalRounds;
                dt.Rows.Add(Database.GolfRounds[i].Year, Database.GolfRounds[i].TotalRounds, Database.GolfRounds[i].PackageType, costPerRound, Database.GolfRounds[i].TotalCost);
            }

            dgvAddRounds.DataSource = dt;
            dgvAddRounds.Columns.Add(addRoundsButton);
            dgvAddRounds.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAddRounds.Columns[3].DefaultCellStyle.Format = "c";
            dgvAddRounds.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAddRounds.Columns[4].DefaultCellStyle.Format = "c";
            dgvAddRounds.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAddRounds.ReadOnly = true;
        }

        private void dgvAddRounds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    // If the button is clicked it creates a new transaction object
                    // and adds it to the transaction table
                    newRounds = currentRounds + Database.GolfRounds[e.RowIndex].TotalRounds;
                    newTransaction = new Transaction("Purchased", Database.GolfRounds[e.RowIndex].TotalRounds, currentRounds, newRounds, email, Database.LoggedInEmployee.ID, ID, " ");
                    
                    if (noEmail)
                    {
                        Email.SendEmail(newTransaction, Database.ResidentTransactions(ID));
                    }

                    Database.SubmitTransaction(newTransaction);
                    editAccount.EditWindowRefresh(ID);
                    this.Close();
                   // MessageBox.Show("Rounds Added");
                }
            }
       
        }
    }
}
