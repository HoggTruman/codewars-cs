// https://www.codewars.com/kata/621f89cc94d4e3001bb99ef4

namespace DontGiveMeFiveReally;

using System;

public static class Kata
{
    // counts[i] contains the count of numbers with a 5 from 0 to 10^i - 1 (e.g. 0-9, 0-99, etc...)
    private static ulong[] counts = [];

    public static ulong DontGiveMeFive(long start, long end)
    {
        int maxPow = Math.Max((int)Math.Log10(Math.Abs(start)), 
                              (int)Math.Log10(Math.Abs(end)));

        counts = new ulong[maxPow + 2];
        counts[1] = 1;
        for (int i = 2; i < counts.Length; ++i)
        {
            counts[i] = 9 * counts[i - 1] + (ulong)Math.Pow(10, i - 1);
        }

        ulong total = (ulong)(end - start + 1);

        if (start >= 0 && end >= 0)
            return total - (CountNumbersWith5((ulong)end) - CountNumbersWith5((ulong)Math.Max(0, start - 1)));

        if (start < 0 && end < 0)
            return total - (CountNumbersWith5((ulong)-start) - CountNumbersWith5((ulong)-end - 1));

        return total - CountNumbersWith5((ulong)end) - CountNumbersWith5((ulong)-start);
    }


    private static ulong CountNumbersWith5(ulong n)
    {
        if (n < 5)
        {
            return 0;
        }

        int maxPow = (int)Math.Log10(n);
        ulong powerTen = (ulong)Math.Pow(10, maxPow);
        ulong leadingDigit = n / powerTen;

        if (leadingDigit < 5)
            return leadingDigit * counts[maxPow] + CountNumbersWith5(n % powerTen);

        if (leadingDigit == 5)
            return leadingDigit * counts[maxPow] + n % powerTen + 1;

        return (leadingDigit - 1) * counts[maxPow] + powerTen + CountNumbersWith5(n % powerTen);
    }
}
