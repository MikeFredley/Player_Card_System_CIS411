using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class Person
    {
        private int Id;
        private string firstName;
        private string lastName;


        public Person()
        {
            ID = 0;
            firstName = "";
            lastName = "";
        }

        public Person(int pID, string pFirstName, string pLastName)
        {
            ID = pID;
            firstName = pFirstName;
            lastName = pLastName;
        }

        public int ID { get => Id; set => Id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
