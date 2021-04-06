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
        List<string> bookNames;
        List<DataTable> dataTables;
        public ExportInfo()
        {
            bookNames = new List<string>();
            dataTables = new List<DataTable>();
        }

        public void ExportTransactions()
        {           
            dataTables.Clear();
            bookNames.Clear();
            dataTables.Add(CreateTransactionsDataTable());
            bookNames.Add("Transactions");
            Export();
        }

        public void ExportAccounts()
        {           
            dataTables.Clear();
            bookNames.Clear();
            dataTables.Add(CreateResidentsDataTable());
            dataTables.Add(CreateEmployeesDataTable());
            bookNames.Add("Residents");
            bookNames.Add("Employees");
            Export();
        }

        public void FullBackup()
        {
            dataTables.Clear();
            bookNames.Clear();

            dataTables.Add(CreateClustersDataTable());
            dataTables.Add(CreatePersonDataTable());
            dataTables.Add(CreateResidentsDataTable());
            dataTables.Add(CreateEmployeesDataTable());
            dataTables.Add(CreateAuthorizedUsersDataTable());                   
            dataTables.Add(CreateGolfRoundsDataTable());           
            dataTables.Add(CreateTransactionsDataTable());

            bookNames.Add("Clusters");
            bookNames.Add("Person");
            bookNames.Add("Residents");
            bookNames.Add("Employees");
            bookNames.Add("Authorized Users");   
            bookNames.Add("Golf Rounds");
            bookNames.Add("Transactions");

            Export();
        }

        private void Export()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            for (int i = 0; i < dataTables.Count; i++)
                            {
                                workbook.Worksheets.Add(dataTables[i], bookNames[i]);
                            }                            
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

        private DataTable CreateResidentsDataTable()
        {
            // Sets up residents datatable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Cluster", typeof(string)));
            dt.Columns.Add(new DataColumn("Unit Number", typeof(int)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("NoEmail", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone Number", typeof(string)));
            dt.Columns.Add(new DataColumn("CommentBox", typeof(string)));

            foreach (ResidentInfo resident in Database.ResidentInfo)
            {
                string comments;
                if (resident.CommentBox == "")
                {
                    comments = " ";
                }
                else
                {
                    comments = resident.CommentBox;
                }
                dt.Rows.Add(resident.ID, resident.FirstName, resident.LastName, resident.Address, resident.ClusterName, resident.UnitNumber, resident.Email,
                            resident.NoEmail, resident.Phone, comments);
            }
            return dt;
        }

        private DataTable CreateEmployeesDataTable()
        {
            // Sets up employee datatable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("First Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Last Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Is Admin", typeof(string)));
            dt.Columns.Add(new DataColumn("Username", typeof(string)));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));
            dt.Columns.Add(new DataColumn("Is Current", typeof(string)));

            foreach (EmployeeInfo employee in Database.EmployeeInfo)
            {
                dt.Rows.Add(employee.ID, employee.FirstName, employee.LastName, employee.IsAdmin, employee.UserName, employee.Password, employee.IsCurrent);
            }
            return dt;
        }

        private DataTable CreateTransactionsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TransNo", typeof(int)));
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Transaction Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Rounds Changed", typeof(int)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Emailed", typeof(string)));
            dt.Columns.Add(new DataColumn("Employee ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Resident ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));

            foreach (Transaction trans in Database.Transaction)
            {
                dt.Rows.Add(trans.TransNo, trans.DateTime, trans.TypeTrans, trans.RoundsChanged, trans.TotalRounds, trans.EmailedTo, trans.EmployeeID, trans.ResidentID, trans.Comments);
            }
            return dt;
        }

        private DataTable CreateAuthorizedUsersDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("OwnerID", typeof(int)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));

            foreach (AdditionalAuthorizedUsers user in Database.AuthorizedUsers)
            {
                dt.Rows.Add(user.OwnerID, user.FirstName, user.LastName);
            }
            return dt;
        }

        private DataTable CreateClustersDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ClusterName", typeof(string)));

            foreach (Clusters cluster in Database.Clusters)
            {
                dt.Rows.Add(cluster.ClusterName);
            }
            return dt;
        }

        private DataTable CreateGolfRoundsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Years", typeof(int)));
            dt.Columns.Add(new DataColumn("TotalRounds", typeof(int)));
            dt.Columns.Add(new DataColumn("PackageType", typeof(string)));
            dt.Columns.Add(new DataColumn("CostPerRound", typeof(decimal)));

            foreach (GolfRounds round in Database.GolfRounds)
            {
                dt.Rows.Add(round.Year, round.TotalRounds, round.PackageType, round.CostPerRound);
            }
            return dt;
        }

        private DataTable CreatePersonDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));

            foreach (Person person in Database.Person)
            {
                dt.Rows.Add(person.ID, person.FirstName, person.LastName);
            }
            return dt;
        }
    }
}
