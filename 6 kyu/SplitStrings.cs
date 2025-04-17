// https://www.codewars.com/kata/515de9ae9dcfc28eb6000001

namespace SplitStrings;

public class SplitString
{
    public static string[] Solution(string str)
    {
        string[] result = new string[(str.Length + 1) / 2];
        for (int i = 0; i < str.Length; i += 2)
        {
            result[i / 2] = i == str.Length - 1?
                str[i] + "_":
                str[i..(i + 2)];
        }

        return result;
    }
}
