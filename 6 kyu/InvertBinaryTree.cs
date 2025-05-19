// https://www.codewars.com/kata/55d459414bd7798fc5000081

namespace InvertBinaryTree;

using System.Collections.Generic;

public class Solution 
{
    public static TreeNode? InvertTree(TreeNode root) 
    {
        if (root == null)
        {
            return null;
        }

        List<TreeNode> children = [root];

        while (children.Count > 0)
        {
            List<TreeNode> nextChildren = [];
            foreach (TreeNode child in children)
            {
                (child.Left, child.Right) = (child.Right, child.Left);

                if (child.Left != null)
                {
                    nextChildren.Add(child.Left);
                }

                if (child.Right != null)
                {
                    nextChildren.Add(child.Right);
                }
            }

            children = nextChildren;
        }


        return root;
    }
}

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
}
