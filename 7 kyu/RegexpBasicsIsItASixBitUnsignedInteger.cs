// https://www.codewars.com/kata/567e8dbb9b6f4da558000030

namespace RegexpBasicsIsItASixBitUnsignedInteger;

using System.Text.RegularExpressions;

static class SimpleExtensions 
{
    public static bool SixBitNumber(this string str) 
    {
        return Regex.IsMatch(str, @"^([1-5]?\d|6[0-3])\z");
    }
}