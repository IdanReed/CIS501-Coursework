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
            Console.Write("Guess an int, M, in range 0..10:  M = ");
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
            

            // retain command window till user presses Enter
            Console.ReadLine();
        }
    }
}
