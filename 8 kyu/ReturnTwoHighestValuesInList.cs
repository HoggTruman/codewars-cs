// https://www.codewars.com/kata/57ab3c09bb994429df000a4a

namespace ReturnTwoHighestValuesInList;

using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static int[] TwoHighest(int[] arr)
    {
        List<int> maxElements = [];

        foreach(int k in arr)
        {
            if (maxElements.Count == 0)
            {
                maxElements.Add(k);
            }
            else if (maxElements.Count == 1)
            {
                if (k > maxElements[0])
                {
                    maxElements = [k, maxElements[0]];                    
                }
                else if (k < maxElements[0])
                {
                    maxElements.Add(k);
                }
            }
            else
            {
                if (k > maxElements[0])
                {
                    maxElements[1] = maxElements[0];
                    maxElements[0] = k;
                }
                else if (k > maxElements[1] && k != maxElements[0])
                {
                    maxElements[1] = k;
                }
            }
        }

        return maxElements.ToArray();
    }

    public static int[] TwoHighestShorter(int[] arr)
    {
        return arr.Distinct().OrderDescending().Take(2).ToArray();
    }
}
