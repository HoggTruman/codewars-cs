// https://www.codewars.com/kata/5583d268479559400d000064

namespace BinaryToTextASCIIConversion;

using System;
using System.Text;

public static class Kata
{
    public static string BinaryToString(string binary)
    {
        var sb = new StringBuilder();
      
        for (int i = 0; i < binary.Length; i += 8)
        {
            sb.Append((char)Convert.ToByte(binary[i..(i+8)], 2));
        }
      
        return sb.ToString();
    }
}
