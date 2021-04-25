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
        private string dateTime;
        private string typeTrans;
        private int totalRounds;
        private string comments;
        private string emailedTo;
        private int employeeID;
        private int residentID;
        private int roundsChanged;
        private int oldBalanace;
        private string empFirstName;
        private string empLastName;
        private string resFirstName;
        private string resLastName;

        public Transaction()
        {
            transNo = 0;
            dateTime = "";
            typeTrans = "";
            totalRounds = 0;
            comments = "";
            emailedTo = "";
            employeeID = 0;
            residentID = 0;
            roundsChanged = 0;
            oldBalanace = 0;
            empFirstName = "";
            empLastName = "";
            resFirstName = "";
            resLastName = "";
        }

        public Transaction(string pTypeTrans,int pRoundsChanged, int pOldBalance, int pTotalRounds, string pEmailedTo, int pEmployeeID, int pResidentID, string pComments)
        {
           // dateTime =DateTime.Now
            typeTrans = pTypeTrans;
            totalRounds = pTotalRounds;
            comments = pComments;
            emailedTo = pEmailedTo;
            employeeID = pEmployeeID;
            residentID = pResidentID;
            roundsChanged = pRoundsChanged;
            oldBalanace = pOldBalance;
        }

        public int TransNo { get => transNo; set => transNo = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
        public string TypeTrans { get => typeTrans; set => typeTrans = value; }
        public int RoundsChanged { get => roundsChanged; set => roundsChanged = value; }
        public int TotalRounds { get => totalRounds; set => totalRounds = value; }
        public string Comments { get => comments; set => comments = value; }
        public string EmailedTo { get => emailedTo; set => emailedTo = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public int ResidentID { get => residentID; set => residentID = value; }
        public int OldBalance { get => oldBalanace; set => oldBalanace = value; }
        public string EmpFirstName { get => empFirstName; set => empFirstName = value; }
        public string EmpLastName { get => empLastName; set => empLastName = value; }
        public string ResFirstName { get => resFirstName; set => resFirstName = value; }
        public string ResLastName { get => resLastName; set => resLastName = value; }
    }
}
