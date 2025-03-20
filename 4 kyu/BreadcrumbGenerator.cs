// https://www.codewars.com/kata/563fbac924106b8bf7000046

namespace BreadcrumbGenerator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static readonly HashSet<string> IgnoredWords = ["the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a"];

    public static string GenerateBC(string url, string separator)
    {
        List<string> elements = [..url.Split('/', StringSplitOptions.RemoveEmptyEntries)];

        if (url.StartsWith("https://") || url.StartsWith("http://"))
        {
            elements = elements[1..];
        }

        if (elements.Count > 1 && (elements[^1].StartsWith("index") || elements[^1].StartsWith('#') || elements[^1].StartsWith('?')))
        {
            elements = elements[..^1];
        }

        if (elements.Count == 1)
        {
            return "<span class=\"active\">HOME</span>";
        }

        StringBuilder sb = new("<a href=\"/\">HOME</a>");
        sb.Append(separator);

        for (int i = 1; i < elements.Count - 1; ++i)
        {
            string href = string.Join('/', elements[1..(i + 1)]);
            sb.Append($"<a href=\"/{href}/\">{ToContent(elements[i])}</a>");
            sb.Append(separator);
        }

        sb.Append($"<span class=\"active\">{ToContent(CleanLast(elements[^1]))}</span>");

        return sb.ToString();
    }

    private static string ToContent(string str)
    {
        if (str.Length > 30)
        {
            return string.Concat(str.Split('-')
                .Where(x => !IgnoredWords.Contains(x))
                .Select(x => x[0]))
                .ToUpper();
        }

        return str.Replace('-', ' ').ToUpper();        
    }

    private static string CleanLast(string str)
    {  
        return str.Split(['#', '?', '.'])[0];
    }
}
