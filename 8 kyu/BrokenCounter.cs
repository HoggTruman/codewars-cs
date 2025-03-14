// https://www.codewars.com/kata/526471539d52735c620000c6

namespace BrokenCounter;

public class Counter
{
    private int _value = 0;
    public int Value
    {
        get => _value;
        private set => _value = value;
    }
  
    public void Increase()
    {
        ++Value;
    }
  
    public void Reset()
    {
        Value = 0;
    }
}
