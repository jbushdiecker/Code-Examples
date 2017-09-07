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
    public partial class Form1 : Form
    {
        private OleDbConnection myCon;
        DataTable table = new DataTable();
        public Form1()
        {
           
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text == "" || txtLast.Text == "" || txtCity.Text == "" || txtPhone.Text == "(   )    -" || txtStreet.Text == "" || txtState.Text == "" || txtZip.Text == "")
            {
                MessageBox.Show("Please make sure all fields are filled", "Error");
               
            }
            else
            {
          
                myCon = new OleDbConnection();
                string sDir = Application.StartupPath;

                myCon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
    "Persist Security Info=False;";
                //MessageBox.Show(myCon.ConnectionString.ToString());
                myCon.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = myCon;
                command.CommandText = "INSERT INTO Clients" + "([ClientID], [ClientFirstName], [ClientLastName], [ClientStreet], [ClientCity], [ClientState], [ClientZip], [ClientPhone])" +

                    "VALUES (" + (GlobalVars.iID + 1).ToString() + ",\"" + txtFirst.Text + "\",\"" + txtLast.Text + "\",\"" + txtStreet.Text + "\",\""
                    + txtCity.Text + "\",\"" + txtState.Text + "\",\"" + txtZip.Text + "\",\"" + txtPhone.Text + "\")";

                int temp = command.ExecuteNonQuery();
                if (temp > 0)
                {
                    MessageBox.Show("Record Added");
                }
                else
                {
                    MessageBox.Show("Record not Added");
                }
                myCon.Close();
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            foreach (DataRow dr in table.Rows)
            {
                string iClientID = dr["ClientID"].ToString();
                if (Convert.ToInt32(iClientID) > GlobalVars.iID)
                {
                    GlobalVars.iID = Convert.ToInt32(iClientID);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtZip_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtZip.Text == "")
            {
                txtZip.SelectionStart = 0;
                txtZip.SelectionLength = 0;
                txtZip.Select();

            }
        
        }

        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {

            
            if (txtPhone.Text == "(   )    -")
            {
                
                txtPhone.SelectionStart = 0;
                txtPhone.SelectionLength = 0;
                txtPhone.Select();
            }
        }
    }
}
