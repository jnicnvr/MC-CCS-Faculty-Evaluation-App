using MC_Design.PanelForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Design
{
    static class Program
    {
        public static string globalString = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new panel_getAAPI());
            //Application.Run(new Login());
          
            //Application.Run(new Register());
        }
    }
}
