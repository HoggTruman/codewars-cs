// https://www.codewars.com/kata/52a89c2ea8ddc5547a000863

namespace CanYouGetTheLoop;

using System.Collections.Generic;

public static class LoopDetector
{
    public class Node
    {
        public required Node next;
    }
}

public class Kata
{
    public static int getLoopSize(LoopDetector.Node startNode)
    {
        Dictionary<LoopDetector.Node, int> nodePositions = [];
        
        LoopDetector.Node node = startNode;
        int i = 0;

        while (!nodePositions.ContainsKey(node))
        {
            nodePositions[node] = i++;
            node = node.next;
        }

        return i - nodePositions[node];
    }
}
