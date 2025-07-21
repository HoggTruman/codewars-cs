// https://www.codewars.com/kata/5a5f9f80f5dc3f942b002309

namespace SchrodingersBoolean;

using System;

public class AlwaysTrue
{
    public static bool operator ==(AlwaysTrue a, bool b)
    {
        if (a == null)
        {
            return false;
        }

        return true;
    }

    public static bool operator !=(AlwaysTrue a, bool b)
    {
        return !(a == b);
    }
}

public class Kata
{
    public static AlwaysTrue omnibool = new();
}
