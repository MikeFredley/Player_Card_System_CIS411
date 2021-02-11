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
        LoginWindow loginScreen;

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

        private void employeeBtn_Click(object sender, EventArgs e)
        {
            loginScreen = new LoginWindow(true, false, this);
            loginScreen.Show();
            this.Hide();
        }

        private void customerBtn_Click(object sender, EventArgs e)
        {
            loginScreen = new LoginWindow(false, true, this);
            loginScreen.Show();
            this.Hide();
        }
    }
}
