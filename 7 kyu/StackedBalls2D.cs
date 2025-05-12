// https://www.codewars.com/kata/5bb804397274c772b40000ca

namespace StackedBalls2D;

using System;

public class Dinglemouse
{
    public static double StackHeight2d(int layers)
    {
        return layers > 0? 1 + (layers - 1) * Math.Sqrt(3) / 2: 0;
    }
}
