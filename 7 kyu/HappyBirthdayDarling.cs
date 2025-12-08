// https://www.codewars.com/kata/5e96332d18ac870032eb735f

namespace HappyBirthdayDarling;

public class Kata
{
    public static string WomensAge(int n)
    {
        return n % 2 == 0? 
            $"{n}? That's just 20, in base {n / 2}!":
            $"{n}? That's just 21, in base {n / 2}!";
    }
}
