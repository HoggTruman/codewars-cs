// https://www.codewars.com/kata/51f1342c76b586046800002a

namespace RoundByHalfSteps;

using System;

public class Kata
{
    public static double Solution(double n)
    {
        double x = Math.Abs(n % 0.5) < 0.25? (int)n: (int)n + Math.Sign(n) * 0.5;
        return n % 1 < 0.5? x: Math.Sign(n) * 0.5;
    }
}
