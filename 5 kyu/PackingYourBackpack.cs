// https://www.codewars.com/kata/5a51717fa7ca4d133f001fdf

namespace PackingYourBackpack;

using System;

public class Packer
{
    public static int PackBagpack(int[] scores, int[] weights, int capacity)
    {
        int[,] memo = new int[weights.Length + 1, capacity + 1];

        for (int i = 1; i <= weights.Length; ++i)
        {
            for (int cap = 1; cap <= capacity; ++cap)
            {
                memo[i, cap] = weights[i - 1] <= cap?
                    Math.Max(memo[i, cap], memo[i - 1, cap - weights[i - 1]] + scores[i - 1]):
                    memo[i - 1, cap];
            }
        }

        return memo[weights.Length, capacity];
    }
}
