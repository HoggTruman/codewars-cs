// https://www.codewars.com/kata/515decfd9dcfc23bb6000006

namespace IPValidation;

using System.Linq;

class Kata
{
    public static bool IsValidIp(string ipAddress)
    {
        var parts = ipAddress.Split('.');
        
        if (parts.Length != 4 || parts.Any(x => x.Length == 0))
        {
            return false;
        }

        foreach(string part in parts)
        {
            if (part.Length > 1 && part.StartsWith('0') ||
                part.Any(x => !char.IsDigit(x)))
            {
                return false;
            }

            int octet = int.Parse(part);
            if (octet > 255 || octet < 0)
            {
                return false;
            }
        }

        return true;
    }
}
