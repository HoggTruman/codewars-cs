// https://www.codewars.com/kata/565f5825379664a26b00007c

namespace SurfaceAreaAndVolumeOfABox;

public class Kata
{
    public static int[] Get_size(int w, int h, int d)
    {
        return [
            2 * (w * h + w * d + h * d),
            w * h * d
        ];
    }
}
