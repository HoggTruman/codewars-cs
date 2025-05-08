// https://www.codewars.com/kata/5b5604e26dc79e6832000101

namespace InvertingAHash;

using System.Collections.Generic;

public class Kata
{
    public static Dictionary<TValue, TKey> InvertHash<TKey, TValue>(Dictionary<TKey, TValue> dictionary) 
        where TKey : notnull
        where TValue : notnull
    {
        Dictionary<TValue, TKey> result = [];

        foreach(var kv in dictionary)
        {
            result[kv.Value] = kv.Key;
        }

        return result;
    }
}
