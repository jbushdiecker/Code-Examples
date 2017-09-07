//LTDesigns - Contracts.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Allow user to generate a contract for a job
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Microsoft.Office.Core;
using word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Data.OleDb;

namespace LTDesigns
{
    public partial class Contracts : Form
    {
        DataTable table = new DataTable();
        public Contracts()
        {
            InitializeComponent();
        }

        private void Contracts_Load(object sender, EventArgs e)
        {
            // fills the cb with the job and client names
            string sDir = Application.StartupPath;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDir + "\\Clients.accdb;" +
"Persist Security Info=False;";  
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT JobName, ClientName, JobPrice, JobEngineering FROM Jobs";
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
               // comboBox1.Items.Add(sClient + ": " + sJob); 
                comboBox1.Items.Add(new ComboItem(sClient + ": " + sJob, iIndex));
                iIndex++;
                    
          

            }
            comboBox1.Sorted = true;

        }
        private void FindAndReplace(word.Application WordApp, object findText, object replaceWithText)
        {
            //replaces tags in the word doc with info about the job
            object matchcase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute (ref findText, ref matchcase, ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            //make sure they made a choice
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please pick a job", "Error!");
                return;

            }
            //new combo item object
            ComboItem ci = (ComboItem)comboBox1.Items[comboBox1.SelectedIndex];
  

            string sFile = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Word Document (*.doc)|*.doc|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
             //open template, fill in info, save
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sFile = saveFileDialog1.FileName;

                    Microsoft.Office.Interop.Word.Application oWord = new word.Application();
                    object missing = System.Reflection.Missing.Value;
                    object isVisible = false;
                    word._Document oDoc;
                    object filename = Application.StartupPath + "\\contract.doc";

                    oDoc = oWord.Documents.Open(ref filename, ref missing, ref missing, ref missing,
                     ref missing, ref missing, ref missing, ref missing,
                     ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing);
                    oDoc.Activate();
                    this.FindAndReplace(oWord, "<name>", table.Rows[ci.iVal - 1]["ClientName"].ToString());
                    this.FindAndReplace(oWord, "<price>", table.Rows[ci.iVal - 1]["JobPrice"].ToString());
                    this.FindAndReplace(oWord, "<down>", ((Convert.ToDecimal(table.Rows[ci.iVal - 1]["JobPrice"])) / 2).ToString());
                    this.FindAndReplace(oWord, "<final>", ((Convert.ToDecimal(table.Rows[ci.iVal - 1]["JobPrice"])) / 2).ToString());

                    this.FindAndReplace(oWord, "<engineering>", table.Rows[ci.iVal - 1]["JobEngineering"].ToString());

                    oDoc.SaveAs(sFile, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing);
                    oDoc.Close(ref missing, ref missing, ref missing);
                    oWord.Application.Quit(ref missing, ref missing, ref missing);
                }
                catch
                {
                    MessageBox.Show("Invalid filename", "Error");
                }
            }
        }
        
    }
    public class ComboItem : Object
    {
        public string sName;
        public int iVal;
        public ComboItem(string name, int iInValue)
        {
            sName = name;
            iVal = iInValue;
        }
        public override string ToString()
        {
            return sName;
        }
        
    }
}
