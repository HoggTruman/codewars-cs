// https://www.codewars.com/kata/55a144eff5124e546400005a

namespace ClassyClasses;

public class Person
{  
    private readonly string _name;
    private readonly int _age;

    public string Info => $"{_name}s age is {_age}";

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }
}
