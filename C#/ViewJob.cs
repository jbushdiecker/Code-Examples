//LTDesigns - ViewJob.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to view/edit jobs
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
    public partial class ViewJob : Form
    {
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        OleDbConnection myCon;
        public ViewJob()
        {
            InitializeComponent();
        }

        private void ViewJob_Load(object sender, EventArgs e)
        {
            //load in the jobs from the db
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
            }
    


            dataGridView1.DataSource = table;
            dataGridView1.Columns[5].ValueType = typeof(System.DateTime);
            dataGridView1.Columns["ClientName"].HeaderText = "Client";
            dataGridView1.Columns["JobName"].HeaderText = "Job";
            dataGridView1.Columns["JobDate"].HeaderText = "Date";
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns["JobID"].Visible = false;
            dataGridView1.Columns["JobPrice"].Visible = false;
            dataGridView1.Columns["InvoiceNumber"].Visible = false;
            dataGridView1.Columns["JobRemainingBal"].Visible = false;
            dataGridView1.Columns["JobEngineering"].Visible = false;
           

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["JobID"].DisplayIndex = 5;
            dataGridView1.Columns["JobDate"].DisplayIndex = 0;

            DataGridViewColumn c = dataGridView1.Columns[5];
            dataGridView1.Sort(c, ListSortDirection.Descending);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT * FROM Clients";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        da.Fill(table2);
                }

                foreach (DataRow dr in table2.Rows)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalVars.bChanged != true)
            {

                int iNum = dataGridView1.CurrentRow.Index;
                int iID = Convert.ToInt32(dataGridView1.Rows[iNum].Cells[0].FormattedValue.ToString());

                txtJobName.Text = table.Rows[iID - 1][1].ToString();
                txtInvoiceNumber.Text = table.Rows[iID - 1][2].ToString();
                txtPrice.Text = table.Rows[iID - 1][3].ToString();
                cbClient.Text = table.Rows[iID - 1][4].ToString();
                txtDate.Text = table.Rows[iID - 1][5].ToString();
                txtRemainingBal.Text = table.Rows[iID - 1][6].ToString();
                txtEngineering.Text = table.Rows[iID - 1][7].ToString();
              
            }
            else
            {
                if ((MessageBox.Show("Do you want to save the changes", "Save?", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {

                    btnUpdate_Click(null, null);
                    int iNum = dataGridView1.CurrentRow.Index;
                    int iID = Convert.ToInt32(dataGridView1.Rows[GlobalVars.iOldIndex].Cells[0].FormattedValue.ToString());

                    txtJobName.Text = table.Rows[iID - 1][1].ToString();
                    txtInvoiceNumber.Text = table.Rows[iID - 1][2].ToString();
                    txtPrice.Text = table.Rows[iID - 1][3].ToString();
                    cbClient.Text = table.Rows[iID - 1][4].ToString();
                    txtDate.Text = table.Rows[iID - 1][5].ToString();
                    txtRemainingBal.Text = table.Rows[iID - 1][6].ToString();
                    txtEngineering.Text = table.Rows[iID - 1][7].ToString();
                }
                else
                {
                    int iNum = dataGridView1.CurrentRow.Index;
                    int iID = Convert.ToInt32(dataGridView1.Rows[iNum].Cells[0].FormattedValue.ToString());

                    txtJobName.Text = table.Rows[iID - 1][1].ToString();
                    txtInvoiceNumber.Text = table.Rows[iID - 1][2].ToString();
                    txtPrice.Text = table.Rows[iID - 1][3].ToString();
                    cbClient.Text = table.Rows[iID - 1][4].ToString();
                    txtDate.Text = table.Rows[iID - 1][5].ToString();
                    txtRemainingBal.Text = table.Rows[iID - 1][6].ToString();
                    txtEngineering.Text = table.Rows[iID - 1][7].ToString();
                }
            }
            GlobalVars.bChanged = false;
            GlobalVars.iOldIndex = dataGridView1.CurrentRow.Index;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            GlobalVars.ErrorCheck(txtJobName, lbJob);
            GlobalVars.ErrorCheck(cbClient, lbClient);
            GlobalVars.ErrorCheck(txtPrice, lbPrice);
            GlobalVars.ErrorCheck(txtInvoiceNumber, lbInvoice);
            GlobalVars.ErrorCheck(txtEngineering, lbEngineering);
            GlobalVars.ErrorCheck(txtDate, lbDate);

            if (txtJobName.Text == "" || txtEngineering.Text == "" || txtInvoiceNumber.Text == "" || txtPrice.Text == "" || txtDate.Text == "  /  /" || cbClient.Text == "")
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
                int iNum = dataGridView1.CurrentRow.Index;
                int iID = Convert.ToInt32(dataGridView1.Rows[GlobalVars.iOldIndex].Cells[0].FormattedValue.ToString());
                myCon = new OleDbConnection();

               string sDir = Application.StartupPath;
                //MessageBox.Show(iID.ToString());
                myCon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
    "Persist Security Info=False;";
                myCon.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = myCon;

                command.CommandText = "UPDATE Jobs SET JobName=\"" + txtJobName.Text + "\", InvoiceNumber =\"" + txtInvoiceNumber.Text + "\", JobPrice=\"" + txtPrice.Text + "\", ClientName=\"" + cbClient.Text + "\", JobDate=\"" + txtDate.Text + "\", JobRemainingBal=\"" + txtRemainingBal.Text + "\", JobEngineering=\"" + txtEngineering.Text + "\"" +
                    "WHERE JobID = " + (iID).ToString();

                int temp = command.ExecuteNonQuery();

                table.Clear();
                System.Threading.Thread.Sleep(1000);

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
                }



                dataGridView1.DataSource = table;
                dataGridView1.Columns[5].ValueType = typeof(System.DateTime);
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.Columns["JobID"].Visible = false;
                dataGridView1.Columns["JobPrice"].Visible = false;
                dataGridView1.Columns["InvoiceNumber"].Visible = false;
                dataGridView1.Columns["JobRemainingBal"].Visible = false;
                dataGridView1.Columns["JobEngineering"].Visible = false;


                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns["JobID"].DisplayIndex = 5;
                dataGridView1.Columns["JobDate"].DisplayIndex = 0;

                DataGridViewColumn c = dataGridView1.Columns[5];
                dataGridView1.Sort(c, ListSortDirection.Descending);
            }
           
           
            
         
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtJobName_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void cbClient_TextUpdate(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtInvoiceNumber_ValueChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtEngineering_ValueChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtRemainingBal_ValueChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.bChanged = true;
        }
    }
}
