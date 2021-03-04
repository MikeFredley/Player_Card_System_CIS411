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
            DataTable dt = new DataTable();
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
            
            for (int i = 0; i < Database.ResidentInfo.Count(); i++)
            {
                dt.Rows.Add(Database.ResidentInfo[i].FirstName, Database.ResidentInfo[i].LastName, Database.ResidentInfo[i].ClusterName, Database.ResidentInfo[i].UnitNumber,
                    Database.ResidentInfo[i].Email, Database.ResidentInfo[i].Phone, Database.ResidentInfo[i].CurrentRounds);
            }

            dgvResidentInfo.DataSource = dt;
            dgvResidentInfo.Columns.Add(deductRoundButton);
            dgvResidentInfo.Columns.Add(editAccountButton);
            dgvResidentInfo.ReadOnly = true;
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
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
            EditAccount addAccount = new EditAccount(false);
            addAccount.Show();
        }

        private void btnUseTest_Click(object sender, EventArgs e)
        {
            DeductRounds deductRounds = new DeductRounds();
            deductRounds.Show();
        }

        private void dgvResidentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the deduct rounds button is clicked
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {
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
                    MessageBox.Show(Database.ResidentInfo[e.RowIndex].ID.ToString());
                }
            }
        }
    }
}
