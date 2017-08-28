using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_VS_GitHub
{
    class Program
    {

        // Welcomes the user, you need to add ", welcome to CIS501"
        // so the output be for example: Hello Jorge, welcome to CIS501!
        static void Main(string[] args)
        {
            Console.Write("Type your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "!");


            // retain command window till user presses Enter
            Console.ReadLine();
        }
    }
}
