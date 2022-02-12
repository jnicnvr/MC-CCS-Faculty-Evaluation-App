using MC_Design.PanelForms.sub_panels;
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

          // Application.Run(new panel_getAAPI());
            Application.Run(new Login());
            //Application.Run(new add_panel_subject());
            //  Application.Run(new panel_subjects());

            // Application.Run(new panel_faculty());

            //Application.Run(new panel_sy());
            //Application.Run(new panel_student());

            //Application.Run(new panel_notification());


            //Application.Run(new panel_classes());
            //Application.Run(new show_evaluation_restriction());
            //Application.Run(new manage_evaluation());

            //  Application.Run(new add_panel_faculty());
            //Application.Run(new add_panel_subject());
            //Application.Run(new add_panel_classes());
            //Application.Run(new add_school_year());

            // Application.Run(new manage_sy());

            //Application.Run(new Register());
          // Application.Run(new Form1());
        }
    }
}
