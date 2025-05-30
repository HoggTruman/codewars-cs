// https://www.codewars.com/kata/526d84b98f428f14a60008da

namespace HammingNumbers;

using System.Linq;

public class Hamming
{
    public static long hamming(int n)
    {
        long[] hammingNumbers = [1, ..new long[n - 1]];
        int[] primes = [2, 3, 5];
        // index of the next hamming number to try multiplying the corresponding prime with
        int[] powers = [0, 0, 0];
        long[] nextOptions = [2, 3, 5];

        for (int i = 1; i < n; ++i)
        {
            hammingNumbers[i] = nextOptions.Min();
            for (int j = 0; j < nextOptions.Length; ++j)
            {
                if (nextOptions[j] == hammingNumbers[i])
                {
                    ++powers[j];
                    nextOptions[j] = hammingNumbers[powers[j]] * primes[j];
                }
            }
        }

        return hammingNumbers[n - 1];        
    }
}
