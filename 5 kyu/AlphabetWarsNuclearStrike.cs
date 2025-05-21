// https://www.codewars.com/kata/59437bd7d8c9438fb5000004

namespace AlphabetWarsNuclearStrike;

using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    public static string AlphabetWar(string b)
    {
        StringBuilder sb = new();
        List<string> parts = [];
        bool containsNuke = b.Contains('#');
        Dictionary<int, int> nukeCounts = [];

        int i = 0;
        while (i != -1 && i < b.Length)
        {
            if (b[i] == '[')
            {
                int nextStart = b.IndexOf(']', i) + 1;
                parts.Add(b[i..nextStart]);
                i = nextStart;
            }
            else
            {
                int bunkerStart = b.IndexOf('[', i);
                string outside = bunkerStart == -1? b[i..]: b[i..bunkerStart];
                parts.Add(outside);
                i = bunkerStart;
            }
        }

        for (i = 0; i < parts.Count; ++i)
        {
            if (!parts[i].StartsWith('['))
            {
                nukeCounts[i] = parts[i].Count(x => x =='#');
            }
        }

        for (i = 0; i < parts.Count; ++i)
        {
            if (parts[i].StartsWith('['))
            {
                nukeCounts.TryGetValue(i - 1, out int left);
                nukeCounts.TryGetValue(i + 1, out int right);
                if (left + right < 2)
                {
                    sb.Append(parts[i][1..^1]);
                }
            }
            else if (!containsNuke)
            {
                sb.Append(parts[i].Replace("#", ""));
            }
        }

        return sb.ToString();
    }
}
