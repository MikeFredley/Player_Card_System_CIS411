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
            foreach (Employee employee in Database.Employee)
            {
                for (int i = 0; i < Database.Person.Count; i++)
                {
                    if (employee.ID == Database.Person[i].ID && employee.IsCurrent)
                    {
                        cmbEmployee.Items.Add(Database.Person[i].FirstName + " " + Database.Person[i].LastName);
                    }
                }
            }
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
            // Creates a new transaction object then sends it to the database
            // class to be added to the list and the database
            Transaction newTransaction = new Transaction("A", newRounds, email, 101, ID, txtReason.Text);
            Database.SubmitTransaction(newTransaction);
            // Refreshes to the new values on the details window and the main screen
            editAccount.EditWindowRefresh(ID);
        }
    }
}
