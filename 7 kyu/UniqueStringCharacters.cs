// https://www.codewars.com/kata/5a262cfb8f27f217f700000b

namespace UniqueStringCharacters;

using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static string Solve(string a, string b)
    {
        HashSet<char> aChars = [.. a];
        HashSet<char> bChars = [.. b];        
        return new string([..a.Where(x => !bChars.Contains(x)), ..b.Where(x => !aChars.Contains(x))]);
    }
}
