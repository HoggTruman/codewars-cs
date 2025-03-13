// https://www.codewars.com/kata/5770e4a5f7d4d2e0e4000073

namespace Reflection2GiveMeAllMethods;

using System.Collections.Generic;
using System.Reflection;

public static class Reflection
{
    public static string[] GetMethodNames(object testObject)
    {
        if (testObject == null)
        {
            return [];
        }            
        
        List<string> methods = [];
        var flags = BindingFlags.Instance | 
            BindingFlags.Public | 
            BindingFlags.NonPublic | 
            BindingFlags.Static;

        foreach (MethodInfo method in testObject.GetType().GetMethods(flags))
        {
            methods.Add(method.Name);
        }

        return methods.ToArray();
    }
}
