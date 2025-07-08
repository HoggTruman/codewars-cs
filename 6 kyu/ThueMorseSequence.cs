// https://www.codewars.com/kata/591aa1752afcb02fa300002a

namespace ThueMorseSequence;

using System.Linq;

public class Kata
{
    public static string ThueMorse(int n) 
    {
        string sequence = "0";
        while (sequence.Length < n)
        {
            sequence += string.Join("", sequence.Select(x => x == '0'? '1': '0'));
        }

        return sequence[..n];
    }
}
