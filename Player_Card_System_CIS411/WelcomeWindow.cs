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
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            employeeScreen = new EmployeeWindow(this);
            employeeScreen.Visible = true;
            this.Hide();


          /*  string userName = txtUsername.Text;
            string passWord = txtPassword.Text;

            foreach (Employee emp in Database.Employee)
            {
                if(userName == emp.Username && passWord == emp.Password)
                {
                    
                    break;
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.", "Error");
                }
            } */
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
