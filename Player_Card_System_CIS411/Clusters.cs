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

        public Clusters()
        {
            clusterName = "";
        }

        public string ClusterName { get => clusterName; set => clusterName = value; }
    }
}
