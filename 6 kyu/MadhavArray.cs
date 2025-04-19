// https://www.codewars.com/kata/59b0492f7d3c9d7d4a0000bd

namespace MadhavArray;

using System.Linq;

public class Kata
{
    public static bool IsMadhavArray(int[] a)
    {
        if (a.Length == 0 || a.Length == 1)
        {
            return false;
        }

        int start = 0;
        int count = 1;

        while (start < a.Length)
        {
            if (start + count - 1 >= a.Length ||
                a[start..(start + count)].Sum() != a[0])
            {
                return false;
            }

            start += count;
            ++count;
        }

        return true;
    }
}
