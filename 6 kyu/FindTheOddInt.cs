// https://www.codewars.com/kata/54da5a58ea159efa38000836

namespace FindTheOddInt;

using System.Collections.Generic;

class Kata
{
    public static int find_it(int[] seq) 
    {
        Dictionary<int, int> counts = [];

        foreach (int k in seq)
        {
            counts.TryGetValue(k, out int count);
            counts[k] = count + 1;
        }

        foreach (int k in counts.Keys)
        {
            if (counts[k] % 2 == 1)
                return k;
        }

        return -1;
    }       
}