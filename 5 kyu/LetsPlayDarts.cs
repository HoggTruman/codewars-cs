// https://www.codewars.com/kata/5870db16056584eab0000006

namespace LetsPlayDarts;

using System;

public class Dartboard
{
    public string GetScore(double x, double y)
    {
        double radius = Math.Sqrt(x * x + y * y);
        double angle = GetAngle(x, y);

        if (radius < 6.35)
            return "DB";

        if (radius < 15.9)
            return "SB";

        if (radius > 170)
            return "X";

        string multiplier = radius > 99 && radius < 107 ? "T":
                            radius > 162 && radius < 170? "D":
                            "";    
        
        return multiplier + GetNumber(angle);
    }


    private static string GetNumber(double angle)
    {
        return angle switch
        {
            <= 9 => "6",
            <= 9 + 1 * 18 => "13",
            <= 9 + 2 * 18 => "4",
            <= 9 + 3 * 18 => "18",
            <= 9 + 4 * 18 => "1",
            <= 9 + 5 * 18 => "20",
            <= 9 + 6 * 18 => "5",
            <= 9 + 7 * 18 => "12",
            <= 9 + 8 * 18 => "9",
            <= 9 + 9 * 18 => "14",
            <= 9 + 10 * 18 => "11",
            <= 9 + 11 * 18 => "8",
            <= 9 + 12 * 18 => "16",
            <= 9 + 13 * 18 => "7",
            <= 9 + 14 * 18 => "19",
            <= 9 + 15 * 18 => "3",
            <= 9 + 16 * 18 => "17",
            <= 9 + 17 * 18 => "2",
            <= 9 + 18 * 18 => "15",
            <= 9 + 19 * 18 => "10",
            _ => "6"
        };
    }

    private static double GetAngle(double x, double y)
    {
        double angle = Math.Atan2(y, x) / Math.PI * 180;
        return angle < 0 ? 360 + angle : angle;
    }
}
