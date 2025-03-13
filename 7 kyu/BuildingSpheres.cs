// https://www.codewars.com/kata/55c1d030da313ed05100005d/csharp

namespace BuildingSpheres;

using System;
public class Sphere
{
	private readonly int _radius;
	private readonly int _mass;

	public Sphere(int radius, int mass)
	{
		_radius = radius;
		_mass = mass;
	}

	public int GetRadius() => _radius;
	public int GetMass() => _mass;
	public double GetVolume() => Math.Round(4d / 3d * Math.PI * Math.Pow(_radius, 3), 5);
	public double GetSurfaceArea() => Math.Round(4d * Math.PI * Math.Pow(_radius, 2), 5);
	public double GetDensity() => Math.Round(_mass / GetVolume(), 5);
}
