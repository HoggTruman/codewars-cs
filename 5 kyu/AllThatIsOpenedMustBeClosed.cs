// https://www.codewars.com/kata/55679d644c58e2df2a00009c

namespace AllThatIsOpenedMustBeClosed;

using System.Collections.Generic;

public class Kata
{
    public static bool IsBalanced(string s, string caps)
    {
        HashSet<char> openers = [];
        HashSet<char> closers = [];
        Dictionary<char, char> matchingOpeners = [];

        for (int i = 0; i < caps.Length; i += 2)
        {
            openers.Add(caps[i]);
            closers.Add(caps[i + 1]);
            matchingOpeners[caps[i + 1]] = caps[i];
        }

        Stack<char> stack = [];

        foreach (char c in s)
        {
            if (closers.Contains(c))
            {
                if (stack.Count == 0 || stack.Peek() != matchingOpeners[c])
                {
                    if (openers.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        return false;
                    }                    
                }
                else
                {
                    stack.Pop();
                }
            }
            else if (openers.Contains(c))
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}