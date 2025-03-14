// https://www.codewars.com/kata/56f7f8215d7c12c0e7000b19

namespace FunWithES6Classes1PeoplePeoplePeople;

public class Person(string firstName = "John", string lastName = "Doe", int age = 0, string gender = "Male")
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public int Age { get; } = age;
    public string Gender { get; } = gender;

    public static string GreetExtraTerrestrials(string race) => $"Welcome to Planet Earth {race}"; 
    public string SayFullName() => $"{FirstName} {LastName}";
}
