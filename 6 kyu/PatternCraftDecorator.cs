// https://www.codewars.com/kata/patterncraft-decorator/

namespace PatternCraftDecorator;

public interface IMarine
{
    int Damage { get; set; }
    int Armor { get; set; }
}

public class Marine : IMarine
{
    public Marine(int damage, int armor)
    {
        Damage = damage;
        Armor = armor;
    }

    public int Damage { get; set; }
    public int Armor { get; set; }
}

public class MarineWeaponUpgrade : IMarine
{
    private IMarine marine;

    public MarineWeaponUpgrade(IMarine marine)
    {
        this.marine = new Marine(marine.Damage + 1, marine.Armor);
    }

    public int Damage
    {
        get => marine.Damage;
        set => marine.Damage = value;
    }

    public int Armor
    {
        get => marine.Armor;
        set => marine.Armor = value;
    }
}

public class MarineArmorUpgrade : IMarine
{
    private IMarine marine;

    public MarineArmorUpgrade(IMarine marine)
    {
        this.marine = new Marine(marine.Damage, marine.Armor + 1);
    }

    public int Damage
    {
        get => marine.Damage;
        set => marine.Damage = value;
    }

    public int Armor
    {
        get => marine.Armor;
        set => marine.Armor = value;
    }
}
