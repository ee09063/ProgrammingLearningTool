using UnityEngine;
using System.Collections;

public class Error : Message {

    private int _line;
    private ErrorManager.ErrorTypes _type;

    public Error(ErrorManager.ErrorTypes type, string content, int line) : base("Error", content)
    {
        _type = _type;
        _line = line;
    }

    public int getLine()
    {
        return _line;
    }

    public ErrorManager.ErrorTypes getType()
    {
        return _type;
    }
}
