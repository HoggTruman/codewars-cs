// https://www.codewars.com/kata/55f160df93f61bb26b00002a

namespace TheBIGPronicChallenge;

using System;

public class Kata
{
    public static bool IsPronic(long n)
    {
        if (n < 0)
        {
            return false;
        }

        long sqrt = (long)Math.Sqrt(n);
        return sqrt * (sqrt + 1) == n;
    }
}
