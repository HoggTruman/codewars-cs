// https://www.codewars.com/kata/5356ad2cbb858025d800111d

namespace NameArrayCapping;

using System.Linq;

public static class Kata
{
    public static string[] CapMe(string[] strings)
    {
        return strings.Select(x => x[..1].ToUpper() + x[1..].ToLower()).ToArray();
    }
}
