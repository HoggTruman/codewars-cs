// https://www.codewars.com/kata/55cacc3039607536c6000081

namespace LinkedListsInsertNthNode;

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
  
    public static Node InsertNth(Node head, int index, int data)
    {
        Node newNode = new(data);
        Node current = head;

        if (index == 0)
        {
            newNode.Next = head;
            return newNode;
        }

        int i = 1;

        while (current != null)
        {
            if (i == index)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                break;
            }

            current = current.Next;
            ++i;
        }

        if (current == null || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return head;
    }
}
