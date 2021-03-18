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
    public partial class AdjustBalance : Form
    {
        int newRounds, currentRounds, ID;
        string email;
        EditAccount editAccount;
        public AdjustBalance(int pCurrentRounds, int pID, string pEmail, EditAccount pEditAccount)
        {
            InitializeComponent();
            lblRounds.Text = pCurrentRounds.ToString();
            currentRounds = pCurrentRounds;
            email = pEmail;
            ID = pID;
            editAccount = pEditAccount;

            // Adds each employee name into the combo box for selecting the transaction employee
            foreach (EmployeeInfo employee in Database.EmployeeInfo)
            {
                if (employee.IsCurrent)
                {
                    cmbEmployee.Items.Add(employee.FirstName + " " + employee.LastName);
                }
            }

            cmbEmployee.Text = Database.LoggedInEmployee.FirstName + " " + Database.LoggedInEmployee.LastName;
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {
            // Adds rounds entered to the current amount of rounds
            newRounds = currentRounds + int.Parse(txtNumRounds.Value.ToString());
            CreateNewTransaction();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubtractRounds_Click(object sender, EventArgs e)
        {
            // Calculates the new amount of rounds for deducting them
            newRounds = currentRounds - int.Parse(txtNumRounds.Value.ToString());
            if (newRounds < 0)
            {
                DialogResult dialogResult = MessageBox.Show("Users Number of Rounds Will go Negative. \n\nDo You Wish to Proceed?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateNewTransaction();
                    this.Close();
                }
            }
            else
            {
                CreateNewTransaction();
                this.Close();
            }
        }

        private void CreateNewTransaction()
        {
            int empID = 0;
            for (int i = 0; i < Database.EmployeeInfo.Count; i++)
            {
                if (cmbEmployee.Text == (Database.EmployeeInfo[i].FirstName + " " + Database.EmployeeInfo[i].LastName))
                {
                    empID = Database.EmployeeInfo[i].ID;
                }
            }

            // Creates a new transaction object then sends it to the database
            // class to be added to the list and the database
            Transaction newTransaction = new Transaction("A", newRounds, email, empID, ID, txtReason.Text);
            Database.SubmitTransaction(newTransaction);
            // Refreshes to the new values on the details window and the main screen
            editAccount.EditWindowRefresh(ID);
        }
    }
}
