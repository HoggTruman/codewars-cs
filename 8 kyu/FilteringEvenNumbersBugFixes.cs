// https://www.codewars.com/kata/566dc566f6ea9a14b500007b

namespace FilteringEvenNumbersBugFixes;

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static List<int> FilterOddNumber(List<int> listOfNumbers)
    {
        return listOfNumbers.Where(x => x % 2 != 0).ToList();
    }
}
