using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ErrorManager
{
    private List<Error> _errors;

    public List<Error> Errors
    {
        get
        {
            return _errors;
        }
    }

    public ErrorManager()
    {
        _errors = new List<Error>();
    }

    public void addError(Error error)
    {
        _errors.Add(error);
        MessageListController.AddMessageToList(error);
    }

    public void checkLineEnding(string codeLine, int lineNumber)
    {
        if (codeLine.Length == 0)
        {
            return;
        }
            
        if (codeLine.Trim()[codeLine.Trim().Length - 1].Equals(';'))
        {
            return;
        }

        Error missingSemicolon = new Error("MISSING_TERMINATOR", "Missing semicolon at the end of line " + lineNumber, lineNumber);
        _errors.Add(missingSemicolon);
        MessageListController.AddMessageToList(missingSemicolon);
    }

    public bool hasErrors()
    {
        return _errors.Count > 0;
    }
}
