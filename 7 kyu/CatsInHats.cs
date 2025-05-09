// https://www.codewars.com/kata/57b5907920b104772c00002a/train/csharp

namespace CatsInHats;

using System;

public class Kata
{
    public static string Height(int n)
    {
        decimal totalHeight = 2_000_000;
        decimal currentHeight = 2_000_000;

        while (n > 0)
        {
            currentHeight /= 2.5m;
            totalHeight += currentHeight;            
            --n;
        }

        return Math.Round(totalHeight, 3).ToString("0.000");
    }
}
