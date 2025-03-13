// https://www.codewars.com/kata/56743fd3a12043ffbb000049


namespace ShesASmallWonder;

using System;
using System.Collections.Generic;
using System.Linq;

public class Robot 
{
    private const string BadWordResponse = "I do not understand the input";
    private const string AlreadyKnownResponse = "I already know the word ";
    private const string NewWordResponse = "Thank you for teaching me ";
    private readonly HashSet<string> _knownWords = [
        ..BadWordResponse.ToLower().Split(), 
        ..AlreadyKnownResponse.ToLower().Split(),
        ..NewWordResponse.ToLower().Split()        
    ];

    public string LearnWord(string word)
    {
        if (word.Length == 0 ||
            !word.All(Char.IsLetter))
        {
            return BadWordResponse;
        }

        string sanitizedWord = word.ToLower();
        if (_knownWords.Contains(sanitizedWord))
        {
            return AlreadyKnownResponse + word;
        }
        
        _knownWords.Add(sanitizedWord);
        return NewWordResponse + word;            
    }
}
