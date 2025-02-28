// https://www.codewars.com/kata/58ee4962dc4f81d6f400001c

namespace ProgramACalculator23DVectors;

using System;

public class Vector
{
    public double I;
    public double J;
    public double K;

    public Vector(double i, double j, double k)
    {
        I = i;
        J = j;
        K = k;
    }

    public double GetMagnitude()
    {
        return Math.Sqrt(I * I + J * J + K * K);
    }

    public static Vector GetI() => new(1, 0, 0);
    public static Vector GetJ() => new(0, 1, 0);
    public static Vector GetK() => new(0, 0, 1);

    public Vector Add(Vector v)
    {
        return new(I + v.I, J + v.J, K + v.K);
    }

    public Vector MultiplyByScalar(double s)
    {
        return new(I * s, J * s, K * s);
    }

    public double Dot(Vector v)
    {
        return I * v.I + J * v.J + K * v.K;
    }

    public Vector Cross(Vector v)
    {
        return new Vector(
            J * v.K - K * v.J,
            K * v.I - I * v.K,
            I * v.J - J * v.I
        );
    }

    public bool IsParallelTo(Vector v)
    {
        if (IsZeroVector() || v.IsZeroVector())
        {
            return false;
        }

        return Cross(v).IsZeroVector();
    }

    public bool IsPerpendicularTo(Vector v)
    {
        if (IsZeroVector() || v.IsZeroVector())
        {
            return false;
        }

        return IsWithinTolerance(Dot(v), 0);
    }

    public Vector Normalize()
    {
        double m = GetMagnitude();
        return new(I / m, J / m, K / m);
    }

    public bool IsNormalized()
    {
        return IsWithinTolerance(GetMagnitude(), 1);
    }

    public bool IsZeroVector()
    {
        return IsWithinTolerance(I, 0) 
            && IsWithinTolerance(J, 0) 
            && IsWithinTolerance(K, 0);
    }

    private static bool IsWithinTolerance(double actual, double expected, double error=0.00001)
    {
        return Math.Abs(expected - actual) <= error;
    }
}
