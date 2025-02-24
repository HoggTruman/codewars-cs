// https://www.codewars.com/kata/62b3e38df90eac002c7a983f

using System;

namespace TypingSeries1TheBackspaceFunction;

public class Kata
{
    public static string Solve(string s)
    {
        const string backspace = "[backspace]";
        string result = "";
        int i = 0;

        while (i < s.Length)
        {
            if (s[i] == '[')
            {
                i += backspace.Length;
                int backCount = 1;

                if (i < s.Length &&
                    s[i] == '*')
                {
                    ++i;
                    string timesAppliedStr = "";
                    while (i < s.Length 
                        && char.IsDigit(s[i]))
                    {
                        timesAppliedStr += s[i];
                        ++i;
                    }

                    backCount = int.Parse(timesAppliedStr);
                }

                if (result.Length > 0) {
                    result = result.Remove(Math.Max(result.Length - backCount, 0));
                }                
            }
            else
            {
                result += s[i++];
            }
        }
        
        return result;
    }
}
