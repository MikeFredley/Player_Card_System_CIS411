using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using System.Drawing;

namespace Player_Card_System_CIS411
{
    class ExportInfo
    {
        DataTable dt;
        public ExportInfo()
        {
            // TODO: This line of code loads data into the 'appData.EMPLOYEE' table. You can move, or remove it, as needed.
          //  this.eMPLOYEETableAdapter.Fill(this.appData.EMPLOYEE);

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Cluster", typeof(string)));
            dt.Columns.Add(new DataColumn("Unit Number", typeof(int)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Current Rounds", typeof(string)));

            AddDataGridRows();

        }

        public void ExportTest()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt, "Employee");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("You have succesfully exported you data to an excel file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void AddDataGridRows()
        {
            for (int i = 0; i < Database.ResidentInfo.Count(); i++)
            {
                dt.Rows.Add(Database.ResidentInfo[i].FirstName, Database.ResidentInfo[i].LastName, Database.ResidentInfo[i].ClusterName, Database.ResidentInfo[i].UnitNumber,
                    Database.ResidentInfo[i].Email, Database.ResidentInfo[i].Phone, Database.ResidentInfo[i].CurrentRounds);
            }
        }

        private void ExportAccounts()
        {
            
        }

        private void ExportTransactions()
        {

        }
    }
}
