// https://www.codewars.com/kata/57a73e697cb1f31dd70000d2

namespace ChineseZodiac;

public partial class Kata
{
    public static readonly string[] Animals = ["Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"];
    public static readonly string[] Elements = ["Wood", "Fire", "Earth", "Metal", "Water"];

    public static string ChineseZodiac(int year)
    {
        string animal = Animals[(year - 1924) % 12];
        string element = Elements[(year - 1924) / 2 % 5];            
        return $"{element} {animal}";
    }
}
