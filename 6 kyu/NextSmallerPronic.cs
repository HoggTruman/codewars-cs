// https://www.codewars.com/kata/5a90f6d457c5624ecc000012

namespace NextSmallerPronic;

using System;

public static class Kata
{
    public static ulong NextSmallerPronic(ulong x)
    {
        ulong sqrt = Convert.ToUInt64(Math.Sqrt(x));
        return sqrt * (sqrt - 1);
    }
}
