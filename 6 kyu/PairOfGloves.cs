// https://www.codewars.com/kata/58235a167a8cb37e1a0000db

namespace PairOfGloves;

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static int NumberOfPairs(string[] gloves)
    {
        Dictionary<string, int> counts = [];
        foreach (string color in gloves)
        {
            counts[color] = counts.TryGetValue(color, out int count)? count + 1: 1;
        }

        return counts.Aggregate(0, (acc, x) => acc + x.Value / 2);
    }
}
