// https://www.codewars.com/kata/582c297e56373f0426000098

using System.Text;

namespace ConvertALinkedListToAString
{
    public class Node 
    {
        public int Data { get; private set; }
        public Node Next { get; private set; }

        public Node(int data, Node next = null) 
        {
            Data = data;
            Next = next;
        }
    }

    public class Kata
    {
        public static string Stringify(Node list)
        {
            StringBuilder sb = new();
            Node? current = list;

            while (current != null)
            {
                sb.Append(current.Data + " -> ");
                current = current.Next;
            }

            return sb.Append("null").ToString();
        }
    }
}

