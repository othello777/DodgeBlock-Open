using System;
using System.Windows.Forms;
using DodgeBlockFormsPort;

namespace ConsoleGame
{
    static class Program
    {
        public static Form1 form = new Form1();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(form);
        }
    }
}