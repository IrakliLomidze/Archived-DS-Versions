using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NGEN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1.CurrentDir = Environment.CurrentDirectory;
            Form1.DotNetFrameworkDir = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v2.0.50727";
            Form1.TempDir  = Environment.GetEnvironmentVariable("TEMP");
            
            Form1.Build = 447;
                                                                                
            if (args.Length > 0)
            {
                if (args[0].ToUpper() == @"-Install".ToUpper()) Form1.DoInstall();
                if (args[0].ToUpper() == @"-Update".ToUpper()) Form1.DoUpdate();
                if (args[0].ToUpper() == @"-Delete".ToUpper()) Form1.DoUninstall();
                return;   
            }
            else
            {
                Application.Run(new Form1());
            }
 
            
        }
    }
}