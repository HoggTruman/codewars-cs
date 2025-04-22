// https://www.codewars.com/kata/67857e40220da0b5a0e7cae2

namespace TheCapturingRook;

using System;
using System.Collections;
using System.Collections.Generic;

public class MinimumRookDistance
{
    public static int CalculateMinRookDistance(int[][] pawns, int[] rook)
    {
        // stores min distances accessed by index of pawn starting on then by mask of visited pawns
        Dictionary<int, Dictionary<int, int>> cache = [];
        BitArray visitedPawns = new(pawns.GetLength(0));

        for (int i = -1; i < pawns.GetLength(0); ++i)
        {
            cache[i] = [];
        }
        
        return CalculateMin(pawns, rook, -1, visitedPawns, cache);
    }

    private static int CalculateMin(int[][] pawns, int[] start, int startIndex, BitArray visitedPawns, Dictionary<int, Dictionary<int, int>> cache)
    {
        if (visitedPawns.HasAllSet())
        {
            return 0;
        }

        int visitedPawnsMask = GetMask(visitedPawns);

        if (cache.ContainsKey(startIndex) &&
            cache[startIndex].ContainsKey(visitedPawnsMask))
        {
            return cache[startIndex][visitedPawnsMask];
        }

        int minDistance = int.MaxValue;
        for (int i = 0; i < pawns.GetLength(0); ++i)
        {
            if (visitedPawns.Get(i) == true)
            {
                continue;
            }

            visitedPawns.Set(i, true);
            int distanceToPawn = Math.Abs(start[0] - pawns[i][0]) + Math.Abs(start[1] - pawns[i][1]);
            minDistance = Math.Min(minDistance, distanceToPawn + CalculateMin(pawns, pawns[i], i, visitedPawns, cache));
            visitedPawns.Set(i, false);
        }

        cache[startIndex][visitedPawnsMask] = minDistance;
        return minDistance;
    }

    private static int GetMask(BitArray visitedPawns)
    {
        int[] array = new int[1];
        visitedPawns.CopyTo(array, 0);
        return array[0];
    }
}
