// https://www.codewars.com/kata/57bc5e0471f2ff9233000005

namespace DoNotLooseAtTicTacToe;

using System;
using System.Linq;

public class TTTSolver
{
    private static readonly int[] FirstMove = [0, 0];
    private static readonly int[][] Edges = [[1, 0], [0, 1], [1, 2], [2, 1]];
    private static readonly int[][] Corners = [[0, 0], [2, 2], [2, 0], [0, 2]];
    private static readonly int[] Center = [1, 1];

    public static int[] TurnMethod(int[][] board, int player)
    {        
        int moves = CountMoves(board);
        int opponent = GetOpponent(player);

        int[]? winningMove = GetWinningMove(board, player);
        if (winningMove != null)
        {
            return winningMove;
        }

        int[]? opponentWinningMove = GetWinningMove(board, GetOpponent(player));
        if (opponentWinningMove != null)
        {
            return opponentWinningMove;
        }

        if (moves == 0)
        {
            return FirstMove;
        }

        if (moves == 1)
        {
            if (IsOccupyingCenter(board, opponent))
            {
                return [0, 0];
            }

            return Center;
        }

        if (moves == 2)
        {
            if (IsOccupyingEdge(board, opponent))
            {
                return Center;
            }
            else if (IsOccupyingCenter(board, opponent))
            {
                return GetOppositeCorner(FirstMove);
            }
            else 
            {
                int[] opponentMove = Corners.First(x => board[x[0]][x[1]] == opponent);
                int[] oppositeOpponent = GetOppositeCorner(opponentMove);
                return oppositeOpponent.SequenceEqual(FirstMove)?
                    GetOpenCorner(board):
                    oppositeOpponent;
            }           
        }

        if (moves == 3)
        {
            if (IsOccupyingCenter(board, opponent))
            {
                return GetOpenCorner(board);
            }
            else if ((board[0][0] == opponent && board[2][2] == opponent) || 
                (board[2][0] == opponent && board[0][2] == opponent))
            {
                return GetOpenEdge(board);                
            }
            else if (IsOccupyingCorner(board, opponent))
            {
                foreach (int[] corner in Corners)
                {
                    if (board[corner[0]][corner[1]] == opponent)
                    {
                        return GetOppositeCorner(corner);
                    }
                }
            }
            else if ((board[1][0] == opponent && board[1][2] == opponent) ||
                (board[0][1] == opponent && board[2][1] == opponent))
            {
                return GetOpenEdge(board);
            }
            else
            {
                return GetOpenCornerWithCommonAdjacentValue(board, opponent);                                 
            }
        }

        if (moves == 4)
        {
            return GetOpenCornerWithCommonAdjacentValue(board, 0);
        }        

        return GetFirstEmpty(board);
    }

    private static int CountMoves(int[][] board)
    {
        int sum = 0;
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board.Length; ++j)
            {
                if (board[i][j] != 0)
                {
                    ++sum;
                }                    
            }
        }

        return sum;
    }

    private static int[]? GetWinningMove(int[][] board, int player)
    {
        // Check Rows + Columns
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board.Length; ++j)
            {
                if (board[i][j] == 0 &&
                    board[i][(j + 1) % board.Length] == player &&
                    board[i][(j + 2) % board.Length] == player)
                {
                    return [i, j];
                }

                if (board[j][i] == 0 &&
                    board[(j + 1) % board.Length][i] == player &&
                    board[(j + 2) % board.Length][i] == player)
                {
                    return [j, i];
                }
            }
        }

        // Check Diagonals
        for (int d = 0; d < board.Length; ++d)
        {
            if (board[d][d] == 0 &&
                board[(d + 1) % board.Length][(d + 1) % board.Length] == player &&
                board[(d + 2) % board.Length][(d + 2) % board.Length] == player)
            {
                return [d, d];
            }

            if (board[(d + 1) * (board.Length - 1) % board.Length][d] == 0 &&
                board[(d + 2) * (board.Length - 1) % board.Length][(d + 1) % board.Length] == player &&
                board[(d + 3) * (board.Length - 1) % board.Length][(d + 2) % board.Length] == player)
            {
                return [(d + 1) * (board.Length - 1) % board.Length, d];
            }
        }

        return null;
    }

    
    private static bool IsOccupyingCorner(int[][] board, int player)
    {
        return Corners.Any(x => board[x[0]][x[1]] == player);
    }

    private static bool IsOccupyingEdge(int[][] board, int player)
    {
        return Edges.Any(x => board[x[0]][x[1]] == player);
    }

    private static bool IsOccupyingCenter(int[][] board, int player)
    {
        return board[Center[0]][Center[1]] == player;
    }

    private static int[] GetOpenEdge(int[][] board)
    {
        foreach(int[] edge in Edges)
        {
            if (board[edge[0]][edge[1]] == 0)
            {
                return edge;
            }
        }
        throw new ArgumentException("No open edges");
    }

    private static int[] GetOpenCorner(int[][] board)
    {
        foreach(int[] corner in Corners)
        {
            if (board[corner[0]][corner[1]] == 0)
            {
                return corner;
            }
        }
        throw new ArgumentException("No open corners");
    }

    private static int[] GetFirstEmpty(int[][] board)
    {
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board.Length; ++j)
            {
                if (board[i][j] == 0)
                {
                    return [i , j];
                }
            }
        }
        throw new ArgumentException("Board does not have any empty positions");
    }

    private static int[] GetOpenCornerWithCommonAdjacentValue(int[][] board, int adjValue)
    {
        if (board[0][0] == 0 && board[1][0] == adjValue && board[0][1] == adjValue)
        {
            return [0, 0];
        }
        else if (board[2][0] == 0 && board[1][0] == adjValue && board[2][1] == adjValue)
        {
            return [2, 0];
        }
        else if (board[0][2] == 0 && board[1][2] == adjValue && board[0][1] == adjValue)
        {
            return [0, 2];
        }
        else if (board[2][2] == 0 && board[1][2] == adjValue && board[2][1] == adjValue)
        {
            return [2, 2];
        }
        throw new ArgumentException($"No corner found where both adjacents have value {adjValue}");
    }

    private static int[] GetOppositeCorner(int[] corner)
    {
        if (corner[0] == 0 && corner[1] == 0) return [2, 2];
        if (corner[0] == 2 && corner[1] == 2) return [0, 0];
        if (corner[0] == 0 && corner[1] == 2) return [2, 0];
        if (corner[0] == 2 && corner[1] == 0) return [0, 2];
        throw new ArgumentException("Position provided is not a corner");
    }        

    private static int GetOpponent(int player)
    {
        return player == 1 ? 2 : 1;
    }
}
