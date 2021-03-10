using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class Employee
    {
        private int Id;
        private bool isAdmin;
        private string username;
        private string password;
        private bool isCurrent;


        public Employee()
        {
            Id = 0;
            IsAdmin = false;
            username = "";
            password = "";
            isCurrent = false;
        }

        public int ID { get => Id; set => Id = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool IsCurrent { get => isCurrent; set => isCurrent = value; }

    }
}
