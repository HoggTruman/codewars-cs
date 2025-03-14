// https://www.codewars.com/kata/525c7c5ab6aecef16e0001a5/csharp

namespace ParseIntReloaded;

using System.Collections.Generic;
using System.Linq;

public class Parser
{
    private static readonly List<string> KeyPowers = ["million", "thousand", "hundred", "one"];
    private static readonly Dictionary<string, int> Units = new()
    {
        {"zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "ten", 10 },
        { "eleven", 11 },
        { "twelve", 12 },
        { "thirteen", 13 },
        { "fourteen", 14 },
        { "fifteen", 15 },
        { "sixteen", 16 },
        { "seventeen", 17 },
        { "eighteen", 18 },
        { "nineteen", 19 },
        { "twenty", 20 },
        { "thirty", 30 },
        { "forty", 40 },
        { "fifty", 50 },
        { "sixty", 60 },
        { "seventy", 70 },
        { "eighty", 80 },
        { "ninety", 90 },
        { "hundred", 100 },
        { "thousand", 1000 },
        { "million", 1_000_000 }
    };


    public static int ParseInt(string s)
    {
        int result = 0;
        int currentMultiplier = 0;
        List<string> parts = [..s.Split([' ', '-']).Where(x => x != "and")];
        int startIndex = 0;

        foreach(string keyPower in KeyPowers)
        {
            int powerIndex = keyPower == "one"?
                parts.Count:
                parts.IndexOf(keyPower, startIndex);

            if (powerIndex != -1)
            {
                for (int i = startIndex; i < powerIndex; ++i)
                {
                    currentMultiplier = parts[i] == "hundred"?
                        currentMultiplier * Units[parts[i]]:
                        currentMultiplier + Units[parts[i]];
                }

                startIndex = powerIndex + 1;
                result += currentMultiplier * Units[keyPower];
                currentMultiplier = 0;
            }            
        }

        return result;
    }
}