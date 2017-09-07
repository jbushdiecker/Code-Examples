//LTDesigns - Main.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to choose what they want to do
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace LTDesigns
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnAddClients_Click(object sender, EventArgs e)
        {
            AddClient f = new AddClient();
            f.Show();
        }

        private void btnViewClients_Click(object sender, EventArgs e)
        {
            ViewClients v = new ViewClients();
            v.Show();


        }

        private void btnAddJobs_Click(object sender, EventArgs e)
        {
            Addjob a = new Addjob();
            a.Show();

        }

        private void btnViewJobs_Click(object sender, EventArgs e)
        {
            ViewJob v = new ViewJob();
            v.Show();
            
        
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            Contracts c = new Contracts();
            c.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice();
            i.Show();
        }

        private void btnSalesData_Click(object sender, EventArgs e)
        {
            SalesData s = new SalesData();
            s.Show();
        }
    }
}
