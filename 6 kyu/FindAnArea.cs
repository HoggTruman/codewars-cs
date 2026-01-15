// https://www.codewars.com/kata/59b166f0a35510270800018d

namespace FindAnArea;

using System.Collections.Generic;

public class Point
{
    public Point(double x, double y)
    {
      X = x;
      Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }
}
 

public class Kata
{
    public static double FindArea(List<Point> points)
    {
        double area = 0;
        Point prev = points[0];

        for (int i = 1; i < points.Count; ++i)
        {
            area += 0.5 * (prev.Y + points[i].Y) * (points[i].X - prev.X);
            prev = points[i];
        }        
        
        return area;
    }
}