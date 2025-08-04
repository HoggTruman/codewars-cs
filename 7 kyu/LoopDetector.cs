// https://www.codewars.com/kata/68851563123e161332d2a84b

namespace LoopDetector;

using System.Collections.Generic;

public class Kata
{
    public static bool HasLoop(int[] arr)
    {
        HashSet<int> visited = [];
        int i = 0;

        while (i < arr.Length)
        {
            if (visited.Contains(i))
            {
                return true;
            }

            visited.Add(i);
            i = arr[i];
        }

        return false;
    }
}
