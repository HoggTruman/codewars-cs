// https://www.codewars.com/kata/5c6d80d7ff00de2dcc4d4188

namespace DiagonalStrings;

using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    public static string[] DiagonalsOfSquare(string[] array)
    {
        if (array.Length == 0 ||
            array.Any(x => array.Length != x.Length))
        {
            return null;
        }

        int n = array.Length;
        List<(string x, int i)> sorted = array.Select((x, i) => (x, i)).OrderBy(x => x.x).ToList();
        string[] result = new string[array.Length];
        for (int i = 0; i < n; ++i)
        {
            StringBuilder sb = new();
            for (int k = 0; k < n; ++k)
            {
                sb.Append(sorted[(i + k) % n].x[k]);
            }
            result[sorted[i].i] = sb.ToString();
        }

        return result;
    }
}