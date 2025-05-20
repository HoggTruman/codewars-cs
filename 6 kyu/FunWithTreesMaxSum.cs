// https://www.codewars.com/kata/57e5279b7cf1aea5cf000359

namespace FunWithTreesMaxSum;

using System;

class TreeNode
{
    public TreeNode? left;
    public TreeNode? right;
    public int value;
}

class Solution
{
    public static int MaxSum(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        if (root.left != null && root.right == null)
        {
            return root.value + MaxSum(root.left);
        }

        if (root.right != null && root.left == null)
        {
            return root.value + MaxSum(root.right);
        }

        return root.value + Math.Max(MaxSum(root.left), MaxSum(root.right));
    }
}
