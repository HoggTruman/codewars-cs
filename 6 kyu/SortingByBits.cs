// https://www.codewars.com/kata/59fa8e2646d8433ee200003f/csharp

namespace SortingByBits;

using System.Linq;

public class Kata
{
    public static int[] SortByBit(int[] array)
    {
        return array.OrderBy(CountOnBits).ThenBy(x => x).ToArray();
    }

    private static int CountOnBits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                ++count;
            }

            n >>= 1;            
        }

        return count;
    }
}
