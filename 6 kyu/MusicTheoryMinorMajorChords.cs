// https://www.codewars.com/kata/57052ac958b58fbede001616

namespace MusicTheoryMinorMajorChords;

using System.Collections.Generic;
using System.Linq;

public static class Kata 
{
    // There is a preloaded list of the 12 notes of a chromatic scale built on C. 
    // This means that there are (almost) all allowed note' s names in music.
    private static readonly string[][] notes = new [] 
    {
        new [] { "C" }, 
        new [] { "C#", "Db" },
        new [] { "D" }, 
        new [] { "D#", "Eb" },
        new [] { "E" },
        new [] { "F" },
        new [] { "F#", "Gb" },
        new [] { "A" },
        new [] { "A#", "Bb" },
        new [] { "B" },
    };

    private static readonly Dictionary<string, int> notePositions = new()
    {
        ["C"] = 0,
        ["C#"] = 1,
        ["Db"] = 1,
        ["D"] = 2,
        ["D#"] = 3,
        ["Eb"] = 3,
        ["E"] = 4,
        ["F"] = 5,
        ["F#"] = 6,
        ["Gb"] = 6,
        ["G"] = 7,
        ["G#"] = 8,
        ["Ab"] = 8,
        ["A"] = 9,
        ["A#"] = 10,
        ["Bb"] = 10,
        ["B"] = 11
    };

  
    public static string MinorOrMajor(string chord) 
    {
        string[] notes = chord.Split();

        if (notes.Length != 3 || !notes.All(notePositions.ContainsKey))
        {
            return "Not a chord";
        }

        int firstInterval = (notePositions[notes[1]] - notePositions[notes[0]] + 12) % 12;
        int secondInterval = (notePositions[notes[2]] - notePositions[notes[1]] + 12) % 12;  

        return (firstInterval, secondInterval) switch
        {
            (4, 3) => "Major",
            (3, 4) => "Minor",
            _ => "Not a chord"
        };
    }
}
