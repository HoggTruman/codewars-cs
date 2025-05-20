// https://www.codewars.com/kata/56cafdabc8cfcc3ad4000a2b

namespace BinaryScORe;

using System.Numerics;

public class BinaryScore
{
    public static BigInteger Score(BigInteger n)
    {
        BigInteger score = 0;

        for (BigInteger k = 1; k <= n; k *= 2)
        {
            score += k;
        }

        return score;
    }
}
