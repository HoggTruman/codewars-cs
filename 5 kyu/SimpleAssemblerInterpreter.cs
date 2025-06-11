// https://www.codewars.com/kata/58e24788e24ddee28e000053

namespace SimpleAssemblerInterpreter;

using System;
using System.Linq;
using System.Collections.Generic;


public static class SimpleAssembler
{
    public static Dictionary<string, int> Interpret(string[] program)
    {
        Dictionary<string, int> registers = [];
        
        int i = 0;
        while (i < program.Length)
        {
            string[] parameters = program[i].Split();
            string command = parameters[0];
            string x = parameters[1];
            string y = parameters.Length == 3? parameters[2]: "";

            if (command == "mov")
            {
                registers[x] = char.IsLetter(y[0])? registers[y]: int.Parse(y);
            }
            else if (parameters[0] == "inc")
            {
                ++registers[x];
            }
            else if (parameters[0] == "dec")
            {
                --registers[x];
            }

            if (command == "jnz")
            {
                int xValue = char.IsLetter(x[0])? registers[x]: int.Parse(x);

                i += xValue != 0?
                    char.IsLetter(y[0])? registers[y]: int.Parse(y):
                    1;
            }
            else
            {
                ++i;
            }
        }

        return registers;
    }
}

