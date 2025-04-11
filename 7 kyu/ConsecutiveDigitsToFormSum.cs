// https://www.codewars.com/kata/5dae2599a8f7d90025d2f15f/train/csharp

namespace ConsecutiveDigitsToFormSum;

using System;

public class Kata 
{
    public static bool ConsecutiveDucks(int n) 
    {
        return Math.Log2(n) % 1 != 0;
    }
}
