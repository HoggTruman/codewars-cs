// https://www.codewars.com/kata/5420fc9bb5b2c7fd57000004

namespace HighestRankNumberInAnArray;

using System.Collections.Generic;

public class Kata
{
    public static int HighestRank(int[] arr)
    {
        Dictionary<int, int> counts = [];
        foreach (int k in arr)
        {
            counts[k] = counts.TryGetValue(k, out int count)? count + 1: 1;
        }

        int highestRank = arr[0];
        foreach (var kv in counts)
        {
            if (kv.Value > counts[highestRank] ||
                (kv.Value == counts[highestRank] && kv.Key > highestRank))
            {
                highestRank = kv.Key;
            }
        }

        return highestRank;
    }
}
