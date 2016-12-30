using UnityEngine;
using System.Collections;

public class Error : Message {

    private int _line;
    private string _type;
    private bool _fixed;

    public Error(string type, string content, int line) : base("Error", content)
    {
        _type = type;
        _line = line;
    }

    public int getLine()
    {
        return _line;
    }

    public string getType()
    {
        return _type;
    }

    public void setFixed(bool fix)
    {
        _fixed = fix;
    }

    public bool isFixed()
    {
        return _fixed;
    }
}
