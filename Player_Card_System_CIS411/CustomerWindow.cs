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
    public partial class CustomerWindow : Form
    {
        WelcomeWindow welcomeWindow;
        public CustomerWindow(WelcomeWindow welcome)
        {
            InitializeComponent();
            welcomeWindow = welcome;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Logging out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                welcomeWindow.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
