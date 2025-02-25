// https://www.codewars.com/kata/56a32dd6e4f4748cc3000006/csharp

namespace Rainfall;

using System;
using System.Collections.Generic;
using System.Linq;

class Rainfall 
{
    private static HashSet<string> towns = ["Rome", "London", "Paris", "NY", "Vancouver", "Sydney", "Bangkok", "Tokyo",
        "Beijing", "Lima", "Montevideo", "Caracas", "Madrid", "Berlin"];

    public static double Mean(string town, string data) 
    {
        List<double> values = GetValues(town, data);
        return values.Count != 0?
            GetValues(town, data).Average():
            -1.0;
    }
    
    public static double Variance(string town, string data) 
    {
        List<double> values = GetValues(town, data);

        if (values.Count == 0) {
            return -1.0;
        }
        
        double squareOfMean = Math.Pow(values.Average(), 2);
        double meanOfSqaures = values.Average(x => x * x);
        return meanOfSqaures - squareOfMean;
    }

    private static List<double> GetValues(string town, string data)
    {
        int monthStart = data.IndexOf(town);
        List<double> values = [];

        if (!towns.Contains(town) || monthStart == -1) {
            return [];
        }        

        for (int month = 1; month <= 12; ++month)
        {
            int start = data.IndexOf(' ', monthStart) + 1;
            int end = data.IndexOf('.', start) + 2;
            values.Add(double.Parse(data[start..end]));
            monthStart = end;
        }

        return values;
    }
}
