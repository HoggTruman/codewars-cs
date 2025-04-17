// https://www.codewars.com/kata/5839edaa6754d6fec10000a2

namespace FindTheMissingLetter;

public class Kata
{
    public static char FindMissingLetter(char[] array)
    {
        for (int i = 0; i < array.Length - 1; ++i)
        {
            if (array[i + 1] != array[i] + 1)
            {
                return (char)(array[i] + 1);
            }
        }

        return (char)(array[^1] + 1);
    }
}
