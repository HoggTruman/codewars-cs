// https://www.codewars.com/kata/5511b2f550906349a70004e1

namespace LastDigitOfALargeNumber;

using System;
using System.Numerics;

class LastDigit
{
    public static int GetLastDigit(BigInteger a, BigInteger b)
    {
        int lastOfA = (int)(a % 10);
        int exp = (int)(b % 4 > 0? b % 4: 4);        
        return b != 0? Convert.ToInt32(Math.Pow(lastOfA, exp)) % 10: 1;
    }
}
