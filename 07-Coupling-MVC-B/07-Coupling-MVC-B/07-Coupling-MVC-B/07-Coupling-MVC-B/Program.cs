using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Coupling_MVC_CardConcepts;

namespace Coupling_MVC_B
{
    // defines the type of method that observes model updates:
    public delegate void Observer();
    // defines the type of method that handles an input event (button press):
    public delegate void InputHandler(object sender, EventArgs e);

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* TO DO:
             *    (i) construct an  OutcomeForm object and connect in to the system.  Run it.
             *    (ii) reconfigure the system so that the newly coded  handle2  method
             *         in GameController is executed when the button is pressed.  Run it.
             *    (iii) remove the ScoreForm from the system.  Run it.
             *    QUESTION:  DID YOU CHANGE ANY CODE ANYWHERE ELSE THAN HERE, IN Main ?
             */
            Deck d = new Deck();
            Hand h = new Hand();
            GameController c = new GameController(d, h);

            ScoreForm score = new ScoreForm(h);
            score.Show();   // shows the passive output Form on the display

            MainForm mainform = new MainForm(c.handle, h);
            c.register(score.showScore);
            c.register(mainform.showCards);

            Application.Run(mainform);  // Run  mainform  to receive the input events that
            //   trigger computation.
            MessageBox.Show("Click to exit.", "Exit");
        }
    }
}
