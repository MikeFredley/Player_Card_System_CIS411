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

            DataGridViewButtonColumn editAccountButton = new DataGridViewButtonColumn();
            editAccountButton.HeaderText = "Details";
            editAccountButton.Name = "btnEditAccount";
            editAccountButton.Text = "Details";
            editAccountButton.UseColumnTextForButtonValue = true;

            RefreshDataGridView();

            dgvViewEmployees.DataSource = dt;
            dgvViewEmployees.Columns.Add(editAccountButton);
            dgvViewEmployees.ReadOnly = true;
        }

        public void RefreshDataGridView()
        {
            dt.Rows.Clear();
            foreach (EmployeeInfo employee in Database.EmployeeInfo)
            {
                dt.Rows.Add(employee.FirstName, employee.LastName, employee.IsAdmin, employee.UserName, employee.IsCurrent);
            }
        }

        private void dgvViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    EmployeeDetails employeeDetails = new EmployeeDetails(this, GetIDFromRow(e));
                    employeeDetails.Show();
                }
            } 
        }

        private int GetIDFromRow(DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < Database.EmployeeInfo.Count; i++)
            {
                // for each row it takes the first and last name of the row where the button was pressed
                // it then searches through the residentinfo list and matches up the firstnames and last names
                // using those it gets the correct ID for that row, which will be used to pass into the
                // appropriate window
                if (dgvViewEmployees.Rows[e.RowIndex].Cells[1].Value.ToString() == Database.EmployeeInfo[i].FirstName &&
                    dgvViewEmployees.Rows[e.RowIndex].Cells[2].Value.ToString() == Database.EmployeeInfo[i].LastName)
                {
                    return Database.EmployeeInfo[i].ID;
                }
            }
            return 0;
        }
    }
}
