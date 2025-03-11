// https://www.codewars.com/kata/5523b97ac8f5025c45000900

namespace Vectors1;

using System;

public class Vector3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double Length { get => Math.Sqrt(X * X + Y * Y + Z * Z); }
}
