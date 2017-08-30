using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_SoftwareArch_Console
{
    class Program
    {

        // echos the user's name and prints a randomly chosen int:
        static void Main(string[] args)
        {
            Console.Write("Type your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");

            // how to generate random numbers:
            Random r = new Random();
            int min = 0;
            int max = 99;
            int n = r.Next(min, max + 1);

            Console.WriteLine("Here is a random generated number between {0} to {1}: {2}", min, max, n);

            // retain command window till user presses Enter
            Console.ReadLine();
        }
    }
}
