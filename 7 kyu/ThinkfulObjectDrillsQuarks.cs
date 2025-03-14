// https://www.codewars.com/kata/5882b052bdeafec15e0000e6

namespace ThinkfulObjectDrillsQuarks;

public class Quark 
{
    public readonly double BaryonNumber = 1d / 3d;
    public string Color { get; private set; }
    public string Flavor { get; private set; }

    public Quark(string color, string flavor)
    {
        Color = color;
        Flavor = flavor;
    }

    public void Interact(Quark q)
    {
        (Color, q.Color) = (q.Color, Color);
    }
}
