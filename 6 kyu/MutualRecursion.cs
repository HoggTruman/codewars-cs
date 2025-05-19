// https://www.codewars.com/kata/53a1eac7e0afd3ad3300008b

namespace MutualRecursion;

using System.Collections.Generic;

public class Kata
{
    private static readonly List<int> mCache = [0];
    private static readonly List<int> fCache = [1];

    public static int M(int n)
    {
        GenerateTerms(n);
        return mCache[n];
    }

    public static int F(int n)
    {
        GenerateTerms(n);
        return fCache[n];
    }    

    private static void GenerateTerms(int n)
    {
        if (mCache.Count < n + 1)
        {
            for (int i = mCache.Count; i <= n; ++i)
            {            
                mCache.Add(i - fCache[mCache[i - 1]]);
                fCache.Add(i - mCache[fCache[i - 1]]);
            }
        }
    }
}
