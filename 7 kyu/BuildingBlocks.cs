// https://www.codewars.com/kata/55b75fcf67e558d3750000a3

namespace BuildingBlocks;

public class Block
{
    private int _width;
    private int _length;
    private int _height;

    public Block(int[] dimensions)
    {
        _width = dimensions[0];
        _length = dimensions[1];
        _height = dimensions[2];
    }

    public int GetWidth() => _width;
    public int GetLength() => _length;
    public int GetHeight() => _height;

    public int GetVolume()
    {
        return _width * _length * _height;
    }

    public int GetSurfaceArea()
    {
        return 2 * _width * _length +
            2 * _width * _height +
            2 * _length * _height;
    }
}
