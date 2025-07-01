// https://www.codewars.com/kata/596f72bbe7cd7296d1000029

namespace ArrayDeepCount;   

public class Kata
{
    public static int DeepCount(object a)
    {
        int count = 0;
        foreach (object x in (object[])a)
        {
            count += x is object[]? 1 + DeepCount(x): 1;     
        }

        return count;
    }
}
