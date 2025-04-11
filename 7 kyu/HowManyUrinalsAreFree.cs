// https://www.codewars.com/kata/5e2733f0e7432a000fb5ecc4

namespace HowManyUrinalsAreFree;

public static class FreeUrinals
{
    public static int GetFreeUrinals(string urinals)
    {
        int freeUrinals = 0;

        for (int i = 1; i < urinals.Length - 1; ++i)
        {
            if (urinals[i] == '1' &&
                (urinals[i - 1] == '1' || urinals[i + 1] == '1'))
            {
                return -1;
            }
        }

        for (int i = 0; i < urinals.Length; ++i)
        {
            if (urinals[i] == '0' &&
                (i - 1 < 0 || urinals[i - 1] == '0') &&
                (i + 1 >= urinals.Length || urinals[i + 1] == '0'))
            {
                ++freeUrinals;
                ++i;
            }
        }

        return freeUrinals;
    }
}
