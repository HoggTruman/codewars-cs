// https://www.codewars.com/kata/526233aefd4764272800036f

namespace MatrixAddition;

public class Kata
{
    public static int[][] MatrixAddition(int[][] a, int[][] b)
    {
        int n = a.Length;
        int[][] result = new int[n][];

        for (int i = 0; i < n; ++i)
        {
            result[i] = new int[n];
            for (int j = 0; j < n; ++j)
            {
                result[i][j] = a[i][j] + b[i][j];
            }
        }

        return result;
    }
}
