// https://www.codewars.com/kata/589ace5eeef39faf49000061

namespace SimpleFun111ReverseBrackets;

using System;
using System.Text;

public class Kata
{
    public string ReverseParentheses(string s)
    {
        StringBuilder sb = new();

        int i = 0;
        while (i < s.Length)
        {
            if (s[i] == '(')
            {
                int closingBracketIndex = FindClosingBracket(s, i);
                string reversed = Reverse(ReverseParentheses(s[(i + 1)..closingBracketIndex]));
                sb.Append(reversed);
                i = closingBracketIndex + 1;
            }
            else
            {
                sb.Append(s[i]);
                ++i;
            }
        }
          
        return sb.ToString();
    }

    public static int FindClosingBracket(string s, int openBracketIndex)
    {
        int openBrackets = 1;

        for (int i = openBracketIndex + 1; i < s.Length; ++i)
        {
            if (s[i] == '(')
            {
                ++openBrackets;
            }
            else if (s[i] == ')')
            {
                --openBrackets;

                if (openBrackets == 0)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new(arr);
    }
}
