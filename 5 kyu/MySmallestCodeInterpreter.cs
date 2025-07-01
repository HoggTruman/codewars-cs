// https://www.codewars.com/kata/526156943dfe7ce06200063e/csharp


namespace MySmallestCodeInterpreter;

using System.Collections.Generic;
using System.Text;

public static class Kata
{
    public static string BrainLuck(string code, string input)
    {
        StringBuilder result = new();
        int[] memory = new int[5000];
        Stack<int> openBrackets = [];
        int dataPointer = 0;
        int codePointer = 0;
        int inputPointer = 0;

        while (codePointer >= 0 && codePointer < code.Length)
        {
            if (code[codePointer] == '>')
            {
                ++dataPointer;
            }
            else if (code[codePointer] == '<')
            {
                --dataPointer;
            }
            else if (code[codePointer] == '+')
            {
                memory[dataPointer] = memory[dataPointer] < 255? memory[dataPointer] + 1: 0;
            }
            else if (code[codePointer] == '-')
            {
                memory[dataPointer] = memory[dataPointer] > 0? memory[dataPointer] - 1: 255;
            }
            else if (code[codePointer] == '.')
            {
                result.Append((char)memory[dataPointer]);
            }
            else if (code[codePointer] == ',')
            {
                memory[dataPointer] = (byte)input[inputPointer];
                ++inputPointer;
            }
            else if (code[codePointer] == '[')
            {
                if (memory[dataPointer] == 0)
                {
                    int openCount = 1;
                    while (openCount > 0)
                    {
                        ++codePointer;
                        if (code[codePointer] == '[')
                        {
                            ++openCount;
                        }
                        else if (code[codePointer] == ']')
                        {
                            --openCount;
                        }                        
                    }
                }
                else
                {
                    openBrackets.Push(codePointer);
                }
            }
            else if (code[codePointer] == ']')
            {
                if (memory[dataPointer] != 0)
                {
                    codePointer = openBrackets.Peek();
                }
                else
                {
                    openBrackets.Pop();
                }
            }

            ++codePointer;
        }

        return result.ToString();
    }
}
