// https://www.codewars.com/kata/56882731514ec3ec3d000009

namespace ConnectFour;

using System.Collections.Generic;

public class ConnectFour
{
    private const int Rows = 6;
    private const int Cols = 7;

    public static string WhoIsWinner(List<string> piecesPositionList)
    {
        string[,] grid = new string[Rows, Cols];

        foreach (string move in piecesPositionList)
        {
            int col = ParseColumn(move[0]);
            string color = move[2..];

            for (int row = Rows - 1; row >= 0; --row)
            {
                if (grid[row, col] == null)
                {
                    grid[row, col] = color;
                    
                    if (ConnectsFour(grid, row, col))
                    {
                        return color;
                    }

                    break;
                }
            }
        }

        return "Draw";
    }


    private static bool ConnectsFour(string[,] grid, int row, int col)
    {
        // Check if move connects four vertically
        for (int i = row - 3; i <= row; ++i)
        {
            if (i >= 0 && i + 3 < Rows &&
                grid[i, col] == grid[i + 1, col] &&
                grid[i + 1, col] == grid[i + 2, col] &&
                grid[i + 2, col] == grid[i + 3, col])
            {
                return true;
            }
        }

        // Check if move connects four horizontally
        for (int i = col - 3; i <= col; ++i)
        {
            if (i >= 0 && i + 3 < Cols &&
                grid[row, i] == grid[row, i + 1] &&
                grid[row, i + 1] == grid[row, i + 2] &&
                grid[row, i + 2] == grid[row, i + 3])
            {
                return true;
            }
        }

        // Check if move connects four diagonally
        for (int i = row - 3, j = col - 3; i <= row && j <= col; ++i, ++j)
        {
            if (i >= 0 && i + 3 < Rows &&
                j >= 0 && j + 3 < Cols &&
                grid[i, j] == grid[i + 1, j + 1] &&
                grid[i + 1, j + 1] == grid[i + 2, j + 2]  &&
                grid[i + 2, j + 2]  == grid[i + 3, j + 3])
            {
                return true;
            }
        }

        for (int i = row + 3, j = col - 3; i >= row && j <= col; --i, ++j)
        {
            if (i < Rows && i - 3 >= 0 &&
                j >= 0 && j + 3 < Cols &&
                grid[i, j] == grid[i - 1, j + 1] &&
                grid[i - 1, j + 1] == grid[i - 2, j + 2] &&
                grid[i - 2, j + 2] == grid[i - 3, j + 3])
            {
                return true;
            }
        }

        return false;
    }


    private static int ParseColumn(char column)
    {
        return column - 'A';
    }
}