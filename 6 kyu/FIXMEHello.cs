// https://www.codewars.com/kata/5b0a80ce84a30f4762000069

namespace FIXMEHello;

using System.Collections.Generic;
using System.Text;

public class Dinglemouse
{
    private string name;
    private int age;
    private char sex;

    private List<string> order = [];

    public Dinglemouse SetAge(int age)
    {
        if (!order.Contains("age"))
        {
            order.Add("age");
        }

        this.age = age;
        return this;
    }

    public Dinglemouse SetSex(char sex)
    {
        if (!order.Contains("sex"))
        {
            order.Add("sex");
        }

        this.sex = sex;
        return this;
    }

    public Dinglemouse SetName(string name)
    {
        if (!order.Contains("name"))
        {
            order.Add("name");
        }

        this.name = name;
        return this;
    }

    public string Hello()
    {
        StringBuilder sb = new("Hello.");

        foreach (string attribute in order)
        {
            if (attribute == "age") sb.Append($" I am {age}.");
            else if (attribute == "sex") sb.Append($" I am {(sex == 'M' ? "male" : "female")}.");
            else if (attribute == "name") sb.Append($" My name is {name}.");
        }

        return sb.ToString();
    }
}