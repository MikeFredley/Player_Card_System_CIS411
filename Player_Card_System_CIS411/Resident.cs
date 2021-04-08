using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class Resident
    {
        private int Id;
        private string address;
        private string email;
        private string phone;
        private string commentBox;
        private bool noEmail;
        private string clusterName;
        private int unitNumber;
        private string lastTransDate;

        public Resident()
        {
            Id = 0;
            address = "";
            email = "";
            phone = "";
            commentBox = "";
            noEmail = true;
            clusterName = "";
            unitNumber = 0;
            lastTransDate = "";
        }

        public Resident(int pId, string pAddress, string pEmail, string pPhone, string pCommentBox, bool pNoEmail, string pClusterName, int pUnitNumber, string pLastTransDate)
        {
            Id = pId;
            address = pAddress;
            email = pEmail;
            phone = pPhone;
            commentBox = pCommentBox;
            noEmail= pNoEmail;
            clusterName = pClusterName;
            unitNumber = pUnitNumber;
            lastTransDate = pLastTransDate;
        }

        public int ID { get => Id; set => Id = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string CommentBox { get => commentBox; set => commentBox = value; }
        public bool NoEmail { get => noEmail; set => noEmail = value; }
        public string ClusterName { get => clusterName; set => clusterName = value; }
        public int UnitNumber { get => unitNumber; set => unitNumber = value; }
        public string LastTransDate { get =>lastTransDate; set => lastTransDate = value; }
    }
}
