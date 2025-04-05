// https://www.codewars.com/kata/5497a3c181dd7291ce000700

namespace FindSumOfTopLeftToBottomRightDiagonals;

public static class Kata
{
    public static int DiagonalSum(int[,] matrix)
    {
        //if (matrix.L)
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            sum += matrix[i, i];
        }

        return sum;
    }
}
