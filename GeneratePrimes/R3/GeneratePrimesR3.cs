using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3
{
    public class GeneratePrimesR3
    {
        private static bool[] isCrossed;
        private static int[] primes;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];

            }
            else
            {
                InitializeArrayOfBooleans(maxValue);
                CrossOutMultiples();
                LoadPrimes();

                return primes;
            }
        }

        private static void LoadPrimes()
        {
            int i;
            int j;
            // how many primes are there?
            int count = PutUncrossedIntegersIntoResult();

            primes = new int[count];

            //move the primes into the result
            for (i = 0, j = 0; i < isCrossed.Length; i++)
            {
                if (!isCrossed[i]) //if prime
                    primes[j++] = i;
            }
        }

        private static int PutUncrossedIntegersIntoResult()
        { 
            int count = 0;
            for (int i = 0; i < isCrossed.Length; i++)
            {
                if (!isCrossed[i])
                    count++; //bump count.
            }
            return count;
        }

        private static void CrossOutMultiples()
        {
            int i;
            int j;
            int maxValue =(int) Math.Sqrt(isCrossed.Length) + 1;
            // sieve
            for (i = 2; i < maxValue; i++)
            {
                if (!isCrossed[i]) //if i is uncrossed, cross its multiples
                {
                    j = CrossOutMultiplesOf(i);
                }
            }
        }

        private static int CrossOutMultiplesOf(int i)
        {
            int j;
            for (j = 2 * i; j < isCrossed.Length; j += i)
                isCrossed[j] = true; // multiple is not prime
            return j;
        }

        private static void InitializeArrayOfBooleans(int maxValue)
        {

            //declarations
            isCrossed = new bool[maxValue + 1];

            // get rid of known non-primes
            isCrossed[0] = isCrossed[1] = true;

            // initialize array to true
            for (int i = 2; i < isCrossed.Length; i++)
                isCrossed[i] = false;


        }
    }
}
