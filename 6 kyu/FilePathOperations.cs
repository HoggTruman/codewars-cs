// https://www.codewars.com/kata/5844e0890d3bedc5c5000e54

namespace FilePathOperations;

class FileMaster
{
    private string _filepath;

    public FileMaster(string filepath)
    {
        _filepath = filepath;
    }

    public string extension()
    {
        return _filepath[(_filepath.IndexOf('.') + 1)..];
    }

    public string filename()
    {
        return _filepath[(_filepath.LastIndexOf('/') + 1).._filepath.IndexOf('.')];
    }

    public string dirpath()
    {
        return _filepath[..(_filepath.LastIndexOf('/') + 1)];
    }
}
