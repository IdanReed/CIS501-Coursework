using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces_CardConcepts;

namespace Interfaces_Controller_Form
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // allocate model (entity) objects and the controller:
            Hand h = new Hand(); Deck d = new Deck();
            GameController c = new GameController(d, h);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(c, h));
        }
    }
}
