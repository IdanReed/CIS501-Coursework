using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimeNumbers
{
    using R1;
    using R2;
    using R3;
    class Program
    {
        static void Main(string[] args)
        {
            char cont = 'y';
            while(cont == 'Y' || cont == 'y')
            {
                Console.WriteLine();
                Console.WriteLine("Enter a number");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] primeNumbers = GeneratePrimesR3.GeneratePrimeNumbers(n);

                StringBuilder s = new StringBuilder();
                foreach(int p in primeNumbers)
                {
                    s.Append(p + " ");
                }
                Console.Write(s.ToString());
                Console.WriteLine();
                Console.WriteLine("Continue?");
                cont = Console.ReadKey().KeyChar;
            }
        }
    }
}
