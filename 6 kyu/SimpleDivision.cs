// https://www.codewars.com/kata/59ec2d112332430ce9000005

namespace SimpleDivision;

using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static bool Solve(int a, int b)
    {
        return GetPrimeFactors(b).All(x => a % x == 0);
    }

    public static HashSet<int> GetPrimeFactors(int n)
    {
        HashSet<int> factors = [];

        if (n % 2 == 0)
        {
            factors.Add(2);
            do
            {
                n /= 2;
            } while (n % 2 == 0);
        }

        for (int k = 3; k * k <= n; k += 2)
        {
            if (n % k == 0)
            {
                factors.Add(k);
                do
                {
                    n /= k;
                } while (n % k == 0);
            }
        }

        if (n > 2)
        {
            factors.Add(n);
        }

        return factors;
    }
}
