// https://www.codewars.com/kata/51fc3beb41ecc97ee20000c3/csharp

namespace LazyRepeater;

using System;

public class Kata
{
    public static Func<char> MakeLooper(string str)
    {
        int call = -1;
        return () => str[++call % str.Length];
    }
}
