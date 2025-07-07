// https://www.codewars.com/kata/5fc7d2d2682ff3000e1a3fbc

namespace MessageValidator;

using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
    public static bool isAValidMessage(string message)
    {
        if (message.Length == 0)
        {
            return true;
        }

        string[] words = Regex.Split(message, @"\d+").Where(x => x.Length > 0).ToArray();
        string[] numbers = Regex.Split(message, @"[a-zA-Z]+").Where(x => x.Length > 0).ToArray();

        if (char.IsLetter(message[0]) || numbers.Length != words.Length)
        {
            return false;
        }

        for (int i = 0; i < numbers.Length; ++i)
        {
            if (int.Parse(numbers[i]) != words[i].Length)
            {
                return false;
            }
        }

        return true;
    }
}
