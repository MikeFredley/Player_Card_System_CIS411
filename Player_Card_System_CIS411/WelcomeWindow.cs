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
    public partial class WelcomeWindow : Form
    {
        EmployeeWindow employeeScreen;
        public WelcomeWindow()
        {
            bool exists = false;
            InitializeComponent();
            foreach (EmployeeInfo emp in Database.EmployeeInfo)
            {
                if (emp.FirstName == "Default")
                {
                    exists = true;
                    break;
                }
            }    

            if (!exists)
            {
                EmployeeInfo employee = new EmployeeInfo();
                employee.FirstName = "Default";
                employee.LastName = "Default";
                employee.UserName = "Default";
                employee.Password = "Default";
                employee.IsAdmin = true;
                employee.IsCurrent = true;
                Database.AddNewEmployee(employee);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {         
            bool login = Database.Login(txtUsername.Text, txtPassword.Text);
            if (login)
            {
                employeeScreen = new EmployeeWindow(this);
                employeeScreen.Visible = true;
                txtUsername.Text = "";
                txtPassword.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or password");
            }  
        }

        private void WelcomeWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
