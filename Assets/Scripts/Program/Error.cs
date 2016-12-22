using UnityEngine;
using System.Collections;

public class Error : Message {

    private int _line;

    public Error(string content, int line) : base("Error", content)
    {
        _line = line;
    }

    public int getLine()
    {
        return _line;
    }
}
