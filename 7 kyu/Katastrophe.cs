// https://www.codewars.com/kata/55a3cb91d1c9ecaa2900001b

namespace Katastrophe;

using System;
using System.Linq;

public class Kata
{
    public static string StrongEnough(int[][] earthquake, int age)
    {
        int magnitude = earthquake.Select(x => x.Sum()).Aggregate((acc, x) => acc * x);
        double strength = 1000 * Math.Pow(0.99, age);
        return magnitude > strength? "Needs Reinforcement!": "Safe!";
    }
}