// https://www.codewars.com/kata/57faa6ff9610ce181b000028

namespace CleanUpAfterYourDog;

public class Kata
{
    public static string Crap(char[,] x, int bags, int cap)
    {
        int crapCount = 0;

        for (int i = 0; i < x.GetLength(0); ++i)
        {
            for (int j = 0; j < x.GetLength(1); ++j)
            {
                if (x[i, j] == 'D')
                    return "Dog!!";

                if (x[i, j] == '@')
                    ++crapCount;
            }
        }

        return crapCount <= bags * cap ? "Clean": "Cr@p";
    }
}