// https://www.codewars.com/kata/5966e33c4e686b508700002d

namespace SumTheStrings;

public static class Program
{
    public static string StringsSum(string s1, string s2)
    {
        return (int.Parse(s1 == ""? "0": s1) + int.Parse(s2 == ""? "0": s2)).ToString();
    }
}
