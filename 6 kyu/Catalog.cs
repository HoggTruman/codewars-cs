// https://www.codewars.com/kata/59d9d8cb27ee005972000045

namespace Catalog;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Catalogue
{
    public static string Catalog(string s, string article)
    {
        List<string> resultLines = [];

        foreach (string line in s.Split("\n", StringSplitOptions.RemoveEmptyEntries))
        {
            var match = Regex.Match(line, @"<prod><name>(.*)</name><prx>(.*)</prx><qty>(.*)</qty></prod>");
            string product = match.Groups[1].Value;

            if (product.Contains(article))
            {
                string price = match.Groups[2].Value;
                string quantity = match.Groups[3].Value;
                resultLines.Add($"{product} > prx: ${price} qty: {quantity}");
            }
        }

        return resultLines.Count> 0? string.Join("\n", resultLines): "Nothing";
    }
}
