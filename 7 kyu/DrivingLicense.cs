// https://www.codewars.com/kata/586a1af1c66d18ad81000134


namespace DrivingLicense;

using System;
using System.Text;

class Kata
{
    public string driver (params string[] data)
    {
        StringBuilder sb = new();

        // 1-5: Add surname characters
        string surname = data[2];
        sb.Append(data[2].Length < 5?
            surname + new string('9', 5 - surname.Length):
            surname[..5]);

        // 6: Add decade digit from DoB
        sb.Append(data[3][^2]);

        // 7-8: Month Of Birth
        string monthOfBirth = data[3].Split('-')[1];
        string gender = data[4];
        int monthNumber = GetMonth(monthOfBirth);
        sb.Append(gender == "M"? $"{monthNumber}".PadLeft(2, '0'): $"{monthNumber + 50}");

        // 9-10: The day digits from DoB
        sb.Append(data[3][..2]);

        // 11: Year digit from DoB
        sb.Append(data[3][^1]);

        // 12-13: First letter of first and middle name
        sb.Append(data[0][0]);
        sb.Append(data[1].Length > 0? data[1][0] : '9');

        // 14: Arbitrary digit
        sb.Append('9');

        // 15-16: Computer Check Digits
        sb.Append("AA");

        return sb.ToString().ToUpper();
    }

    private static int GetMonth(string month)
    {
        string firstThreeCharacters = month[..3];
        return firstThreeCharacters switch
        {
            "Jan" => 1,
            "Feb" => 2,
            "Mar" => 3,
            "Apr" => 4,
            "May" => 5,
            "Jun" => 6,
            "Jul" => 7,
            "Aug" => 8,
            "Sep" => 9,
            "Oct" => 10,
            "Nov" => 11,
            "Dec" => 12,
            _ => throw new ArgumentException("Invalid month provided")
        };
    }
}
