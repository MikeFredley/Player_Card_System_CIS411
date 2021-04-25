using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player_Card_System_CIS411
{
    public partial class AddCluster : Form
    {
        ManageClusters manageClusters;
        public AddCluster(ManageClusters pManageClusters)
        {
            InitializeComponent();
            manageClusters = pManageClusters;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool clusterCheck = false;
            if (txtAddCluster.Text != "")
            {
                foreach (Clusters cluster in Database.Clusters)
                {
                    if(cluster.ClusterName == txtAddCluster.Text)
                    {
                        Database.UpdateClusters(cluster.ClusterName, false);
                        manageClusters.InitializeDataGridView();
                        MessageBox.Show("Cluster Added!");
                        clusterCheck = true;
                        this.Close();
                        break;
                    }
                }

                if (!clusterCheck)
                {
                    Database.AddCluster(txtAddCluster.Text, false);
                    manageClusters.InitializeDataGridView();
                    MessageBox.Show("Cluster Added!");
                    this.Close();
                }                
            }
            else
            {
                MessageBox.Show("Enter a cluster name");
            }
        }
    }
}
