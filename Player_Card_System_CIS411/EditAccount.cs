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
    public partial class EditAccount : Form
    {
        public EditAccount(bool isEdit)
        {
            InitializeComponent();
            if(!isEdit)
            {
                this.Text = "Add Account";
                txtID.ReadOnly = false;
                txtID.Text = "";
                txtFirstName.ReadOnly = false;
                txtFirstName.Text = "";
                txtLastName.ReadOnly = false;
                txtLastName.Text = "";
                cmbCluster.Enabled = true;
                txtUnit.ReadOnly = false;
                txtUnit.Text = "";
                txtEmail.ReadOnly = false;
                txtEmail.Text = "";
                txtPhone.ReadOnly = false;
                txtPhone.Text = "";
                txtCardNumber.ReadOnly = false;
                txtCardNumber.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {
            DeductRounds addRounds = new DeductRounds(false);
            addRounds.Show();
        }
    }
}
