// https://www.codewars.com/kata/568338ea371e86728c000002

namespace RegexpBasicsParsingTime;

using System.Text.RegularExpressions;

public static class Kata
{
    public static int? ToSeconds(this string time)
    {
        var match = Regex.Match(time, @"^(\d\d):(\d\d):(\d\d)$");

        if (!match.Success)
        {
            return null;
        }

        int hours = int.Parse(match.Groups[1].Value);
        int minutes = int.Parse(match.Groups[2].Value);
        int seconds = int.Parse(match.Groups[3].Value);

        if (minutes > 59 || seconds > 59)
        {
            return null;
        }

        return hours * 3600 + minutes * 60 + seconds;
    }
}
