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
        int currentRounds, ID, newRounds, saveIndex;
        EditAccount editAccount;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public AddRounds(int pCurrentRounds, int pID, EditAccount pEditAccount)
        {
            currentRounds = pCurrentRounds;
            ID = pID;
            editAccount = pEditAccount;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            decimal totalCost;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year", typeof(string)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Package Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost Per Round", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Total Cost", typeof(decimal)));

            DataGridViewButtonColumn addRoundsButton = new DataGridViewButtonColumn();
            addRoundsButton.HeaderText = "Add Rounds";
            addRoundsButton.Name = "btnAddRounds";
            addRoundsButton.Text = "Add Rounds";
            addRoundsButton.UseColumnTextForButtonValue = true;

            for (int i = 0; i < Database.GolfRounds.Count; i++)
            {
                totalCost = Database.GolfRounds[i].TotalRounds * Database.GolfRounds[i].CostPerRound;
                dt.Rows.Add(Database.GolfRounds[i].Year, Database.GolfRounds[i].TotalRounds, Database.GolfRounds[i].PackageType, Database.GolfRounds[i].CostPerRound, totalCost);
            }

            dgvAddRounds.DataSource = dt;
            dgvAddRounds.Columns.Add(addRoundsButton);
            dgvAddRounds.ReadOnly = true;
        }

        private void dgvAddRounds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  Console.WriteLine(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    newRounds = currentRounds + Database.GolfRounds[e.RowIndex].TotalRounds;
                    newTransaction = new Transaction("P", "Purchase", newRounds, 101, ID);
                    Database.SubmitTransaction(newTransaction);
                    editAccount.EditWindowRefresh(ID);
                    MessageBox.Show("Rounds Added");
                }
            } 
        }
    }
}
