// https://www.codewars.com/kata/590adadea658017d90000039

namespace FruitMachine;

using System.Collections.Generic;

public class Kata
{
    private static readonly Dictionary<string, int> _triple = new()
    {
        { "Wild", 100 },
        { "Star", 90 },
        { "Bell", 80 },
        { "Shell", 70 },
        { "Seven", 60 },
        { "Cherry", 50 },
        { "Bar", 40 },
        { "King", 30 },
        { "Queen", 20 },
        { "Jack", 10 },
    };

    private static readonly Dictionary<string, int> _pair = new()
    {
        { "Wild", 10 },
        { "Star", 9 },
        { "Bell", 8 },
        { "Shell", 7 },
        { "Seven", 6 },
        { "Cherry", 5 },
        { "Bar", 4 },
        { "King", 3 },
        { "Queen", 2 },
        { "Jack", 1 },
    };

    public int fruit(List<string[]> reels, int[] spins)
    {
        string first = reels[0][spins[0]];
        string second = reels[1][spins[1]];
        string third = reels[2][spins[2]];

        if (first == second && second == third)
        {
            return _triple[first];
        }

        if (first == second)
        {
            return third == "Wild"? 2 * _pair[first]: _pair[first];
        }
        if (first == third)
        {
            return second == "Wild"? 2 * _pair[first]: _pair[first];
        }
        if (second == third)
        {
            return first == "Wild"? 2 * _pair[second]: _pair[second];
        }

        return 0;
    }
}

