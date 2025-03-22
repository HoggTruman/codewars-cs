// https://www.codewars.com/kata/57e1e61ba396b3727c000251

namespace StringCleaning;
using System.Text;

public class Kata
{
    public static string StringClean(string s)
    {
        StringBuilder sb = new();
        foreach (char c in s)
        {
            if (!char.IsDigit(c))
                sb.Append(c);
        }

        return sb.ToString();
    }
}
