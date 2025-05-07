// https://www.codewars.com/kata/5274e122fc75c0943d000148

namespace GroupedByCommas;

using System.Text;

public static class Kata
{
    public static string GroupByCommas(int n)
    {
        StringBuilder sb = new();
        string number = n.ToString();

        if (number.Length <= 3)
        {
            return number;
        }

        int firstComma = (number.Length + 2) % 3;

        for (int i = 0; i < number.Length; ++i)
        {
            sb.Append(number[i]);

            if (i != number.Length - 1 && i % 3 == firstComma)
            {
                sb.Append(',');
            }
        }
        
        return sb.ToString();
    }
}