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
    public partial class LoginWindow : Form
    {
        bool isEmployee;
        bool isCustomer;
        EmployeeWindow employeeScreen;
        CustomerWindow customerScreen;
        WelcomeWindow welcomeWindow;
        public LoginWindow(bool employee, bool customer, WelcomeWindow welcome)
        {
            InitializeComponent();
            isEmployee = employee;
            isCustomer = customer;
            welcomeWindow = welcome;

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
                    employeeScreen = new EmployeeWindow(welcomeWindow);
                    employeeScreen.Visible = true;
                    this.Hide();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.");
                }
            }
            else
            {
                if ((txtUsername.Text == "Customer") && (txtPassword.Text == "Customer"))
                {
                    customerScreen = new CustomerWindow(welcomeWindow);
                    customerScreen.Visible = true;
                    this.Hide();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.");
                }
            }
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            welcomeWindow.Show();
        }
    }
}
