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

        public EditAccount(bool isEdit, int rowIndex)
        {
            InitializeComponent();
            if(!isEdit)
            {
                this.Text = "Add Account";
                txtFirstName.ReadOnly = true;
                txtFirstName.Text = Database.ResidentInfo[rowIndex].FirstName;
                txtLastName.ReadOnly = true;
                txtLastName.Text = Database.ResidentInfo[rowIndex].LastName; ;
                cmbCluster.Enabled = false;
                txtUnit.ReadOnly = true;
                txtUnit.Text = "";
                txtEmail.ReadOnly = true;
                txtEmail.Text = Database.ResidentInfo[rowIndex].Email;
                txtPhone.ReadOnly = true;
                txtPhone.Text = Database.ResidentInfo[rowIndex].Phone;
                txtCardNumber.ReadOnly = true;
                txtCardNumber.Text = Database.ResidentInfo[rowIndex].ID + "";
                btnTransHistory.Visible = true;
                //delete this
               // pictureBox1.Visible = true;
                btnAddRounds.Visible = true;

                rowIndexHolder = rowIndex;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {

        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            cmbCluster.Enabled = true;
            txtUnit.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
                
            btnEditInfo.Visible = false;
            btnSave.Visible = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            cmbCluster.Enabled = false;
            txtUnit.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;

            btnEditInfo.Visible = true;
            btnSave.Visible = false;

            Database.ResidentInfo[rowIndexHolder].FirstName = txtFirstName.Text;
            Database.ResidentInfo[rowIndexHolder].LastName = txtLastName.Text;
            //Database.ResidentInfo[rowIndexHolder].ClusterName = txtFirstName.Text;
            Database.ResidentInfo[rowIndexHolder].UnitNumber = int.Parse(txtUnit.Text);
            Database.ResidentInfo[rowIndexHolder].Email = txtEmail.Text;
            Database.ResidentInfo[rowIndexHolder].Phone = txtPhone.Text;
        }
    }
}
