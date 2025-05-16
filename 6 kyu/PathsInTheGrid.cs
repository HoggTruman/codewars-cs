// https://www.codewars.com/kata/56a127b14d9687bba200004d

namespace PathsInTheGrid;

using System.Numerics;

public class GridPath
{
    public static BigInteger NumberOfRoutes(int m, int n)
    {
        int totalMoves = m + n - 2;
        int downMoves = m - 1;
        int rightMoves = n - 1;
        return Factorial(totalMoves) / (Factorial(downMoves) * Factorial(rightMoves));
    }

    public static BigInteger Factorial(int n)
    {
        BigInteger result = 1;

        for (int k = 1; k <= n; ++k)
        {
            result *= k;
        }

        return result;
    }
}
