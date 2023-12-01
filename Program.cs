using System;
using System.Windows.Forms;

namespace RecinosGameOfLife
{
    class Program
    {


        /*

        Important Information: The mouse can be used to toggle cells on and off or create cells once you erase the universe by clicking clear. 
        Or the grid may be reset at your whim, randomly of course.

        */

        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Game());
        }
    }
}
