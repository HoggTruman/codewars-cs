// https://www.codewars.com/kata/54fb853b2c8785dd5e000957

namespace ChainMe;

using System;

public static class Kata
{
    public static double Chain(double input, Func<double,double>[] fs)
    {
        double result = input;

        foreach(var func in fs)
        {
            result = func(result);
        }

        return result;
    }
}
