// https://www.codewars.com/kata/5cb7baa989b1c50014a53333

namespace IsSatorSquare;

using System.Collections.Generic;
using System.Text;

class Solution
{
    public static bool IsSatorSquare(char[,] tablet)
    {
        int n = tablet.GetLength(0);
        HashSet<string> downWords = [];
        HashSet<string> rightWords = [];
        HashSet<string> upWords = [];
        HashSet<string> leftWords = [];
        

        for (int i = 0; i < n; ++i)
        {
            StringBuilder down = new();
            StringBuilder right = new();
            StringBuilder up = new();
            StringBuilder left = new();

            for (int j = 0; j < n; ++j)
            {
                down.Append(tablet[j, i]);
                right.Append(tablet[i, j]);
                up.Append(tablet[n - j - 1, n - i - 1]);
                left.Append(tablet[n - i - 1, n - j - 1]);
            }

            downWords.Add(down.ToString());
            rightWords.Add(right.ToString());
            upWords.Add(up.ToString());
            leftWords.Add(left.ToString());
        }

        return downWords.SetEquals(rightWords)
            && rightWords.SetEquals(upWords)
            && leftWords.SetEquals(leftWords);
    }
}
