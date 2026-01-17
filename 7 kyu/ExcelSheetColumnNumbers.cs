// https://www.codewars.com/kata/55ee3ebff71e82a30000006a

namespace ExcelSheetColumnNumbers;

using System;

public class ExcelToNumber 
{
    public static long TitleToNumber(string title) 
    {
        long column = 0;

        for (int i = 0; i < title.Length; ++i)
        {
            long value = title[title.Length - i - 1] - 'A' + 1;
            column += value * (long)Math.Pow(26, i);
        }

        return column;
    }
}