using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Coupling_MVC_CardConcepts;

namespace Coupling_MVC_Deal
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

            // WRITE ME: CONSTRUCT MODEL OBJECTS
            Deck d = new Deck();
            Hand h = new Hand();
            //           CONSTRUCT CONTROLLER
            GameController controller = new GameController(d, h);
            //           FINISH CODE IN INPUT VIEW
            //           CONSTRUCT VIEWS
            ScoreForm scoreForm = new ScoreForm(h);
            MainForm mainForm = new MainForm(controller.handle, h);
            //           REGISTER VIEWS WITH CONTROLLER
            controller.register(mainForm.showCards);
            controller.register(scoreForm.showScore);
            //           START THE SYSTEM
            scoreForm.Show();
            Application.Run(mainForm);

            //MessageBox.Show("Click to exit.", "Exit");
        }
    }
}
