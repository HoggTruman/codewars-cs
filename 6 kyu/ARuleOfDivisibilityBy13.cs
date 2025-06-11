// https://www.codewars.com/kata/564057bc348c7200bd0000ff


namespace ARuleOfDivisibilityBy13;

using System.Collections.Generic;
using System.Linq;

public class Thirteen
{    
    public static long Thirt(long n) 
    {
        List<long> sequence = [1, 10, 9, 12, 3, 4];
        long k = n;
        List<long> digitsRtoL = [];

        while (true)
        {
            digitsRtoL = GetDigitsRtoL(k);
            long sum = digitsRtoL.Select((x, i) => x * sequence[i % sequence.Count]).Sum();
            if (sum == k)
            {
                break;
            }
            k = sum;
        }

        return k;
    }

    private static List<long> GetDigitsRtoL(long n)
    {
        List<long> digitsRtoL = [];
        while (n > 0)
        {
            digitsRtoL.Add(n % 10);
            n /= 10;
        }

        return digitsRtoL;
    }
}