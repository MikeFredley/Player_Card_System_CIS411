﻿using System;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeductRounds_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            if (Database.ResidentInfo[resIndex].NoEmail)
            {
                email = Database.ResidentInfo[resIndex].Email;
            }
            else
            {
                email = "";
            }
            newTransaction = new Transaction("U", newRounds, email, 101, Database.ResidentInfo[resIndex].ID, "");
            Database.SubmitTransaction(newTransaction);
            employeeWindow.RefreshDataTable();
        }
    }
}
