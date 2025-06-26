// https://www.codewars.com/kata/55f95dbb350b7b1239000030

namespace RequiredDataI;

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static object[] CountSel(int[] lst)
    {
        Dictionary<int, int> counts = [];
        foreach (int k in lst)
        {
            counts.TryGetValue(k, out int count);
            counts[k] = count + 1;
        }

        int length = lst.Length;
        int distinct = counts.Count;
        int singleOccurence = counts.Where(x => x.Value == 1).Count();
        int maxCount = counts.Values.Max();
        int[] maxCountElements = counts.Where(x => x.Value == maxCount).Select(x => x.Key).Order().ToArray();

        return [length, distinct, singleOccurence, new object[] { maxCountElements, maxCount }];
    }
}
