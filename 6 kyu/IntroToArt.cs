// https://www.codewars.com/kata/5d7d05d070a6f60015c436d1

namespace IntroToArt;

using System;

public class IntroToArt 
{
    public string[] GetW(int h) 
    {  
        if (h < 2)
        {
            return [];
        }

        string[] result = new string[h];
        result[0] = "*" + new String(' ', 2 * h - 3) + "*" + new String(' ', 2 * h - 3) + "*";
        for (int i = 1; i < h - 1; ++i)
        {
            string outerSpace = new(' ', i);
            string innerSpace = new(' ', 2 * h - 3 - 2 * i);
            string middleSpace = new(' ', 2 * i - 1);
            result[i] = outerSpace + "*" + innerSpace + "*" + middleSpace + "*" + innerSpace + "*" + outerSpace;
        }

        result[h - 1] = new String(' ', h - 1) + "*" + new String(' ', 2 * h - 3) + "*" + new String(' ', h - 1);

        return result;
    }
}
