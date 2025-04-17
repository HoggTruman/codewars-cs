// https://www.codewars.com/kata/526571aae218b8ee490006f4

namespace BitCounting;

public class Kata
{
    public static int CountBits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }

        return count;
    }
}
