// https://www.codewars.com/kata/56a921fa8c5167d8e7000053

namespace PasswordValidator;

using System.Linq;

public class PasswordValidator
{
    public static bool Password(string password)
    {
        return password.Length >= 8
            && password.Any(char.IsUpper)
            && password.Any(char.IsLower)
            && password.Any(char.IsDigit);
    }
}

