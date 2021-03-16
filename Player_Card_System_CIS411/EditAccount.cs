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
    public partial class EditAccount : Form
    {
        int rowIndexHolder;
        EmployeeWindow employeeWindow;
        bool isEdit;
        public EditAccount(bool pIsEdit, int ID, EmployeeWindow pEmployeeWindow)
        {
            isEdit = pIsEdit;
            InitializeComponent();
            // Adds every cluster name to the dropdown list
            foreach (Clusters cluster in Database.Clusters)
            {
                cmbCluster.Items.Add(cluster.ClusterName);
            }
            employeeWindow = pEmployeeWindow;
            if (!isEdit)
            {
                this.Text = "Add Account";
                txtFirstName.ReadOnly = false;
                txtFirstName.Text = "";
                txtLastName.ReadOnly = false;
                txtLastName.Text = "";
                cmbCluster.Enabled = true;
                txtUnit.ReadOnly = false;
                txtUnit.Text = "";
                txtEmail.ReadOnly = false;
                txtEmail.Text = "";
                txtPhone.ReadOnly = false;
                txtPhone.Text = "";
                txtID.ReadOnly = false;
                txtID.Text = "";
                txtAddress.ReadOnly = false;
                txtAddress.Text = "";
                btnTransHistory.Visible = false;
                txtComments.ReadOnly = false;
                txtComments.Text = "";
                pictureBox1.Visible = false;
                btnAddRounds.Visible = false;
                btnEditInfo.Visible = false;
                chkEmails.Enabled = true;
                btnSave.Visible = true;
            }
            else
            {
                EditWindowRefresh(ID);
            }
        }

        public void EditWindowRefresh(int ID)
        {
            // Makes sure all of the textboxes stay up to date after being called
            for (int i = 0; i < Database.ResidentInfo.Count; i++)
            {
                if (Database.ResidentInfo[i].ID == ID)
                {
                    txtID.Text = Database.ResidentInfo[i].ID.ToString();
                    txtFirstName.Text = Database.ResidentInfo[i].FirstName;
                    txtLastName.Text = Database.ResidentInfo[i].LastName;
                    cmbCluster.Text = Database.ResidentInfo[i].ClusterName;
                    txtUnit.Text = Database.ResidentInfo[i].UnitNumber.ToString();
                    txtEmail.Text = Database.ResidentInfo[i].Email;
                    txtPhone.Text = Database.ResidentInfo[i].Phone;
                    txtAddress.Text = Database.ResidentInfo[i].Address;
                    txtComments.Text = Database.ResidentInfo[i].CommentBox;
                    chkEmails.Checked = Database.ResidentInfo[i].NoEmail;
                    lblCurrentBalance.Text = "Current Rounds: " + Database.ResidentInfo[i].CurrentRounds;                  
                    rowIndexHolder = i;
                }
            }
            employeeWindow.RefreshDataTable();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            employeeWindow.RefreshDataTable();
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {
            AddRounds addRoundWindow = new AddRounds(Database.ResidentInfo[rowIndexHolder].CurrentRounds, Database.ResidentInfo[rowIndexHolder].ID, IsEmail(), this);
            addRoundWindow.Show();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            // Allows you to edit stuff in the textboxes
            txtID.ReadOnly = false;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            cmbCluster.Enabled = true;
            txtUnit.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtComments.ReadOnly = false;
            txtAddress.ReadOnly = false;
            btnEditInfo.Visible = false;
            chkEmails.Enabled = true;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Disables you from being able to edit stuff in the textboxes
            txtID.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            cmbCluster.Enabled = false;
            txtUnit.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtComments.ReadOnly = true;
            txtAddress.ReadOnly = true;
            btnEditInfo.Visible = true;
            btnSave.Visible = false;
            chkEmails.Enabled = false;

            if (!isEdit)
            {
                
            }
            else
            {
                // If its the edit window then it calls the method to update the tables
                // instead of adding to them
                Database.ResidentInfo[rowIndexHolder].FirstName = txtFirstName.Text;
                Database.ResidentInfo[rowIndexHolder].LastName = txtLastName.Text;
                Database.ResidentInfo[rowIndexHolder].ClusterName = cmbCluster.Text;
                Database.ResidentInfo[rowIndexHolder].UnitNumber = int.Parse(txtUnit.Text);
                Database.ResidentInfo[rowIndexHolder].Email = txtEmail.Text;
                Database.ResidentInfo[rowIndexHolder].Phone = txtPhone.Text;
                Database.ResidentInfo[rowIndexHolder].CommentBox = txtComments.Text;
                Database.ResidentInfo[rowIndexHolder].Address = txtAddress.Text;
                Database.ResidentInfo[rowIndexHolder].NoEmail = chkEmails.Checked;
                Database.UpdateResidentPersonTable(rowIndexHolder);
                employeeWindow.RefreshDataTable();
            } 
        }

        // If the person chooses to be emailed then it will use their email in the transaction for adding rounds
        private string IsEmail()
        {
            if (Database.ResidentInfo[rowIndexHolder].NoEmail)
            {
                return Database.ResidentInfo[rowIndexHolder].Email;
            }
            else
            {
                return "";
            }
        }

        private void btnTransHistory_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionWindow = new TransactionHistory(Database.ResidentInfo[rowIndexHolder].ID);
            transactionWindow.Show();
        }

        private void btnAdjustBalance_Click(object sender, EventArgs e)
        {
            AdjustBalance adjustBalance = new AdjustBalance(Database.ResidentInfo[rowIndexHolder].CurrentRounds, Database.ResidentInfo[rowIndexHolder].ID, IsEmail(), this);
            adjustBalance.Show();
        }
    }
}
