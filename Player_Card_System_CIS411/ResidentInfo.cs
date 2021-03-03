﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class ResidentInfo
    {
        private int id;
        private string firstName;
        private string lastName;
        private string clusterName;
        private int unitNumber;
        private string email;
        private string phone;
        private string currentRounds;

        public ResidentInfo()
        {
            id = 0;
            firstName = "";
            lastName = "";
            clusterName = "";
            unitNumber = 0;
            email = "";
            phone = "";
            currentRounds = "";
        }

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string ClusterName { get => clusterName; set => clusterName = value; }
        public int UnitNumber { get => unitNumber; set => unitNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string CurrentRounds { get => currentRounds; set => currentRounds = value; }
    }
}
