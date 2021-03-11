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
    public partial class AddRounds : Form
    {
        DataTable dt;
        public AddRounds()
        {
            InitializeComponent();
        }

        private void InitializeDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year", typeof(string)));
            dt.Columns.Add(new DataColumn("Total Rounds", typeof(int)));
            dt.Columns.Add(new DataColumn("Package Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost Per Round", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Total Cost", typeof(decimal)));

            DataGridViewButtonColumn addRoundsButton = new DataGridViewButtonColumn();
            addRoundsButton.HeaderText = "Add Rounds";
            addRoundsButton.Name = "btnAddRounds";
            addRoundsButton.Text = "Add Rounds";
            addRoundsButton.UseColumnTextForButtonValue = true;


        }
    }
}
