// https://www.codewars.com/kata/5340298112fa30e786000688

namespace DifferenceOf2;

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static (int, int)[] TwosDifference(int[] array)
    {
        List<(int, int)> result = [];
        HashSet<int> numbers = [.. array];

        foreach (int k in array.Order())
        {
            if (numbers.Contains(k + 2))
            {
                result.Add((k, k + 2));
            }
        }
        return [.. result];
    }
}
