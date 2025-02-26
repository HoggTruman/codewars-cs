// https://www.codewars.com/kata/572bbd7c72a38bd878000a73

namespace ImplementTheFractionsClass;

public class Fraction
{
    private long Top { get; set; }
    private long Bottom { get; set; }
    
    public Fraction(long numerator, long denominator)
    {
        long gcd = GCD(numerator, denominator);
        Top = numerator / gcd;
        Bottom = denominator / gcd;
    }
  
    public override int GetHashCode() => this.GetHashCode(); // not actually used
    public override bool Equals(object o) => Compare(this, o as Fraction) == 0;
    public static bool operator ==(Fraction f1, Fraction f2) => Compare(f1, f2) == 0;
    public static bool operator !=(Fraction f1, Fraction f2) => Compare(f1, f2) != 0;
    private static long Compare(Fraction f1, Fraction f2) => f1.Top * f2.Bottom - f2.Top * f1.Bottom;

    public override string ToString() => $"{Top}/{Bottom}";

    public static Fraction operator +(Fraction a, Fraction b)
    {
        long bottom = a.Bottom * b.Bottom;
        long top = a.Top * b.Bottom + b.Top * a.Bottom;
        return new Fraction(top, bottom);
    }

    private static long GCD(long a, long b)
    {
        return b == 0? a: GCD(b, a % b);
    }
}
