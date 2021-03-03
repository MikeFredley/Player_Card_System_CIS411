using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class Transaction
    {
        private int transNo;
        private string whoEntered;
        private string dateTime;
        private string typeTrans;
        private string reason;
        private int totalRounds;
        private string comments;
        private string noEmail;
        private int employeeID;
        private int residentID;
        //private int cardNo; ????

        public Transaction()
        {
            transNo = 0;
            whoEntered = "";
            dateTime = "";
            typeTrans = "";
            reason = "";
            totalRounds = 0;
            comments = "";
            noEmail = "";
            employeeID = 0;
            residentID = 0;
        }

        public int TransNo { get => transNo; set => transNo = value; }
        public string WhoEntered { get => whoEntered; set => whoEntered = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
        public string TypeTrans { get => typeTrans; set => typeTrans = value; }
        public string Reason { get => reason; set => reason = value; }
        public int TotalRounds { get => totalRounds; set => totalRounds = value; }
        public string Comments { get => comments; set => comments = value; }
        public string NoEmail { get => noEmail; set => noEmail = value; }
        private int EmployeeID { get => employeeID; set => employeeID = value; }
        private int ResidentID { get => residentID; set => residentID = value; }

    }
}
