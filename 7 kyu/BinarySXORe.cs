// https://www.codewars.com/kata/56d3e702fc231fdf72001779

namespace BinarySXORe;

using System;
using System.Numerics;

public class BinarySxore
{
    public static BigInteger Sxore (BigInteger n)
    {
        int mod = (int)(n % 4);
        return mod switch
        {
            0 => n,
            1 => 1,
            2 => n + 1,
            3 => 0,
            _ => throw new Exception("Something went wrong.")
        };
    }
}
