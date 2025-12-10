// https://www.codewars.com/kata/5bc6f9110ca59325c1000254

namespace CountSquaresInTheChessBoard;

using System.Collections.Generic;

public class ChessBoard
{
    public static Dictionary<int, int> Count(int[][] b)
    {
        int n = b.Length;
        Dictionary<int, int> result = [];

        // memoR[i][j] contains the number of empty squares in the rectangle up to but excluding the ith row and jth column.
        int[,] memo = new int[n + 1, n + 1];

        for (int r = 0; r < n; ++r)
        {
            int empty = 0;
            for (int c = 0; c < n; ++c)
            {
                empty += b[r][c];                
                memo[r + 1, c + 1] = memo[r, c + 1] + empty;
            }
        }

        for (int k = 2; k <= n; ++k)
        {
            int count = 0;
            int area = k * k;
            for (int r = 0; r < n - k + 1; ++r)
            {
                for (int c = 0; c < n - k + 1; ++c)
                {
                    if (memo[r + k, c + k] - memo[r, c + k] - memo[r + k, c] + memo[r, c] == area)
                    {
                        ++count;
                    }
                }
            }

            if (count != 0)
            {
                result[k] = count;
            }
        }        

        return result;
    }


    //private static bool IsSquare(int r, int c, int k, int[,] memo)
    //{
    //    int empty = memo[r + k, c + k] - memo[r, c + k] - memo[r + k, c] + memo[r, c];
    //}




    public static Dictionary<int, int> CountSlow(int[][] b)
    {
        int n = b.Length;
        Dictionary<int, int> result = [];

        // memo[i][j] contains the number of empty squares in the ith row up to excluding the jth column
        int[,] memo = new int[n, n + 1];

        for (int r = 0; r < n; ++r)
        {
            int count = 0;
            for (int c = 0; c < n; ++c)
            {
                count += b[r][c];
                memo[r, c + 1] = count;
            }
        }

        for (int k = 2; k <= n; ++k)
        {
            int count = 0;
            for (int r = 0; r < n - k + 1; ++r)
            {
                for (int c = 0; c < n - k + 1; ++c)
                {
                    if (IsSquareSlow(r, c, k, memo))
                    {
                        ++count;
                    }
                }
            }

            if (count != 0)
            {
                result[k] = count;
            }
        }        

        return result;
    }


    private static bool IsSquareSlow(int r, int c, int k, int[,] memo)
    {
        for (int i = r; i < r + k; ++i)
        {
            if (memo[i, c + k] - memo[i, c] != k)
            {
                return false;
            }                            
        }

        return true;
    }
}