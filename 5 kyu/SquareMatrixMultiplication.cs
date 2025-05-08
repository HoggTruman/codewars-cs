// https://www.codewars.com/kata/5263a84ffcadb968b6000513

namespace SquareMatrixMultiplication;

public class Kata
{
    public static int[,] MatrixMultiplication(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);
        int[,] result = new int[n, n];
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                for (int k = 0; k < n; ++k)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }
}
