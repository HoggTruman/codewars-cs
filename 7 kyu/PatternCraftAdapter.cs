// https://www.codewars.com/kata/patterncraft-adapter/

namespace PatternCraftAdapter;

using System;

public class Target
{
    public int Health { get; set; }
}

public interface IUnit
{
    void Attack(Target target);
}

public class Marine : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 6;
    }
}

public class Zealot : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 8;
    }
}

public class Zergling : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 5;
    }
}

public class Mario
{
    public int jumpAttack()
    {
        Console.WriteLine("Mamamia!");
        return 3;
    }
}

public class MarioAdapter : IUnit
{
    private Mario _mario;

    public MarioAdapter(Mario mario)
    {
        _mario = mario;
    }    

    public void Attack(Target target)
    {
        target.Health -= _mario.jumpAttack();
    }
}