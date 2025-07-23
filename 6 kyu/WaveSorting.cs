// https://www.codewars.com/kata/596f28fd9be8ebe6ec0000c1

namespace WaveSorting;

using System;

public class Kata
{
    public static void WaveSort(int[] arr)
    {
        Array.Sort(arr);
        for (int i = 1; i < arr.Length; i += 2)
        {
            (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
        }
    }
}
