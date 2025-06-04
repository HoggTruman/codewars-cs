// https://www.codewars.com/kata/5d81d8571c6411001a40ba66

namespace DotsAndBoxesValidator;

using System;
using System.Collections.Generic;
using System.Linq;

public class DnB
{
    public static int[] DotsAndBoxes(int[][] r)
    {
        int[][] moves = r.Select(x => x.Order().ToArray()).ToArray();
        int n = Convert.ToInt32(Math.Sqrt(r.Max(x => x[1]) + 1));

        HashSet<(int, int)> lines = [];
        Dictionary<int, int> scores = new() { { 1, 0 }, { 2, 0 } };
        int activePlayer = 1;        

        foreach (var line in moves)
        {
            lines.Add((line[0], line[1]));
            int boxesCompleted = 0;
            if (line[1] - line[0] == 1)
            {
                bool completesUpper = lines.Contains((line[0] - n, line[1] - n)) &&
                    lines.Contains((line[0] - n, line[0])) &&
                    lines.Contains((line[1] - n, line[1]));
                bool completesLower = lines.Contains((line[0] + n, line[1] + n)) &&
                    lines.Contains((line[0], line[0] + n)) &&
                    lines.Contains((line[1], line[1] + n));
                boxesCompleted = Convert.ToInt32(completesUpper) + Convert.ToInt32(completesLower);
            }
            else
            {
                bool completesLeft = line[0] % n > 0 &&
                    lines.Contains((line[0] - 1, line[1] - 1)) &&
                    lines.Contains((line[0] - 1, line[0])) &&
                    lines.Contains((line[1] - 1, line[1]));
                bool completesRight = line[0] % n < n - 1 &&
                    lines.Contains((line[0] + 1, line[1] + 1)) &&
                    lines.Contains((line[0], line[0] + 1)) &&
                    lines.Contains((line[1], line[1] + 1));
                boxesCompleted = Convert.ToInt32(completesLeft) + Convert.ToInt32(completesRight);
            }

            scores[activePlayer] += boxesCompleted;
            if (boxesCompleted == 0)
            {
                activePlayer = activePlayer == 1? 2: 1;
            }
        }

        return [scores[1], scores[2]];
    }    
}
