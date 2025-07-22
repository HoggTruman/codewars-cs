// https://www.codewars.com/kata/52a4e42ce950ed50da000748

namespace ArrayIntersectAll;

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string[] Intersect(params string[][] arrays)
    {
        if (arrays.Length == 0)
        {
            return [];
        }

        HashSet<string> elements = new(arrays[0]);

        for (int i = 1; i < arrays.Length; ++i)
        {
            elements.IntersectWith(arrays[i]);
        }

        return elements.ToArray();
    }
}
