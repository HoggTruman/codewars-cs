// https://www.codewars.com/kata/528d9adf0e03778b9e00067e

namespace FindTheMine;

using System;

public class Kata
{
    public static Tuple<int, int> MineLocation(int[,] field)
    {
        for (int i = 0; i < field.GetLength(0); ++i)
        {
            for (int j = 0; j < field.GetLength(1); ++j)
            {
                if (field[i, j] == 1)
                {
                    return new(i, j);
                }
            }
        }

        throw new InvalidOperationException("No Mine Present!");
    }
}
