// https://www.codewars.com/kata/529b418d533b76924600085d

namespace ConvertPascalStringIntoSnakeCase;

using System;
using System.Linq;

public static class Kata 
{
    public static string ToUnderscore(int str) 
    {
        return str.ToString();
    }

    public static string ToUnderscore(string str) 
    {
        string result = "";
        foreach (char c in str)
        {
            result += char.IsUpper(c)? $"_{char.ToLower(c)}": c.ToString();
        }
        return result.TrimStart('_');
    }
}
