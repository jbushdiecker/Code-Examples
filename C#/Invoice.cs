//LTDesigns - Invoice.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to create an invoice for a job
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;

using Excel = Microsoft.Office.Interop.Excel;


using System.Windows.Forms;

namespace LTDesigns
{
    public partial class Invoice : Form
    {
        DataTable table = new DataTable();
        public Invoice()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            //check the users data entry
            if (txtAmount.Text == "" || txtDescription.Text == "" || cbJob.Text == "")
            {
                MessageBox.Show("Please make sure all fields are filled", "Error");
            }
            else
            {
                ComboItem ci = (ComboItem)cbJob.Items[cbJob.SelectedIndex];
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                string sFile = "";
                saveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                //open the template, put data in cells, save
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sFile = saveFileDialog1.FileName;

                        object missing = System.Reflection.Missing.Value;
                        var m_InputWorkSheetName = Application.StartupPath + "\\invoice.xlsx";

                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(m_InputWorkSheetName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                        Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                        string currentSheet = "Invoice";

                        Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
                        Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("E7", "E7");
                        excelCell.Value2 = table.Rows[ci.iVal - 1]["ClientName"].ToString();

                        Excel.Range excelDes = (Excel.Range)excelWorksheet.get_Range("B14, B14");
                        excelDes.Value2 = txtDescription.Text;

                        Excel.Range excelAmount = (Excel.Range)excelWorksheet.get_Range("E14, E14");
                        excelAmount.Value2 = txtAmount.Text;

                        Excel.Range excelinvoice = (Excel.Range)excelWorksheet.get_Range("E3, E3");
                        excelinvoice.Value2 = table.Rows[ci.iVal - 1]["InvoiceNumber"].ToString();

                        Excel.Range excelfor = (Excel.Range)excelWorksheet.get_Range("E5", "E5");
                        excelfor.Value2 = table.Rows[ci.iVal - 1]["JobName"].ToString();

                        excelWorkbook.SaveAs(sFile, Excel.XlFileFormat.xlWorkbookDefault, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
                        excelWorkbook.Close(missing, missing, missing);
                        excelApp.Application.Quit();
                    }
                    catch
                    {
                        MessageBox.Show("Invalid filename", "Error!");
                    }
                }
            }
     
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            //fill the cb with the job info
            string sDir = Application.StartupPath;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
"Persist Security Info=False;";
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT JobName, ClientName, InvoiceNumber FROM Jobs";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        da.Fill(table);
                }
            }
            int iIndex = 1;
            foreach (DataRow dr in table.Rows)
            {
                string sJob = dr["JobName"].ToString();
                string sClient = dr["ClientName"].ToString();
              
                cbJob.Items.Add(new ComboItem(sClient + ": " + sJob, iIndex));
                iIndex++;

            }
            cbJob.Sorted = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

     
        
    }

}
