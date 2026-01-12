// https://www.codewars.com/kata/5afd3c451839f13b95000132

namespace ClickbaitMatrixShift;

public class JomoPipi
{
    public static char[][] Shift(char[][] m, int n)
    {
        int rows = m.Length;
        int cols = m[0].Length;
        char[][] result = new char[rows][];

        for (int i = 0; i < rows; ++i)
        {
            result[i] = new char[cols];
        }

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                int nextPos = (r * cols + c + n) % (rows * cols);
                result[nextPos / cols][nextPos % cols] = m[r][c];
            }
        }

        return result;
    }
}