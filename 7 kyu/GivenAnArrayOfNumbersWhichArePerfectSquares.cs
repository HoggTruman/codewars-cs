// https://www.codewars.com/kata/53227465e4d01b5d5200011e

namespace GivenAnArrayOfNumbersWhichArePerfectSquares;

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata 
{
    public static int[] GetSquares(int[] array)
    {
        HashSet<int> perfectSquares = [];
        foreach (int k in array)
        {
            if (k >= 0 && Math.Sqrt(k) % 1 == 0)
            {
                perfectSquares.Add(k);
            }
        }

        return perfectSquares.Order().ToArray();
    }
}
