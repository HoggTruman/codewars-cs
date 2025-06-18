// https://www.codewars.com/kata/515f51d438015969f7000013

namespace PyramidArray;

public class Kata
{
    public static int[][] Pyramid(int n)
    {
        int[][] result = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            result[i] = new int[i + 1];
            for (int j = 0; j < i + 1; ++j)
            {
                result[i][j] = 1;
            }
        }

        return result;
    }
}
