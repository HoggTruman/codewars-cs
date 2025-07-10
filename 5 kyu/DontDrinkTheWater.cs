// https://www.codewars.com/kata/562e6df5cf2d3908ad00019e

namespace DontDrinkTheWater;

using System.Collections.Generic;

public class Kata
{
    public static char[,] SeparateLiquids(char[,] glass)
    {
        int rows = glass.GetLength(0);
        int cols = glass.GetLength(1);
        char[] density = ['O', 'A', 'W', 'H'];
        Dictionary<char, int> counts = new()
        {
            { 'O', 0 },
            { 'A', 0 },
            { 'W', 0 },
            { 'H', 0 }
        };

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                ++counts[glass[i, j]];
            }
        }


        int sorted = 0;
        foreach (char liquid in density)
        {
            for (int k = 1; k <= counts[liquid]; ++k)
            {
                int r = sorted / cols;
                int c = sorted % cols;
                glass[r, c] = liquid;
                ++sorted;
            }
        }

        return glass;
    }
}
