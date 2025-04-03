// https://www.codewars.com/kata/564ab935de55a747d7000040

namespace NotAllButSometimesAll;

using System.Collections.Generic;
using System.Text;

public class Kata
{
    public static string Remove(string str, Dictionary<char,int> what)
    {
        StringBuilder sb = new();

        foreach(char c in str)
        {
            if (what.TryGetValue(c, out int count) &&
                count > 0)
            {
                --what[c];
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
