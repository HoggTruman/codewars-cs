// https://www.codewars.com/kata/5a89cdf1ba1bb5f3a300062e

namespace ImplementingALINQMinByOperator;

using System;
using System.Collections.Generic;

public static class Extensions
{
    public static TSource MinBy<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer = null)
    {
        // argument validation and defaulting for comparer
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
        if (comparer == null) comparer = Comparer<TKey>.Default;
      
        var enumerator = source.GetEnumerator();

        if (!enumerator.MoveNext()) throw new InvalidOperationException();
        
        TSource minElement = enumerator.Current;
        TKey minKey = keySelector(enumerator.Current);

        while (enumerator.MoveNext())
        {
            TKey currentKey = keySelector(enumerator.Current);
            if (comparer.Compare(currentKey, minKey) < 0)
            {
                minElement = enumerator.Current;
                minKey = currentKey;
            }
        }

        return minElement;
    }
}
