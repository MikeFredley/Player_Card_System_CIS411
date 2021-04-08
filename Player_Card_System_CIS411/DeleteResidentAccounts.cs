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
    public partial class DeleteResidentAccounts : Form
    {
        AdminWindow adminWindow;
        public DeleteResidentAccounts(AdminWindow pAdminWindow)
        {
            InitializeComponent();
            adminWindow = pAdminWindow;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ResidentInfo> resToDelete = new List<ResidentInfo>();
            if (txtGetDate.Text != "")
            {
                foreach (ResidentInfo res in Database.ResidentInfo)
                {
                    if (res.LastTransDate != "")
                    {
                        DateTime resTransDate = Convert.ToDateTime(res.LastTransDate);
                        DateTime enteredDate = Convert.ToDateTime(txtGetDate.Text);
                        if (resTransDate > enteredDate)
                        {

                        }
                        else
                        {
                            resToDelete.Add(res);
                        }
                    }
                }
                int count = resToDelete.Count;
                if (count != 0)
                {
                    Database.DeleteResidentAccounts(resToDelete);
                    MessageBox.Show(count + " Residents Deleted!");
                }
                else
                {
                    MessageBox.Show("No Residents Deleted!");
                }
            }
            else
            {
                MessageBox.Show("Enter a date.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteResidentAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminWindow.OpenWindow = false;
        }
    }
}
