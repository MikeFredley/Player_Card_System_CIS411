using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Player_Card_System_CIS411
{
    public static class Database
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;
        private static List<Person> person;
        private static List<Resident> resident;
        private static List<Transaction> transaction;
        private static List<ResidentInfo> residentInfo;


        static Database()
        {
            connectionString = Properties.Settings.Default.OceanVillagePlayerCardConnectionString;
            person = new List<Person>();
            resident = new List<Resident>();
            transaction = new List<Transaction>();
            residentInfo = new List<ResidentInfo>();
            try
            {
                connection = new SqlConnection(connectionString);
                
                ReadPerson();              
                ReadResident();              
                ReadTransaction();
                Console.WriteLine(transaction[0].DateTime);
                CreateResidentInfo();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void ReadClusters()
        {

        }

        private static void ReadEmployee()
        {

        }

        private static void ReadGolf_Rounds()
        {

        }

        private static void ReadPerson()
        {
            connection.Open();
            string GetPersonSQL = "SELECT ID, FirstName, LastName FROM Person";
            command = new SqlCommand(GetPersonSQL, connection);

            SqlDataReader personReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (personReader.Read())
            {
                Person tempPerson = new Person();
                tempPerson.ID = int.Parse(personReader["ID"].ToString());
                tempPerson.FirstName = personReader["FirstName"].ToString();
                tempPerson.LastName = personReader["LastName"].ToString();
                person.Add(tempPerson);

                tempPerson = null;
            }
            connection.Close();
        }

        private static void ReadResident()
        {
            connection.Open();
            string GetResidentSQL = "SELECT ID, Address, Email, Phone, CommentBox, CardRelation, ClusterName, UnitNumber FROM Resident";
            command = new SqlCommand(GetResidentSQL, connection);

            SqlDataReader residentReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (residentReader.Read())
            {
                Resident tempResident = new Resident();
                tempResident.ID = int.Parse(residentReader["ID"].ToString());
                tempResident.Address = residentReader["Address"].ToString();
                tempResident.Email = residentReader["Email"].ToString();
                tempResident.Phone = residentReader["Phone"].ToString();
                tempResident.CommentBox = residentReader["CommentBox"].ToString();
                tempResident.CardRelation = residentReader["CardRelation"].ToString();
                tempResident.ClusterName = residentReader["ClusterName"].ToString();
                tempResident.UnitNumber = int.Parse(residentReader["UnitNumber"].ToString());
                resident.Add(tempResident);

                tempResident = null;
            }
            connection.Close();
        }

        private static void ReadTransaction()
        {
            connection.Open();
            string GetTransactionSQL = "SELECT TransNo, DateTime, TypeTrans, Reason, TotalRounds, Comments, NoEmail, EmployeeID, ResidentID, CardNo FROM Trans_Action";
            command = new SqlCommand(GetTransactionSQL, connection);

            SqlDataReader transactionReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (transactionReader.Read())
            {
                Transaction tempTransaction = new Transaction();
                tempTransaction.TransNo = int.Parse(transactionReader["TransNo"].ToString());
                tempTransaction.DateTime = transactionReader["DateTime"].ToString();
                tempTransaction.TypeTrans = transactionReader["TypeTrans"].ToString();
                tempTransaction.Reason = transactionReader["Reason"].ToString();
                tempTransaction.TotalRounds = int.Parse(transactionReader["TotalRounds"].ToString());
                tempTransaction.Comments = transactionReader["Comments"].ToString();
                tempTransaction.NoEmail = transactionReader["NoEmail"].ToString();
                tempTransaction.EmployeeID = int.Parse(transactionReader["EmployeeID"].ToString());
                tempTransaction.ResidentID = int.Parse(transactionReader["ResidentID"].ToString());
                tempTransaction.CardNo = int.Parse(transactionReader["CardNo"].ToString());
                transaction.Add(tempTransaction);

                tempTransaction = null;
            }
            connection.Close();
        }

        private static void CreateResidentInfo()
        {
            
            // 69420 FUCK-A-SQL-QUERY BLAZE SHIT LMAO
            for (int i = 0; i < person.Count(); i++)
            {
                for (int j = 0; j < resident.Count(); j++)
                {
                    if (person[i].ID == resident[j].ID)
                    {
                        ResidentInfo tempResInfo = new ResidentInfo();
                        tempResInfo.ID = resident[j].ID;
                        tempResInfo.FirstName = person[i].FirstName;
                        tempResInfo.LastName = person[i].LastName;
                        tempResInfo.ClusterName = resident[j].ClusterName;
                        tempResInfo.UnitNumber = resident[j].UnitNumber;
                        tempResInfo.Email = resident[j].Email;
                        tempResInfo.Phone = resident[j].Phone;

                        residentInfo.Add(tempResInfo);
                        tempResInfo = null;
                    }
                }
            }

            DateTime today = DateTime.Today;
            int result;
            int todayDay = today.DayOfYear;
            int dbDay;

            for (int i = 0; i < residentInfo.Count(); i++)
            {
                for (int j = 0; j < transaction.Count(); j++)
                {
                    if (residentInfo[i].ID == transaction[j].ResidentID)
                    {
                        dbDay = Convert.ToDateTime(transaction[j].DateTime).DayOfYear;
                        result = todayDay - dbDay;
                        result = DateTime.Compare(today, Convert.ToDateTime(transaction[j].DateTime));
                        Console.WriteLine(result);
                    }
                }
            }
        }

        internal static List<ResidentInfo> ResidentInfo { get => residentInfo; set => residentInfo = value; }
    }
}
