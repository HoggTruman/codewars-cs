// https://www.codewars.com/kata/63b84f54693cb10065687ae5

namespace TheSpiralingBox;

using System;

public class SpiralingBox
{
    public static int[,] CreateBox(int cols, int rows)
    {
        int[,] box = new int[rows, cols];
        int maxRow = (rows - 1) / 2;
        int maxCol = (cols - 1) / 2;

        for (int i = 0; i < rows; ++i)
        {
            int rowVal = i <= maxRow? i + 1: rows - i;
            for (int j = 0; j < cols; ++j)
            {                
                int colVal = j <= maxCol? j + 1: cols - j;
                box[i, j] = Math.Min(rowVal, colVal);
            }
        }

        return box;
    }
}