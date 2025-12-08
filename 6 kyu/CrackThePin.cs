// https://www.codewars.com/kata/5efae11e2d12df00331f91a6

namespace CrackThePin;

using System;
using System.Security.Cryptography;
using System.Text;

public class CodeWars
{
    public static string crack(string hash)
    {
        hash = hash.ToUpper();
        for (int k = 0; k <= 99999; ++k)
        {
            string pin = k.ToString("D5");
            byte[] inputBytes = Encoding.ASCII.GetBytes(pin);
            byte[] outputBytes = MD5.HashData(inputBytes);
            string pinHash = Convert.ToHexString(outputBytes);

            if (pinHash == hash)
            {
                return pin;
            }
        }

        return "";
    }
}
