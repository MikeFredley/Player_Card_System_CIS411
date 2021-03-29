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
    public partial class ViewGolfRounds : Form
    {
        DataTable dt;
        int rowIndex;
        AdminWindow adminWindow;
        bool openWindow;

        public bool OpenWindow { get => openWindow; set => openWindow = value; }
        public void SetRemoveButton(bool isEnabled) { btnRemove.Enabled = isEnabled; }
        public ViewGolfRounds(AdminWindow pAdminWindow)
        {
            InitializeComponent();
            InitializeDataGridView();
            adminWindow = pAdminWindow;
            openWindow = false;
        }

        private void InitializeDataGridView()
        {
           
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year", typeof(string)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Package Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost Per Round", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Total Cost", typeof(decimal)));

            RefreshDataGridView();

            dgvViewRounds.DataSource = dt;
            dgvViewRounds.ReadOnly = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (GolfRounds round in Database.GolfRounds)
            {
                if (round.Year == dgvViewRounds.Rows[rowIndex].Cells[0].Value.ToString() &&
                    round.TotalRounds == int.Parse(dgvViewRounds.Rows[rowIndex].Cells[1].Value.ToString()) &&
                    round.PackageType == dgvViewRounds.Rows[rowIndex].Cells[2].Value.ToString() &&
                    round.CostPerRound == Convert.ToDecimal(dgvViewRounds.Rows[rowIndex].Cells[3].Value.ToString()))
                {
                    Database.DeleteGolfRounds(round.Year, round.TotalRounds, round.PackageType, round.CostPerRound);
                    break;
                }
            }
            RefreshDataGridView();
            MessageBox.Show("Golf Rounds Deleted");
        }

        private void dgvViewRounds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        public void RefreshDataGridView()
        {
            dt.Clear();
            for (int i = 0; i < Database.GolfRounds.Count; i++)
            {
                decimal totalCost = Database.GolfRounds[i].TotalRounds * Database.GolfRounds[i].CostPerRound;
                dt.Rows.Add(Database.GolfRounds[i].Year, Database.GolfRounds[i].TotalRounds, Database.GolfRounds[i].PackageType, Database.GolfRounds[i].CostPerRound, totalCost);
            }
        }

        private void btnAddDeal_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                btnRemove.Enabled = false;
                AddNewDeals newDeals = new AddNewDeals(this);
                newDeals.Show();
            }           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewGolfRounds_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openWindow)
            {
                adminWindow.OpenWindow = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
