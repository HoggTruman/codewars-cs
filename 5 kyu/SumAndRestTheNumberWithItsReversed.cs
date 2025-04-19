// https://www.codewars.com/kata/5603a9585480c94bd5000073

namespace SumAndRestTheNumberWithItsReversed;

using System;
using System.Collections.Generic;

public static class Kata 
{
    public static int SumDifRev(int n) 
    {
        List<int> sequence = [];
        Dictionary<int, int> reverse = new();

        for (int k = 0; k <= 9; ++k)
        {
            reverse[k] = k;
        }
        

        int nDigits = 2;
        while (sequence.Count < n)
        {
            for (int firstDigit = 1; firstDigit <= 9; ++firstDigit)
            {
                int front = firstDigit * (int)Math.Pow(10, nDigits - 1);
                for (int n_remDigits = 1; n_remDigits < nDigits; ++n_remDigits)
                {
                    int multiplier = (int)Math.Pow(10, nDigits - n_remDigits);
                    for (int remainingDigits = n_remDigits == 1? 0:(int)Math.Pow(10, n_remDigits - 1); remainingDigits < (int)Math.Pow(10, n_remDigits); ++remainingDigits)
                    {   
                        int k = front + remainingDigits;
                        int kRev = reverse[remainingDigits] * multiplier + firstDigit;
                        reverse[k] = kRev;
                    }
                }                
            }

            for (int k = (int)Math.Pow(10, nDigits - 1); k < (int)Math.Pow(10, nDigits); ++k)
            {
                if (k % 10 != 0 &&
                    k != reverse[k] &&
                    (k + reverse[k]) % Math.Abs(k - reverse[k]) == 0)
                {
                    sequence.Add(k);
                }
            }
            ++nDigits;
        }

        return sequence[n - 1];
    }    
}
