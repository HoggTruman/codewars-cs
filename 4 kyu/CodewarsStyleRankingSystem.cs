// https://www.codewars.com/kata/51fda2d95d6efda45e00004e

namespace CodewarsStyleRankingSystem;

using System;

public class User 
{
    public const int MinRank = -8;
    public const int MaxRank = 8;

    public int rank = MinRank;
    public int progress = 0;

    public void incProgress(int actRank) 
    {
        if (actRank < MinRank || actRank > MaxRank || actRank == 0)
        {
            throw new ArgumentException("Invalid activity rank");
        }

        int rankDiff = CalculateRankDifference(rank, actRank);

        if (rankDiff <= -2 || rank == 8) return;
        else if (rankDiff == -1) progress += 1;
        else if (rankDiff == 0) progress += 3;
        else if (rankDiff > 0) progress += 10 * rankDiff * rankDiff;

        if (progress >= 100)
        {
            rank = CalculateNextRank(rank, progress / 100);
            progress = rank < 8? progress % 100: 0;            
        }
    }

    private static int CalculateRankDifference(int from, int to)
    {
        return Math.Sign(from) == Math.Sign(to)?
            to - from:
            to - from + Math.Sign(from);
    }

    private static int CalculateNextRank(int rank, int rankUps)
    {
        int result = rank + rankUps;
        if (result >= 0 && rank < 0) 
        {
            ++result;
        }

        return Math.Min(MaxRank, result);
    }
}
