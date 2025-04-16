// https://www.codewars.com/kata/5d8108a41e94580023bd6419

namespace ATMHeist;

public class Kata 
{
    public static int MaximumThrill(int[] arr) 
    {
        if (arr.Length == 0)
        {
            return 0;
        }

        int startIndex = 0;
        for (int i = 1; i < arr.Length; ++i)
        {
            if (arr[i] > arr[startIndex] + i - startIndex)
            {
                startIndex = i;
            }
        }

        int endIndex = startIndex;
        for (int i = startIndex + 1; i < arr.Length; ++i)
        {
            if (arr[i] + i - endIndex > arr[endIndex])
            {
                endIndex = i;
            }
        }

        return arr[startIndex] + arr[endIndex] + endIndex - startIndex;
    }
}
