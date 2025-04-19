// https://www.codewars.com/kata/55c9172ee4bb15af9000005d

namespace Pentabonacci;

using System.Collections.Generic;
using System.Linq;

public class Pentanacci 
{
    public static long CountOddPentaFib(long n) 
    {
        List<long> seq = [0, 1, 1, 2, 4];

        while (seq.Count < n + 1)
        {
            seq.Add(seq[^1] + seq[^2] + seq[^3] + seq[^4] + seq[^5]);
        }

        return seq[..(int)(n + 1)].Count(x => x % 2 != 0) - (n > 2? 1: 0);
    }
}
