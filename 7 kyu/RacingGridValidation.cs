// https://www.codewars.com/kata/692c80fa12006b05757089dd

namespace RacingGridValidation;

public static class Kata
{
    public static bool ValidateRace(int[] moves)
    {
        bool[] positionOccupied = new bool[moves.Length];

        for (int i = 0; i < moves.Length; ++i)
        {
            int startPosition = i + moves[i];
            if (startPosition < 0 || startPosition >= moves.Length || positionOccupied[startPosition])
            {
                return false;
            }

            positionOccupied[startPosition] = true;
        }

        return true;
    }
}
