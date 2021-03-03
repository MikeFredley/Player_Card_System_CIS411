using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Player_Card_System_CIS411
{
    class Database
    {
        private string connectionString;
        private SqlCommand command;
        private SqlConnection connection;
        private List<Person> person;
        private List<Resident> resident;
        private List<ResidentInfo> residentInfo;

        public Database()
        {
            connectionString = Properties.Settings.Default.OceanVillagePlayerCardConnectionString;
            person = new List<Person>();
            resident = new List<Resident>();
            residentInfo = new List<ResidentInfo>();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                ReadPerson();
                connection.Open();
                ReadResident();

                Console.WriteLine("Person: " + person.Count());
                Console.WriteLine("Resident: " + resident.Count());
                
                CreateResidentInfo();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ReadClusters()
        {

        }

        private void ReadEmployee()
        {

        }

        private void ReadGolf_Rounds()
        {

        }

        private void ReadPerson()
        {
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

        private void ReadResident()
        {
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

        private void ReadTransaction()
        {

        }

        private void CreateResidentInfo()
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
        }

        public List<ResidentInfo> ResidentInfo { get => residentInfo; set => residentInfo = value; }
    }
}
