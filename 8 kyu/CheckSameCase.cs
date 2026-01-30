// https://www.codewars.com/kata/5dd462a573ee6d0014ce715b

namespace CheckSameCase;

public class Kata
{
    public static int SameCase(char a, char b) 
    {
        if (!char.IsLetter(a) || !char.IsLetter(b))
            return -1;

        return char.IsUpper(a) == char.IsUpper(b) ? 1 : 0;
    }
}