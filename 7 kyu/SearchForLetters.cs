// https://www.codewars.com/kata/52dbae61ca039685460001ae

namespace SearchForLetters;

using System.Linq;

public class Kata
{
    public static string Change(string input)
    {
        char[] isPresent = Enumerable.Repeat('0', 26).ToArray();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                isPresent[char.ToLower(c) - 'a'] = '1';
            }
        }

        return string.Join("", isPresent);
    }
}
