// https://www.codewars.com/kata/555eded1ad94b00403000071

namespace SumOfTheFirstNthTermOfSeries;

using System;
using System.Linq;

public class NthSeries 
{	
	public static string seriesSum (int n) 
	{
		decimal sum = Enumerable.Range(0, n).Sum(x => 1m / (1m + 3m * x));
		return String.Format("{0:0.00}", Math.Round(sum, 2));
	}
}
