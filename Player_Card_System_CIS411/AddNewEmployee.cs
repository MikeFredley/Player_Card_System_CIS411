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
    public partial class AddNewEmployee : Form
    {
        EmployeeViewer employeeViewer;
        public AddNewEmployee(EmployeeViewer pEmployeeViewer)
        {
            InitializeComponent();
            employeeViewer = pEmployeeViewer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckPassword())
            {
                EmployeeInfo newEmployee = new EmployeeInfo();
                newEmployee.FirstName = txtFirstName.Text;
                newEmployee.LastName = txtLastName.Text;
                newEmployee.IsAdmin = chkIsAdmin.Checked;
                newEmployee.UserName = txtUserName.Text;
                newEmployee.Password = txtPassword.Text;
                newEmployee.IsCurrent = true;
                Database.AddNewEmployee(newEmployee);
                employeeViewer.RefreshDataGridView();
                MessageBox.Show("New Employee Added");
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords Do Not Match!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckPassword()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                return true;
            }
            return false;
        }
    }
}
