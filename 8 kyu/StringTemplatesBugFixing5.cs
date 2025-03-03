// https://www.codewars.com/kata/55c90cad4b0fe31a7200001f

namespace StringTemplatesBugFixing5;

using System;

public static class Kata 
{
    public static string buildString(string[] args)
    {
      return String.Format("I like {0}!", String.Join(", ", args));
    }
}
