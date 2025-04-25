// https://www.codewars.com/kata/55466989aeecab5aac00003e

namespace RectanglesIntoSquares;

using System.Collections.Generic;

public class SqInRect 
{	
	public static List<int> sqInRect(int length, int width) 
	{
		if (length == width)
		{
			return null!;
		}
			
		List<int> result = [];

		while (length > 0 && width > 0)
		{
			if (width < length)
			{
				result.Add(width);
				length -= width;
			}
			else
			{
				result.Add(length);
				width -= length;
			}
		}
		
		return result;
	}
}

