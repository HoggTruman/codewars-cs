// https://www.codewars.com/kata/57ea70aa5500adfe8a000110

namespace FoldAnArray;

public class Kata
{
    public static int[] FoldArray(int[] array, int runs)
    {
        int[] folded = array;
        for (int run = 1; run <= runs; ++run)
        {
            int[] next = new int[(folded.Length + 1) / 2];
            for (int i = 0; i < next.Length; ++i)
            {
                next[i] = folded[i] + folded[folded.Length - i - 1];
            }

            if (folded.Length % 2 == 1)
            {
                next[next.Length - 1] = folded[next.Length - 1];
            }

            folded = next;
        }

        return folded;
    }
}
