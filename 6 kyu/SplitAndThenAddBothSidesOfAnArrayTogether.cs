// https://www.codewars.com/kata/5946a0a64a2c5b596500019a

namespace SplitAndThenAddBothSidesOfAnArrayTogether;


public class Kata 
{
    public static int[] SplitAndAdd(int[] numbers, int n) 
    {
        int[] result = [..numbers];        
        
        for (int k = 1; k <= n; ++k)
        {
            if (result.Length == 1)
            {
                return result;
            }

            for (int i = 0; i < result.Length / 2; ++i)
            {
                result[result.Length - i - 1] += result[result.Length / 2 - i - 1];
            }

            result = result[(result.Length / 2)..];
        }

        return result;
    }
}
