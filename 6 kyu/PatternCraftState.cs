// https://www.codewars.com/kata/5682e72eb7354b2f39000021

namespace PatternCraftState;

public interface IUnit
{
    IUnitState State { get; set; }
    bool CanMove { get; }
    int Damage { get; }
}

public interface IUnitState
{
    bool CanMove { get; set; }
    int Damage { get; set; }
}

public class SiegeState : IUnitState
{
    public bool CanMove { get; set; } = false;
    public int Damage { get; set; } = 20;
}

public class TankState : IUnitState
{
    public bool CanMove { get; set; } = true;
    public int Damage { get; set; } = 5;
}

public class Tank : IUnit
{
    public IUnitState State { get; set; } = new TankState();

    public bool CanMove => State.CanMove;
    public int Damage => State.Damage;
}
