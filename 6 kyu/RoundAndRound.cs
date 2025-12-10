// https://www.codewars.com/kata/5996eb39cdc8eb39f80000a0

namespace RoundAndRound;

using System;

public static class RoundAndRound
{
    public static decimal RoundBy2DecimalPlaces(this decimal number)
    {
        return Math.Round(number, 2, MidpointRounding.AwayFromZero);
    }
}
