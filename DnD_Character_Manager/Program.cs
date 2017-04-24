using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Character_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //COMMENT COMMENT 123 BRADLEy DO YoU READ ME?!
            //got the poop, and sent it back
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Main_Menu().Show();
            Application.Run();
        }
    }
}
