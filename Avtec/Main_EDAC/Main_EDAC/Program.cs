using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Logger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static System.Threading.Thread tst = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new frmStart());
            Application.Run(new frmMain());
            //Application.Run(new frmConf());
            //Application.Run(new frmAbout());
		
                    
        }
        //public static void ThreadProc()
        //{
        //    Application.Run(new frmStart());
        //}
       
    }
}
