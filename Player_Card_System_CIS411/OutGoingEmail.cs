using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class OutGoingEmail
    {
        private string emailAddress;
        private string emailPassword;

        public OutGoingEmail()
        {
            emailAddress = "";
            emailPassword = "";
        }

        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public string EmailPassword { get => emailPassword; set => emailPassword = value; }
    }
}
