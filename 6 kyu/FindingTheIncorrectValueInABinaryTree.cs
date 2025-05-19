// https://www.codewars.com/kata/63f13a354a828b0041979359

namespace FindingTheIncorrectValueInABinaryTree;

public class IncorrectValueInBinaryTree
{
    public static (int, int) FindIncorrectNumber(int[] tree) 
    {   
        for (int i = 0; i < tree.Length; ++i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);

            if (left >= tree.Length)
            {
                break;
            }

            if (tree[i] != tree[left] + tree[right]) // leftChild < tree.Length && rightChild < tree.Length &&
            {
                // check left child has sum of children
                int leftLeft = LeftChild(left);
                int leftRight = RightChild(left);

                if (leftRight < tree.Length &&
                    tree[left] != tree[leftLeft] + tree[leftRight])
                {
                    return (left, tree[leftLeft] + tree[leftRight]);
                }

                // check right child has sum of children
                int rightLeft = LeftChild(right);
                int rightRight = RightChild(right);

                if (rightRight < tree.Length)
                {
                    if (tree[right] != tree[rightLeft] + tree[rightRight])
                    {
                        return (right, tree[rightLeft] + tree[rightRight]);
                    }                    
                }
                else
                {
                    // when both children are leaves, the right child is incorrect
                    return (right, tree[i] - tree[left]);
                }

                // i is the incorrect value if both children have the sum of their children
                return (i, tree[left] + tree[right]);
            }
        }

        return (0, 0);
    }

    public static int LeftChild(int i)
    {
        return 2 * i + 1;
    }

    public static int RightChild(int i)
    {
        return 2 * i + 2;
    }
}
