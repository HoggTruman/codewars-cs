// https://www.codewars.com/kata/56170e844da7c6f647000063

namespace DrinkAbout;

public class Kata
{
    public static string PeopleWithAgeDrink(int old)
    {
        return old switch
        {
            < 14 => "drink toddy",
            < 18 => "drink coke",
            < 21 => "drink beer",
            _ => "drink whisky"
        };
    }
}
