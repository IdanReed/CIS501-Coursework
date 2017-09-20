using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces_CardConcepts;

namespace Interfaces_Delegate_Form
{
    // the Delegate defines a data type for methods:
    public delegate string EventHandler(object sender, EventArgs e);

    static class Program
    {
        /// <summary>
        /// Card game assembly:
        /// </summary>
        [STAThread]
        static void Main()
        {
            // allocate model (entity) objects and the controller:
            Hand h = new Hand();
            Deck d = new Deck();
            GameController c = new GameController(d, h);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // IMPORTANT: note first argument to  new Form1
            // Activate Form and give it handles to the event handler and model:
            Application.Run(new Form1(c.handle, h));
        }
    }
}
