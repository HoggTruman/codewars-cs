// https://www.codewars.com/kata/58ce88427e6c3f41c2000087

namespace AmISafeToDrive;

using System;
using System.Collections.Generic;

class Kata
{
    public Dictionary<double, bool> drive (double[,] drinks, string finished, string drive_time)
    {
        double bloodUnits = 0;
        for (int i = 0; i < drinks.GetLength(0); ++i)
        {
            bloodUnits += drinks[i, 0] * drinks[i, 1] / 1000;
        }

        double finishedHours = ToHours(finished);
        double startDriveHours = ToHours(drive_time);
        double timeBetween = startDriveHours < finishedHours? 
            24 + startDriveHours - finishedHours: 
            startDriveHours - finishedHours;

        return new() { [Math.Round(bloodUnits, 2)] = timeBetween > bloodUnits };
    }

    public static double ToHours(string time)
    {
        double hours = double.Parse(time[..2]);
        double minutes = double.Parse(time[3..]);
        return hours + minutes / 60;
    }
}
