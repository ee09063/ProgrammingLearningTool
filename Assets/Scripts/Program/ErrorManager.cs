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

    public void checkLineEnding(string lineEnding, int line)
    {
        Debug.Log("[ERROR MANAGER] Checking Line Ending  ." + lineEnding + ".");
        Error missingSemicolon = new Error("Missing semicolon at the end of line", line);
        if (lineEnding == null)
        {
            _errors.Add(missingSemicolon);
            Debug.Log(_errors.Count);
            MessageListController.AddMessageToList(missingSemicolon);
        }
        else
        {
            if (!lineEnding.Trim().Equals(";") || lineEnding.Trim().Equals(""))
            {
                MessageListController.AddMessageToList(missingSemicolon);
            }
        }
    }

    public bool hasErrors()
    {
        return _errors.Count > 0;
    }
}
