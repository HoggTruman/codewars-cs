// https://www.codewars.com/kata/54b724efac3d5402db00065e

namespace DecodeTheMorseCode;

using System.Collections.Generic;
using System.Linq;

class MorseCodeDecoder
{
	public static readonly Dictionary<string, string> Codes = new()
	{
		[".-"] = "A",
		["-..."] = "B",
		["-.-."] = "C",
		["-.."] = "D",
		["."] = "E",
		["..-."] = "F",
		["--."] = "G",
		["...."] = "H",
		[".."] = "I",
		[".---"] = "J",
		["-.-"] = "K",
		[".-.."] = "L",
		["--"] = "M",
		["-."] = "N",
		["---"] = "O",
		[".--."] = "P",
		["--.-"] = "Q",
		[".-."] = "R",
		["..."] = "S",
		["-"] = "T",
		["..-"] = "U",
		["...-"] = "V",
		[".--"] = "W",
		["-..-"] = "X",
		["-.--"] = "Y",
		["--.."] = "Z",
		["...---..."] = "SOS",
		["-.-.--"] = "!",
		[".-.-.-"] = ".",
	};
		
	public static string Decode(string morseCode)
	{
		string[] wordCodes = morseCode.Trim().Split("   ");
		var words = wordCodes.Select(word => string.Join("", word.Split().Select(x => Codes[x])));
		return string.Join(" ", words);
	}
}
