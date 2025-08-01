// https://www.codewars.com/kata/57fea63854685b1189000169

namespace GatherGenerics;

interface IParser<out T>
{
    T Parse(string value);
}


