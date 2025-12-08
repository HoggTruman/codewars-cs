// https://www.codewars.com/kata/530d0298e09e54a3620006c2

namespace PalindromesBelow;

using System.Collections.Generic;

public static class ExtensionMethods
{
	public static int[] PalindromeBelow (this int number, int baseValue)
	{	
		List<int> palindromes = [];

		for (int k = 1; k < number; ++k)
		{
			List<int> digits = GetDigits(k, baseValue);
			if (IsPalindrome(digits))
			{
				palindromes.Add(k);
			}
		}

		return palindromes.ToArray();
	}


	private static List<int> GetDigits(int n, int baseValue)
	{
		List<int> digits = [];

		while (n > 0)
		{
			digits.Add(n % baseValue);
			n /= baseValue;
		}

		digits.Reverse();
		return digits;
	}


	private static bool IsPalindrome(List<int> digits)
	{
		for (int i = 0; i < digits.Count / 2; ++i)
		{
			if (digits[i] != digits[digits.Count - 1 - i])
			{
				return false;
			}
		}

		return true;
	}
}
