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
    public partial class HelpWindow : Form
    {
        EditAccount editAccount;
        public HelpWindow(EditAccount pEditAccount)
        {
            InitializeComponent();
            editAccount = pEditAccount;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            editAccount.OpenWindow = false;
            editAccount.Visible = true;
        }
    }
}
