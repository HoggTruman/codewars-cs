// https://www.codewars.com/kata/5286b2e162056fd0cb000c20

namespace Collatz;

using System.Collections.Generic;

public class Kata
{
    public static string Collatz(int n)
    {
        List<int> terms = [n];

        while (n != 1)
        {
            n = n % 2 == 0?
                n / 2:
                3 * n + 1;

            terms.Add(n);
        }

        return string.Join("->", terms);
    }
}
