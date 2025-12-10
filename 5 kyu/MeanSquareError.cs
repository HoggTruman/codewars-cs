// https://www.codewars.com/kata/51edd51599a189fe7f000015

namespace MeanSquareError;

public class Kata
{
    public static double Solution(int[] first, int[] second)
    {
        double sum = 0;
        for (int i = 0; i < first.Length; ++i)
        {
            int diff = first[i] - second[i];
            sum += diff * diff;
        }
        
        return sum / first.Length;
    }
}