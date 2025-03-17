// https://www.codewars.com/kata/5806c2f897dba05dd900004c

namespace NDimensionalVectorMagnitude;

using System;
using System.Linq;

public class Kata
{
    public static double Magnitude(double[] vector)
    {
        return Math.Sqrt(vector.Sum(x => x * x));
    }
}
