// https://www.codewars.com/kata/5576f6719988e71ea30000ae

namespace FloodFill;

using System.Collections.Generic;

public struct Point(int y, int x)
{
    public int X = x;
    public int Y = y;
}

public class Kata
{
    public static int[,] FloodFill(int[,] array, int y, int x, int newValue)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        if (y >= rows || y < 0 ||
            x >= cols || x < 0 ||
            array[y, x] == newValue)
        {
            return array;
        }        

        int oldValue = array[y, x];        
        array[y, x] = newValue;
        Queue<Point> toFlood = [];
        toFlood.Enqueue(new(y, x));

        while (toFlood.Count > 0)
        {
            Point p = toFlood.Dequeue();

            if (p.Y > 0 && array[p.Y - 1, p.X] == oldValue)
            {
                array[p.Y - 1, p.X] = newValue;
                toFlood.Enqueue(new(p.Y - 1, p.X));
            }
            if (p.Y < rows - 1 && array[p.Y + 1, p.X] == oldValue)
            {
                array[p.Y + 1, p.X] = newValue;
                toFlood.Enqueue(new(p.Y + 1, p.X));
            }
            if (p.X > 0 && array[p.Y, p.X - 1] == oldValue)
            {
                array[p.Y, p.X - 1] = newValue;
                toFlood.Enqueue(new(p.Y, p.X - 1));
            }
            if (p.X < cols - 1 && array[p.Y, p.X + 1] == oldValue)
            {
                array[p.Y, p.X + 1] = newValue;
                toFlood.Enqueue(new(p.Y, p.X + 1));
            }
        }        

        return array;
    }
}
