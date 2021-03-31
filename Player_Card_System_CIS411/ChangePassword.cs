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
        public ChangePassword(int pEmpIndex)
        {
            InitializeComponent();
            empIndex = pEmpIndex;
        }

        private void btnChange_Click(object sender, EventArgs e)
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
