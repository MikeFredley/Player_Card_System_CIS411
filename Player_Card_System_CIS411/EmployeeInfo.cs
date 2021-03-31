using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class EmployeeInfo
    {
        private int id;
        private string firstName;
        private string lastName;
        private bool isAdmin;
        private string userName;
        private string password;
        private bool isCurrent;

        public EmployeeInfo()
        {
            id = 0;
            firstName = "";
            lastName = "";
            isAdmin = false;
            userName = "";
            password = "";
            isCurrent = false;
        }

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public bool IsCurrent { get => isCurrent; set => isCurrent = value; }
    }
}
