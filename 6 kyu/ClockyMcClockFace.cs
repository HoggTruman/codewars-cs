// https://www.codewars.com/kata/59752e1f064d1261cb0000ec

namespace ClockyMcClockFace;

public class Dinglemouse
{
    public static string WhatTimeIsIt(double angle)
    {
        int totalMinutes = (int)(angle * 2);
        int hours = totalMinutes >= 60? totalMinutes / 60: 12;
        int minutes = totalMinutes % 60;
        return hours.ToString("D2") + ":" + minutes.ToString("D2");
    }
}
