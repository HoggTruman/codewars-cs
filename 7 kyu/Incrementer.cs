// https://www.codewars.com/kata/590e03aef55cab099a0002e8

namespace Incrementer;

public static class Kata
{
    public static int[] Incrementer(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; ++i)
        {
            numbers[i] = (numbers[i] + i + 1) % 10;
        }

        return numbers;
    }
}