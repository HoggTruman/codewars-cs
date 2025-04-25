// https://www.codewars.com/kata/525f4206b73515bffb000b21

namespace AddingBigNumbers;

using System;
using System.Linq;
using System.Text;

public class Kata
{
    public static string Add(string a, string b)
    {
        StringBuilder sb = new();
        int minLength = Math.Min(a.Length, b.Length);
        int carrying = 0;

        for (int i = 0; i < minLength; ++i)
        {
            int sumDigits = CharToInt(a[a.Length - 1 - i]) + CharToInt(b[b.Length - 1 - i]) + carrying;
            carrying = sumDigits / 10;
            sb.Append(sumDigits % 10);
        }

        string remaining = a.Length > b.Length?
            a[..(a.Length - b.Length)]:
            b[..(b.Length - a.Length)];

        for (int i = 0; i < remaining.Length; ++i)
        {
            int sumDigits = CharToInt(remaining[remaining.Length - 1 - i]) + carrying;
            carrying = sumDigits / 10;
            sb.Append(sumDigits % 10);
        }

        if (carrying > 0)
        {
            sb.Append('1');
        }

        return new(sb.ToString().Reverse().ToArray());
    }

    public static int CharToInt(char c) => (int)char.GetNumericValue(c);
}
