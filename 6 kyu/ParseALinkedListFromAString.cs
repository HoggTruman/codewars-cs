// https://www.codewars.com/kata/582c5382f000e535100001a7

namespace ParseALinkedListFromAString;

using System;
using System.Collections.Generic;

public class Node
{
    public int Data;
    public Node Next;
  
    public Node(int data, Node next = null)
    {
        this.Data = data;
        this.Next = next;
    }
  
    public override bool Equals(Object obj)
    {
        // Check for null values and compare run-time types.
        if (obj == null || GetType() != obj.GetType()) { return false; }
  
        return this.ToString() == obj.ToString();
    }
  
    public override string ToString()
    {
        List<int> result = new List<int>();
        Node curr = this;
    
        while (curr != null)
        {
            result.Add(curr.Data);
            curr = curr.Next;
        }
    
        return String.Join(" -> ", result) + " -> null";
    }
}

public static class Kata
{
    public static Node Parse(string nodes)
    {
        if (nodes == "null")
        {
            return null;
        }

        string[] values = nodes.Split(" -> ");
        Node front = new(int.Parse(values[0]));
        Node prev = front;

        for (int i = 1; i < values.Length - 1; ++i)
        {
            prev.Next = new(int.Parse(values[i]));
            prev = prev.Next;
        }

        return front;
    }
}
