// https://www.codewars.com/kata/525caa5c1bf619d28c000335

namespace TicTacToeChecker;

using System.Linq;

public class TicTacToe
{
    public int IsSolved(int[,] board)
    {
        int n = 3;

        for (int i = 0; i < n; ++i)
        {
            if (board[i, 0] != 0 &&
                board[i, 0] == board[i, 1] &&
                board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }

            if (board[0, i] != 0 &&
                board[0, i] == board[1, i] &&
                board[1, i] == board[2, i])
            {
                return board[0, i];
            }
        }

        if (board[1, 1] != 0 &&
            (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
            (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2]))
        {
            return board[1, 1];
        }

        return board.Cast<int>().Any(x => x == 0)? -1: 0;
    }
}
