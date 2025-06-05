// https://www.codewars.com/kata/59e4b634f703c4c95c000097

namespace SelectConsecutive;

using System;
using System.Collections.Generic;
using System.Linq;

public static class Ext
{
    public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> selector)
    {
        if (source == null || selector == null)
        {
            throw new ArgumentNullException();
        }

        return Generate(source, selector);
    }

    private static IEnumerable<TResult> Generate<TSource, TResult>(
        IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> selector)
    {
        var enumerator = source.GetEnumerator();
        TSource? prev = default;
        if (enumerator.MoveNext())
        {
            prev = enumerator.Current;
        }

        while (enumerator.MoveNext())
        {            
            yield return selector(prev, enumerator.Current);
            prev = enumerator.Current;
        }
    }
}
