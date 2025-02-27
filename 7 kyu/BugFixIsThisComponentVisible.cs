// https://www.codewars.com/kata/678a4ce740343f67dcea893a;

namespace BugFixIsThisComponentVisible;

public class Component
{
    private string _id;
    private Component? _parent;
    private Component[] _children;
    private bool? _visibility;

    public Component(string id, Component[] children)
    {
        _id = id;
        _children = children;
        _visibility = null;
        _parent = null;
        foreach (var child in _children)
        {
            child._parent = this;
        }
    }

    public bool? Visibility
    {
        set { _visibility = value; }
    }

    public bool IsVisible
    {
        get
        {
            if (_visibility.HasValue)
                return _visibility.Value;
            
            return _parent != null? _parent.IsVisible: true;
        }
    }

    public override string ToString()
    {
        return _id;
    }
}

