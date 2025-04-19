// https://www.codewars.com/kata/56060ba7b02b967eb1000013/

namespace RaiseMeToTheThirdPower;

using System;
using System.Collections.Generic;
using System.Linq;

public class ThirdPow 
{
    private static List<long> Cache = [6];

    public static long IntCubeSumDiv(long n)
    {
        if (Cache.Count >= n)
        {
            return Cache[(int)n - 1];
        }

        long k = Cache.Last() + 1;

        while (Cache.Count < n)
        {
            if (k * k * k % GetDivisorSum(k) == 0)
            {
                Cache.Add(k);
            }

            ++k;
        }

        return Cache[(int)n - 1];
    }

    public static long GetDivisorSum(long n)
    {
        long sum = 0;
        double sqrt = Math.Sqrt(n);

        for (long k = 1; k < sqrt; ++k)
        {
            if (n % k == 0)
            {
                sum += k + n / k;                                
            }
        }

        if (sqrt % 1 == 0)
        {
            sum += (long)sqrt;
        }

        return sum;
    }
}
