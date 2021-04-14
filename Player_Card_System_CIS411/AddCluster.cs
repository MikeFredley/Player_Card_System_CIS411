﻿using System;
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
            if (txtAddCluster.Text != "")
            {
                if(Database.AddCluster(txtAddCluster.Text, false))
                {
                    MessageBox.Show("Cluster Added!");
                    manageClusters.InitializeDataGridView();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add cluster");
                }
            }
            else
            {
                MessageBox.Show("Enter a cluster name");
            }
        }
    }
}
