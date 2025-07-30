// https://www.codewars.com/kata/522551eee9abb932420004a0

namespace NthFibonacci;

using System.Collections.Generic;

public class Fibonacci
{
    public int NthFib(int n)
    {
        List<int> sequence = [0, 1];

        while (sequence.Count < n)
        {
            sequence.Add(sequence[^1] + sequence[^2]);
        }

        return sequence[n - 1];
    }
}
