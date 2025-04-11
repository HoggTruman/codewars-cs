// https://www.codewars.com/kata/59b844528bcb7735560000a0

namespace NiceArray;

using System.Collections.Generic;

public class Kata
{
    public static bool IsNice(int[] arr)
    {
        if (arr.Length == 0)
        {
            return false;
        }

        HashSet<int> nums = new(arr);

        foreach (int num in nums)
        {
            if (!nums.Contains(num + 1) && !nums.Contains(num - 1))
            {
                return false;
            }
        }

        return true;
    }
}
