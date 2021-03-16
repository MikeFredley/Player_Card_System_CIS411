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
        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person newPerson = new Person();
            newPerson.FirstName = txtFirstName.Text;
            newPerson.LastName = txtLastName.Text;

            Employee newEmployee = new Employee();
            newEmployee.IsAdmin = chkIsAdmin.Checked;
            newEmployee.Username = txtUserName.Text;
            newEmployee.Password = txtPassword.Text;
            newEmployee.IsCurrent = true;
            Database.AddNewEmployee(newPerson, newEmployee);
        }
    }
}
