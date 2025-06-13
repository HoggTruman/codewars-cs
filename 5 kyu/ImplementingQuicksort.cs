// https://www.codewars.com/kata/6641778ddab67c48a794387d

namespace ImplementingQuicksort;

using System.Collections.Generic;
using System.Linq;

public class Quicksort
{
    public static List<int[]> QuicksortAlgorithm(int[] data)
    {        
        return QuicksortPart(data, 0, data.Length - 1).ToList();
    }

    private static IEnumerable<int[]> QuicksortPart(int[] data, int start, int end)
    {
        if (end <= start)
        {
            return [];
        }

        List<int[]> snapshots = [];
        int pivot = start;
        int i = start + 1;
        int j = end;

        while (i <= j)
        {
            while (i <= j && data[i] <= data[pivot])
            {
                ++i;
            }

            if (j >= i && data[j] >= data[pivot])
            {
                --j;
            }

            if (i < j && data[i] > data[pivot] && data[j] < data[pivot])
            {
                (data[i], data[j]) = (data[j], data[i]);
                snapshots.Add([..data]);
            }            
        }

        if (j > pivot && data[j] != data[pivot])
        {
            (data[pivot], data[j]) = (data[j], data[pivot]);
            snapshots.Add([..data]);
        }        

        return snapshots
            .Concat(QuicksortPart(data, start, j - 1))
            .Concat(QuicksortPart(data, j + 1, end));
    }
}