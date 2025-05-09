// https://www.codewars.com/kata/6472390e0d0bb1001d963536

namespace FlipYourStackOfPancakes;

using System.Collections.Generic;
using System.Linq;

public class PancakeFlip
{
    public static List<int> FlipPancakes(List<int> stack)
    {
        List<int> flips = [];
        List<int> sorted = stack.Order().ToList();

        for (int i = stack.Count - 1; i >= 1; --i)
        {
            if (stack[i] == sorted[i])
            {
                continue;
            }

            if (stack[0] != sorted[i])
            {
                int nextIndex = stack.IndexOf(sorted[i]);
                stack.Reverse(0, nextIndex + 1);
                flips.Add(nextIndex);
            }
            
            stack.Reverse(0, i + 1);
            flips.Add(i);
        }
        
        return flips;
    }
}
