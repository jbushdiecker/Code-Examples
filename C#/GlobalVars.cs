//LTDesigns - GlobalVars.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - hold global variables
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LTDesigns
{
    class GlobalVars
    {
        public static int iID = 0;
        public static int iOldIndex = 0;
        public static int iOldIndex2 = 0;
        public static int iJobID = 0;
        public static int iInvoice = 0;
        public static bool bChanged = false;


        public static bool ErrorCheck(System.Windows.Forms.TextBox tb, System.Windows.Forms.Label lb)
        {
            if (tb.Text == "")
            {
                lb.ForeColor = System.Drawing.Color.Red;
                tb.Focus();
                return true;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Black;
                return false;
            }
        }

        public static bool ErrorCheck(System.Windows.Forms.MaskedTextBox tb, System.Windows.Forms.Label lb)
        {
            if (tb.Text == "(   )    -" || tb.Text == "" || tb.Text == "  /  /")
            {
                lb.ForeColor = System.Drawing.Color.Red;
                tb.Focus();
                return true;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Black;
                return false;
            }
        }
        public static bool ErrorCheck(System.Windows.Forms.NumericUpDown tb, System.Windows.Forms.Label lb)
        {
            if (tb.Text == "(   )    -" || tb.Text == "" || tb.Text == "  /  /")
            {
                lb.ForeColor = System.Drawing.Color.Red;
                tb.Focus();
                return true;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Black;
                return false;
            }
        }
        public static bool ErrorCheck(System.Windows.Forms.ComboBox tb, System.Windows.Forms.Label lb)
        {
            if (tb.Text == "")
            {
                lb.ForeColor = System.Drawing.Color.Red;
                tb.Focus();
                return true;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Black;
                return false;
            }
        }
    }
}
