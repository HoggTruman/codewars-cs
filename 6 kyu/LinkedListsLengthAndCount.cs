// https://www.codewars.com/kata/55beec7dd347078289000021

namespace LinkedListsLengthAndCount;

using System;

public partial class Node
{
    public int Data;
    public Node Next;
  
    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
  
    public static int Length(Node head)
    {
        if (head == null)
        {
            return 0;
        }

        int length = 1;
        Node currentNode = head.Next;

        while (currentNode != null)
        {
            ++length;
            currentNode = currentNode.Next;
        }

        return length;
    }
  
    public static int Count(Node head, Predicate<int> func)
    {
        if (head == null)
        {
            return 0;
        }

        int count = 0;
        Node currentNode = head;

        while (currentNode != null)
        {
            if (func(currentNode.Data))
            {
                ++count;
            }
            currentNode = currentNode.Next;
        }

        return count;
    }
}
