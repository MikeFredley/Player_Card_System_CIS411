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
    public partial class ChangePassword : Form
    {
        int empIndex;
        bool emailPassword;
        AdminWindow adminWindow;

        public ChangePassword(int pEmpIndex)
        {
            InitializeComponent();
            empIndex = pEmpIndex;
            emailPassword = false;
        }
        
        public ChangePassword(bool pEmailPassword, AdminWindow pAdminWindow)
        {
            InitializeComponent();
            emailPassword = pEmailPassword;
            adminWindow = pAdminWindow;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (!emailPassword)
            {
                if (CheckPassword())
                {
                    Database.ChangePassword(empIndex, txtPassword.Text);
                    MessageBox.Show("Password Changed!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords Do Not Match!");
                }
            }
            else
            {
                if(CheckPassword())
                {
                    Database.ChangeOutGoingEmailPassword(txtPassword.Text);
                    MessageBox.Show("Email Password Changed!");
                    adminWindow.OpenWindow = false;
                    this.Close();
                }
            }     

        }

        private bool CheckPassword()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                return true;
            }
            return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
