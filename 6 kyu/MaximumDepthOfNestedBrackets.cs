// https://www.codewars.com/kata/60e4dfc1dc28e70049e2cb9d

namespace MaximumDepthOfNestedBrackets;

using System;
using System.Collections.Generic;

public class SolutionMaxDepth 
{ 
    public static List<string> StringsInMaxDepth(string s)
    {
        List<string> result = [];
        int maxDepth = GetMaxBracketDepth(s);
         
        if (maxDepth == 0)
        {
            return [s];
        }

        int depth = 0;       
        int openBracketIndex = -1;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '(')
            {
                ++depth;
                if (depth == maxDepth)
                {
                    openBracketIndex = i;
                }
            }
            else if (s[i] == ')')
            {
                if (depth == maxDepth)
                {                    
                    result.Add(s[(openBracketIndex + 1)..i]);
                }
                --depth;
            }      
        }

        return result;
    }

    public static int GetMaxBracketDepth(string s)
    {
        int depth = 0;
        int maxDepth = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '(')
            {
                ++depth;
                maxDepth = Math.Max(maxDepth, depth);
            }
            else if (s[i] == ')')
            {
                --depth;
            }
        }

        return maxDepth;
    }
}
