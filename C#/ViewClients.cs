//LTDesigns - ViewClients.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to view/edit a client
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data.OleDb;

namespace LTDesigns
{
    public partial class ViewClients : Form
    {
        DataTable table = new DataTable();
        OleDbConnection myCon;
        public ViewClients()
        {
            InitializeComponent();
        }

        private void ViewClients_Load(object sender, EventArgs e)
        {
            //load in all the clients form the db
            string sDir = Application.StartupPath;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
"Persist Security Info=False;";
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT * FROM Clients";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        da.Fill(table);
                }
            }
            dataGridView1.DataSource = table;
         
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns["ClientStreet"].Visible = false;
            dataGridView1.Columns["ClientCity"].Visible = false;
            dataGridView1.Columns["ClientState"].Visible = false;
            dataGridView1.Columns["ClientZIP"].Visible = false;
            dataGridView1.Columns["ClientPhone"].Visible = false;
            dataGridView1.Columns["ClientID"].Visible = false;

            dataGridView1.Columns["ClientFirstName"].HeaderText = "First Name";
            dataGridView1.Columns["ClientLastName"].HeaderText = "Last Name";

            dataGridView1.RowHeadersVisible = false;

            foreach (DataRow dr in table.Rows)
            {
                string iClientID = dr["ClientID"].ToString();
                if (Convert.ToInt32(iClientID) > GlobalVars.iID)
                {
                    GlobalVars.iID = Convert.ToInt32(iClientID);
                }
            }

            DataGridViewColumn c = dataGridView1.Columns[2];
            dataGridView1.Sort(c, ListSortDirection.Ascending);


            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            GlobalVars.bChanged = false;
            dataGridView1.Sort(c, ListSortDirection.Ascending);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // fill the form objects when the select a client, check if they want to save changes
            int iNum = dataGridView1.CurrentRow.Index;
            int iID = Convert.ToInt32(dataGridView1.Rows[iNum].Cells[0].FormattedValue.ToString());

            if (GlobalVars.bChanged != true)
            {


                try
                {
                    txtFirst.Text = table.Rows[iID - 1][1].ToString();
                    txtLast.Text = table.Rows[iID - 1][2].ToString();
                    txtStreet.Text = table.Rows[iID - 1][3].ToString();
                    txtCity.Text = table.Rows[iID - 1][4].ToString();
                    txtState.Text = table.Rows[iID - 1][5].ToString();
                    txtZip.Text = table.Rows[iID - 1][6].ToString();
                    txtPhone.Text = table.Rows[iID - 1][7].ToString();

                }
                catch (Exception ex)
                {
                }
            }
            else
            {

                //if ((MessageBox.Show("Do you want to save the changes", "Save?", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                //{

                //    btnUpdate_Click(null, null);

                //    txtFirst.Text = table.Rows[iID - 1][1].ToString();
                //    txtLast.Text = table.Rows[iID - 1][2].ToString();
                //    txtStreet.Text = table.Rows[iID - 1][3].ToString();
                //    txtCity.Text = table.Rows[iID - 1][4].ToString();
                //    txtState.Text = table.Rows[iID - 1][5].ToString();
                //    txtZip.Text = table.Rows[iID - 1][6].ToString();
                //    txtPhone.Text = table.Rows[iID - 1][7].ToString();
                //}
                //else
                //{
                //    txtFirst.Text = table.Rows[iID - 1][1].ToString();
                //    txtLast.Text = table.Rows[iID - 1][2].ToString();
                //    txtStreet.Text = table.Rows[iID - 1][3].ToString();
                //    txtCity.Text = table.Rows[iID - 1][4].ToString();
                //    txtState.Text = table.Rows[iID - 1][5].ToString();
                //    txtZip.Text = table.Rows[iID - 1][6].ToString();
                //    txtPhone.Text = table.Rows[iID - 1][7].ToString();
                //}
            }
            GlobalVars.iOldIndex2 = dataGridView1.CurrentRow.Index;
            GlobalVars.bChanged = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { 
            //check the users data
            
            GlobalVars.ErrorCheck(txtFirst, lbFirst);
            GlobalVars.ErrorCheck(txtLast, lbLast);
            GlobalVars.ErrorCheck(txtStreet, lbStreet);
            GlobalVars.ErrorCheck(txtCity, lbCity);
            GlobalVars.ErrorCheck(txtPhone, lbPhone);
            GlobalVars.ErrorCheck(txtState, lbState);
            GlobalVars.ErrorCheck(txtZip, lbZip);


            if (txtFirst.Text == "" || txtLast.Text == "" || txtCity.Text == "" || txtPhone.Text == "(   )    -" || txtStreet.Text == "" || txtState.Text == "" || txtZip.Text == "")
            {
                MessageBox.Show("Please make sure all fields are filled", "Error");

            }
            else
            {
                //save the changes into the db
                myCon = new OleDbConnection();
                int iNum = dataGridView1.CurrentRow.Index;
                int iID = Convert.ToInt32(dataGridView1.Rows[GlobalVars.iOldIndex2].Cells[0].FormattedValue.ToString());

                string sDir = Application.StartupPath;
                //MessageBox.Show(iID.ToString());
                myCon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
    "Persist Security Info=False;";
                myCon.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = myCon;

                command.CommandText = "UPDATE Clients SET ClientFirstName=\"" + txtFirst.Text + "\", ClientLastName =\"" + txtLast.Text + "\", ClientStreet=\"" + txtStreet.Text + "\", ClientCity=\"" + txtCity.Text + "\", ClientState=\"" + txtState.Text + "\", ClientZip=\"" + txtZip.Text + "\", ClientPhone=\"" + txtPhone.Text + "\"" +
                    "WHERE ClientID = " + (iID).ToString();

                int temp = command.ExecuteNonQuery();

                table.Clear();
                System.Threading.Thread.Sleep(1000);

                string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
"Persist Security Info=False;";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    string query = @"SELECT * FROM Clients";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                            da.Fill(table);
                    }
                }
                dataGridView1.DataSource = table;

               // dataGridView1.AutoResizeColumns(
                  //  DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.Columns["ClientStreet"].Visible = false;
                dataGridView1.Columns["ClientCity"].Visible = false;
                dataGridView1.Columns["ClientState"].Visible = false;
                dataGridView1.Columns["ClientZIP"].Visible = false;
                dataGridView1.Columns["ClientPhone"].Visible = false;
                dataGridView1.Columns["ClientID"].Visible = false;

                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns["ClientFirstName"].HeaderText = "First Name";
                dataGridView1.Columns["ClientLastName"].HeaderText = "Last Name";

                foreach (DataRow dr in table.Rows)
                {
                    string iClientID = dr["ClientID"].ToString();
                    if (Convert.ToInt32(iClientID) > GlobalVars.iID)
                    {
                        GlobalVars.iID = Convert.ToInt32(iClientID);
                    }
                }

                DataGridViewColumn c = dataGridView1.Columns[2];
                dataGridView1.Sort(c, ListSortDirection.Ascending);
               // dataGridView1.AutoResizeColumns(
                   // DataGridViewAutoSizeColumnsMode.AllCells);
                
            }  
        }
        //tag that user made changes
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtState_TextUpdate(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            GlobalVars.bChanged = true;   
        }
    }
}
