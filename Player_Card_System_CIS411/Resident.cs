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
        private string cardRelation;
        private string clusterName;
        private int unitNumber;

        public Resident()
        {
            Id = 0;
            address = "";
            email = "";
            phone = "";
            commentBox = "";
            cardRelation = "";
            clusterName = "";
            unitNumber = 0;
        }

        public Resident(int pId, string pAddress, string pEmail, string pPhone, string pCommentBox, string pCardRelation, string pClusterName, int pUnitNumber)
        {
            Id = pId;
            address = pAddress;
            email = pEmail;
            phone = pPhone;
            commentBox = pCommentBox;
            cardRelation = pCardRelation;
            clusterName = pClusterName;
            unitNumber = pUnitNumber;
        }

        public int ID { get => Id; set => Id = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string CommentBox { get => commentBox; set => commentBox = value; }
        public string CardRelation { get => cardRelation; set => cardRelation = value; }
        public string ClusterName { get => clusterName; set => clusterName = value; }
        public int UnitNumber { get => unitNumber; set => unitNumber = value; }
    }
}
