// https://www.codewars.com/kata/657e578bdc80170abd4dca79

namespace MinimumPercentageOfVisitors;

using System;
using System.Linq;

public class Kata
{
    public static int MinimumPercentage(int[] foods)
    {
        return Math.Max(0, 100 - foods.Sum(x => 100 - x));
    }
}