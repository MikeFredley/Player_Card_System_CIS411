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
    public partial class EmployeeWindow : Form
    {
        WelcomeWindow welcomeWindow;
        public EmployeeWindow(WelcomeWindow welcome)
        {
            InitializeComponent();
            welcomeWindow = welcome;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeWindow_FormClosing(object sender, FormClosingEventArgs e)
        { 
            welcomeWindow.Show();
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            EditAccount editScreen = new EditAccount(true);
            editScreen.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            EditAccount addAccount = new EditAccount(false);
            addAccount.Show();
        }

        private void btnUseTest_Click(object sender, EventArgs e)
        {
            DeductRounds deductRounds = new DeductRounds();
            deductRounds.Show();
        }
    }
}
