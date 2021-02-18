﻿using System;
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Logging out", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                welcomeWindow.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            EditAccount editScreen = new EditAccount();
            editScreen.Show();
        }
    }
}
