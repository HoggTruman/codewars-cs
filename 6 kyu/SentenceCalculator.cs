// https://www.codewars.com/kata/5970fce80ed776b94000008b

namespace SentenceCalculator;

public class Calculator
{
    public static int LettersToNumbers(string s)
    {
        int score = 0;

        foreach (char c in s)
        {
            if(char.IsUpper(c))
            {
                score += 2 * (1 + c - 'A'); 
            }
            else if (char.IsLower(c))
            {
                score += 1 + c -'a';
            }
            else if (char.IsDigit(c))
            {
                score += c - '0';
            }
        }

        return score;
    }
}
