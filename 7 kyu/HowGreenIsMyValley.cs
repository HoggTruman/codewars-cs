// https://www.codewars.com/kata/56e3cd1d93c3d940e50006a4

namespace HowGreenIsMyValley;

using System.Collections.Generic;
using System.Linq;

public class Valley
{
    public static int[] MakeValley(int[] arr)
    {
        IEnumerable<int> sorted = arr.OrderDescending();
        return sorted.Where((x, i) => i % 2 == 0)
               .Concat(sorted.Where((x, i) => i % 2 != 0).Reverse())
               .ToArray();
    }
}
