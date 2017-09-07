//LTDesigns - LTDesigns.cs
//Created by J. Bushdiecker
//Created on 10/22/12
//(c) Copyright 2012, P.I.R.A.T.E
//Purpose - Runs the program
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;

namespace LTDesigns
{
    static class LTDesigns
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
