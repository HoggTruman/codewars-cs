// https://www.codewars.com/kata/54f8b0c7a58bce9db6000dc4

namespace RotateArray;

public class Kata
{
    public static object[] Rotate(object[] array, int n)
    {
        n %= array.Length;
        return n >= 0?
            [..array[^n..], ..array[..^n]]:
            [..array[-n..], ..array[..-n]];
    }
}
