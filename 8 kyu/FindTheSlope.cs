// https://www.codewars.com/kata/55a75e2d0803fea18f00009d

namespace FindTheSlope;

using System;

public class Slope
{
    public String slope(int[] points)
    {
        int deltax = points[2] - points[0];
        int deltay = points[3] - points[1];

        if (deltax == 0)
        {
            return "undefined";
        }
        
        return (deltay / deltax).ToString();
    }
}