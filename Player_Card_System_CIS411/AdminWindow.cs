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
    public partial class AdminWindow : Form
    {
        EmployeeWindow employeeWindow;
        bool openWindow;

        public bool OpenWindow { get => openWindow; set => openWindow = value; }
        public AdminWindow(EmployeeWindow pEmployeeWindow)
        {
            InitializeComponent();
            employeeWindow = pEmployeeWindow;
            openWindow = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                employeeWindow.OpenWindow = false;
                employeeWindow.RefreshDataTable();
                employeeWindow.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                EmployeeViewer employeeViewer = new EmployeeViewer(this);
                employeeViewer.Show();
                this.Visible = false;
            }
            else
            {

            }

        }

        private void btnExportAccounts_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                ExportInfo export = new ExportInfo();
                export.ExportAccounts();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnExportTransactions_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                ExportInfo export = new ExportInfo();
                export.ExportTransactions();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                ExportInfo export = new ExportInfo();
                export.FullBackup();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnNewDeals_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                ViewGolfRounds viewRounds = new ViewGolfRounds(this);
                viewRounds.Show();
                this.Visible = false;
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }
            
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                ImportInfo import = new ImportInfo();
                employeeWindow.RefreshDataTable();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnResetSeason_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                DialogResult dialog = MessageBox.Show("This will clear ALL existing transactions within the system.\nIt is recommended to take a full backup before clicking 'Yes'.", "Warning", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Database.WipeTransactions();
                    employeeWindow.RefreshDataTable();
                    MessageBox.Show("Transactions Wiped!");
                }

            }
        }

        private void btnDeleteAccounts_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                DeleteResidentAccounts delResAccounts = new DeleteResidentAccounts(this);
                delResAccounts.Show();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }
        }

        private void btnChangeEmailPassword_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                ChangePassword changePassword = new ChangePassword(true, this);
                changePassword.Show();
            }
            else
            {
                // MessageBox.Show("Close other windows before opening another.");
            }

        }

        private void btnManageClusters_Click(object sender, EventArgs e)
        {
            if (!openWindow)
            {
                openWindow = true;
                ManageClusters manage = new ManageClusters(this);
                manage.Show();
                this.Visible = false;
            }
        }
    }
}
