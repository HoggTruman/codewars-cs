// https://www.codewars.com/kata/525d50d2037b7acd6e000534

namespace ArrayHelpers;

using System.Linq;

static class Extensions 
{
    public static int[] Square(this int[] arr)
    {
        return arr.Select(x => x * x).ToArray();
    }

    public static int[] Cube(this int[] arr)
    {
        return arr.Select(x => x * x * x).ToArray();
    }

    public static double Average(this int[] arr)
    {
        return arr.Length > 0? (double)arr.Sum() / arr.Length: double.NaN;
    }

    public static int Sum(this int[] arr)
    {
        return arr.Aggregate(0, (acc, x) => acc + x);
    }

    public static int[] Even(this int[] arr)
    {
        return arr.Where(x => x % 2 == 0).ToArray();
    }

    public static int[] Odd(this int[] arr)
    {
        return arr.Where(x => x % 2 != 0).ToArray();
    }
}
