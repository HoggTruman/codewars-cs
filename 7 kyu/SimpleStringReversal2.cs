// https://www.codewars.com/kata/5a8d1c82373c2e099d0000ac

namespace SimpleStringReversal2;

using System;
using System.Text;

public class Solution
{    
    public static string solve(string s, int a, int b)
    {
        StringBuilder sb = new();
        sb.Append(s.AsSpan(0, a));

        char[] reverse = s.Substring(a, Math.Min(b - a + 1, s.Length - a)).ToCharArray();
        Array.Reverse(reverse);
        sb.Append(reverse);

        if (b + 1 < s.Length)
        {
            sb.Append(s.AsSpan(b + 1));
        }

        return sb.ToString();
    }
}