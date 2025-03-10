// https://www.codewars.com/kata/57722700c37fc4cc99000033

namespace Reflection3AddTheMemberResults;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Reflection
{
    public static string ConcatStringMembers(object TestObject)
    {
        if (TestObject == null) 
            return "";

        HashSet<string> results = [];

        foreach (MethodInfo method in TestObject.GetType().GetMethods())
        {
            if (method.ReturnType == typeof(string) &&
                method.GetParameters().Length == 0 &&
                method.Name != "ToString")
            {
                results.Add((string)method.Invoke(TestObject, null));
            }
        }

        foreach (PropertyInfo prop in TestObject.GetType().GetProperties())
        {
            if (prop.PropertyType == typeof(string))
            {
                results.Add((string)prop.GetValue(TestObject, null));
            }
        }

        foreach (FieldInfo field in TestObject.GetType().GetFields())
        {
            Console.WriteLine(field);
            if (field.FieldType == typeof(string))
            {
                results.Add((string)field.GetValue(TestObject));
            }
        }

        return String.Join("", results.OrderByDescending(x => x.Length).ThenBy(x => x).ToList());
    }
}
