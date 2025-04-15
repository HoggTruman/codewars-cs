// https://www.codewars.com/kata/582dafb611d576b745000b74

namespace ForUFCFans;

using System;

public static class Kata
{
    public static string Quote(string fighter)
    {
        return fighter.ToLower() switch
        {
            "george saint pierre" => "I am not impressed by your performance.",
            "conor mcgregor" => "I'd like to take this chance to apologize.. To absolutely NOBODY!",
            _ => throw new ArgumentException()
        };
    }
}
