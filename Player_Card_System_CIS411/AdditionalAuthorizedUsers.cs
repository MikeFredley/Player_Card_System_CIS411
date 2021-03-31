using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class AdditionalAuthorizedUsers
    {
        int ownerID;
        string firstName;
        string lastName;

        public AdditionalAuthorizedUsers()
        {
            ownerID = 0;
            firstName = "";
            lastName = "";
        }

        public int OwnerID { get => ownerID; set => ownerID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
