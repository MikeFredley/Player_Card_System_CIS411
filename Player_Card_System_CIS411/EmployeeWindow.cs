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
    public partial class EmployeeWindow : Form
    {
        WelcomeWindow welcomeWindow;
        DataTable dt;
        //  Database data;
        public EmployeeWindow(WelcomeWindow welcome)
        {
            InitializeComponent();
            welcomeWindow = welcome;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // data = new Database();
            InitializeDataGridView();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            welcomeWindow.Show();
        }

        private void InitializeDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Cluster", typeof(string)));
            dt.Columns.Add(new DataColumn("Unit Number", typeof(int)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Current Rounds", typeof(string)));

            DataGridViewButtonColumn deductRoundButton = new DataGridViewButtonColumn();
            deductRoundButton.HeaderText = "Deduct Rounds";
            deductRoundButton.Name = "btnDeductRounds";
            deductRoundButton.Text = "Deduct Rounds";
            deductRoundButton.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn editAccountButton = new DataGridViewButtonColumn();
            editAccountButton.HeaderText = "Details";
            editAccountButton.Name = "btnEditAccount";
            editAccountButton.Text = "Details";
            editAccountButton.UseColumnTextForButtonValue = true;

            AddDataGridRows();

            dgvResidentInfo.DataSource = dt;
            dgvResidentInfo.Columns.Add(deductRoundButton);
            dgvResidentInfo.Columns.Add(editAccountButton);
            dgvResidentInfo.ReadOnly = true;
        }

        private void AddDataGridRows()
        {
            for (int i = 0; i < Database.ResidentInfo.Count(); i++)
            {
                dt.Rows.Add(Database.ResidentInfo[i].FirstName, Database.ResidentInfo[i].LastName, Database.ResidentInfo[i].ClusterName, Database.ResidentInfo[i].UnitNumber,
                    Database.ResidentInfo[i].Email, Database.ResidentInfo[i].Phone, Database.ResidentInfo[i].CurrentRounds);
            }
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            // EditAccount editScreen = new EditAccount(true);
            //  editScreen.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            EditAccount addAccount = new EditAccount(false, 0, this);
            addAccount.Show();
        }

        private void btnUseTest_Click(object sender, EventArgs e)
        {
          //  DeductRounds deductRounds = new DeductRounds();
           // deductRounds.Show();
        }

        private void dgvResidentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the deduct rounds button is clicked
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {
                    DeductRounds deductRounds = new DeductRounds(GetIDFromRow(e), this);
                    deductRounds.Show();
                }
            }

            // If the Edit account button is clicked
            if (e.ColumnIndex == 8)
            {
                if (e.RowIndex >= 0)
                {
                    EditAccount editScreen = new EditAccount(true, GetIDFromRow(e), this);
                    editScreen.Show();
                }
            }
        }

        public int GetIDFromRow(DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < Database.ResidentInfo.Count; i++)
            {
                // for each row it takes the first and last name of the row where the button was pressed
                // it then searches through the residentinfo list and matches up the firstnames and last names
                // using those it gets the correct ID for that row, which will be used to pass into the
                // appropriate window
                if (dgvResidentInfo.Rows[e.RowIndex].Cells[0].Value.ToString() == Database.ResidentInfo[i].FirstName &&
                    dgvResidentInfo.Rows[e.RowIndex].Cells[1].Value.ToString() == Database.ResidentInfo[i].LastName)
                {
                    return Database.ResidentInfo[i].ID;
                }
            }
            return 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            // if some jackass doesnt want to hit the shift key then he doesnt have too
            searchText = searchText.ToLower();
            // A list to save the row indices of the items searched in the list
            List<int> saveIndex = new List<int>();
            bool breakForEach = false;

            try
            {
                // Goes through every row in the datagridview
                foreach (DataGridViewRow row in dgvResidentInfo.Rows)
                {
                    row.Selected = false;
                    // It then goes through every column of that row
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        // if its at the last row that is blank it
                        // stops the loop or else it will throw a nullpointer exception
                        if (row.Cells[i].Value == null)
                        {
                            // Breaks the loops if nothing is found
                            if (saveIndex.Count == 0)
                            {
                                breakForEach = true;
                                break;
                            }
                            // Wonky stuff happens if this isn't here when the search finishes
                            // This else statement basically means the search completed succesfully
                            else
                            {
                                //MessageBox.Show("Search Complete");
                                break;
                            }
                        }
                        // Checks each value of every column for that row
                        else if (row.Cells[i].Value.ToString().ToLower().IndexOf(searchText) != -1)
                        {
                            // If it matches what the user entered it selects the row and breaks the loop
                            saveIndex.Add(row.Index);
                            //row.Selected = true;
                            break;
                        }
                    }
                    // If nothing is found it tells you nothing was found and refreshes the grid view
                    if (saveIndex.Count == 0 && breakForEach)
                    {
                        MessageBox.Show("No Items Found");
                        dt.Rows.Clear();
                        AddDataGridRows();
                        break;
                    }
                }

                // Adds the rows that meet the search criteria
                if (saveIndex.Count != 0)
                {
                    dt.Rows.Clear();
                    for (int i = 0; i < saveIndex.Count(); i++)
                    {
                        dt.Rows.Add(Database.ResidentInfo[saveIndex[i]].FirstName, Database.ResidentInfo[saveIndex[i]].LastName, Database.ResidentInfo[saveIndex[i]].ClusterName, Database.ResidentInfo[saveIndex[i]].UnitNumber,
                            Database.ResidentInfo[saveIndex[i]].Email, Database.ResidentInfo[saveIndex[i]].Phone, Database.ResidentInfo[saveIndex[i]].CurrentRounds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshDataTable()
        {
            dt.Rows.Clear();
            AddDataGridRows();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshDataTable();
        }
    }
}
