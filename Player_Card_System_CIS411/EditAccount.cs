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
    public partial class EditAccount : Form
    {
        public EditAccount(bool isEdit, int ID)
        {
            InitializeComponent();
            if(!isEdit)
            {
                this.Text = "Add Account";
                txtFirstName.ReadOnly = false;
                txtFirstName.Text = "";
                txtLastName.ReadOnly = false;
                txtLastName.Text = "";
                cmbCluster.Enabled = true;
                txtUnit.ReadOnly = false;
                txtUnit.Text = "";
                txtEmail.ReadOnly = false;
                txtEmail.Text = "";
                txtPhone.ReadOnly = false;
                txtPhone.Text = "";
                txtID.ReadOnly = false;
                txtID.Text = "";
                btnTransHistory.Visible = false;
                pictureBox1.Visible = false;
                btnAddRounds.Visible = false;
            }
            else
            {
                /*for (int i = 0; i < Database.ResidentInfo.Count; i++)
                {
                    if (Database.ResidentInfo[i].ID == ID )
                    {
                        txtID.Text = Database.ResidentInfo[i].ID.ToString();
                        txtFirstName.Text = Database.ResidentInfo[i].FirstName;
                        txtLastName.Text = Database.ResidentInfo[i].LastName;
                        cmbCluster.Text = Database.ResidentInfo[i].ClusterName;
                        txtUnit.Text = Database.ResidentInfo[i].UnitNumber.ToString();
                        txtEmail.Text = Database.ResidentInfo[i].Email;
                        txtPhone.Text = Database.ResidentInfo[i].Phone;
                    }
                } */
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnAddRounds_Click(object sender, EventArgs e)
        {

        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            cmbCluster.Enabled = true;
            txtUnit.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
                
            btnEditInfo.Visible = false;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            cmbCluster.Enabled = false;
            txtUnit.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;

            btnEditInfo.Visible = true;
            btnSave.Visible = false;
        }
    }
}
