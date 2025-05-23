// https://www.codewars.com/kata/67757660c552a3a7ef9aaceb

namespace CheckWhetherANumberIsValidInAGivenNumeralSystem;

using System.Collections.Generic;
using System.Linq;

public class SolutionClass
{
    private readonly static char[] characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static bool ValidateBase(string num, int base_)
    {
        HashSet<char> validCharacters = new(characters[..base_]);
        return num.All(validCharacters.Contains);
    }
}
