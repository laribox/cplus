﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CompetencePlus;

namespace CompetencePlusForm
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
           
          
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MenuApplication());
          
            
           
        }
    }
}
