// https://www.codewars.com/kata/540afbe2dc9f615d5e000425/train/csharp

using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidateSudokuWithSizeNxN;

public class Sudoku
{
    private readonly int[][] _sudoku;

    public Sudoku(int[][] sudokuData)
    {
        _sudoku = sudokuData;
    }

    public bool IsValid()
    {
        return HasValidDimensions()
            && HasValidRows()
            && HasValidColumns()
            && HasValidLittleSquares();
    }


    private bool HasValidDimensions()
    {
        int sqrtN = (int)Math.Sqrt(_sudoku.Length);
        return sqrtN * sqrtN == _sudoku.Length
            && _sudoku.All(x => x.Length == _sudoku.Length);
    }


    private bool HasValidRows()
    {
        for (int r = 0; r < _sudoku.Length; ++r)
        {
            HashSet<int> numsInRow = [];
            for (int c = 0; c < _sudoku.Length; ++c)
            {
                if (!IsValidCell(_sudoku[r][c], numsInRow)) {
                    return false;
                }

                numsInRow.Add(_sudoku[r][c]);
            }
        }

        return true;
    }


    private bool HasValidColumns()
    {
        for (int c = 0; c < _sudoku.Length; ++c)
        {
            HashSet<int> numsInCol = [];
            for (int r = 0; r < _sudoku.Length; ++r)
            {
                if (!IsValidCell(_sudoku[r][c], numsInCol)) {
                    return false;
                }

                numsInCol.Add(_sudoku[r][c]);
            }
        }

        return true;
    }


    private bool HasValidLittleSquares()
    {
        int sqrtN = (int)Math.Sqrt(_sudoku.Length);
        for (int sq = 0; sq < _sudoku.Length; ++sq)
        {
            HashSet<int> numsInSquare = [];
            for (int e = 0; e < _sudoku.Length; ++e)
            {
                int r = (sq / sqrtN) * sqrtN + e / sqrtN;
                int c = (sq % sqrtN) * sqrtN + e % sqrtN;

                if (!IsValidCell(_sudoku[r][c], numsInSquare)) {
                    return false;
                }

                numsInSquare.Add(_sudoku[r][c]);
            }            
        }

        return true;
    }

    private bool IsValidCell(int value, HashSet<int> existingValues)
    {
        return value >= 1 
            && value <= _sudoku.Length
            && !existingValues.Contains(value);
    }
}
