// https://www.codewars.com/kata/58fa273ca6d84c158e000052/csharp

namespace NumberOfDecimalDigits;

public class DecTools 
{
    public static int Digits(ulong n) 
    {
        return n <= 9 ? 1 : Digits(n / 10) + 1;
    }
}
