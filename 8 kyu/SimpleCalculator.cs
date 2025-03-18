// https://www.codewars.com/kata/5810085c533d69f4980001cf

namespace SimpleCalculator;

using System;

public class Kata
{
    public static double Calculator(double a, double b, char op)
    {
        return op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => throw new ArgumentException("Operator symbol must be one of +-*/")
        };
    }
}
