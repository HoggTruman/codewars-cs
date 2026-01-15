// https://www.codewars.com/kata/59727ff285281a44e3000011

namespace BandNameGenerator;

using System.Text;

public class Kata
{
    public static string BandNameGenerator(string str)
    {
        StringBuilder sb = new();

        if (str[0] == str[^1])
        {
            sb.Append(char.ToUpper(str[0]));
            sb.Append(str[1..]);
            sb.Append(str[1..]);
        }
        else
        {
            sb.Append("The ");
            sb.Append(char.ToUpper(str[0]));
            sb.Append(str[1..]);
        }

        return sb.ToString();
    }
}