// https://www.codewars.com/kata/525f47c79f2f25a4db000025

namespace ValidPhoneNumber;

using System.Text.RegularExpressions;

public static class Kata
{
    public static bool ValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^\(\d{3}\) \d{3}-\d{4}$");
    }
}