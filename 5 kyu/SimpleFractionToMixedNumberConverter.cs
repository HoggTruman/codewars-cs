// https://www.codewars.com/kata/556b85b433fb5e899200003f

namespace SimpleFractionToMixedNumberConverter;

using System;

public class Kata
{
    public static string MixedFraction(string s)
    {
        int slashIndex = s.IndexOf('/');
        int numerator = int.Parse(s[..slashIndex]);
        int denominator = int.Parse(s[(slashIndex + 1)..]);

        if (denominator == 0)
        {
            throw new DivideByZeroException();
        }

        int gcd = GCD(numerator, denominator);
        string sign = Math.Sign(numerator) == Math.Sign(denominator)? "": "-";
        int whole = Math.Abs(numerator / denominator);        
        denominator = Math.Abs(denominator / gcd);
        numerator = Math.Abs(numerator / gcd % denominator);        
        
        if (numerator == 0 && whole == 0) return "0";
        if (whole == 0) return $"{sign}{numerator}/{denominator}";
        if (numerator == 0) return $"{sign}{whole}";
        return $"{sign}{whole} {numerator}/{denominator}";
    }

    private static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);    
    }
}
