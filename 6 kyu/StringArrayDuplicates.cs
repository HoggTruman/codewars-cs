// https://www.codewars.com/kata/59f08f89a5e129c543000069

namespace StringArrayDuplicates;

using System.Linq;
using System.Text;

public class Solution
{
    public static string[] dup(string[] arr)
    {
        return arr.Select(RemoveConsecutiveDuplicates).ToArray();
    }

    private static string RemoveConsecutiveDuplicates(string s)
    {
        StringBuilder sb = new();
        foreach(char c in s)
        {
            if (sb.Length == 0 || c != sb[^1])
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
