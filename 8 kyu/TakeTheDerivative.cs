// https://www.codewars.com/kata/5963c18ecb97be020b0000a2

namespace TakeTheDerivative;

public class Kata
{
    public static string Derive(double coefficient, double exponent)
    {
        return $"{coefficient * exponent}x^{exponent - 1}";
    }
}
