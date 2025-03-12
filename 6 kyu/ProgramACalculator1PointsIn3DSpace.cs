// https://www.codewars.com/kata/58e46873c45e9af88d00006a

namespace ProgramACalculator1PointsIn3DSpace;

using System;

public class Point
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    

    public Point(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point GetOrigin()
    {
        return new Point(0, 0 ,0);
    }

    public double GetDistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public double GetDistanceFromPoint(Point p)
    {
        return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2) + Math.Pow(Z - p.Z, 2));
    }
}
