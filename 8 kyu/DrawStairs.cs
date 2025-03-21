// https://www.codewars.com/kata/5b4e779c578c6a898e0005c5

namespace DrawStairs;

using System.Text;

public class Kata
{
    public static string DrawStairs(int n)
    {
        if (n == 0)
        {
            return "";
        }

        StringBuilder sb = new("I");
        for (int i = 2; i <= n; ++i)
        {
            sb.Append('\n');
            sb.Append(new string(' ', i - 1));
            sb.Append('I');            
        }

        return sb.ToString();
    }
}
