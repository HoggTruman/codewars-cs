// https://www.codewars.com/kata/5d6a11ab2a1ef8001dd1e817

namespace ConnectTheDots;

using System;
using System.Collections.Generic;
using System.Linq;

public class Dinglemouse
{
    public static string ConnectTheDots(string paper)
    {
        char[][] grid = paper.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray()).ToArray();
        Dictionary<char, (int Row, int Col)> letters = [];

        for (int i = 0; i < grid.Length; ++i)
        {
            for (int j = 0; j < grid[0].Length; ++j)
            {
                if (char.IsLetter(grid[i][j]))
                {
                    letters[grid[i][j]] = (i, j);
                }
            }
        }

        char current = 'a';
        char next = 'b';
        while (letters.ContainsKey(next))
        {
            (int Row, int Col) from = letters[current];
            (int Row, int Col) to = letters[next];
            int rDelta = Math.Sign(to.Row - from.Row);
            int cDelta = Math.Sign(to.Col - from.Col);

            for (int r = from.Row, c = from.Col; r != to.Row || c != to.Col; r += rDelta, c += cDelta)
            {
                grid[r][c] = '*';
            }

            current = next;
            next = (char)(current + 1);
        }

        grid[letters[current].Row][letters[current].Col] = '*';

        return string.Join('\n', grid.Select(x => string.Join("", x))) + "\n";
    }
}
