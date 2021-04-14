using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class Clusters
    {
        private string clusterName;
        private bool isDeleted;

        public Clusters()
        {
            clusterName = "";
            isDeleted = false;
        }

        public string ClusterName { get => clusterName; set => clusterName = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
    }
}
