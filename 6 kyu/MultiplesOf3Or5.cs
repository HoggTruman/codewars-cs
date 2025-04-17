// https://www.codewars.com/kata/514b92a657cdc65150000006

namespace MultiplesOf3Or5;

public static class Kata
{
    public static int Solution(int value)
    {
        int sum = 0;

        for (int k = 3; k < value; ++k)
        {
            if (k % 3 == 0 || k % 5 == 0)
            {
                sum += k;
            }
        }

        return sum;
    }
}
