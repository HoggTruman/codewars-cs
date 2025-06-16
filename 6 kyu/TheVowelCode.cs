// https://www.codewars.com/kata/53697be005f803751e0015aa

namespace TheVowelCode;

using System.Linq;

public static class VowelCode
{
    public static string Encode(string msg)
    {
        return string.Join("", msg.Select(EncodeChar));
    }
  
    public static string Decode(string msg)
    {
        return string.Join("", msg.Select(DecodeChar));
    }

    private static char EncodeChar(char c)
    {
        return c switch
        {
            'a' => '1',
            'e' => '2',
            'i' => '3',
            'o' => '4',
            'u' => '5',
            _ => c
        };
    }

    private static char DecodeChar(char c)
    {
        return c switch
        {
            '1' => 'a',
            '2' => 'e',
            '3' => 'i',
            '4' => 'o',
            '5' => 'u',
            _ => c
        };
    }
}

