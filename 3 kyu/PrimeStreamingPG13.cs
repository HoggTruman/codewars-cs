// https://www.codewars.com/kata/5519a584a73e70fa570005f5

namespace PrimeStreamingPG13;

using System.Collections.Generic;
public class Primes
{
    public static IEnumerable<int> Stream()
    {
        const long n = 20_000_000;
        bool[] isPrime = new bool[n + 1];
        for (long i = 2; i < isPrime.Length; ++i) {
            isPrime[i] = true;
        }            

        for (long p = 2; p <= n; ++p)
        {
            if (isPrime[p])
            {
                yield return (int)p;

                for (long k = p * p; k <= n; k += p) {
                    isPrime[k] = false;
                }
            }
        }
    }
}
