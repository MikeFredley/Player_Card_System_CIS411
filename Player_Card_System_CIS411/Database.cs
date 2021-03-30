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
        private static List<Employee> employee;
        private static List<Transaction> transaction;
        private static List<ResidentInfo> residentInfo;
        private static List<Clusters> clusters;
        private static List<GolfRounds> golfRounds;
        private static List<AdditionalAuthorizedUsers> authorizedUsers;
        private static EmployeeInfo loggedInEmployee;
        private static List<EmployeeInfo> employeeInfo;
        private static OutGoingEmail outGoingEmail;

        static Database()
        {
            connectionString = Properties.Settings.Default.OceanVillagePlayerCardConnectionString;
            person = new List<Person>();
            resident = new List<Resident>();
            transaction = new List<Transaction>();
            residentInfo = new List<ResidentInfo>();
            employee = new List<Employee>();
            clusters = new List<Clusters>();
            golfRounds = new List<GolfRounds>();
            authorizedUsers = new List<AdditionalAuthorizedUsers>();
            employeeInfo = new List<EmployeeInfo>();
            outGoingEmail = new OutGoingEmail();
            try
            {
                connection = new SqlConnection(connectionString);

                ReadOutGoingEmail();
                ReadPerson();              
                ReadResident();              
                ReadTransaction();             
                CreateResidentInfo();
                connection.Close();
                ReadEmployee();
                ReadClusters();
                ReadGolf_Rounds();
                ReadAdditionalAuthorizedUsers();
                CreateEmployeeInfo();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void ReadOutGoingEmail()
        {       
            connection.Open();
            string GetEmailSQL = "SELECT EmailAddress, EmailPassword FROM Outgoing_Email";
            command = new SqlCommand(GetEmailSQL, connection);

            SqlDataReader emailReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (emailReader.Read())
            {
                outGoingEmail.EmailAddress = emailReader["EmailAddress"].ToString();
                outGoingEmail.EmailPassword = emailReader["EmailPassword"].ToString();
            }
            connection.Close();
        }

        // Method to read from the Clusters Table
        private static void ReadClusters()
        {
            clusters.Clear();
            connection.Open();
            string GetClustersSQL = "Select ClusterName FROM Clusters";
            command = new SqlCommand(GetClustersSQL, connection);

            SqlDataReader clustersReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (clustersReader.Read())
            {
                Clusters tempCluster = new Clusters();
                tempCluster.ClusterName = clustersReader["ClusterName"].ToString();
                clusters.Add(tempCluster);

                tempCluster = null;
            }
            connection.Close();
        }

        // Method to read from the Employee table
        private static void ReadEmployee()
        {
            connection.Close();
            employee.Clear();
            connection.Open();
            string GetEmployeeSQL = "SELECT ID, IsAdmin, UserName, Password, IsCurrent FROM Employee";
            command = new SqlCommand(GetEmployeeSQL, connection);

            SqlDataReader employeeReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (employeeReader.Read())
            {
                Employee tempEmployee = new Employee();
                tempEmployee.ID = int.Parse(employeeReader["ID"].ToString());
                tempEmployee.IsAdmin = Convert.ToBoolean(employeeReader["IsAdmin"]);
                tempEmployee.Username = employeeReader["UserName"].ToString();
                tempEmployee.Password = employeeReader["Password"].ToString();
                tempEmployee.IsCurrent = Convert.ToBoolean(employeeReader["IsCurrent"]);
                employee.Add(tempEmployee);

                tempEmployee = null;
            }
            connection.Close();
        }

        private static void ReadGolf_Rounds()
        {
            golfRounds.Clear();
            connection.Open();
            string GetGolfRoundsSQL = "SELECT Years, TotalRounds, PackageType, CostPerRound FROM Golf_Rounds";
            command = new SqlCommand(GetGolfRoundsSQL, connection);

            SqlDataReader golfRoundsReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (golfRoundsReader.Read())
            {
                GolfRounds tempRounds = new GolfRounds();
                tempRounds.Year = golfRoundsReader["Years"].ToString();
                tempRounds.TotalRounds = int.Parse(golfRoundsReader["TotalRounds"].ToString());
                tempRounds.PackageType = golfRoundsReader["PackageType"].ToString();
                tempRounds.CostPerRound = Convert.ToDecimal(golfRoundsReader["CostPerRound"].ToString());
                golfRounds.Add(tempRounds);

                tempRounds = null;
            }
            connection.Close();
        }


        // Method to read form the Person table
        private static void ReadPerson()
        {
            person.Clear();
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

        // Method to read of the Resident Table
        private static void ReadResident()
        {
            resident.Clear();
            connection.Open();
            string GetResidentSQL = "SELECT ID, Address, Email, Phone, CommentBox, NoEmail, ClusterName, UnitNumber FROM Resident";
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
                tempResident.NoEmail = Convert.ToBoolean(residentReader["NoEmail"]);
                tempResident.ClusterName = residentReader["ClusterName"].ToString();
                tempResident.UnitNumber = int.Parse(residentReader["UnitNumber"].ToString());
                resident.Add(tempResident);

                tempResident = null;
            }
            connection.Close();
        }

        // Method to read from the Transaction table
        private static void ReadTransaction()
        {
            transaction.Clear();
            connection.Open();
            string GetTransactionSQL = "SELECT TransNo, DateTime, TypeTrans, TotalRounds, Comments, EmailedTo, EmployeeID, ResidentID FROM Trans_Action";
            command = new SqlCommand(GetTransactionSQL, connection);

            SqlDataReader transactionReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (transactionReader.Read())
            {
                Transaction tempTransaction = new Transaction();
                tempTransaction.TransNo = int.Parse(transactionReader["TransNo"].ToString());
                tempTransaction.DateTime = transactionReader["DateTime"].ToString();
                tempTransaction.TypeTrans = transactionReader["TypeTrans"].ToString();
                tempTransaction.TotalRounds = int.Parse(transactionReader["TotalRounds"].ToString());
                tempTransaction.Comments = transactionReader["Comments"].ToString();
                tempTransaction.EmailedTo = transactionReader["EmailedTo"].ToString();
                tempTransaction.EmployeeID = int.Parse(transactionReader["EmployeeID"].ToString());
                tempTransaction.ResidentID = int.Parse(transactionReader["ResidentID"].ToString());
                transaction.Add(tempTransaction);

                tempTransaction = null;
            }
            connection.Close();
        }

        // Creates the resident info list that combines info from the
        // Person, Resident, and Transaction Tables
        private static void CreateResidentInfo()
        {
            residentInfo.Clear();
            // Combines the needed information from the 
            // Person and Resident tables into one list
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
                        tempResInfo.CommentBox = resident[j].CommentBox;
                        tempResInfo.NoEmail = resident[j].NoEmail;
                        tempResInfo.Address = resident[j].Address;

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
            connection.Close();
        }

        private static void CreateEmployeeInfo()
        {
            // Does the same thing as residentInfo
            // just for the employees
            employeeInfo.Clear();
            for (int i = 0; i < person.Count; i++)
            {
                for (int j = 0; j < employee.Count; j++)
                {
                    if (person[i].ID == employee[j].ID)
                    {
                        EmployeeInfo tempEmployeeInfo = new EmployeeInfo();
                        tempEmployeeInfo.ID = employee[j].ID;
                        tempEmployeeInfo.FirstName = person[i].FirstName;
                        tempEmployeeInfo.LastName = person[i].LastName;
                        tempEmployeeInfo.IsAdmin = employee[j].IsAdmin;
                        tempEmployeeInfo.UserName = employee[j].Username;
                        tempEmployeeInfo.Password = employee[j].Password;
                        tempEmployeeInfo.IsCurrent = employee[j].IsCurrent;

                        employeeInfo.Add(tempEmployeeInfo);
                        tempEmployeeInfo = null;
                    }
                }
            }
        }

        internal static void SetOutGoingEmail(string emailAddress, string emailPassword)
        {
            connection.Open();
            string InsertEmailSQL = "INSERT INTO Outgoing_Email (EmailAddress, EmailPassword) " +
                                    "VALUES (@pEmailAddress, @pEmailPassword)";
            command = new SqlCommand(InsertEmailSQL, connection);

            try
            {
                command.Parameters.AddWithValue("@pEmailAddress", emailAddress);
                command.Parameters.AddWithValue("@pEmailPassword", PasswordEncrypt.hash(emailPassword));
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Outgoing Email Added");
                }
                else
                {
                    Console.WriteLine("Failed to Add Outgoing Email");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Insert Outgoing Email " + ex.Message);
            }
            connection.Close();
            ReadOutGoingEmail();
        }

        internal static void ChangeOutGoingEmailPassword(string newPassword)
        {
            connection.Open();
            string updateEmailPasswordSQL = "UPDATE OutGoing_Email " +
                                            "SET EmailPassword = @pEmailPassword " +
                                            "WHERE EmailAddress = @pEmailAddress";
            command = new SqlCommand(updateEmailPasswordSQL, connection);

            try
            {
                command.Parameters.AddWithValue("@pEmailAddress", outGoingEmail.EmailAddress);
                command.Parameters.AddWithValue("@pEmailPassword", PasswordEncrypt.hash(newPassword));
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Outgoing Email Password Changed!");
                    connection.Close();
                    ReadOutGoingEmail();
                }
                else
                {
                    Console.WriteLine("Failed to Change Outgoing Email Password");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Change Outgoing Email Password " + ex.Message);
            }
            connection.Close();
        }

        // Method to write new lines to the Transaction database
        internal static void SubmitTransaction(Transaction newTransaction)
        {
            connection.Open();
            string InsertTransactionSQL = "INSERT INTO Trans_Action (DateTime, TypeTrans, TotalRounds, EmailedTo, Comments, EmployeeID, ResidentID) " +
                                          "VALUES (@pDateTime, @pTypeTrans, @pTotalRounds, @pEmailedTo, @pComments, @pEmployeeID, @pResidentID)";
            command = new SqlCommand(InsertTransactionSQL, connection);

            try
            {
                DateTime date = DateTime.Now;
                command.Parameters.AddWithValue("@pDateTime", date);
                command.Parameters.AddWithValue("@pTypeTrans", newTransaction.TypeTrans);
                command.Parameters.AddWithValue("@pTotalRounds", newTransaction.TotalRounds);
                command.Parameters.AddWithValue("@pEmailedTo", newTransaction.EmailedTo);
                command.Parameters.AddWithValue("@pComments", newTransaction.Comments);
                command.Parameters.AddWithValue("@pEmployeeID", newTransaction.EmployeeID);
                command.Parameters.AddWithValue("@pResidentID", newTransaction.ResidentID);

                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Transaction Added");                   
                }
                else
                {
                    Console.WriteLine("Transaction Failed");
                }
                connection.Close();
                ReadTransaction();
                CreateResidentInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Insert Data " + ex.Message);
            }
        }

        // Updates the person and resident tables for the edit account window
        // I feel like most of this is self explanatory at this point
        internal static void UpdateResidentPersonTable(int resIndex)
        {
            connection.Open();
            string UpdateResidentSQL = "UPDATE Resident " +
                                       "SET Address = @pAddress, Email = @pEmail, Phone = @pPhone, NoEmail = @pNoEmail, CommentBox = @pCommentBox, " +
                                       "ClusterName = @pClusterName, UnitNumber = @pUnitNumber " + 
                                       "WHERE ID = @pID";
            command = new SqlCommand(UpdateResidentSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pID", residentInfo[resIndex].ID);
                command.Parameters.AddWithValue("@pAddress", residentInfo[resIndex].Address);
                command.Parameters.AddWithValue("@pEmail", residentInfo[resIndex].Email);
                command.Parameters.AddWithValue("@pPhone", residentInfo[resIndex].Phone);
                command.Parameters.AddWithValue("@pNoEmail", ResidentInfo[resIndex].NoEmail.ToString());
                command.Parameters.AddWithValue("@pCommentBox", residentInfo[resIndex].CommentBox);
                command.Parameters.AddWithValue("@pClusterName", residentInfo[resIndex].ClusterName);
                command.Parameters.AddWithValue("@pUnitNumber", residentInfo[resIndex].UnitNumber);

                int rowsAffected = command.ExecuteNonQuery(); 
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Resident Updated");
                }
                else
                {
                    Console.WriteLine("Resident Update Failed");
                }              
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could Not Update Resident Data" + ex.Message);
            }

            string UpdatePersonSQL = "UPDATE Person " +
                                     "SET FirstName = @pFirstName, LastName = @pLastName " +
                                     "WHERE ID = @pID";
            command = new SqlCommand(UpdatePersonSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pID", residentInfo[resIndex].ID);
                command.Parameters.AddWithValue("@pFirstName", residentInfo[resIndex].FirstName);
                command.Parameters.AddWithValue("@pLastName", residentInfo[resIndex].LastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Person Updated");
                }
                else
                {
                    Console.WriteLine("Person Update Failed");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could Not Update Person Data " + ex.Message);
            }
            connection.Close();
        }

        internal static int AddResident(ResidentInfo newResident)
        {
            // Add first name and last name to person table
            connection.Open();
            string InsertToPersonSQL = "INSERT INTO Person (FirstName, LastName) " +
                                       "VALUES (@pFirstName, @pLastName)";
            command = new SqlCommand(InsertToPersonSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pFirstName", newResident.FirstName);
                command.Parameters.AddWithValue("@pLastName", newResident.LastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Inserted New Person");
                }
                else
                {
                    Console.WriteLine("New Person Insert Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Insert Into Person " + ex.Message);
            }
            connection.Close();

            // Read from person table to get the new ID where the name was added
            ReadPerson();
            int ID = 0;
            bool canContinue = false;
            for (int i = 0; i < person.Count; i++)
            {
                if (person[i].FirstName == newResident.FirstName && person[i].LastName == newResident.LastName)
                {
                    ID = person[i].ID;
                    canContinue = true;
                }
            }

            // use that ID and insert rest of information into Resident table
            if (canContinue)
            {
                connection.Open();
                string InsertToResidentSQL = "INSERT INTO Resident (ID, Address, Email, Phone, CommentBox, UnitNumber, NoEmail, ClusterName) " +
                                             "VALUES (@pID, @pAddress, @pEmail, @pPhone, @pCommentBox, @pUnitNumber, @pNoEmail, @pClusterName) ";
                                             
                command = new SqlCommand(InsertToResidentSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@pID", ID);
                    command.Parameters.AddWithValue("@pAddress", newResident.Address);
                    command.Parameters.AddWithValue("@pEmail", newResident.Email);
                    command.Parameters.AddWithValue("@pPhone", newResident.Phone);
                    command.Parameters.AddWithValue("@pCommentBox", newResident.CommentBox);
                    command.Parameters.AddWithValue("@pUnitNumber", newResident.UnitNumber);
                    command.Parameters.AddWithValue("@pNoEmail", newResident.NoEmail.ToString());
                    command.Parameters.AddWithValue("@pClusterName", newResident.ClusterName);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Inserted New Resident");
                        connection.Close();
                        ReadResident();
                        CreateResidentInfo();
                        return ID;
                    }
                    else
                    {
                        Console.WriteLine("New Resident Insert Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Resident " + ex.Message);
                    connection.Close();
                }
                connection.Close();
            }
            else
            {
                Console.WriteLine("New ID Does Not Exist In Person");
            }
            return 0;
        }

        private static void ReadAdditionalAuthorizedUsers()
        {
            
            connection.Open();
            string ReadAuthorizedUsersSQL = "SELECT OwnerID, FirstName, LastName FROM Additional_Authorized_Users";

            command = new SqlCommand(ReadAuthorizedUsersSQL, connection);

            SqlDataReader authorizedReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            authorizedUsers.Clear();
            while (authorizedReader.Read())
            {
                AdditionalAuthorizedUsers newUser = new AdditionalAuthorizedUsers();
                newUser.OwnerID = int.Parse(authorizedReader["OwnerID"].ToString());
                newUser.FirstName = authorizedReader["FirstName"].ToString();
                newUser.LastName = authorizedReader["LastName"].ToString();
                authorizedUsers.Add(newUser);
                newUser = null;
            }
            connection.Close();
        }

        internal static void AddAuthorizedUser(AdditionalAuthorizedUsers newAuthorizedUser)
        {
            connection.Open();
            string InsertAuthorizedUserSQL = "INSERT INTO Additional_Authorized_Users (OwnerID, FirstName, LastName) " +
                                             "VALUES (@pOwnerID, @pFirstName, @pLastName)";
            command = new SqlCommand(InsertAuthorizedUserSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pOwnerID", newAuthorizedUser.OwnerID);
                command.Parameters.AddWithValue("@pFirstName", newAuthorizedUser.FirstName);
                command.Parameters.AddWithValue("@pLastName", newAuthorizedUser.LastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Inserted New Authorized User");
                    connection.Close();
                    ReadAdditionalAuthorizedUsers();                   
                }
                else
                {
                    Console.WriteLine("New Authorized User Insert Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Insert Into Authorized User " + ex.Message);
            }
            connection.Close();
        }

        internal static void DeleteAuthorizedUser(int pID, string pFirstName, string pLastName)
        {
            connection.Open();
            string DeleteAuthorizedUserSQL = "DELETE FROM ADDITIONAL_AUTHORIZED_USERS " + 
                                             "WHERE OwnerID = @pOwnerID AND FirstName = @pFirstName AND LastName = @pLastName";
            command = new SqlCommand(DeleteAuthorizedUserSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pOwnerID", pID);
                command.Parameters.AddWithValue("@pFirstName", pFirstName);
                command.Parameters.AddWithValue("@pLastName", pLastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Deleted Authorized User");
                    connection.Close();
                    ReadAdditionalAuthorizedUsers();
                }
                else
                {
                    Console.WriteLine("Delete Authorized User Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Delete Authorized User " + ex.Message);
            }
            connection.Close();
        }

        // Everything that has to do with logging in
        internal static bool Login(string pUserName, string pPassword)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID FROM EMPLOYEE WHERE UserName=@UserName AND Password=@Password";
            command.Parameters.AddWithValue("@UserName", pUserName);
            command.Parameters.AddWithValue("@Password", PasswordEncrypt.hash(pPassword));
            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            if (result != null)
            {
                connection.Open();
                command.CommandText = "SELECT ID FROM EMPLOYEE WHERE ID=@pID AND IsCurrent = @pIsCurrent";
                command.Parameters.AddWithValue("@pID", result.ToString());
                command.Parameters.AddWithValue("@pIsCurrent", "True");
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {                   
                    for (int i = 0; i < employeeInfo.Count; i++)
                    {
                        if (employeeInfo[i].ID == int.Parse(result.ToString()))
                        {
                            loggedInEmployee = employeeInfo[i];
                        }
                    }
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                connection.Close();
                return false;
            }
            
        }

        internal static void AddNewEmployee(EmployeeInfo newEmployee)
        {
            // Add new Person
            connection.Open();
            string InsertToPersonSQL = "INSERT INTO Person (FirstName, LastName) " +
                                       "VALUES (@pFirstName, @pLastName)";
            command = new SqlCommand(InsertToPersonSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pFirstName", newEmployee.FirstName);
                command.Parameters.AddWithValue("@pLastName", newEmployee.LastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Inserted New Person");
                }
                else
                {
                    Console.WriteLine("New Person Insert Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Insert Into Person " + ex.Message);
            }
            connection.Close();
            // Read from person to get new ID
            ReadPerson();
            int ID = 0;
            bool canContinue = false;
            for (int i = 0; i < person.Count; i++)
            {
                if (person[i].FirstName == newEmployee.FirstName && person[i].LastName == newEmployee.LastName)
                {
                    ID = person[i].ID;
                    canContinue = true;
                }
            }    
            // Use new ID to add to Employee
            if (canContinue)
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO EMPLOYEE (ID, UserName, Password, IsAdmin, IsCurrent) VALUES (@pID, @pUserName, @pPassword, @pIsAdmin, @pIsCurrent)";
                command.Parameters.AddWithValue("@pID", ID);
                command.Parameters.AddWithValue("@pUserName", newEmployee.UserName);
                command.Parameters.AddWithValue("@pPassword", PasswordEncrypt.hash(newEmployee.Password));
                command.Parameters.AddWithValue("@pIsAdmin", newEmployee.IsAdmin.ToString());
                command.Parameters.AddWithValue("@pIsCurrent", newEmployee.IsCurrent.ToString());
                connection.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Employee Inserted");
                    ReadEmployee();
                    CreateEmployeeInfo();
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Error Adding to Employee");
                    connection.Close();
                }
                connection.Close();
            }
            else
            {
                Console.WriteLine("New ID Does Not Exist In Person");
                connection.Close();
            }
        }

        internal static void UpdateEmployee(int empIndex)
        {
            connection.Open();
            string UpdateEmployeeSQL = "UPDATE Employee " +
                                       "SET IsAdmin = @pIsAdmin, UserName = @pUserName, IsCurrent = @pIsCurrent " +
                                       "WHERE ID = @pID";
            command = new SqlCommand(UpdateEmployeeSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pID", employeeInfo[empIndex].ID);
                command.Parameters.AddWithValue("@pIsAdmin", employeeInfo[empIndex].IsAdmin.ToString());
                command.Parameters.AddWithValue("@pUserName", employeeInfo[empIndex].UserName);
                command.Parameters.AddWithValue("@pIsCurrent", employeeInfo[empIndex].IsCurrent.ToString());

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee Updated");
                }
                else
                {
                    Console.WriteLine("Employee Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Update Employee Data" + ex.Message);
            }


            string UpdatePersonSQL = "UPDATE Person " +
                                     "SET FirstName = @pFirstName, LastName = @pLastName " +
                                     "WHERE ID = @pID";
            command = new SqlCommand(UpdatePersonSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pID", employeeInfo[empIndex].ID);
                command.Parameters.AddWithValue("@pFirstName", employeeInfo[empIndex].FirstName);
                command.Parameters.AddWithValue("@pLastName", employeeInfo[empIndex].LastName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Person Updated");
                }
                else
                {
                    Console.WriteLine("Person Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Update Person Data " + ex.Message);
            }
            connection.Close();
        }

        internal static void ChangePassword(int empIndex, string newPassword)
        {
            connection.Open();
            string UpdateEmployeeSQL = "UPDATE Employee " +
                                       "SET Password = @pPassword " +
                                       "WHERE ID = @pID";
            command = new SqlCommand(UpdateEmployeeSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pID", employeeInfo[empIndex].ID);
                command.Parameters.AddWithValue("@pPassword", PasswordEncrypt.hash(newPassword));

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Password Changed");
                }
                else
                {
                    Console.WriteLine("Password Change Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Change Password" + ex.Message);
            }
            connection.Close();
        }

        internal static bool AddGolfRounds(GolfRounds golfRounds)
        {
            connection.Open();
            string AddGolfRoundsSQL = "INSERT INTO Golf_Rounds " +
                                      "(Years, TotalRounds, PackageType, CostPerRound) " +
                                      "VALUES (@pYears, @pTotalRounds, @pPackageType, @pCostPerRound)";
            command = new SqlCommand(AddGolfRoundsSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pYears", golfRounds.Year);
                command.Parameters.AddWithValue("@pTotalRounds", golfRounds.TotalRounds);
                command.Parameters.AddWithValue("@pPackageType", golfRounds.PackageType);
                command.Parameters.AddWithValue("@pCostPerRound", Convert.ToDecimal(golfRounds.CostPerRound));

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Golf Rounds Added");
                    connection.Close();
                    ReadGolf_Rounds();
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to Add Golf Rounds");
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Add Golf Rounds" + ex.Message);
                connection.Close();
                return false;
            }       
        }

        internal static void DeleteGolfRounds(string pYears, int pTotalRounds, string pPackageType, decimal pCostPerRound)
        {
            connection.Open();
            string DeleteGolfRoundSQL = "DELETE FROM Golf_Rounds " +
                                             "WHERE Years = @pYears AND TotalRounds = @pTotalRounds AND PackageType = @pPackageType AND CostPerRound = @pCostPerRound";
            command = new SqlCommand(DeleteGolfRoundSQL, connection);
            try
            {
                command.Parameters.AddWithValue("@pYears", pYears);
                command.Parameters.AddWithValue("@pTotalRounds", pTotalRounds);
                command.Parameters.AddWithValue("@pPackageType", pPackageType);
                command.Parameters.AddWithValue("@pCostPerRound", pCostPerRound);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Deleted Golf Rounds");
                    connection.Close();
                    ReadGolf_Rounds();
                }
                else
                {
                    Console.WriteLine("Delete Golf Rounds Failed");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could Not Delete Golf Rounds " + ex.Message);
                connection.Close();
            }
        }

        internal static void WipeDatabase()
        {
            connection.Open();
            string WipeDatabaseSQL = "DELETE FROM Trans_Action DELETE FROM ADDITIONAL_AUTHORIZED_USERS DELETE FROM Employee DELETE FROM Resident DELETE FROM Person DELETE FROM GOLF_ROUNDS DELETE FROM Clusters";
            command = new SqlCommand(WipeDatabaseSQL, connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Database Wiped");
                connection.Close();
            }
            else
            {
                Console.WriteLine("Delete Golf Rounds Failed");
            }
            connection.Close();
        }

        internal static void RestoreDatabase(DataTable dt, string dtName)
        {
            //WipeDatabase();
            connection.Open();

            if (dtName == "Person")
            {
                string RestorePersonSQL = "SET IDENTITY_INSERT Person ON; INSERT INTO Person (ID, FirstName, LastName) " +
                                      "VALUES (@pID, @pFirstName, @pLastName)";
                
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(RestorePersonSQL, connection);
                        command.Parameters.AddWithValue("@pID", row["ID"]);
                        command.Parameters.AddWithValue("@pFirstName", row["FirstName"]);
                        command.Parameters.AddWithValue("@pLastName", row["LastName"]);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Inserted New Person");
                        }
                        else
                        {
                            Console.WriteLine("New Person Insert Failed");
                        }
                    }
                    connection.Close();
                    ReadPerson();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Person " + ex.Message);
                }
            }
            else if(dtName == "Authorized Users")
            {
                string RestoreAuthorizedUserSQL = "INSERT INTO Additional_Authorized_Users (OwnerID, FirstName, LastName) " +
                                 "VALUES (@pOwnerID, @pFirstName, @pLastName)";
                
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(RestoreAuthorizedUserSQL, connection);
                        command.Parameters.AddWithValue("@pOwnerID", row["OwnerID"]);
                        command.Parameters.AddWithValue("@pFirstName", row["FirstName"]);
                        command.Parameters.AddWithValue("@pLastName", row["LastName"]);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Inserted New Authorized User");                          
                        }
                        else
                        {
                            Console.WriteLine("New Authorized User Insert Failed");
                        }
                    }
                    connection.Close();
                    ReadAdditionalAuthorizedUsers();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Authorized User " + ex.Message);
                }
            }
            else if (dtName == "Clusters")
            {
                string RestoreClustersSQL = "INSERT INTO Clusters (ClusterName) VALUES (@pClusterName)";
                

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(RestoreClustersSQL, connection);
                        command.Parameters.AddWithValue("@pClusterName", row["ClusterName"]);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Inserted New Cluster");
                        }
                        else
                        {
                            Console.WriteLine("New Cluster Insert Failed");
                        }
                    }
                    connection.Close();
                    ReadClusters();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Clusters " + ex.Message);
                }
            }
            else if(dtName == "Employees")
            {             
                string RestoreEmployeeSQL = "INSERT INTO EMPLOYEE (ID, UserName, Password, IsAdmin, IsCurrent) VALUES (@pID, @pUserName, @pPassword, @pIsAdmin, @pIsCurrent)";
                
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(RestoreEmployeeSQL, connection);
                        command.Parameters.AddWithValue("@pID", row["ID"]);
                        command.Parameters.AddWithValue("@pUserName", row["Username"]);
                        command.Parameters.AddWithValue("@pPassword", row["Password"]);
                        command.Parameters.AddWithValue("@pIsAdmin", row["Is Admin"]);
                        command.Parameters.AddWithValue("@pIsCurrent", row["Is Current"]);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Employee Inserted");
                        }
                        else
                        {
                            Console.WriteLine("Error Adding to Employee");
                        }
                    }
                    connection.Close();
                    ReadEmployee();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Employee " + ex.Message);
                }               
            }
            else if(dtName == "Golf Rounds")
            {
                string AddGolfRoundsSQL = "INSERT INTO Golf_Rounds " +
                          "(Years, TotalRounds, PackageType, CostPerRound) " +
                          "VALUES (@pYears, @pTotalRounds, @pPackageType, @pCostPerRound)";
                
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(AddGolfRoundsSQL, connection);
                        command.Parameters.AddWithValue("@pYears", row["Years"]);
                        command.Parameters.AddWithValue("@pTotalRounds", row["TotalRounds"]);
                        command.Parameters.AddWithValue("@pPackageType", row["PackageType"]);
                        command.Parameters.AddWithValue("@pCostPerRound", row["CostPerRound"]);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Golf Rounds Added");                         
                        }
                        else
                        {
                            Console.WriteLine("Failed to Add Golf Rounds");
                        }
                    }
                    connection.Close();
                    ReadGolf_Rounds();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Add Golf Rounds" + ex.Message);
                }
            }
            else if(dtName == "Residents")
            {
                string InsertToResidentSQL = "INSERT INTO Resident (ID, Address, Email, Phone, CommentBox, UnitNumber, NoEmail, ClusterName) " +
                                             "VALUES (@pID, @pAddress, @pEmail, @pPhone, @pCommentBox, @pUnitNumber, @pNoEmail, @pClusterName) "; 
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(InsertToResidentSQL, connection);
                        command.Parameters.AddWithValue("@pID", row["ID"]);
                        command.Parameters.AddWithValue("@pAddress", row["Address"]);
                        command.Parameters.AddWithValue("@pEmail", row["Email"]);
                        command.Parameters.AddWithValue("@pPhone", row["Phone Number"]);
                        command.Parameters.AddWithValue("@pCommentBox", row["CommentBox"]);
                        command.Parameters.AddWithValue("@pUnitNumber", row["Unit Number"]);
                        command.Parameters.AddWithValue("@pNoEmail", row["NoEmail"]);
                        command.Parameters.AddWithValue("@pClusterName", row["Cluster"]);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Inserted New Resident");
                        }
                        else
                        {
                            Console.WriteLine("New Resident Insert Failed");
                        }
                    }
                    connection.Close();
                    ReadResident();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Into Resident " + ex.Message);
                }
            }
            else if (dtName == "Transactions")
            {
                string InsertTransactionSQL = "INSERT INTO Trans_Action (DateTime, TypeTrans, TotalRounds, EmailedTo, Comments, EmployeeID, ResidentID) " +
                              "VALUES (@pDateTime, @pTypeTrans, @pTotalRounds, @pEmailedTo, @pComments, @pEmployeeID, @pResidentID)";
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        command = new SqlCommand(InsertTransactionSQL, connection);
                        command.Parameters.AddWithValue("@pDateTime", row["Date"]);
                        command.Parameters.AddWithValue("@pTypeTrans", row["Transaction Type"]);
                        command.Parameters.AddWithValue("@pTotalRounds", row["Total Rounds"]);
                        command.Parameters.AddWithValue("@pEmailedTo", row["Emailed"]);
                        command.Parameters.AddWithValue("@pComments", row["Comments"]);
                        command.Parameters.AddWithValue("@pEmployeeID", row["Employee ID"]);
                        command.Parameters.AddWithValue("@pResidentID", row["Resident ID"]);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Transaction Added");
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    connection.Close();
                    ReadTransaction();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Insert Data " + ex.Message);
                }
            }
            connection.Close();
            CreateEmployeeInfo();
            CreateResidentInfo();
        }

        internal static List<ResidentInfo> ResidentInfo { get => residentInfo; set => residentInfo = value; }
        internal static List<Employee> Employee { get => employee; set => employee = value; }
        internal static List<Resident> Resident { get => resident; set => resident = value; }
        internal static List<Transaction> Transaction { get => transaction; set => transaction = value; }
        internal static List<Clusters> Clusters { get => clusters; set => clusters = value; }
        internal static List<Person> Person { get => person; set => person = value; }
        internal static List<GolfRounds> GolfRounds { get => golfRounds; set => golfRounds = value; }
        internal static List<AdditionalAuthorizedUsers> AuthorizedUsers { get => authorizedUsers; set => authorizedUsers = value; }
        internal static EmployeeInfo LoggedInEmployee { get => loggedInEmployee; set => loggedInEmployee = value; }
        internal static List<EmployeeInfo> EmployeeInfo { get => employeeInfo; set => employeeInfo = value; }
        internal static OutGoingEmail OutGoingEmail { get => outGoingEmail; set => outGoingEmail = value; }
    }
}
