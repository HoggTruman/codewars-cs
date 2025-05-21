// https://www.codewars.com/kata/57e5a6a67fbcc9ba900021cd

namespace FunWithTreesArrayToTree;

class TreeNode 
{
    public TreeNode? left;
    public TreeNode? right;
    public int value;
    
    public TreeNode(int value, TreeNode left, TreeNode right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }
    
    public TreeNode(int value) 
    {
        this.value = value;
    }
}

class Solution
{
    public static TreeNode? ArrayToTree(int[] array)
    {
        TreeNode[] nodes = new TreeNode[array.Length];

        for (int i = 0; i < array.Length; ++i)
        {
            nodes[i] = new TreeNode(array[i]);
            if (i != 0)
            {
                TreeNode parent = nodes[GetParent(i)];
                if (i % 2 == 0)
                {
                    parent.right = nodes[i];
                }
                else
                {
                    parent.left = nodes[i];
                }
            }
        }

        return nodes.Length > 0? nodes[0]: null;
    }

    public static int GetParent(int i)
    {
        return (i - 1) / 2;
    }
}
