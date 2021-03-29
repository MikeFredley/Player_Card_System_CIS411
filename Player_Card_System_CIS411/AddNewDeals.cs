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
    public partial class AddNewDeals : Form
    {
        ViewGolfRounds viewRounds;
        public AddNewDeals(ViewGolfRounds pViewRounds)
        {
            InitializeComponent();
            viewRounds = pViewRounds;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GolfRounds golfRounds = new GolfRounds();
                golfRounds.Year = txtYear.Text;
                golfRounds.TotalRounds = int.Parse(txtTotalRounds.Text);
                golfRounds.PackageType = txtPackageType.Text;
                golfRounds.CostPerRound = Convert.ToDecimal(txtCostPerRound.Text);

                if (Database.AddGolfRounds(golfRounds))
                {
                    MessageBox.Show("Golf Rounds Added!");
                    viewRounds.RefreshDataGridView();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to Add Rounds");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding Golf Rounds " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewDeals_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewRounds.OpenWindow = false;
            viewRounds.SetRemoveButton(true);
        }
    }
}
