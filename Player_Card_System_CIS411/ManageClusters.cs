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
    public partial class ManageClusters : Form
    {
        int dgvIndex;
        AdminWindow adminWindow;
        public ManageClusters(AdminWindow pAdminWindow)
        {
            InitializeComponent();
            InitializeDataGridView();
            adminWindow = pAdminWindow;
        }

        internal void InitializeDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cluster Name", typeof(string)));
            
            foreach (Clusters cluster in Database.Clusters)
            {
                if (!cluster.IsDeleted)
                {
                    dt.Rows.Add(cluster.ClusterName);
                }             
            }

            dgvClusters.DataSource = dt;
            dgvClusters.ReadOnly = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete the selected cluster?", "Warning", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                foreach (Clusters cluster in Database.Clusters)
                {
                    if (cluster.ClusterName == dgvClusters.Rows[dgvIndex].Cells[0].Value.ToString())
                    {
                        Database.UpdateClusters(cluster.ClusterName, true);
                        break;
                    }
                }
                InitializeDataGridView();
            }
            
        }

        private void dgvClusters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvIndex = e.RowIndex;
        }

        private void ManageClusters_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminWindow.OpenWindow = false;
            adminWindow.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCluster add = new AddCluster(this);
            add.Show();
        }
    }
}
