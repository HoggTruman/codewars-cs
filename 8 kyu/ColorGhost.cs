// https://www.codewars.com/kata/53f1015fa9fe02cbda00111a

namespace ColorGhost;

using System;

public class Ghost
{
    private static string[] colors = { "white", "red", "purple", "yellow" };
    private string _color;

    public Ghost()
    {
        _color = colors[new Random().Next(colors.Length)];        
    }

    public string GetColor() => _color;        
}
