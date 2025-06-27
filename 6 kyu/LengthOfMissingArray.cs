// https://www.codewars.com/kata/57b6f5aadb5b3d0ae3000611

namespace LengthOfMissingArray;

using System.Linq;

public class Kata
{
    public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
    {
        if (arrayOfArrays == null || arrayOfArrays.Length == 0 || 
            arrayOfArrays.Any(x => x == null || x.Length == 0))
        {
            return 0;
        }

        var ordered = arrayOfArrays.OrderBy(x => x.Length).ToList();
        for (int i = 1; i < ordered.Count; ++i)
        {
            if (ordered[i].Length != ordered[i - 1].Length + 1)
            {
                return ordered[i - 1].Length + 1;
            }
        }

        return 0;
    }
}
