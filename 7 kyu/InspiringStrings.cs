// https://www.codewars.com/kata/5939ab6eed348a945f0007b2

namespace InspiringStrings;

public class Kata
{
    public static string LongestWord(string stringOfWords)
    {
        string longestWord = "";
        foreach (string word in stringOfWords.Split())
        {
            if (word.Length >= longestWord.Length)
            {
                longestWord = word;
            }
        }

        return longestWord;
    }
}
