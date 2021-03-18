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
    public partial class EmployeeViewer : Form
    {
        DataTable dt;
        public EmployeeViewer()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployee = new AddNewEmployee(this);
            addEmployee.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Is Admin", typeof(string)));
            dt.Columns.Add(new DataColumn("Username", typeof(string)));
            dt.Columns.Add(new DataColumn("Is Current", typeof(string)));

            RefreshDataGridView();

            dgvViewEmployees.DataSource = dt;
            dgvViewEmployees.ReadOnly = true;
        }

        public void RefreshDataGridView()
        {
            foreach (EmployeeInfo employee in Database.EmployeeInfo)
            {
                dt.Rows.Add(employee.FirstName, employee.LastName, employee.IsAdmin, employee.UserName, employee.IsCurrent);
            }
        }
    }
}
