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

    public void addError(string content, int line)
    {
        Error error = new Error(content, line);
        _errors.Add(error);
        MessageListController.AddMessageToList(error);
    }

    public void checkLineEnding(string codeLine, int lineNumber)
    {
        if (codeLine.Length == 0)
        {
            return;
        }

        Debug.Log("[ERROR MANAGER] Checking Line Ending in line " + codeLine + " on line " + lineNumber);
        Error missingSemicolon = new Error("Missing semicolon at the end of line " + lineNumber, lineNumber);

        if (codeLine.Trim()[codeLine.Length - 1].Equals(';'))
        {
           return;
        }

        _errors.Add(missingSemicolon);
        MessageListController.AddMessageToList(missingSemicolon);
    }

    public bool hasErrors()
    {
        return _errors.Count > 0;
    }
}
