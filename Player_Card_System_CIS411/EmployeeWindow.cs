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
            editAccountButton.HeaderText = "Edit Account";
            editAccountButton.Name = "btnEditAccount";
            editAccountButton.Text = "Edit Account";
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
            //EditAccount editScreen = new EditAccount(true);
            //editScreen.Show();
            EditAccount editScreen = new EditAccount(true);
            editScreen.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            //EditAccount addAccount = new EditAccount(false);
            //addAccount.Show();
            EditAccount addAccount = new EditAccount(false);
            addAccount.Show();
        }

        private void btnUseTest_Click(object sender, EventArgs e)
        {
            //DeductRounds deductRounds = new DeductRounds();
            //deductRounds.Show();
        }

        private void dgvResidentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the deduct rounds button is clicked
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {
                    // grabs the residents ID in the corresponding row
                    //MessageBox.Show(Database.ResidentInfo[e.RowIndex].ID.ToString());

                    int rowIndexHolder = e.RowIndex;
                    DeductRounds deductWindow = new DeductRounds(rowIndexHolder);
                    deductWindow.Show();
                    // grabs the residents ID in the corresponding row
                    MessageBox.Show(Database.ResidentInfo[e.RowIndex].ID.ToString());
                }
            }

            // If the Edit account button is clicked
            if (e.ColumnIndex == 8)
            {
                if (e.RowIndex >= 0)
                {
                    // grabs the residents ID in the corresponding row
                    //MessageBox.Show(Database.ResidentInfo[e.RowIndex].ID.ToString());
                    // grabs the residents ID in the corresponding row
                    MessageBox.Show(Database.ResidentInfo[e.RowIndex].ID.ToString());
                }
            }
        }

                    int rowIndexHolder = e.RowIndex;

                    EditAccount editWindow = new EditAccount(false, rowIndexHolder);
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            // if some jackass doesnt want to hit the shift key then he doesnt have too
            searchText = searchText.ToLower();
            List<int> saveIndex = new List<int>();
            bool breakForEach = false;

                    editWindow.Show();

                }
            }
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
                            if (saveIndex.Count == 0)
                            {
                                breakForEach = true;
                                break;
                            }
                            else
                            {
                                //MessageBox.Show("Search Complete");
                                break;
                            }                         
                        }
                        else 
                        // Checks each value of every column for that row
                        if (row.Cells[i].Value.ToString().ToLower().Equals(searchText))
                        {
                            // If it matches what the user entered it selects the row and breaks the loop
                            saveIndex.Add(row.Index);
                            //row.Selected = true;
                            break;
                        }                        
                    }
                    if (saveIndex.Count == 0 && breakForEach)
                    {
                        MessageBox.Show("No Items Found");
                        dt.Rows.Clear();
                        AddDataGridRows();
                        break;
                    }
                }

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            AddDataGridRows();
        }
    }
}
