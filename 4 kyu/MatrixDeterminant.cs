// https://www.codewars.com/kata/52a382ee44408cea2500074c

namespace MatrixDeterminant;

using System.Linq;

public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        int n = matrix.GetLength(0);

        if (n == 1)
        {
            return matrix[0][0];
        }

        int determinant = 0;

        for (int j = 0; j < n; ++j)
        {
            int[][] subMatrix = new int[n - 1][];

            for (int k = 0; k < n - 1; ++k)
            {
                subMatrix[k] = [..matrix[k + 1].Where((x, i) => i != j)];                
            }

            determinant += j % 2 == 0? 
                Determinant(subMatrix) * matrix[0][j]: 
                Determinant(subMatrix) * -matrix[0][j];
        }

        return determinant;
    }
}
