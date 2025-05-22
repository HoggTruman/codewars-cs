// https://www.codewars.com/kata/54c9fcad28ec4c6e680011aa

namespace MergedStringChecker;

public class StringMerger
{
	public static bool isMerge(string s, string a, string b)
	{
		return IsMerge(s, a, b, 0, 0, 0);
	}

	public static bool IsMerge(string s, string a, string b, int i_s, int i_a, int i_b)
	{
		if (i_s == s.Length)
		{
			return i_a == a.Length && i_b == b.Length;
		}

		if (i_a < a.Length && a[i_a] == s[i_s] && 
			i_b < b.Length && b[i_b] == s[i_s])
		{
			return IsMerge(s, a, b, i_s + 1, i_a + 1, i_b) || IsMerge(s, a, b, i_s + 1, i_a, i_b + 1);
		}
		else if (i_a < a.Length && a[i_a] == s[i_s])
		{
			return IsMerge(s, a, b, i_s + 1, i_a + 1, i_b);
		}
		else if (i_b < b.Length && b[i_b] == s[i_s])
		{
			return IsMerge(s, a, b, i_s + 1, i_a, i_b + 1);
		}

		return false;
	}
}

