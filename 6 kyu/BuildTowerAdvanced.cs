// https://www.codewars.com/kata/57675f3dedc6f728ee000256

namespace BuildTowerAdvanced;

public class Kata
{  
    public static string[] TowerBuilder(int nFloors, int blockWidth, int blockHeight)
    {
        string[] building = new string[nFloors * blockHeight];

        for (int i = 0; i < nFloors; ++i)
        {
            string padding = new(' ', blockWidth * (nFloors - i - 1));
            string row =  padding + new string('*', blockWidth * (2 * i + 1)) + padding;
            for (int h = 0; h < blockHeight; ++h)
            {
                building[i * blockHeight + h] = row;
            }
        }        

        return building;
    }
}
