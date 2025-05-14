// https://www.codewars.com/kata/52b305bec65ea40fe90007a7

namespace ArrhGrabscrab;

using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static List<string> Grabscrab(string anagram, List<string> dictionary)
    {
        List<string> result = [];
        var anagramCounts = GetCharCounts(anagram);

        foreach (string word in dictionary)
        {
            var wordCounts = GetCharCounts(word);

            if (word.All(x => anagramCounts.TryGetValue(x, out int count) && count == wordCounts[x]))
            {
                result.Add(word);
            }
        }

        return result;
    }

    private static Dictionary<char, int> GetCharCounts(string word)
    {
        Dictionary<char, int> counts = [];

        foreach (char c in word)
        {
            if (counts.TryGetValue(c, out int count))
            {
                counts[c] = count + 1;
            }
            else
            {
                counts[c] = 1;
            }
        }

        return counts;
    }
}
