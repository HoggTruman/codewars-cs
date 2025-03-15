// https://www.codewars.com/kata/66bdf9f511467a75cf5ff88b

namespace TheEpicRPGBattle;

using System;

enum Action
{
    Buff = 1,
    NormalAttack = 2,
    SpecialAttack = 3
}

abstract class Actor(int maxHP, int attack, int specialAttack, string characterClass)
{
    private int _hp = maxHP;
    protected readonly int _attack = attack;
    protected readonly int _specialAttack = specialAttack;

    public readonly string CharacterClass = characterClass;
    public readonly int MaxHP = maxHP;
    public int HP
    {
        get => _hp;
        set => _hp = Math.Max(0, Math.Min(MaxHP, value));
    }

    public virtual int Attack
    {
        get => _attack;
    }

    public virtual int SpecialAttack
    {
        get => _specialAttack;
    }
    
    public abstract void Buff();

    public virtual void ReceiveAttack(int damage)
    {
        HP -= damage;
    }
}
    
class Warrior : Actor
{
    private bool _hasIronSkin = false;

    public Warrior() : base(260, 40, 75, "Warrior") { }    

    public override void Buff()
    {
        _hasIronSkin = true;
        HP += 40;
    }

    public override void ReceiveAttack(int damage)
    {
        if (_hasIronSkin)
        {
            _hasIronSkin = false;
            damage /= 2;
        }

        base.ReceiveAttack(damage);
    }
}
  
class Mage : Actor
{
    private bool _hasArcaneShield = false;

    public Mage() : base(200, 50, 90, "Mage") { }  

    public override void Buff()
    {
        _hasArcaneShield = true;
    }

    public override void ReceiveAttack(int damage)
    {
        if (_hasArcaneShield)
        {
            _hasArcaneShield = false;
            return;
        }

        base.ReceiveAttack(damage);
    }
}
  
class Assassin : Actor
{
    private int _instinctTurns = 0;

    public Assassin() : base(235, 30, 30, "Assassin") { }

    public override int Attack
    {
        get
        {
            int damage = _instinctTurns > 0? _attack + 40: _attack;
            _instinctTurns = Math.Max(0, _instinctTurns - 1);
            return damage;
        }
    }

    public override int SpecialAttack
    {
        get
        {
            int damage = 2 * (_instinctTurns > 0? _attack + 40: _attack);
            _instinctTurns = Math.Max(0, _instinctTurns - 1);
            return damage;
        }
    }

    public override void Buff()
    {
        _instinctTurns = 3;
    }
}
    
class Battle
{
    private readonly Actor Player1; 
    private readonly Actor Player2;

    public Battle(Actor player1, Actor player2)
    {
        Player1 = player1;
        Player2 = player2;
    }
      
    public string PlayTurn(Action act1, Action act2)
    {
        if (Player1.HP == 0 || Player2.HP == 0)
        {
            return "This battle is over!";
        }

        if (act1 == Action.Buff) Player1.Buff();
        else if (act1 == Action.NormalAttack) Player2.ReceiveAttack(Player1.Attack);
        else if (act1 == Action.SpecialAttack) Player2.ReceiveAttack(Player1.SpecialAttack);

        if (Player2.HP == 0)
        {
            return $"The {Player1.CharacterClass} won! Remaining HP = {Player1.HP}";
        }

        if (act2 == Action.Buff) Player2.Buff();
        else if (act2 == Action.NormalAttack) Player1.ReceiveAttack(Player2.Attack);
        else if (act2 == Action.SpecialAttack) Player1.ReceiveAttack(Player2.SpecialAttack);

        if (Player1.HP == 0)
        {
            return $"The {Player2.CharacterClass} won! Remaining HP = {Player2.HP}";
        }

        return $"{Player1.CharacterClass} HP = {Player1.HP}, {Player2.CharacterClass} HP = {Player2.HP}";
    }
}

