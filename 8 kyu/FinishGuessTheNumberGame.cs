// https://www.codewars.com/kata/568018a64f35f0c613000054

namespace FinishGuessTheNumberGame;

using System;

public class Guesser
{
    private int number;
    private int lives;

    public Guesser(int number, int lives)
    {
        this.number = number;
        this.lives = lives;
    }

    public bool Guess(int n)
    {
        if (lives == 0)
            throw new Exception("Out of lives!");

        if (number == n)
            return true;

        --lives;
        return false;
    }
}
