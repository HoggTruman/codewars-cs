// https://www.codewars.com/kata/57a4c85de298a795210002da

namespace CountdownLongestWord;

using System.Collections.Generic;
using System.Linq;

public partial class Kata
{
    private static string[] words = [];

    public static string[] LongestWord(string letters)
    {   
        IOrderedEnumerable<string> wordsByLength = words.OrderByDescending(x => x.Length);
        int longestLength = -1;
        List<string> longestWords = [];
        Dictionary<char, int> letterCounts = GetCharCounts(letters.ToUpper());

        foreach (string word in wordsByLength)
        {
            if (longestLength != -1 && word.Length < longestLength)
            {
                break;
            }

            Dictionary<char, int> wordCharCounts = GetCharCounts(word);

            if (wordCharCounts.Keys.Any(x => !letterCounts.TryGetValue(x, out int letterCount) || wordCharCounts[x] > letterCount))
            {
                continue;
            }

            if (longestLength == -1)
            {
                longestLength = word.Length;
            }
            
            longestWords.Add(word);
        }
        
        return longestWords.Count > 0 ? [..longestWords.Order()]: null;
    }


    private static Dictionary<char, int> GetCharCounts(string word)
    {
        Dictionary<char, int> counts = [];

        foreach (char c in word)
        {
            counts.TryGetValue(c, out int count);
            counts[c] = count + 1;            
        }

        return counts;
    }
}
