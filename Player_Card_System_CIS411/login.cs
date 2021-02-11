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
    public partial class login : Form
    {
        bool isEmployee;
        bool isCustomer;
        Employee employeeScreen;
        Customer customerScreen;
        public login(bool employee, bool customer)
        {
            InitializeComponent();
            isEmployee = employee;
            isCustomer = customer;

            if(isEmployee)
            {
                lblLogin.Text = "Employee Login";
            }
            else
            {
                lblLogin.Text = "Customer Login";
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        public void setIsEmployee(bool employee)
        {
            isEmployee = employee;
        }

        public void setIsCustomer(bool customer)
        {
            isCustomer = customer;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(isEmployee)
            {
                if((txtUsername.Text == "Employee") && (txtPassword.Text == "Employee"))
                {
                    employeeScreen = new Employee();
                    employeeScreen.Visible = true;
                }
            }
            else
            {
                if ((txtUsername.Text == "Customer") && (txtPassword.Text == "Customer"))
                {
                    customerScreen = new Customer();
                    customerScreen.Visible = true;
                }
            }
        }
    }
}
