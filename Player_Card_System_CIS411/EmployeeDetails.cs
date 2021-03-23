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
    public partial class EmployeeDetails : Form
    {
        int ID, rowIndexHolder;
        EmployeeViewer employeeViewer;
        public EmployeeDetails(EmployeeViewer pEmployeeViewer, int pID)
        {
            InitializeComponent();
            ID = pID;
            employeeViewer = pEmployeeViewer;

            for (int i = 0; i < Database.EmployeeInfo.Count; i++)
            {
                if (Database.EmployeeInfo[i].ID == ID)
                {
                    txtFirstName.Text = Database.EmployeeInfo[i].FirstName;
                    txtLastName.Text = Database.EmployeeInfo[i].LastName;
                    txtUserName.Text = Database.EmployeeInfo[i].UserName;
                    chkIsAdmin.Checked = Database.EmployeeInfo[i].IsAdmin;
                    chkIsCurrent.Checked = Database.EmployeeInfo[i].IsCurrent;
                    rowIndexHolder = i;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnEdit.Visible = false;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtUserName.ReadOnly = false;
            chkIsAdmin.Enabled = true;
            chkIsCurrent.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(rowIndexHolder);
            changePassword.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnEdit.Visible = true;

            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtUserName.ReadOnly = true;
            chkIsAdmin.Enabled = false;
            chkIsCurrent.Enabled = false;

            Database.EmployeeInfo[rowIndexHolder].FirstName = txtFirstName.Text;
            Database.EmployeeInfo[rowIndexHolder].LastName = txtLastName.Text;
            Database.EmployeeInfo[rowIndexHolder].IsAdmin = chkIsAdmin.Checked;
            Database.EmployeeInfo[rowIndexHolder].UserName = txtUserName.Text;
            Database.EmployeeInfo[rowIndexHolder].IsCurrent = chkIsCurrent.Checked;
            Database.UpdateEmployee(rowIndexHolder);
            employeeViewer.RefreshDataGridView();
        }
    }
}
