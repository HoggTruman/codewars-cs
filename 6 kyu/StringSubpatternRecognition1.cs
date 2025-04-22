// https://www.codewars.com/kata/5a49f074b3bfa89b4c00002b

namespace StringSubpatternRecognition1;

class Kata
{
    public static bool HasSubpattern(string str)
    {
        return (str + str).IndexOf(str, 1) != str.Length;
    }
}
