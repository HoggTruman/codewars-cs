// https://www.codewars.com/kata/5ad1e412cc2be1dbfb000016

namespace MissingAlphabet;

using System.Collections.Generic;
using System.Text;

class MissingAlphabet
{
    public static string InsertMissingLetters(string str) 
    {
        HashSet<char> originalLetters = new(str);
        HashSet<char> processedLetters = [];
        StringBuilder sb = new();
        foreach(char originalLetter in str)
        {
            sb.Append(originalLetter);
            if (!processedLetters.Contains(originalLetter))
            {
                foreach (char letter in "abcdefghijklmnopqrstuvwxyz")
                {
                    if (letter > originalLetter &&
                        !originalLetters.Contains(letter))
                    {
                        sb.Append(char.ToUpper(letter));
                    }
                }
                processedLetters.Add(originalLetter);
            }
        }

        return sb.ToString();
    }
}
