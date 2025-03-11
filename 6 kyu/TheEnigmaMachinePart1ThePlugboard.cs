// https://www.codewars.com/kata/5523b97ac8f5025c45000900

namespace TheEnigmaMachinePart1ThePlugboard;

using System;
using System.Collections.Generic;

public class Plugboard 
{
    private readonly Dictionary<char, char> _pairings = [];
        
    public Plugboard(string wires = "") 
    {
        ProcessWires(wires);
    }

    public char process(char c) 
    {
        if (!_pairings.ContainsKey(c))
            return c;

        return _pairings[c];
    }

    private void ProcessWires(string wires)
    {
        if (wires.Length % 2 != 0 ||
            wires.Length > 20)
        {
            throw new Exception("Invalid wires provided (too long)");
        }

        for (int i = 0; i < wires.Length; i += 2)
        {
            if (_pairings.ContainsKey(wires[i]) ||
                _pairings.ContainsKey(wires[i + 1]))
            {
                throw new Exception("Invalid wires provided (duplicate pairings)");
            }

            _pairings[wires[i]] = wires[i + 1];
            _pairings[wires[i + 1]] = wires[i];
        }
    }
}
