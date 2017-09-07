//LTDesigns - Addjob.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to add a job into the data base
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
    public partial class Addjob : Form
    {
        private OleDbConnection myCon;
        DataTable table = new DataTable();
        public Addjob()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check for data, highlight red where not entered
            GlobalVars.ErrorCheck(txtJobName, lbJob);
            GlobalVars.ErrorCheck(cbClient, lbClient);
            GlobalVars.ErrorCheck(txtPrice, lbPrice);
            GlobalVars.ErrorCheck(txtInvoiceNumber, lbInvoice);
            GlobalVars.ErrorCheck(txtEngineering, lbEngineering);
            GlobalVars.ErrorCheck(txtDate, lbDate);


            if (txtJobName.Text == "" || txtEngineering.Text == "" || txtInvoiceNumber.Text == "" || txtPrice.Text == "" || txtDate.Text == "  /  /" || cbClient.Text =="")
            {
                MessageBox.Show("Please make sure all fields are filled", "Error");
            }
            else
            {
                try
                {
                    Convert.ToDateTime(txtDate.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid date", "Error!");
                    txtDate.Clear();
                    txtDate.Focus();
                    return;

                }
                //open db connection
            
                myCon = new OleDbConnection();
                string sDir = Application.StartupPath;

                myCon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
    "Persist Security Info=False;";
                myCon.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = myCon;

                command.CommandText = "INSERT INTO Jobs" + "([JobID], [JobName], [InvoiceNumber], [JobPrice], [ClientName], [JobDate], [JobRemainingBal], [JobEngineering]) " +
                    " VALUES (" + (GlobalVars.iJobID + 1).ToString() + ",\"" + txtJobName.Text + "\",\"" +
                    txtInvoiceNumber.Text + "\",\"" + txtPrice.Text + "\",\"" +
                    cbClient.Text + "\",\"" + txtDate.Text + "\",\"" + txtPrice.Text + "\",\"" + txtEngineering.Text + "\")";
              

                int temp = command.ExecuteNonQuery();
          
                myCon.Close();
            }
        }

        private void Addjob_Load(object sender, EventArgs e)
        {
            // fills the client cb and gets the next jobid
            string sDir = Application.StartupPath;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
"Persist Security Info=False;";
       

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT * FROM Jobs";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        da.Fill(table);
                }

           
                foreach (DataRow dr in table.Rows)
                {
                    try
                    {
                        int iJobId = Convert.ToInt32(dr["JobID"].ToString());
                        int iInvoice = Convert.ToInt32(dr["InvoiceNumber"].ToString());
                        if (iJobId > GlobalVars.iJobID)
                        {
                            GlobalVars.iJobID = Convert.ToInt32(iJobId);
                       
                        }
                        if (iInvoice > GlobalVars.iInvoice)
                        {
                            GlobalVars.iInvoice = iInvoice;
                        }



                    }
                        
                    catch (Exception e1)
                    {
                    
                    }
                }

                txtInvoiceNumber.Value = (GlobalVars.iInvoice + 1);
            }
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT * FROM Clients";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        da.Fill(table);
                }

                foreach (DataRow dr in table.Rows)
                {
                    string name = dr["ClientFirstName"].ToString();
                    string name2 = dr["ClientLastName"].ToString();
                    if (name + name2 != "")
                    {
                    cbClient.Items.Add(name + " " + name2);
                    }
                }


            }

        }

        private void txtDate_MouseClick(object sender, MouseEventArgs e)
        {
            // fixes the mtb annoyance
            if (txtDate.Text == "  /  /")
            {
                txtDate.SelectionStart = 0;
                txtDate.SelectionLength = 0;
                txtDate.Select();
            }
        }

        private void txtDate_Validating(object sender, CancelEventArgs e)
        {
           
            
        }
    }
}
