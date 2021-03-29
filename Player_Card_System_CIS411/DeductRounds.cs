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
    public partial class DeductRounds : Form
    {
        int resIndex;
        int newRounds;
        Transaction newTransaction;
        EmployeeWindow employeeWindow;
        public DeductRounds(int ID, EmployeeWindow pEmployeeWindow)
        {
            InitializeComponent();
            employeeWindow = pEmployeeWindow;
            // Grabs the residents current rounds
            for (int i = 0; i < Database.ResidentInfo.Count; i++)
            {
                if (Database.ResidentInfo[i].ID == ID)
                {
                    lblCurrenRounds.Text = Database.ResidentInfo[i].CurrentRounds + "";
                    resIndex = i;
                }
            }          

            foreach (EmployeeInfo employee in Database.EmployeeInfo)
            {
                if (employee.IsCurrent)
                {
                    cmbEmployee.Items.Add(employee.FirstName + " " + employee.LastName);
                }                
            }

            cmbEmployee.Text = Database.LoggedInEmployee.FirstName + " " + Database.LoggedInEmployee.LastName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeductRounds_FormClosing(object sender, FormClosingEventArgs e)
        {
            employeeWindow.OpenWindow = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Calculates the new amount of rounds for deducting them
            newRounds = Database.ResidentInfo[resIndex].CurrentRounds - int.Parse(txtNumRounds.Value.ToString());
            if(newRounds < 0)
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
            string email;
            int empID = 0;

            if (Database.ResidentInfo[resIndex].NoEmail)
            {
                email = Database.ResidentInfo[resIndex].Email;
            }
            else
            {
                email = "";
            }

            for (int i = 0; i < Database.EmployeeInfo.Count; i++)
            {
                if (cmbEmployee.Text == (Database.EmployeeInfo[i].FirstName + " " + Database.EmployeeInfo[i].LastName))
                {
                    empID = Database.EmployeeInfo[i].ID;
                }
            }


            newTransaction = new Transaction("U", newRounds, email, empID, Database.ResidentInfo[resIndex].ID, "");
            Database.SubmitTransaction(newTransaction);
            employeeWindow.RefreshDataTable();

            if (email != "")
            {
                Email.RoundsDeductedEmail(int.Parse(txtNumRounds.Value.ToString()), newRounds, email);
            }
        }
    }
}
