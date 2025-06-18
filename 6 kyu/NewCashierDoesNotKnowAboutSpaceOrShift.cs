// https://www.codewars.com/kata/5d23d89906f92a00267bb83d

namespace NewCashierDoesNotKnowAboutSpaceOrShift;

using System.Collections.Generic;

public static class Kata
{
    public static string GetOrder(string input)
    {	
        List<string> items = ["burger", "fries", "chicken", "pizza", "sandwich", "onionrings", "milkshake", "coke"];
        Dictionary<string, int> counts = [];
        int i = 0;
        while (i < input.Length)
        {
            foreach(string item in items)
            {
                if (input.IndexOf(item, i) == i)
                {
                    counts[item] = counts.TryGetValue(item, out int count)? count + 1: 1;
                    i += item.Length;
                    break;
                }
            }
        }

        List<string> order = [];
        foreach (string item in items)
        {
            string titleCase = char.ToUpper(item[0]) + item[1..];
            if (counts.TryGetValue(item, out int count))
            {
                for (int k = 1; k <= count; ++k)
                {
                    order.Add(titleCase);
                }
            }
        }

        return string.Join(" ", order);
    }
}
