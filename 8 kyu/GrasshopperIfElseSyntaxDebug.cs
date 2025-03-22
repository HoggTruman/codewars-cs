// https://www.codewars.com/kata/57089707fe2d01529f00024a

namespace GrasshopperIfElseSyntaxDebug;

public class Player
{
    private int health = 100;
    public int Health
    {
        get
        {
            return this.health;
        }
        set
        {
            health = value;
        }
    }
  
    public bool CheckAlive() => Health > 0;
}
