// https://www.codewars.com/kata/656e4602ee72af0017e37e82

namespace CuckooClock;

using System;

public class CuckooClockSolution
{
    public static string CuckooClock(string inputTime, int chimes)
    {
        double time = int.Parse(inputTime[..2]) + int.Parse(inputTime[3..]) / 60.0;

        if (time % 0.25 != 0)
        {
            time = Math.Ceiling(time * 4) / 4;
            if (time == 13)
            {
                time = 1;
            }
        }

        int chimeCount = time % 1 == 0? (int)time: 1;

        while(chimeCount < chimes)
        {
            time = time == 12.75? 1: time + 0.25;
            chimeCount += time % 1 == 0? (int)time: 1;
        }
        
        int hours = (int)time;
        int minutes = (int)(time % 1 * 60);

        return hours.ToString("D2") + ":" + minutes.ToString("D2");
    }
}
