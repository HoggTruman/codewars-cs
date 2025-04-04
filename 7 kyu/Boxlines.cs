// https://www.codewars.com/kata/6129095b201d6b000e5a33f0

namespace Boxlines;

public static class Kata
{
    public static ulong F(ushort x, ushort y, ushort z) 
    {
        ulong xLines = x * (y + 1ul) * (z + 1ul);
        ulong yLines = y * (x + 1ul) * (z + 1ul);
        ulong zLines = z * (x + 1ul) * (y + 1ul);
        return xLines + yLines + zLines;
    }
}
