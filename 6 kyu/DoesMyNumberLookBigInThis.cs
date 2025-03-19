// https://www.codewars.com/kata/5287e858c6b5a9678200083c

using System;

class DoesMyNumberLookBigInThis
{
    public static bool Narcissistic(int value)
    {
        int numDigits = (int)Math.Log10(value) + 1;
        int sum = 0;
        int remaining = value;        

        while (remaining > 0)
        {
            sum += (int)Math.Pow(remaining % 10, numDigits);
            remaining /= 10;
        }

        return sum == value;
    }
}
