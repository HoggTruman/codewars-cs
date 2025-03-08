// https://www.codewars.com/kata/58cfe6c9f9dffe0f5100017f

namespace SimpleClassTerminology;

public class DemoClass
{
    private int _privateField;
    public string PublicField = "None";
    public int LimitedProperty { get; private set; }

    public DemoClass(int value)
    {
        _privateField = value;
    }
}
