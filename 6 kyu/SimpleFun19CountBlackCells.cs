// https://www.codewars.com/kata/588475d575431d0a0e000023

namespace SimpleFun19CountBlackCells;

public class Kata
{
    public int CountBlackCells(int h, int w)
    {
        return h + w + GCD(h, w) - 2;         
    }

    private static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);    
    }
}
