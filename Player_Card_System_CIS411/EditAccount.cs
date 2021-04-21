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
        DataTable dt;
        int rowDGVIndex;
        bool openWindow;

        public bool OpenWindow { get => openWindow; set => openWindow = value; }
        public void SetExitButton(bool isEnabled) { btnExit.Enabled = isEnabled; }
        public void SetEditButton(bool isEnabled) { btnEditInfo.Enabled = isEnabled; }
        public EditAccount(bool pIsEdit, int ID, EmployeeWindow pEmployeeWindow)
        {
            isEdit = pIsEdit;
            InitializeComponent();
            openWindow = false;
            // Adds every cluster name to the dropdown list
            foreach (Clusters cluster in Database.Clusters)
            {
                if (!cluster.IsDeleted)
                {
                    cmbCluster.Items.Add(cluster.ClusterName);
                }            
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
              //  txtID.ReadOnly = false;
                txtID.Text = "";
                btnTransHistory.Visible = false;
                txtComments.ReadOnly = false;
                txtComments.Text = "";               
                btnAddRounds.Visible = false;
                btnEditInfo.Visible = false;
                chkEmails.Enabled = true;
                btnSave.Visible = true;
                btnAdjustBalance.Visible = false;
                btnAddUser.Visible = false;
                btnRemoveUser.Visible = false;
                btnDeleteAccount.Visible = false;
                txtID.Visible = false;
                lblID.Visible = false;
                txtLastTransDate.Visible = false;
                lblLastTrans.Visible = false;
                lblCurrentBalance.Visible = false;
                lblAuthorizedUsers.Visible = false;
                dgvAuthorizedUsers.Visible = false;
            }
            else
            {
                EditWindowRefresh(ID);
            }
            InitializeDataGridView();
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
                    txtComments.Text = Database.ResidentInfo[i].CommentBox;
                    chkEmails.Checked = Database.ResidentInfo[i].NoEmail;
                    txtLastTransDate.Text = Database.ResidentInfo[i].LastTransDate;
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
            if (!openWindow)
            {
                employeeWindow.RefreshDataTable();
                employeeWindow.OpenWindow = false;
                employeeWindow.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
            //    btnExit.Enabled = false;
            //    btnEditInfo.Enabled = false;
                AddRounds addRoundWindow = new AddRounds(Database.ResidentInfo[rowIndexHolder].CurrentRounds, Database.ResidentInfo[rowIndexHolder].ID, IsEmail(), Database.ResidentInfo[rowIndexHolder].NoEmail, this);
                addRoundWindow.Show();
            }
            else
            {
                //MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                // Allows you to edit stuff in the textboxes
                //   txtID.ReadOnly = false;
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                cmbCluster.Enabled = true;
                txtUnit.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtPhone.ReadOnly = false;
                txtComments.ReadOnly = false;
                btnEditInfo.Visible = false;
                chkEmails.Enabled = true;
                btnSave.Visible = true;
                openWindow = true;
                btnAddRounds.Visible = false;
                btnAdjustBalance.Visible = false;
                btnDeleteAccount.Visible = false;
                btnTransHistory.Visible = false;
                btnAddUser.Visible = false;
                btnRemoveUser.Visible = false;
                btnCancel.Visible = true;
                if (txtEmail.Text == " ")
                {
                    txtEmail.Text = "";
                }               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string email;
            // If any textbox is empty is throws and error
            if (txtFirstName.Text == "" || txtLastName.Text == "" || cmbCluster.Text == "" || txtUnit.Text == "")
            {
                MessageBox.Show("Please fill in the required fields");
            }
            else
            {
                try
                {
                    if (CheckClusterBox())
                    {
                        if (!isEdit)
                        {
                         /*   foreach (ResidentInfo res in Database.ResidentInfo)
                            {
                                if (res.FirstName == txtFirstName.Text && res.LastName == txtLastName.Text ||
                                    res.Email == txtEmail.Text && res.Phone == txtPhone.Text)
                                {
                                    DialogResult dialog = MessageBox.Show("There is already an account with similiar information.\nDo you wish to proceed?", "Warning", MessageBoxButtons.YesNo);
                                    if (dialog == DialogResult.Yes)
                                    {

                                    }
                                    else
                                    {
                                       // this.Close();
                                    }
                                }
                            } */
                            // this will prevent the backup/restore stuff from messing up
                            // later down the road   
                            if (txtEmail.Text == "")
                            {
                                email = " ";
                                chkEmails.Checked = false;
                            }
                            else
                            {
                                email = txtEmail.Text;
                            }
                            // If youre adding a resident with the addperson button it runs this code
                            ResidentInfo newResident = new ResidentInfo();
                            newResident.FirstName = txtFirstName.Text;
                            newResident.LastName = txtLastName.Text;
                            newResident.ClusterName = cmbCluster.Text;
                            newResident.UnitNumber = int.Parse(txtUnit.Text);
                            newResident.Email = email;
                            newResident.Phone = txtPhone.Text;
                            newResident.CommentBox = txtComments.Text;
                            newResident.NoEmail = chkEmails.Checked;
                            int ID = Database.AddResident(newResident);
                            this.EditWindowRefresh(ID);
                            isEdit = true;

                            txtID.Visible = true;
                            lblID.Visible = true;
                            txtLastTransDate.Visible = true;
                            lblLastTrans.Visible = true;
                            lblCurrentBalance.Visible = true;
                            lblAuthorizedUsers.Visible = true;
                            dgvAuthorizedUsers.Visible = true;
                            btnTransHistory.Visible = true;
                            this.Text = "Account Details";
                            InitializeDataGridView();
                        }
                        else
                        {
                            // this will prevent the backup/restore stuff from messing up
                            // later down the road
                            if (txtEmail.Text == "")
                            {
                                email = " ";
                                chkEmails.Checked = false;
                            }
                            else
                            {
                                email = txtEmail.Text;
                            }
                            // If its the edit window then it calls the method to update the tables
                            // instead of adding to them
                            Database.ResidentInfo[rowIndexHolder].FirstName = txtFirstName.Text;
                            Database.ResidentInfo[rowIndexHolder].LastName = txtLastName.Text;
                            Database.ResidentInfo[rowIndexHolder].ClusterName = cmbCluster.Text;
                            Database.ResidentInfo[rowIndexHolder].UnitNumber = int.Parse(txtUnit.Text);
                            Database.ResidentInfo[rowIndexHolder].Email = email;
                            Database.ResidentInfo[rowIndexHolder].Phone = txtPhone.Text;
                            Database.ResidentInfo[rowIndexHolder].CommentBox = txtComments.Text;
                            Database.ResidentInfo[rowIndexHolder].NoEmail = chkEmails.Checked;
                            Database.UpdateResidentPersonTable(rowIndexHolder);
                            employeeWindow.RefreshDataTable();
                            
                        }

                        // Disables you from being able to edit stuff in the textboxes
                        //  txtID.ReadOnly = true;

                        btnAdjustBalance.Visible = true;
                        btnAddUser.Visible = true;
                        btnRemoveUser.Visible = true;
                        btnAddRounds.Visible = true;
                        btnDeleteAccount.Visible = true;
                        btnTransHistory.Visible = true;
                        btnCancel.Visible = false;

                        txtFirstName.ReadOnly = true;
                        txtLastName.ReadOnly = true;
                        cmbCluster.Enabled = false;
                        txtUnit.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtPhone.ReadOnly = true;
                        txtComments.ReadOnly = true;
                        btnEditInfo.Visible = true;
                        btnSave.Visible = false;
                        chkEmails.Enabled = false;
                        openWindow = false;
                        btnAddRounds.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cluster entered is not a valid cluster");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error With Existing Information");
                }
            }
        }

        private bool CheckClusterBox()
        {
            bool check = false;
            foreach(Clusters cluster in Database.Clusters)
            {
                if (cmbCluster.Text == cluster.ClusterName)
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }
            return check;
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
                return " ";
            }
        }

        private void btnTransHistory_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
             //   btnExit.Enabled = false;
              //  btnEditInfo.Enabled = false;
                TransactionHistory transactionWindow = new TransactionHistory(Database.ResidentInfo[rowIndexHolder].ID, this, Database.ResidentInfo[rowIndexHolder].Email);
                transactionWindow.Show();
                this.Visible = false;
            }
            else
            {
                //MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnAdjustBalance_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
            //    btnExit.Enabled = false;
          //      btnEditInfo.Enabled = false;
                AdjustBalance adjustBalance = new AdjustBalance(Database.ResidentInfo[rowIndexHolder].CurrentRounds, Database.ResidentInfo[rowIndexHolder].ID, IsEmail(), Database.ResidentInfo[rowIndexHolder].NoEmail, this);
                adjustBalance.Show();
            }
            else
            {
                //MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
             //   btnExit.Enabled = false;
             //   btnEditInfo.Enabled = false;
                AddAuthorizedUser authorizedUser = new AddAuthorizedUser(Database.ResidentInfo[rowIndexHolder].ID, this);
                authorizedUser.Show();
            }
            else
            {
                //MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void InitializeDataGridView()
        {
            if (isEdit)
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("First Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Last Name", typeof(string)));

                RefreshDataGridView();

                dgvAuthorizedUsers.DataSource = dt;
                dgvAuthorizedUsers.ReadOnly = true;
            }         
        }

        public void RefreshDataGridView()
        {
            dt.Rows.Clear();
            foreach (AdditionalAuthorizedUsers user in Database.AuthorizedUsers)
            {
                if (user.OwnerID == Database.ResidentInfo[rowIndexHolder].ID)
                {
                    dt.Rows.Add(user.FirstName, user.LastName);
                }
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if(!openWindow)
            {
                if (dgvAuthorizedUsers.Rows[rowDGVIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("No Users to delete.");
                }
                else
                {
                    foreach (AdditionalAuthorizedUsers user in Database.AuthorizedUsers)
                    {
                        if (user.FirstName == dgvAuthorizedUsers.Rows[rowDGVIndex].Cells[0].Value.ToString() &&
                            user.LastName == dgvAuthorizedUsers.Rows[rowDGVIndex].Cells[1].Value.ToString())
                        {
                            Database.DeleteAuthorizedUser(user.OwnerID, user.FirstName, user.LastName);
                            break;
                        }
                    }
                    RefreshDataGridView();
                    MessageBox.Show("Authorized User Deleted");
                }
            }
        }

        private void dgvAuthorizedUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowDGVIndex = e.RowIndex;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to delete this user?", "Delete Account", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Database.DeleteResidentAccounts(Database.ResidentInfo[rowIndexHolder]);
                    this.Close();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                HelpWindow help = new HelpWindow(this);
                help.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdjustBalance.Visible = true;
            btnAddUser.Visible = true;
            btnRemoveUser.Visible = true;
            btnAddRounds.Visible = true;
            btnDeleteAccount.Visible = true;
            btnTransHistory.Visible = true;
            btnCancel.Visible = false;

            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            cmbCluster.Enabled = false;
            txtUnit.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtComments.ReadOnly = true;
            btnEditInfo.Visible = true;
            btnSave.Visible = false;
            chkEmails.Enabled = false;
            openWindow = false;
            btnAddRounds.Focus();
        }
    }
}
