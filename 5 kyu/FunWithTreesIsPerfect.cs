// https://www.codewars.com/kata/57dd79bff6df9b103b00010f

namespace FunWithTreesIsPerfect;

using System;
using System.Collections.Generic;
using System.Linq;

public class TreeNode
{
    public TreeNode? left;
    public TreeNode? right;

    public static bool IsPerfect(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }    

        List<TreeNode?> children = [root.left, root.right];

        while (children.All(x => x != null))
        {
            children = children.SelectMany(x => new List<TreeNode?>(){ x!.left, x.right }).ToList();
        }

        return children.All(x => x == null);
    }
    
    public static TreeNode Leaf()
    {
        return new TreeNode();
    }

    public static TreeNode Join(TreeNode left, TreeNode right)
    {
        return new TreeNode().WithChildren(left, right);
    }

    public TreeNode WithLeft(TreeNode left)
    {
        this.left = left;
        return this;
    }

    public TreeNode WithRight(TreeNode right)
    {
        this.right = right;
        return this;
    }

    public TreeNode WithChildren(TreeNode left, TreeNode right) 
    {
        this.left = left;
        this.right = right;
        return this;
    }

    public TreeNode WithLeftLeaf() 
    {
        return WithLeft(Leaf());
    }

    public TreeNode WithRightLeaf()
    {
        return WithRight(Leaf());
    }

    public TreeNode WithLeaves() 
    {
        return WithChildren(Leaf(), Leaf());
    }
}

