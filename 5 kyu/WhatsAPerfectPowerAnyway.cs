// https://www.codewars.com/kata/54d4c8b08776e4ad92000835

namespace WhatsAPerfectPowerAnyway;

using System;
using System.Collections.Generic;
using System.Linq;

public class PerfectPower
{
    public static (int, int)? IsPerfectPower(int n)
    {
        if (n == 0 || n == 1)
        {
            return null;
        }

        var factorCounts = GetPrimeFactors(n);
        var countsPrimeFactors = factorCounts.Select(x => GetPrimeFactors(x.Value).Keys);
        int exp = countsPrimeFactors
            .Aggregate(new HashSet<int>(countsPrimeFactors.First()), (acc, x) => { acc.IntersectWith(x); return acc; })
            .FirstOrDefault();

        if (exp != 0)
        {
            int m = factorCounts.Aggregate(1, (acc, x) => acc * Convert.ToInt32(Math.Pow(x.Key, x.Value / exp)));
            return (m, exp);
        }

        return null;
    }


    private static Dictionary<int, int> GetPrimeFactors(int n)
    {
        if (n == 0)
        {
            return [];
        }

        Dictionary<int, int> factors = [];

        while (n % 2 == 0)
        {
            factors[2] = factors.TryGetValue(2, out int count)? count + 1: 1;
            n /= 2;
        }

        for (int k = 3; k * k <= n; k += 2)
        {
            while (n % k == 0)
            {
                factors[k] = factors.TryGetValue(k, out int count)? count + 1: 1;
                n /= k;
            }
        }

        if (n > 2)
        {
            factors[n] = 1;
        }

        return factors;
    }
}
