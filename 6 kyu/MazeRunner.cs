// https://www.codewars.com/kata/58663693b359c4a6560001d6

namespace MazeRunner;

using System;

class Kata
{
    public string mazeRunner(int[,] maze, string[] directions)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        (int Row, int Col) pos = (-1, -1);

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                if (maze[i, j] == 2)
                {
                    pos = (i, j);
                }
            }
        }

        foreach (string direction in directions)
        {
            pos = NextPosition(pos.Row, pos.Col, direction);
            if (pos.Row < 0 || pos.Row >= rows ||
                pos.Col < 0 || pos.Col >= cols ||
                maze[pos.Row, pos.Col] == 1)
            {
                return "Dead";
            }

            if (maze[pos.Row, pos.Col] == 3)
            {
                return "Finish";
            }
        }

        return "Lost";
    }

    private (int Row, int Col) NextPosition(int row, int col, string direction)
    {
        return direction switch
        {
            "N" => (row - 1, col),
            "E" => (row, col + 1),
            "S" => (row + 1, col),
            "W" => (row, col - 1),
            _ => throw new Exception()
        };
    }
}
