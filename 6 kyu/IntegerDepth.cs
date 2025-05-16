// https://www.codewars.com/kata/59b401e24f98a813f9000026

namespace IntegerDepth;

using System.Collections.Generic;

public class Kata 
{
    public static int ComputeDepth(int n)
    {
        HashSet<int> discovered = [];

        int term = n;
        int count = 0;

        while (discovered.Count < 10)
        {
            while (term > 0)
            {
                discovered.Add(term % 10);
                term /= 10;
            }

            ++count;
            term = (count + 1) * n;            
        }

        return count;
    }
}
