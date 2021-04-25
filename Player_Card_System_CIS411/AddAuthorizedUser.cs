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
    public partial class AddAuthorizedUser : Form
    {
        int ID;
        EditAccount editAccount;
        public AddAuthorizedUser(int pID, EditAccount pEditAccount)
        {
            InitializeComponent();
            ID = pID;
            editAccount = pEditAccount;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Please fill in both fields.");
            }
            else
            {
                AdditionalAuthorizedUsers newAuthorizedUser = new AdditionalAuthorizedUsers();
                newAuthorizedUser.OwnerID = ID;
                newAuthorizedUser.FirstName = txtFirstName.Text;
                newAuthorizedUser.LastName = txtLastName.Text;
                Database.AddAuthorizedUser(newAuthorizedUser);
                editAccount.RefreshDataGridView();
            //    MessageBox.Show("New Authorized User Added.");
                this.Close();
            }

        }

        private void AddAuthorizedUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            editAccount.OpenWindow = false;
            editAccount.SetEditButton(true);
        }
    }
}
