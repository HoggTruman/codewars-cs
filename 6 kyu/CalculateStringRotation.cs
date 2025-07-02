// https://www.codewars.com/kata/5596f6e9529e9ab6fb000014

namespace CalculateStringRotation;

public class CalculateStringRotation
{
    public static int ShiftedDiff(string first, string second)
    {
        return first.Length == second.Length? (second + second).IndexOf(first): -1;
    }
}