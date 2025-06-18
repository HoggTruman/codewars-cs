// https://www.codewars.com/kata/5514e5b77e6b2f38e0000ca9

namespace PlusOneArray;

using System.Linq;

public static class Kata
{
    public static int[] UpArray(int[] num)
    {
        if (num.Length == 0 || num.Any(x => x < 0 || x > 9))
        {
            return null;
        }

        int[] result = [..num];
        for (int i = result.Length - 1; i >= 0; --i)
        {
            result[i] = (result[i] + 1) % 10;
            if (result[i] != 0)
            {
                break;
            }
            else if (i == 0)
            {
                result = [1, ..result];
            }
        }

        return result;
    }
}