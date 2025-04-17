// https://www.codewars.com/kata/52b757663a95b11b3d00062d

namespace WeirdStringCase;

using System.Text;

public class Kata
{
    public static string ToWeirdCase(string s)
    {
        StringBuilder sb = new();
        int wordIndex = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == ' ')
            {
                wordIndex = 0;
                sb.Append(' ');
            }
            else
            {
                sb.Append(wordIndex % 2 == 0? char.ToUpper(s[i]): char.ToLower(s[i]));
                ++wordIndex;
            }
        }
        return sb.ToString();
    }
}
