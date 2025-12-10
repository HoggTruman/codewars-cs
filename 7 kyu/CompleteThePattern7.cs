// https://www.codewars.com/kata/557592fcdfc2220bed000042

namespace CompleteThePattern7;

using System.Text;

public class CyclicalPermutation
{
    public static string Pattern(int n)
    {
        StringBuilder sb = new();

        for (int k = 0; k < n; ++k)
        {
            for (int offset = 0; offset < n; ++offset)
            {
                sb.Append(1 + (k + offset) % n);
            }

            if (k != n - 1)
            {
                sb.Append('\n');
            }                
        }

        return sb.ToString();
    }
}