using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2
{
    public class GeneratePrimesR2
    {
        private static bool[] f;
        private static int[] primes;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];

            }
            else
            {
                Initialize(maxValue);
                Sieve();
                LoadPrimes();

                return primes;
            }
        }

        private static void LoadPrimes()
        {
            int i;
            int j;
            // how many primes are there?
            int count = 0;
            for (i = 0; i < f.Length; i++)
            {
                if (f[i])
                    count++; //bump count.
            }

            primes = new int[count];

            //move the primes into the result
            for (i = 0, j = 0; i < f.Length; i++)
            {
                if (f[i]) //if prime
                    primes[j++] = i;
            }
        }

        private static void Sieve()
        {
            int i;
            int j;
            // sieve
            for (i = 2; i < Math.Sqrt(f.Length) + 1; i++)
            {
                if (f[i]) //if i is uncrossed, cross its multiples
                {
                    for (j = 2 * i; j < f.Length; j += i)
                        f[j] = false; // multiple is not prime
                }
            }
        }

        private static void Initialize(int maxValue)
        {

            //declarations
            f = new bool[maxValue + 1];

            // get rid of known non-primes
            f[0] = f[1] = false;

            // initialize array to true
            for (int i = 0; i < f.Length; i++)
                f[i] = true;

            
        }
    }
}
