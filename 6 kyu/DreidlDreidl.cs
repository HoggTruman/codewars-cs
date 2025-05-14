// https://www.codewars.com/kata/52b013920b1d45c8b4000355

namespace DreidlDreidl;

public class Driedel
{
    public static int Gamble(string[] rolls, int myCoins, int pot)
    {
        for (int i = 0; i < rolls.Length; ++i)
        {
            if (rolls[i] == "Gimel")
            {
                myCoins += pot;
                pot = 0;
            }
            else if (rolls[i] == "Hei")
            {
                myCoins += pot / 2;
                pot = (pot + 1) / 2;
            }
            else if (rolls[i] == "Shin")
            {
                --myCoins;
                ++pot;
            }
        }

        return myCoins;
    }
}
