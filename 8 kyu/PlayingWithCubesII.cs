// https://www.codewars.com/kata/55c0ac142326fdf18d0000af

namespace PlayingWithCubesII;

public class Cube
{
    private int Side;
  
    public Cube(int side=0)
    {
        SetSide(side);
    }
  
    public int GetSide()
    {
        return this.Side;
    }
  
    public void SetSide(int s)
    {
        this.Side = s >= 0? s: -s;
    }
}
