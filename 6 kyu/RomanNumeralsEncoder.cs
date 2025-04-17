// https://www.codewars.com/kata/51b62bf6a9c58071c600001b

namespace RomanNumeralsEncoder;

using System.Collections.Generic;
using System.Text;

public class RomanConvert
{
    public static readonly Dictionary<string, int> SymbolValues = new()
	{
		["M"] = 1000,
		["CM"] = 900,
		["D"] = 500,
		["CD"] = 400,
		["C"] = 100,
		["XC"] = 90,
		["L"] = 50,
		["XL"] = 40,
		["X"] = 10,
		["IX"] = 9,
		["V"] = 5,
		["IV"] = 4,
		["I"] = 1
	};

	public static readonly List<string> Symbols = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"]; 

	public static string Solution(int n)
	{
		StringBuilder sb = new();
		foreach(string symbol in Symbols)
		{
			while (SymbolValues[symbol] <= n)
			{
				sb.Append(symbol);
				n -= SymbolValues[symbol];
			}
		}

		return sb.ToString();
	}
}

