//LTDesigns - SalesData.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Display info about jobs
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
    public partial class SalesData : Form
    {
        DataTable table = new DataTable();
        public SalesData()
        {
            InitializeComponent();
        }

        private void SalesData_Load(object sender, EventArgs e)
        {
            //fill the datatable with the info from access db
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
            dataGridView1.Columns["JobDate"].ValueType = typeof(System.DateTime);
            
            dataGridView1.Columns["JobID"].Visible = false;
            dataGridView1.Columns["JobEngineering"].Visible = false;
           
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["JobID"].DisplayIndex = 5;
            dataGridView1.Columns["JobDate"].DisplayIndex = 0;

            dataGridView1.Columns["Total"].DisplayIndex = 7;

            dataGridView1.Columns["ClientName"].DisplayIndex = 1;
            dataGridView1.Columns["JobName"].DisplayIndex = 2;
            dataGridView1.Columns["InvoiceNumber"].DisplayIndex = 3;
            dataGridView1.Columns["JobPrice"].DisplayIndex = 4;

            dataGridView1.Columns["InvoiceNumber"].HeaderText = "Invoice \nNumber";
            dataGridView1.Columns["JobDate"].HeaderText = "Date";
            dataGridView1.Columns["ClientName"].HeaderText = "Client";
            dataGridView1.Columns["JobName"].HeaderText = "Job";
            dataGridView1.Columns["JobPrice"].HeaderText = "Price";
            dataGridView1.Columns["JobRemainingBal"].HeaderText = "Remaining \nBalance";
            decimal total = 0.00M;
          
           
            DataGridViewColumn c = dataGridView1.Columns["JobDate"];
            dataGridView1.Sort(c, ListSortDirection.Ascending);

            //calc a running total
            foreach (DataGridViewRow d in dataGridView1.Rows)
            {
                total = total + Convert.ToDecimal(d.Cells[4].Value);
             
                d.Cells["Total"].Value = total.ToString();
      
            }
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);


            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Dont sort plz
           
        }
    }
}
