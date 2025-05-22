// https://www.codewars.com/kata/56efab15740d301ab40002ee

namespace ReducingBySteps;

using System;

public class Operarray 
{
    public static long gcdi(long x, long y) 
    {
        return Math.Abs(y == 0 ? x : gcdi(y, x % y)); 
    }

    public static long lcmu(long a, long b) 
    {
        return Math.Abs(a * b / gcdi(a, b));
    }

    public static long som(long a, long b) 
    {
        return a + b;
    }

    public static long maxi(long a, long b) 
    {
        return Math.Max(a, b);
    }

    public static long mini(long a, long b) 
    {
        return Math.Min(a, b);
    }

    public static long oper(Func<long, long, long> fct, long a, long b) 
    {
        return fct(a, b);
    }

    public static long[] OperArray(Func<long, long, long> fct, long[] arr, long init) 
    {
        long[] result = new long[arr.Length];
        result[0] = fct(init, arr[0]);
        
        for (int i = 1; i < arr.Length; ++i)
        {
            result[i] = fct(arr[i], result[i - 1]);
        }

        return result;
    }
}
