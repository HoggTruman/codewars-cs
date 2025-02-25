// https://www.codewars.com/kata/56dae2913cb6f5d428000f77/train/csharp

namespace ThinkingAndTestingNotPerfectThrowAway;

using System;
    
public class Kata
{
    public string Testit(string s){
        string result = "";

        for (int i = 0; i < s.Length; ++i)
        {
            if (IsPrime(i))
                result += s[i];
        }
        return result;
    }


    private static bool IsPrime(int n)
    {
        if (n == 0 || n == 1)
            return false;

        for (int k = 2; k <= Math.Sqrt(n); ++k)
        {
            if (n % k == 0)
                return false;
        }

        return true;
    }
}
