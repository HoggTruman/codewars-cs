// https://www.codewars.com/kata/5794cf0b73938ec43700002b

namespace GenericTypeLoop;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Loop<T> : IEnumerable<T>
{
    private List<T> _items = [];

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Left()
    {
        _items = [.. _items.Skip(1), _items[0]];
    }

    public void Rigth()
    {
        _items = [_items[^1], .. _items.Take(_items.Count - 1)];
    }

    public T PopOut()
    {
        T item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public T ShowFirst()
    {
        return _items[0];
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}
