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


            /* pulls the most recent date out of the transaction history or every account
             * 
             * Gets info that looks like this        
             * | DateTime | TotalRounds | ResidentID |
             * |2020-10-12| 1           | 105        |
             * |2020-12-09| 10          | 104        |
             * |2020-12-09| 1           | 103        |
             * 
             */

            List<GetRounds> getRounds = new List<GetRounds>();
            connection.Open();
            string GetTransDateID = "Select DateTime, Trans_Action.TotalRounds, Trans_Action.ResidentID FROM TRANS_ACTION" +
                    " inner join" +
                    "(" +
                        "Select MAX(DateTime) as LatestDate, [ResidentID]" +
                        " FROM TRANS_ACTION" +
                        " group by ResidentID" +
                    ") SubMax" +
                    " on TRANS_ACTION.DateTime = SubMax.LatestDate" +
                    " and TRANS_ACTION.ResidentID = SubMax.ResidentID";

            command = new SqlCommand(GetTransDateID, connection);

            SqlDataReader infoReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Puts info into object list to store it
            while (infoReader.Read())
            {
                GetRounds tempRounds = new GetRounds();
                tempRounds.DateTime = infoReader["DateTime"].ToString();
                tempRounds.Rounds = int.Parse(infoReader["TotalRounds"].ToString());
                tempRounds.ID = int.Parse(infoReader["ResidentID"].ToString());

                getRounds.Add(tempRounds);
                tempRounds = null;
            } 

            // Compares new list by ID with the residentInfo list to get the correct
            // number of rounds for that resident

            foreach (ResidentInfo res in residentInfo)
            {
                for (int i = 0; i < getRounds.Count(); i++)
                {
                    if (res.ID == getRounds[i].ID)
                    {
                        res.CurrentRounds = getRounds[i].Rounds;
                    }
                }
            }
            

            
            /*DateTime today = DateTime.Today;
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
            } */
        }

        internal static List<ResidentInfo> ResidentInfo { get => residentInfo; set => residentInfo = value; }
    }
}
