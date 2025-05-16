// https://www.codewars.com/kata/59884371d1d8d3d9270000a5

namespace NutFarm;

public class Dinglemouse
{
    public static int[] ShakeTree(string[] tree)
    {
        string nuts = tree[0];
        int[] result = new int[nuts.Length];

        for (int i = 0; i < nuts.Length; ++i)
        {
            if (nuts[i] != 'o')
            {
                continue;
            }

            int row = 1;
            int col = i;
            while (row < tree.Length && tree[row][col] != '_')
            {
                if (tree[row][col] == '\\')
                {
                    ++col;
                }
                else if (tree[row][col] == '/')
                {
                    --col;
                }

                ++row;
            }

            if (row == tree.Length)
            {
                ++result[col];
            }
        }

        return result;
    }
}
