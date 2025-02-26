// https://www.codewars.com/kata/5324945e2ece5e1f32000370

namespace SumStringsAsNumbers;

using System.Text;

public static class Kata
{
    public static string sumStrings(string a, string b)
    {
        StringBuilder result = new("");
        string longer = a.Length > b.Length? a: b;        
        int carry = 0;

        for (int i = 1; i <= longer.Length + 1; ++i)
        {
            int sumDigits = a.GetBackVal(i) + b.GetBackVal(i) + carry;
            result.Insert(0, sumDigits % 10);
            carry = sumDigits >= 10? 1: 0;            
        }

        while (result[0] == '0')
        {
            result.Remove(0, 1);
        }

        return result.ToString();
    }

    private static int GetBackVal(this string s, int i) => (i <= s.Length? s[^i] - '0': 0);
}
