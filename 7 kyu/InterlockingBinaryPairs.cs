// https://www.codewars.com/kata/628e3ee2e1daf90030239e8a

namespace InterlockingBinaryPairs;

public static class Kata
{
    public static bool Interlockable(ulong a, ulong b)
    {
        return (a & b) == 0;
    }
}