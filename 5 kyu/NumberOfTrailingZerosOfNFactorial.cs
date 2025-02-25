// https://www.codewars.com/kata/52f787eb172a8b4ae1000a34

namespace NumberOfTrailingZerosOfNFactorial;

public static class Kata 
{
    public static int TrailingZeros(int n)
    {
        int fiveFactorCount = 0;
        for (int d = 5; d <= n; d *= 5)
        {
            fiveFactorCount += n / d;
        }

        return fiveFactorCount;
    }
}
