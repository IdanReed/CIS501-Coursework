using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace State_Diagrams
{

    // Displays a view of the number-guessing game:
    public partial class Form1 : Form
    {

        GameController c;  // holds handle to the controller object (no delegates today, OK?)
        Status state;     // remembers the current state of the game

        public Form1(GameController c)
        {
            this.c = c;
            this.state = Status.Start;
            InitializeComponent();  // constructs the graphical part of the Form
            // set the label on it:
            label1.Text = "Type an int in range 0..10";
        }

        // handles a click of the OK button:
        private void button1_Click(object sender, EventArgs e)
        {
            
            Tuple<Status, int> pair = c.handle(textBox1.Text);
            state = pair.Item1;    // remember the new state of the game
            int num = pair.Item2;  // a number computed by the controller
            int m = 0;
            // FINISH ME
            switch (state)
            {
                case Status.Start:
                    label1.Text = "Guess an int, M, in range 0..10:  M = ";
                    break;
                case Status.HaveMN:
                    label1.Text = "I guessed N. Now you type an int, P, such that M + N + P = 10:  P =";
                    break;
                case Status.Lose:
                    label1.Text = "You lose";
                    break;
                case Status.Win:
                    label1.Text = "You win";
                    break;
                 
            }
        }
        /*
         *Console.Write("Guess an int, M, in range 0..10:  M = ");
            string m = Console.ReadLine();
            if (Convert.ToInt32(m) > 10)
            {
                Console.WriteLine("Out of range");
                Console.ReadLine();
                return;
            }
            int max = 10 - Convert.ToInt32(m);
            
            Console.WriteLine("I guess int, N, in range 0..{0}", max);

            // how to generate random numbers:
            Random r = new Random();
            int min = 0;
            max = 10-Convert.ToInt32(m);
            int n = r.Next(min, max + 1);
            Console.Write(n);
            Console.Write("now you type an int, P, such that M + N + P = 10:  P =" );
            string p = Console.ReadLine();
            int sum = Convert.ToInt32(m) + Convert.ToInt32(n) + Convert.ToInt32(p);
            Console.WriteLine(sum);

            if (sum == 10)
            {
                Console.WriteLine("You win!");
            }else
            {
                Console.WriteLine("You lose!");
            } 
         */

    }
}
