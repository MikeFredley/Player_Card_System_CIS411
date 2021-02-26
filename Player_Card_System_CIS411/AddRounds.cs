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
        public AddRounds()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRounds_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oceanVillagePlayerCardDataSet.PERSON' table. You can move, or remove it, as needed.
         //   this.pERSONTableAdapter.Fill(this.oceanVillagePlayerCardDataSet.PERSON);
            // TODO: This line of code loads data into the 'oceanVillagePlayerCardDataSet.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.oceanVillagePlayerCardDataSet.EMPLOYEE);

        }
    }
}
