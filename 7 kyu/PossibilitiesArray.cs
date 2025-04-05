// https://www.codewars.com/kata/59b710ed70a3b7dd8f000027

namespace PossibilitiesArray;

using System.Collections.Generic;

public static class Kata
{
    public static bool IsAllPossibilities(int[] arr)
    {
        HashSet<int> possibilities = new();
        foreach(int k in arr)
        {
            if (k < 0 || k >= arr.Length || possibilities.Contains(k))
            {
                return false;
            }
            possibilities.Add(k);
        }

        return true;
    }
}
