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
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            EmployeeViewer employeeViewer = new EmployeeViewer();
            employeeViewer.Show();
        }

        private void btnExportAccounts_Click(object sender, EventArgs e)
        {
            ExportInfo export = new ExportInfo();
            export.ExportAccounts();
        }

        private void btnExportTransactions_Click(object sender, EventArgs e)
        {
            ExportInfo export = new ExportInfo();
            export.ExportTransactions();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            ExportInfo export = new ExportInfo();
            export.FullBackup();
        }

        private void btnNewDeals_Click(object sender, EventArgs e)
        {
            ViewGolfRounds viewRounds = new ViewGolfRounds();
            viewRounds.Show();
        }
    }
}
